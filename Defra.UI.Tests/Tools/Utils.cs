﻿using OpenQA.Selenium;
using System.Globalization;

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

        public static DateTime GetCurrentTime()
        {
            DateTime currentDate = DateTime.Today;
            return currentDate;
        }

        public static void ChangePageView(this IWebDriver driver, int percentage)
        {
            var jse = (IJavaScriptExecutor)driver;
            jse.ExecuteScript($"document.body.style.zoom = '{percentage}%';");

            driver.Wait(2);
        }
    }
}
