namespace Defra.UI.Tests.Pages.CP.Interfaces
{
    public interface ISearchDocumentPage
    {
      bool IsPageLoaded();
      void EnterPTDNumber(string ptdNumber);
      void SelectSearchRadioOption(string radioButtonValue);
      void EnterApplicationNumber(string applicationNumber);
      void EnterMicrochipNumber(string microchipNumber);
      void SearchButton();
      void ClearSearchButton();
      bool IsError(string errorMessage);
        bool VerifyTheValuesAreCleared();
    }
}