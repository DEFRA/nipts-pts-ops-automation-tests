using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Classes;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Pages.CP.Pages;
using Defra.UI.Tests.Pages.WELSH.Classes;
using Defra.UI.Tests.Pages.WELSH.Interfaces;
using Defra.UI.Tests.Tools;
using Reqnroll;
using Reqnroll.BoDi;

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
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<EmailSignUpPage, IEmailSignUpPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GovernmentGatewayTypePage, IGovernmentGatewayTypePage>());
            

            // CP Testing
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignInCPPage, ISignInCPPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<RouteCheckingPage, IRouteCheckingPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<WelcomePage, IWelcomePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SearchDocumentPage, ISearchDocumentPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationSummaryPage, IApplicationSummaryPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ReportNonCompliancePage, IReportNonCompliancePage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<DocumentNotFoundPage, IDocumentNotFoundPage>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GBChecksReferralPage, IGBChecksReferralPage>());

            //Read Email
            _objectContainer.RegisterInstanceAs(GetBaseWithScenarioContext<FetchCodeFromEmail, IFetchCodeFromEmail>());


            // AP Welsh Testing
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<HomePageWelsh, IHomePageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetMicrochipPageWelsh, IPetMicrochipPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetMicrochipDatePageWelsh, IPetMicrochipDatePageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ChangeDetailsPageWelsh, IChangeDetailsPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSpeciesPageWelsh, IPetSpeciesPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetNamePageWelsh, IPetNamePageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetSexPageWelsh, IPetSexPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetDOBPageWelsh, IPetDOBPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetColourPageWelsh, IPetColourPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetBreedPageWelsh, IPetBreedPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<SignificantFeaturesPageWelsh, ISignificantFeaturesPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationDeclarationPageWelsh, IApplicationDeclarationPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<GetYourPetMicrochippedPageWelsh, IGetYourPetMicrochippedPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<ApplicationSubmissionPageWelsh, IApplicationSubmissionPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerDetailsPageWelsh, IPetOwnerDetailsPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerNamePageWelsh, IPetOwnerNamePageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerPostCodePageWelsh, IPetOwnerPostCodePageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerAddressPageWelsh, IPetOwnerAddressPageWelsh>());
            _objectContainer.RegisterInstanceAs(GetBaseWithContainer<PetOwnerPhoneNumberPageWelsh, IPetOwnerPhoneNumberPageWelsh>());
        }


        private TU GetBaseWithContainer<T, TU>() where T : TU => (TU)Activator.CreateInstance(typeof(T), _objectContainer);
        private TU GetBaseWithContainerScenarioContext<T, TU>() where T : TU => (TU)Activator.CreateInstance(typeof(T), _objectContainer, _scenarioContext);
        private TU GetBaseWithScenarioContext<T, TU>() where T : TU => (TU)Activator.CreateInstance(typeof(T), _scenarioContext);
    }
}