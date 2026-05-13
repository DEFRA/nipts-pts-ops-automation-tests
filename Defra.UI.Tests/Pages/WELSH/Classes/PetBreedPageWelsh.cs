using Defra.UI.Tests.Configuration;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Reqnroll.BoDi;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetBreedPageWelsh : IPetBreedPageWelsh
    {
        private readonly IObjectContainer _objectContainer;
        public PetBreedPageWelsh(IObjectContainer container)
        {
            _objectContainer = container;
        }

        #region Page objects
        private IWebDriver _driver => _objectContainer.Resolve<IWebDriver>();
        public IWebElement PageHeading => _driver.WaitForElement(By.XPath("//h1[contains(@class,'govuk-fieldset__heading')]"), true);
        public IWebElement drpBreedType => _driver.WaitForElementExists(By.Id("BreedId"));
        private IWebElement txtBreed => _driver.WaitForElement(By.Name("BreedName"));
        private IWebElement drpBreedsListBox => _driver.WaitForElement(By.Id("BreedId__listbox"));
        private IWebElement btnContinue => _driver.WaitForElement(By.XPath("//button[@class='govuk-button']"));
        private IReadOnlyCollection<IWebElement> lblErrorMessages => _driver.WaitForElements(By.XPath("//div[@class='govuk-error-summary__body']//a"));
        private IWebElement footerLinkAccessibilityinWelsh => _driver.WaitForElement(By.XPath("//a[contains(text(),'Datganiad hygyrchedd')]"));
        private IWebElement footerLinkcookiesinWelsh => _driver.WaitForElement(By.XPath("// a [contains(text(),'Cwcis')]"));
        private IWebElement footerLinkPrivacynoticeinWelsh => _driver.WaitForElement(By.XPath("//a[contains(text(),'Hysbysiad preifatrwydd (yn agor mewn tab newydd)')]"));
        private IWebElement footerLinkTermsandconditionsinWelsh => _driver.WaitForElement(By.XPath("//a[contains(text(),'Telerau ac amodau')]"));
        private IWebElement txtHintBreed => _driver.WaitForElement(By.CssSelector("#BreedId__assistiveHint"));
        #endregion


        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            string heading = PageHeading.Text.Trim().Replace("\u2019", "'").Replace("\u2018", "'");
            return heading.Contains(pageTitle);
        }

        public string SelectPetsBreed(int breedIndex, bool isUpdate = false)
        {
            _driver.Wait(2);
            drpBreedType.Click();

            if (isUpdate)
            {
                drpBreedType.SendKeys(Keys.Backspace);
            }

            var selectedBreed = _driver.WaitForElement(By.Id($"BreedId__option--{breedIndex}"));

            var selectedBread = selectedBreed.Text;
            selectedBreed.Click();

            return selectedBread;
        }

        public void ClickParhauButton()
        {
            _driver.ParhauButton();
        }

        public void EnterFreeTextBreed(string breed)
        {
            drpBreedType.Click();

            txtBreed.SendKeys(breed);
            txtBreed.SendKeys(Keys.Tab);
        }

        public bool IsError(string errorMessage)
        {
            foreach (var element in lblErrorMessages)
            {
                if (element.Text.Contains(errorMessage))
                {
                    return true;
                }
            }

            return false;
        }

        public bool VerifyBreedsListInWelsh(string species)
        {
            drpBreedType.Click();

            List<string> expectedDogBreeds = new List<string> { "Brid cymysg neu anhysbys", "Adargi Labrador", "Adargi melyn", "Basenji", "Bichon Frise", "Bleiddgi'r Almaen", "Bocser", "Borzoi", "Ci Affgan", "Ci Basset", "Ci codi llwynog", "Ci Dalmataidd", "Ci defaid",
                "Ci defaid Awstralia", "Ci defaid Shetland", "Ci defaid y goror", "Ci dŵr Portiwgal", "Ci Esgimo Alasca", "Ci mawr Denmarc", "Ci Sant Bernard", "Ci smwt", "Ci tarw", "Ci tarw Frengig", "Ci’r Tir Newydd", "Cockapoo", "Corfilgi", "Corgi (Penfro ac Aberteifi)",
                "Corhelgi", "Cyfeirgi Gwyddelig", "Cyfeirgi Seisnig", "Chihuahuah", "Chow", "Dachshund", "Daeargi Airedale", "Daeargi Albanaidd", "Daeargi Almaenig blew cwta", "Daeargi Boston", "Daeargi byrgoes", "Daeargi Gwyddelig", "Daeargi gwyn yr Ucheldiroedd",
                "Daeargi Jack Russell", "Daeargi tarw", "Dobermann Pinscher", "Gwaetgi", "Hen gi defaid Seisnig", "Hysgi Siberia", "Lhasa Apso", "Llamgi", "Malinois Gwlad Belg", "Mastiff", "Milgi", "Milgi Eidalaidd", "Mynyddgi Bern", "Papillon", "Pecinî", "Pomeraniad",
                "Pwdl (Pwdl Tegan)", "Pwdl (Tal a Bychan)", "Rottweiler", "Samoyed", "Sbaengi Siarl", "Shar Pei", "Shih Tzu", "Tervuren Gwlad Belg", "Vizsla", "Weimaraner" };

            List<string> expectedCatBreeds = new List<string> { "Brid cymysg neu anhysbys", "Birman", "Cath Abysinia", "Cath Angora Twrci", "Cath Americanaidd blew cwta", "Cath Bengal", "Cath Bersia", "Cath Brydeinig blew cwta", "Cath Byrma",
                "Cath clustiau plyg blew hir o’r Alban", "Cath clustiau plyg o’r Alban", "Cath Chartreux", "Cath ddomestig blew canolig", "Cath ddomestig blew cwta", "Cath ddomestig blew hir", "Cath ddwyreiniol blew cwta", "Cath ddwyreiniol blew hir",
                "Cath estron blew cwta", "Cath Fan Twrci", "Cath fforestydd Norwy", "Cath gwta", "Cath Himalaiaidd", "Cath las Rwsia", "Cath Maine", "Cath safana", "Cath Siám", "Cath Siberia", "Cath Toncin", "Ocicat", "Ragdoll", "Rex Cernyw",
                "Rex Dyfnaint", "Sffincs" };

            IList<IWebElement> breeds = drpBreedsListBox.FindElements(By.TagName("li"));
            if (species == "Ci")
            {
                List<string> acutalDogBreeds = new List<String>();
                foreach (IWebElement option in breeds)
                {
                    if (!string.IsNullOrEmpty(option.Text.Trim()))
                    {
                        acutalDogBreeds.Add(option.Text.Trim());
                    }
                }

                for (int i = 0; i < expectedDogBreeds.Count; i++)
                {
                    if (expectedDogBreeds[i] != acutalDogBreeds[i])
                    {
                        return false;
                    }
                }
            }

            else if (species == "Cath")
            {
                List<string> acutalCatBreeds = new List<String>();
                foreach (IWebElement option in breeds)
                {
                    if (!string.IsNullOrEmpty(option.Text.Trim()))
                    {
                        acutalCatBreeds.Add(option.Text.Trim());
                    }
                }

                for (int i = 0; i < expectedCatBreeds.Count; i++)
                {
                    if (expectedCatBreeds[i] != acutalCatBreeds[i])
                    {
                        return false;
                    }
                }
            }
            return true;
        }
 
        public bool VerifyFooterLinksinWelsh()
        {

            return footerLinkAccessibilityinWelsh.Text.Equals("Datganiad hygyrchedd")
                && footerLinkcookiesinWelsh.Text.Equals("Cwcis")
                && footerLinkPrivacynoticeinWelsh.Text.Equals("Hysbysiad preifatrwydd (yn agor mewn tab newydd)")
                && footerLinkTermsandconditionsinWelsh.Text.Equals("Telerau ac amodau");

        }

    

        public bool VerifyHintText()
        {
            return txtHintBreed.Text.Contains("Teipiwch frîd eich cath neu dewiswch o'r opsiynau a awgrymir.");
        }
     
        #endregion
         }
                         
        }
