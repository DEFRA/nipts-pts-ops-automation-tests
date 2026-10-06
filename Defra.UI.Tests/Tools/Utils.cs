using NUnit.Framework;
using OpenQA.Selenium;
using System.Globalization;
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
