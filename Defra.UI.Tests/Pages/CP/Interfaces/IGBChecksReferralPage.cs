using Microsoft.Crm.Sdk.Messages;
using Reqnroll;

namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IGBChecksReferralPage
    {
        bool IsPageLoaded(); 
        void ClickViewLink(string departureTime);
        void ClickPTDOrReferenceNumber();
        bool IsGBCheckReportPageLoaded();
        bool IsGBUpdateReferralOutcomePageLoaded();
        bool CheckReportPageSubheadings(string subHeading1, string subHeading2);
        bool CheckOutcome(string checkOutcome);
        bool ReasonForReferral(string referralReason);
        bool MCNumberFoundInScan(string mcNumber);
        bool AdditionalComments(string additionalComments);
        bool GBChecker(string gbChecker);
        bool RouteInGBCheckPage(string route);
        bool ScheduledDepartDate();
        bool ScheduledDepartTime(string departTime);
        bool CheckPTDNumberFormat(string ptdNumberPrefix);
        bool ClickApplicationRef(string referenceNumber);
        void ClickOnUpdateReferralOutcomeButton();
        bool VerifyTravelStatus(string travelStatus, string travelStatus1);
        bool VerifyBGColorforTravelStatus(string referenceNumber, string travelStatus, string color);
        bool CheckRouteDetailOnReferredToSPSPage(string route, string departureTime);
        bool VerifyDetailsOfOutcome(string outcomeDetails);
        bool CheckReferredToSPSTableLabels(string ptdOrRefNumber, string pet, string microchip, string travelBy, string spsOutcome);
        bool CheckReferredToSPSTableValues(string ptdOrRefNumber, string pet, string microchip, string travelBy, string spsOutcome);
        bool CheckPTDOrRefNumDuplicates(string ptdOrRefNumber);
        bool CheckPassCount(string count, string departureTime);
        bool CheckFailCount(string count, string departureTime);
        bool DateAndTimeChecked();
        bool CheckPagination();
        bool CheckDirectPageNavigation();
        bool IsViewLinkPresent(string departureTime);
        void ClickViewLink();
        bool VerifyAdditionalCommentsNotPresent();
    }
}