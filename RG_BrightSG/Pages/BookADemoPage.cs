using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Remote;
using NUnit.Framework;
using System.Threading;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium.Support.UI;
using SeleniumExtras.PageObjects;

namespace RG_BrightSG
{
    class BookADemoPage
    {
        String test_url = "https://www.brightpay.co.uk/";

        private IWebDriver driver;
        private WebDriverWait wait;

        public BookADemoPage(IWebDriver driver)
        {
            this.driver = driver;
            wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
            PageFactory.InitElements(driver, this);
        }

        [FindsBy(How = How.Name, Using = "Name")]
        [CacheLookup]
        private IWebElement nameTextField;

        [FindsBy(How = How.Name, Using = "Email")]
        [CacheLookup]
        private IWebElement emailTextField;

        [FindsBy(How = How.Name, Using = "Phone")]
        [CacheLookup]
        private IWebElement phoneTextField;

        [FindsBy(How = How.Name, Using = "CompanyName")]
        [CacheLookup]
        private IWebElement companyNameTextField;

        [FindsBy(How = How.Name, Using = "PayrollSoftware")]
        [CacheLookup]
        private IWebElement payrollSoftwareDropdown;

        [FindsBy(How = How.Name, Using = "PayrollUsage")]
        [CacheLookup]
        private IWebElement payrollUsageTextField;

        [FindsBy(How = How.Name, Using = "IsSignUp")]
        [CacheLookup]
        private IWebElement signUpCheckbox;

        [FindsBy(How = How.Id, Using = "FormSubmit")]
        [CacheLookup]
        private IWebElement submitButton;

        [FindsBy(How = How.XPath, Using = "/html/body/header/div[2]/div/div[3]/div/div/div/div/form/div[2]/table/tbody/tr/td/h2")]
        [CacheLookup]
        private IWebElement thankYouMessage;



        public void populateRequestDemoForm()
        {
            nameTextField.SendKeys("test");
            emailTextField.SendKeys("test@test.com");
            phoneTextField.SendKeys("test");
            companyNameTextField.SendKeys("test");

            SelectElement payrollSoftwareDropdown = new SelectElement(driver.FindElement(By.Name("PayrollSoftware")));
            payrollSoftwareDropdown.SelectByText("Other");

            SelectElement whoDoYouProcessForDropdown = new SelectElement(driver.FindElement(By.Name("PayrollUsage")));
            whoDoYouProcessForDropdown.SelectByText("Single company (Employer)");

            signUpCheckbox.Click();
            submitButton.Click();

        }

        public void thankYouMessageDisplayed()
        {
            Assert.True(thankYouMessage.Displayed);

        }







    }
}
