using Reqnroll.BoDi;
using Defra.UI.Tests.HelperMethods;
using Defra.UI.Tests.Pages.AP.Interfaces;
using Defra.UI.Tests.Tools;
using OpenQA.Selenium;
using Defra.UI.Tests.Configuration;

namespace Defra.UI.Tests.Pages.AP.Classes
{
    public class PetBreedPage : IPetBreedPage
    {
        private readonly IObjectContainer _objectContainer;
        public PetBreedPage(IObjectContainer container)
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
        #endregion

        #region Methods
        public bool IsNextPageLoaded(string pageTitle)
        {
            if (ConfigSetup.BaseConfiguration.TestConfiguration.IsAccessibilityEnabled)
            {
                Cognizant.WCAG.Compliance.Checker.Analyzer.Execute(_driver);
            }

            return PageHeading.Text.Contains(pageTitle);
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

        public void ClickContinueButton()
        {
            _driver.ContinueButton();
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

        public bool VerifyBreedsList(string species)
        {
            drpBreedType.Click();
            
            List<string> expectedDogBreeds = new List<string> { "Mixed breed or unknown", "Afghan Hound", "Airedale Terrier", "Alaskan Malamute", "Australian Shepherd", "Basenji", "Basset Hound", "Beagle", "Belgian Malinois", "Belgian Tervuren", "Bernese Mountain Dog",
                "Bichon Frise", "Bloodhound", "Border Collie", "Borzoi", "Boston Terrier", "Boxer", "Bull Terrier", "Bulldog", "Cairn Terrier", "Cavalier King Charles Spaniel", "Chihuahua", "Chow Chow", "Cockapoo", "Cocker Spaniel",
                "Collie", "Corgi (Pembroke and Cardigan)", "Dachshund", "Dalmatian", "Doberman Pinscher", "English Setter", "Fox Terrier", "French Bulldog", "German Shepherd", "German Shorthaired Pointer", "Golden Retriever", "Great Dane",
                "Greyhound", "Irish Setter", "Irish Terrier", "Italian Greyhound", "Jack Russell Terrier", "Labrador Retriever", "Lhasa Apso", "Mastiff", "Newfoundland", "Old English Sheepdog", "Papillon", "Pekingese", "Pomeranian",
                "Poodle (Standard and Miniature)", "Portuguese Water Dog", "Pug", "Rottweiler", "Saint Bernard", "Samoyed", "Scottish Terrier", "Shar Pei", "Shetland Sheepdog", "Shih Tzu", "Siberian Husky", "Toy Poodle", "Vizsla",
                "Weimaraner", "West Highland White Terrier", "Whippet" };

            List<string> expectedCatBreeds = new List<string> { "Mixed breed or unknown", "Abyssinian", "American Shorthair", "Bengal", "Birman", "British Shorthair", "Burmese", "Chartreux", "Cornish Rex", "Devon Rex", "Domestic Longhair", "Domestic Mediumhair", 
                "Domestic Shorthair", "Exotic Shorthair", "Himalayan", "Maine Coon", "Manx", "Norwegian Forest Cat", "Ocicat", "Oriental Longhair", "Oriental Shorthair", "Persian", "Ragdoll", "Russian Blue", "Savannah", "Scottish Fold", "Scottish Fold Longhair", 
                "Siamese", "Siberian", "Sphynx", "Tonkinese", "Turkish Angora", "Turkish Van"};

            IList<IWebElement> breeds = drpBreedsListBox.FindElements(By.TagName("li"));
            if (species == "Dog")
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

            else if (species == "Cat")
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
        #endregion
    }
}