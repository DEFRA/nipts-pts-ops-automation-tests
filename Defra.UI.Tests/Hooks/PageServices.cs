using Defra.UI.Tests.Data.Users;
using Defra.UI.Tests.Pages.AP.Classes;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Pages.CP.Interfaces;
using Defra.UI.Tests.Pages.CP.Pages;
using Defra.UI.Tests.Tools;
using Microsoft.Extensions.DependencyInjection;

namespace Defra.UI.Tests.Hooks
{
    public class PageServices
    {
        public static IServiceCollection SetupPageDependencies(IServiceCollection services)
        {
            services.AddSingleton<IAccessibility, Accessibility>();
            services.AddSingleton<IUserObject, UserObject>();
            services.AddSingleton<IUrlBuilder, UrlBuilder>();
            services.AddSingleton<ISignInPage, SignInPage>();
            services.AddSingleton<ILandingPage, LandingPage>();
            services.AddSingleton<IHomePage, HomePage>();
            services.AddSingleton<IGetYourPetMicrochippedPage, GetYourPetMicrochippedPage>();
            services.AddSingleton<IPetOwnerDetailsPage, PetOwnerDetailsPage>();
            services.AddSingleton<IPetMicrochipPage, PetMicrochipPage>();
            services.AddSingleton<IPetMicrochipDatePage, PetMicrochipDatePage>();
            services.AddSingleton<IPetSpeciesPage, PetSpeciesPage>();
            services.AddSingleton<IPetBreedPage, PetBreedPage>();
            services.AddSingleton<IPetNamePage, PetNamePage>();
            services.AddSingleton<IPetSexPage, PetSexPage>();
            services.AddSingleton<IPetDOBPage, PetDOBPage>();
            services.AddSingleton<IPetColourPage, PetColourPage>();
            services.AddSingleton<ISignificantFeaturesPage, SignificantFeaturesPage>();
            services.AddSingleton<IApplicationDeclarationPage, _applicationDeclarationPage>();
            services.AddSingleton<IApplicationSubmissionPage, ApplicationSubmissionPage>();
            services.AddSingleton<IPetOwnerNamePage, PetOwnerNamePage>();
            services.AddSingleton<IPetOwnerPostCodePage, PetOwnerPostCodePage>();
            services.AddSingleton<IPetOwnerAddressPage, PetOwnerAddressPage>();
            services.AddSingleton<IPetOwnerPhoneNumberPage, PetOwnerPhoneNumberPage>();
            services.AddSingleton<IPetOwnerAddressManuallyPage, PetOwnerAddressManuallyPage>();
            services.AddSingleton<IChangeDetailsPage, ChangeDetailsPage>();
            services.AddSingleton<ISummaryPage, SummaryPage>();
            services.AddSingleton<IManageAccountPage, ManageAccountPage>();

            // CP Testing
            services.AddSingleton<ISignInCPPage, SignInCPPage>();
            services.AddSingleton<IRouteCheckingPage, RouteCheckingPage>();
            services.AddSingleton<IWelcomePage, WelcomePage>();
            services.AddSingleton<ISearchDocumentPage, SearchDocumentPage>();
            services.AddSingleton<IApplicationSummaryPage, ApplicationSummaryPage>();
            services.AddSingleton<IReportNonCompliancePage, ReportNonCompliancePage>();
            services.AddSingleton<IDocumentNotFoundPage, DocumentNotFoundPage>();

            return services;
        }
    }
}
