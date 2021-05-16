using Xunit;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium.UITest
{
    public class UITest
    {

        public const string homeUrl = "http://localhost:53524";
        public const string privacyUrl = "http://localhost:53524/Home/Privacy";
        public const string pageTitle = "Home Page - SeleniumTest";
        public const string h1Welcome = "Welcome";


        OpenBrowser openBrowser = new OpenBrowser();

        [Fact]
        [Trait("Category", "Smoke")]
        public void LoadAplicationPage()
        {   
            openBrowser.StartWebDriver(homeUrl);
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void ReloadNavigate()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(homeUrl);

                // naviage to Privacy
                driver.Navigate().GoToUrl(privacyUrl);

                // go back
                driver.Navigate().Back();

                // go forward again
                driver.Navigate().Forward();
            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void CheckPageElements()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // got to URL first
                driver.Navigate().GoToUrl(homeUrl);

                // get page title from driver
                string title = driver.Title;

                // Assert page title
                Assert.Equal(pageTitle, title);

                // Assert h1 tag
                IWebElement h1Element = driver.FindElement(By.ClassName("display-4")); // create reference
                string driverWelcome = h1Element.Text;
                Assert.Equal(h1Welcome, driverWelcome);

            }
        }

        [Fact]
        [Trait("Category", "Smoke")]
        public void PrivacyBtn_Click()
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // got to Home url
                driver.Navigate().GoToUrl(homeUrl);

                // get privacy button element
                IWebElement privacy_btn = driver.FindElement(By.Name("privacy-link"));

                // click the button
                privacy_btn.Click();

                // check that we are in the privacy page
                Assert.Equal("Privacy Policy - SeleniumTest", driver.Title);
                Assert.Equal(privacyUrl, driver.Url);
            }
        }
    }
}
