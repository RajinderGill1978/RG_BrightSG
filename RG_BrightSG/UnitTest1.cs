using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;

namespace RG_BrightSG
{
    public class Tests
    {
        IWebDriver driver;

        [SetUp]
        public void Setup()
        {
            // Local Selenium WebDriver
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
        }

        [Test]
        public void BookADemo()
        {
            HomePage home_page = new HomePage(driver);
            BookADemoPage demo_page = new BookADemoPage(driver);

            home_page.goToPage();
            home_page.clickBookADemoButton();
            demo_page.populateRequestDemoForm();
            demo_page.thankYouMessageDisplayed();
            demo_page.thankYouMessageDisplayed();
        }


        [TearDown]
        public void close_Browser()
        {
            driver.Quit();
        }
    }
}