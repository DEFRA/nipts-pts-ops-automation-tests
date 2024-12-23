﻿namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IRouteCheckingPage
    {
        bool IsPageLoaded();
        bool IsSignedOut();
        void SelectTransportationOption(string option);
        void SelectFerryRouteOption(string routeOption);
        void SelectDropDownDepartureTime();
        void SelectSaveAndContinue();
        bool IsError(string errorMessage);
        void SelectFlightNumber(string routeFlight);
        void SelectScheduledDepartureDate(string departureDay, string departureMonth, string departureYear);
        void SelectDropDownDepartureTimeMinuteOnly();
    }
}