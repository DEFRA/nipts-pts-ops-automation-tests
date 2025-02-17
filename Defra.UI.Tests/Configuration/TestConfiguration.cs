﻿
namespace Defra.UI.Tests.Configuration
{
    public class TestConfiguration
    {
        public string ComplianceUrl { get; set; }
        public string ApplicationUrl { get; set; }
        public string Environment { get; set; }
        public string Platform { get; set; }
        public bool Headless { get; set; }
        public int GlobalWaitsInSeconds { get; set; }
        public string DeviceName { get; set; }
        public string BSOSVersion { get; set; }
        public string Project { get; set; }
        public string Build { get; set; }
        public bool IsEmulationEnabled { get; set; }
        public string EmulateDeviceInfo { get; set; }
        public string BSBrowserVersion { get; set; }
        public string EnvAPLogin { get; set; }
        public string EnvCPLogin { get; set; }
        public bool IsAccessibilityEnabled { get; set; }
    }
}
