using BoDi;
using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Tools;
using TechTalk.SpecFlow;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Pages.CP.Pages;
using Defra.UI.Tests.Pages.AP.ChangeDetails;
using Defra.UI.Tests.Pages.AP.ApplicationSubmittedPage;
using Defra.UI.Tests.Pages.AP.ApplicationDeclarationPage;
using Defra.UI.Tests.Pages.AP.PetOwnerPhoneNumberPage;
using Defra.UI.Tests.Pages.AP.PetOwnerAddressManuallyPage;
using Defra.UI.Tests.Pages.AP.PetSexPage;
using Defra.UI.Tests.Pages.AP.PetOwnerNamePage;
using Defra.UI.Tests.Pages.AP.PetMicrochipPage;
using Defra.UI.Tests.Pages.AP.SignificantFeaturesPage;
using Defra.UI.Tests.Pages.AP.SummaryPage;
using Defra.UI.Tests.Pages.AP.ManageAccountPage;
using Defra.UI.Tests.Pages.AP.PetSpeciesPage;
using Defra.UI.Tests.Pages.AP.PetDOBPage;
using Defra.UI.Tests.Pages.AP.GetYourPetMicrochippedPage;
using Defra.UI.Tests.Pages.AP.PetMicrochipDatePage;
using Defra.UI.Tests.Pages.AP.PetOwnerPostCodePage;
using Defra.UI.Tests.Pages.AP.PetColourPage;
using Defra.UI.Tests.Pages.AP.SignInPage;
using Defra.UI.Tests.Pages.AP.LandingPage;
using Defra.UI.Tests.Pages.AP.PetNamePage;
using Defra.UI.Tests.Pages.AP.PetOwnerAddressPage;
using Defra.UI.Tests.Pages.AP.PetBreedPage;
using Defra.UI.Tests.Pages.AP.HomePage;
using Defra.UI.Tests.Pages.AP.PetOwnerDetailsPage;



namespace Defra.UI.Tests.Hooks
{
    [Binding]
    public class PageHooks
    {

        private readonly IObjectContainer _objectContainer;
        private readonly ScenarioContext _scenarioContext;

        public PageHooks(IObjectContainer objectContainer, ScenarioContext senarioContext)
        {
            _objectContainer = objectContainer;
            _scenarioContext = senarioContext;

        }

        [BeforeScenario(Order = (int)HookRunOrder.Pages)]
        public void BeforeScenario()
        {
            BindAllPages();
        }

        private void BindAllPages()
        {
            //Accessibility Testing
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<Accessibility, IAccessibility>());

            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UserObject, IUserObject>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<UrlBuilder, IUrlBuilder>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInPage, ISignInPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<LandingPage, ILandingPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<HomePage, IHomePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GetYourPetMicrochippedPage, IGetYourPetMicrochippedPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerDetailsPage, IPetOwnerDetailsPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetMicrochipPage, IPetMicrochipPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetMicrochipDatePage, IPetMicrochipDatePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSpeciesPage, IPetSpeciesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetBreedPage, IPetBreedPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetNamePage, IPetNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSexPage, IPetSexPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetDOBPage, IPetDOBPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetColourPage, IPetColourPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignificantFeaturesPage, ISignificantFeaturesPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationDeclarationPage, IApplicationDeclarationPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationSubmissionPage, IApplicationSubmissionPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerNamePage, IPetOwnerNamePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerPostCodePage, IPetOwnerPostCodePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerAddressPage, IPetOwnerAddressPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerPhoneNumberPage, IPetOwnerPhoneNumberPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerAddressManuallyPage, IPetOwnerAddressManuallyPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ChangeDetailsPage, IChangeDetailsPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SummaryPage, ISummaryPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ManageAccountPage, IManageAccountPage>());

            // CP Testing
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInCPPage, ISignInCPPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<RouteCheckingPage, IRouteCheckingPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<WelcomePage, IWelcomePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SearchDocumentPage, ISearchDocumentPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationSummaryPage, IApplicationSummaryPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ReportNonCompliancePage, IReportNonCompliancePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<DocumentNotFoundPage, IDocumentNotFoundPage>());

        }


        private TU GetBaseWithContainer<T, TU>() where T : TU => (TU)Activator.CreateInstance(typeof(T), _objectContainer);
        private TU GetBaseWithContainerScenarioContext<T, TU>() where T : TU => (TU)Activator.CreateInstance(typeof(T), _objectContainer, _scenarioContext);
        private TU GetBaseWithScenarioContext<T, TU>() where T : TU => (TU)Activator.CreateInstance(typeof(T), _scenarioContext);
    }
}