using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;


namespace Selenium.UITest
{
    public class OpenBrowser
    {
        public void StartWebDriver(string url)
        {
            using (IWebDriver driver = new ChromeDriver())
            {
                // open driver and go to Home page
                driver.Navigate().GoToUrl(url);
            }
        }
    }
}
