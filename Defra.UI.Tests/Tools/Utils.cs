using NUnit.Framework;
using OpenQA.Selenium;
using System.Globalization;
using System.Linq;
using System.Security.Cryptography;
using System.Text.RegularExpressions;

namespace Defra.UI.Tests.Tools
{
    public static class Utils
    {
        public static string GenerateRandomName()
        {
            var size = 25;
            var random = new Random();
            var alphabets = "abcdefghijklmnopqrstuvwyxzABCDEFGHIJKLMNOPQRSTUVWXYZ";

            char[] chars = new char[size];
            for (int i = 0; i < size; i++)
            {
                chars[i] = alphabets[random.Next(alphabets.Length)];
            }
            return new string(chars);
        }

        public static string NormalizeAddress(string s)
        {
            if (string.IsNullOrWhiteSpace(s)) return string.Empty;

            s = s.ToUpperInvariant();
            s = Regex.Replace(s, @"\s+", " ");
            s = s.Replace(",", " ").Trim();

            string[] counties = new[]
            {
                "OXFORDSHIRE","BERKSHIRE","BUCKINGHAMSHIRE","CAMBRIDGESHIRE","CORNWALL",
                "CUMBRIA","DERBYSHIRE","DEVON","DORSET","DURHAM","ESSEX","GLOUCESTERSHIRE",
                "GREATER LONDON","GREATER MANCHESTER","HAMPSHIRE","HEREFORDSHIRE","HERTFORDSHIRE",
                "KENT","LANCASHIRE","LEICESTERSHIRE","LINCOLNSHIRE","MERSEYSIDE","NORFOLK",
                "NORTHAMPTONSHIRE","NORTHUMBERLAND","NOTTINGHAMSHIRE","SHROPSHIRE","SOMERSET",
                "STAFFORDSHIRE","SUFFOLK","SURREY","WARWICKSHIRE","WEST MIDLANDS","WEST SUSSEX",
                "WEST YORKSHIRE","WILTSHIRE","WORCESTERSHIRE","EAST SUSSEX","SOUTH YORKSHIRE",
                "TYNE AND WEAR"
            };

            foreach (var county in counties)
                s = Regex.Replace(s, $@"\b{Regex.Escape(county)}\b", "", RegexOptions.IgnoreCase);

            s = Regex.Replace(s, @"\s+", " ").Trim();
            return s;
        }

        public static DateTime ConvertToDate(string dateTime)
        {
            return DateTime.ParseExact(dateTime, "dd/MM/yyyy", CultureInfo.InvariantCulture);
        }

        public static string GenerateRandomUKPhonenumber()
        {
            var randomDigits = new Random().Next(10000000, 99999999);
            var phoneNumber = "075" + randomDigits.ToString();
            return phoneNumber;
        }

        public static string GenerateMicrochipNumber()
        {
            return DateTime.Now.ToString("ddMMyyHHmmssfff");
        }

        public static string GenerateRandomNumber()
        {
            return DateTime.Now.ToString("ddMMyyHHmmss");
        }

        public static DateTime GetCurrentTime()
        {
            DateTime currentDate = DateTime.Today;
            return currentDate;
        }

        public static string GetCurrentDate(string format)
        {
            return DateTime.Today.ToString(format);
        }

        public static string GetFutureDate(int daysInFuture)
        {
            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(daysInFuture);
            return futureDate.ToString("dd/MM/yyyy");
        }

        public static string GetPastDate(int daysInFuture)
        {
            DateTime currentDate = DateTime.Today;
            DateTime futureDate = currentDate.AddDays(-daysInFuture);
            return futureDate.ToString("dd/MM/yyyy");
        }

        public static void ChangePageView(this IWebDriver driver, int percentage)
        {
            var jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript($"document.body.style.zoom = '{percentage}%';");

            driver.Wait(2);
        }

        public static void ScrollAndClick(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", element);
            element.Click();
        }

        public static void ScrollToElement(this IWebElement element, IWebDriver driver)
        {
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView()", element);
        }
               
        public static void AppendToLoginLog(params (string Key, string Value)[] values)
        {
            var repositoryRoot = GetRepositoryRoot();
            var logDirectory = Path.Combine(repositoryRoot, "TestLogs");
            Directory.CreateDirectory(logDirectory);

            var logFile = Path.Combine(logDirectory, $"LoginSteps_{DateTime.UtcNow:yyyyMMdd}.log");
            var testName = TestContext.CurrentContext.Test?.Name ?? "UnknownTest";

            var keyValueText = string.Join(" | ", values.Select(v => $"{v.Key}: {v.Value}"));
            var line = $"{DateTime.UtcNow:O} | {testName} | {keyValueText}{Environment.NewLine}";

            File.AppendAllText(logFile, line);
        }

        public static void WriteGovernmentGatewayIdToFile(string governmentGatewayId)
        {
            AppendToLoginLog(("GovernmentGatewayID", governmentGatewayId));
        }

        public static void GenerateCsvFromTodayLog()
        {
            var repositoryRoot = GetRepositoryRoot();
            var logDirectory = Path.Combine(repositoryRoot, "TestLogs");
            var logFile = Path.Combine(logDirectory, $"LoginSteps_{DateTime.UtcNow:yyyyMMdd}.log");
            var csvFile = Path.Combine(logDirectory, $"LoginSteps_{DateTime.UtcNow:yyyyMMdd}.csv");

            GenerateCsvFromLog(logFile, csvFile);
        }

        public static void GenerateCsvFromLog(string logFilePath, string csvFilePath)
        {
            if (!File.Exists(logFilePath))
            {
                return;
            }

            // Data for the run currently being accumulated per scenario (reset whenever a new
            // 'ScenarioStart' entry is seen, so an older/previous run's data for that scenario
            // never leaks into this run's row).
            var currentRunData = new Dictionary<string, Dictionary<string, List<string>>>();

            // Every completed run (completed = a TestResult entry was logged), in log order.
            // Every run gets its own row - reruns of the same scenario are NOT deduplicated,
            // so the CSV always reflects everything logged for the day, just like the .log file.
            var completedRuns = new List<(string Scenario, string RunTimestamp, Dictionary<string, List<string>> Data)>();

            // Scenarios that started a run but never logged a TestResult (still running/crashed),
            // kept so they can still be represented by a best-effort row.
            var incompleteRuns = new Dictionary<string, (string RunTimestamp, Dictionary<string, List<string>> Data)>();

            // The timestamp (from the log line) of the most recent run start per scenario.
            var currentRunStart = new Dictionary<string, string>();

            var scenarioOrder = new List<string>();
            var columnOrder = new List<string>();

            foreach (var rawLine in File.ReadAllLines(logFilePath))
            {
                if (string.IsNullOrWhiteSpace(rawLine))
                {
                    continue;
                }

                var segments = rawLine.Split(" | ", StringSplitOptions.None);
                if (segments.Length < 2)
                {
                    continue;
                }

                var scenarioName = segments[1].Trim();

                if (!scenarioOrder.Contains(scenarioName))
                {
                    scenarioOrder.Add(scenarioName);
                }

                var keyValues = new List<(string Key, string Value)>();
                var startsNewRun = false;

                for (var i = 2; i < segments.Length; i++)
                {
                    var separatorIndex = segments[i].IndexOf(": ", StringComparison.Ordinal);
                    if (separatorIndex < 0)
                    {
                        continue;
                    }

                    var key = segments[i].Substring(0, separatorIndex).Trim().Trim('*').Trim();
                    var value = segments[i].Substring(separatorIndex + 2).Trim();

                    if (key.Equals("ScenarioStart", StringComparison.OrdinalIgnoreCase))
                    {
                        startsNewRun = true;
                    }

                    keyValues.Add((key, value));
                }

                // A fresh 'ScenarioStart' entry means a new run of this scenario has started
                // (logged before any step, including login/email creation, runs), so discard any
                // data accumulated from a previous (stale/incomplete) run.
                if (startsNewRun || !currentRunData.ContainsKey(scenarioName))
                {
                    currentRunData[scenarioName] = new Dictionary<string, List<string>>();
                    currentRunStart[scenarioName] = segments[0].Trim();
                }

                var runData = currentRunData[scenarioName];
                var isTestResultLine = false;

                foreach (var (key, value) in keyValues)
                {
                    if (key.Equals("ScenarioStart", StringComparison.OrdinalIgnoreCase))
                    {
                        continue;
                    }

                    if (!runData.TryGetValue(key, out var values))
                    {
                        values = new List<string>();
                        runData[key] = values;
                    }

                    if (!values.Contains(value))
                    {
                        values.Add(value);
                    }

                    if (key.Equals("TestResult", StringComparison.OrdinalIgnoreCase))
                    {
                        isTestResultLine = true;
                    }
                    else if (!columnOrder.Contains(key))
                    {
                        columnOrder.Add(key);
                    }
                }

                var runTimestamp = currentRunStart.TryGetValue(scenarioName, out var startTs) ? startTs : segments[0].Trim();

                if (isTestResultLine)
                {
                    // Record this completed run as its own row - do not overwrite/replace any
                    // earlier completed run of the same scenario.
                    completedRuns.Add((scenarioName, runTimestamp, runData));
                    incompleteRuns.Remove(scenarioName);
                }
                else
                {
                    incompleteRuns[scenarioName] = (runTimestamp, runData);
                }
            }

            columnOrder.Add("TestResult");

            var csvLines = new List<string>
            {
                string.Join(",", new[] { "RunTimestamp (UTC)", "Scenario" }.Concat(columnOrder).Select(CsvEscape))
            };

            foreach (var (scenarioName, runTimestamp, runData) in completedRuns)
            {
                var row = new List<string> { FormatTimestamp(runTimestamp), scenarioName };
                foreach (var column in columnOrder)
                {
                    var value = runData.TryGetValue(column, out var values) ? string.Join("; ", values) : string.Empty;
                    row.Add(value);
                }

                csvLines.Add(string.Join(",", row.Select(CsvEscape)));
            }

            // Best-effort rows for scenarios whose latest run never logged a TestResult (e.g. still
            // running or crashed), appended after the completed runs.
            foreach (var scenarioName in scenarioOrder)
            {
                if (!incompleteRuns.TryGetValue(scenarioName, out var incompleteRun))
                {
                    continue;
                }

                var row = new List<string> { FormatTimestamp(incompleteRun.RunTimestamp), scenarioName };
                foreach (var column in columnOrder)
                {
                    var value = incompleteRun.Data.TryGetValue(column, out var values) ? string.Join("; ", values) : string.Empty;
                    row.Add(value);
                }

                csvLines.Add(string.Join(",", row.Select(CsvEscape)));
            }

            var csvDirectory = Path.GetDirectoryName(csvFilePath);
            if (!string.IsNullOrEmpty(csvDirectory))
            {
                Directory.CreateDirectory(csvDirectory);
            }

            File.WriteAllLines(csvFilePath, csvLines);
        }

        private static string FormatTimestamp(string rawTimestamp)
        {
            if (string.IsNullOrWhiteSpace(rawTimestamp))
            {
                return string.Empty;
            }

            if (DateTime.TryParse(rawTimestamp, CultureInfo.InvariantCulture, DateTimeStyles.RoundtripKind, out var parsed))
            {
                var utc = parsed.Kind == DateTimeKind.Utc ? parsed : parsed.ToUniversalTime();
                return utc.ToString("yyyy-MM-dd HH:mm:ss") + " UTC";
            }

            return rawTimestamp;
        }

        private static string CsvEscape(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            if (value.Contains(',') || value.Contains('"') || value.Contains('\n') || value.Contains('\r'))
            {
                return "\"" + value.Replace("\"", "\"\"") + "\"";
            }

            return value;
        }

        private static string GetRepositoryRoot()
        {
            var current = new DirectoryInfo(AppContext.BaseDirectory);

            while (current != null)
            {
                if (Directory.Exists(Path.Combine(current.FullName, ".git")))
                {
                    return current.FullName;
                }

                current = current.Parent;
            }

            return TestContext.CurrentContext.WorkDirectory;
        }

        public static string GenerateRandomKey(int length)
        {
            const string chars = "ABCDEFGHJKLMNPQRSTUVWXYZabcdefghijkmnopqrstuvwxyz23456789!@#$%^&*";
            var buffer = new char[length];

            for (var i = 0; i < buffer.Length; i++)
            {
                buffer[i] = chars[RandomNumberGenerator.GetInt32(chars.Length)];
            }

            return new string(buffer);
        }
    }
}
