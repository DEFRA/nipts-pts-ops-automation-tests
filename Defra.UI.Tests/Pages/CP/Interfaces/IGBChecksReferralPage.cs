using Microsoft.Crm.Sdk.Messages;

namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface IGBChecksReferralPage
    {
        bool IsPageLoaded(); 
        void ClickViewLink();
        void ClickPTDOrReferenceNumber();
        bool IsGBCheckReportPageLoaded();
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
    }
}