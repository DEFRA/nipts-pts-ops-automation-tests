namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IRouteCheckingPage
    {
        bool IsPageLoaded();
        bool IsSignedOut();
        void SelectTransportationOption(string option);
        void SelectFerryRouteOption(string routeOption);
        void SelectDropDownDepartureTime(string departTime);
        void SelectSaveAndContinue();
        bool IsError(string errorMessage);
        void SelectFlightNumber(string routeFlight);
        void SelectScheduledDepartureDate(string departureDay, string departureMonth, string departureYear);
        void SelectDropDownDepartureTimeHourOnly(string hour);
        bool CheckRouteSubheading(string subHeading);
        bool CheckRouteOptionsSelection();
        bool CheckFerryRouteSubheading(string subHeading);
        bool CheckFerryRouteOptionsSelection();
        bool IsTestEnvironmentPrototypePageLoaded();
        bool CheckDepartureTimeOnHomePage(string departureDay, string departureMonth, string departureYear, string departureTime);
        bool FlightNumberSection(string routeFlight);
        bool CheckDateSubheading(string dateSubHeading);
        bool CheckHintOfDateSubheading(string hint);
        bool CheckTimeSubheading(string timeSubHeading);
        bool CheckHintOfTimeSubheading(string hint);
        bool CheckCurrentDatePrepopulation();
        bool CheckRouteDetailOnHomePageHeader(string route);
        bool CheckNoPrepopulatedDepartureTime();
        void CheckDepartBefore48OrAfter24Hrs(string departureDay, string departureMonth, string departureYear, string departureHour, string departureMinute, string timeCheck);
    }
}