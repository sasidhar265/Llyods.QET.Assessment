using System.Text.Json;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Lloyds.QET.Assessment.UiTest
{
	public class LloydBranchTest
	{
        [Test]
        public void GetBranchPhoneNumbers()
        {
            // reading the directory path where we placed the json file
            string directoryPath = Path.Combine(Directory.GetParent(Directory.GetCurrentDirectory()).Parent.Parent.FullName, "UiTest");

            // directory path + filename along with file extension
            string file = directoryPath + "/testData.json";

            //reading the data from file
            string jsonData = File.ReadAllText(file);

            //parsing json file content
            var testData = JsonDocument.Parse(jsonData);

            // getting length of pincodes array in json file
            var arrayLength = testData.RootElement.GetProperty("PinCodes").GetArrayLength();


            // initializing webdriver with chrome driver
            WebDriver driver = GetWebDriver();

            // maximizing the window of browser
            driver.Manage().Window.Maximize();

            // navigating to the url
            driver.Navigate().GoToUrl("https://www.lloydsbank.com");

            // implicitly waiting
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            driver.FindElement(By.ClassName("top-header-menu-item")).Click();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);

            // javascript code to scroll any element
            ((IJavaScriptExecutor)driver).ExecuteScript("arguments[0].scrollIntoView(true);",
                driver.FindElement(By.XPath("//span[text()='Branch Finder']")));

            driver.FindElement(By.XPath("//span[text()='Branch Finder']")).Click();
            //driver.FindElement(By.XPath("/*[text() = 'Reject all']")).Click();
            //driver.FindElement(By.XPath(""));

            for (int i = 0; i <= arrayLength; i++)
            {
                var pinCode = testData.RootElement.GetProperty("PinCodes")[i].ToString();
                driver.FindElement(By.Id("q")).SendKeys(pinCode);
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.FindElement(By.XPath("//*[@id='search-form']/div[1]/button")).Click();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                //driver.FindElement(By.PartialLinkText("Lloyds Bank Strand")).Click();
                //driver.FindElement(By.Id("q")).Clear();
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                Console.WriteLine(pinCode);
            }

            driver.Close();
            driver.Quit();
        }

        private WebDriver GetWebDriver()
        {
            WebDriver driver = new ChromeDriver();
            return driver;
        }
    }
}

