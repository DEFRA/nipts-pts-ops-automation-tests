namespace Defra.UI.Tests.Pages.CP.Interfaces
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
        bool CheckRouteSubheading(string subHeading);
        bool CheckRouteOptionsSelection();
        bool CheckFerryRouteSubheading(string subHeading);
        bool CheckFerryRouteOptionsSelection();
        bool IsTestEnvironmentPrototypePageLoaded();
        bool CheckFooter();
        bool CheckDepartureTimeOnHomePage();
        bool FlightNumberSection(string routeFlight);
    }
}