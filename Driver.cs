using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using OpenQA.Selenium.Support.UI;

/// Goes to my Univeristy website to 
/// grab my homework and put it in 
/// Google Calandar. 
/// @author Sam Prewitt
/// @version 10.20.2020

namespace Driver
{
    class Driver
    {
        static void Main(string[] args)
        {
           IWebDriver driver = new ChromeDriver();
            IWebDriver calDriver = new ChromeDriver();
            driver.Url = "https://asulearn.appstate.edu/";

            driver.Manage().Window.Maximize();

            //String Title = driver.Title;
            //Console.WriteLine(Title);

            //driver.manage().window().maximize();

            IWebElement element = driver.FindElement(By.LinkText("ASU log in"));
            element.Click();

            String userName = ("*****");
            String userName2 = ("*****");
            String password = ("*****");

            IWebElement userNameTB = driver.FindElement(By.Id("username"));
            userNameTB.SendKeys(userName);

            IWebElement passwordTB = driver.FindElement(By.Id("password"));
            passwordTB.SendKeys(password + "\n");

            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            
            try
                {
                    IWebElement assignment = driver.FindElement(By.XPath("//*[@id='yui_3_17_2_1_1604991256770_51']"));
                    assignment.Click();
                } catch (NoSuchElementException e)
                {
                    // I don't actually understand why assignment works but throws a NoSuchElementException. 
                    // There is an element because Selenium actually clicks on it...
                    // This try/catch prevents the program from crashing. 
                }
            
            // NEEDS to be updated.
            String className = driver.FindElement(By.PartialLinkText("C S2450-101_INTRO TO COMPUTER SYSTEMS (FALL 2020)")).Text;
            
            
            
            calDriver.Url = "https://accounts.google.com/signin/v2/identifier?service=cl&passive=1209600&osid=1&continue=https%3A%2F%2Fcalendar.google.com%2Fcalendar%2Frender&followup=https%3A%2F%2Fcalendar.google.com%2Fcalendar%2Frender&scc=1&flowName=GlifWebSignIn&flowEntry=ServiceLogin";
            calDriver.Manage().Window.Maximize();

            IWebElement element2 = calDriver.FindElement(By.Name("identifier"));
            element2.SendKeys(userName2 + "\n");

            calDriver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(5);

            IWebElement element3 = calDriver.FindElement(By.Id("username"));
            element3.SendKeys(userName + "\n");
            element3 = calDriver.FindElement(By.Id("password"));
            element3.SendKeys(password + "\n");

            element3 = calDriver.FindElement(By.XPath("//*[@id='view_container']/div/div/div[2]/div/div[2]/div/div[1]/div/div/button/div[2]"));
            element3.Click();

            element3 = calDriver.FindElement(By.XPath("/html/body/div[2]/div[1]/div[1]/div[1]/button/span[2]"));
            element3.Click();

            element3 = calDriver.FindElement(By.XPath("//*[@id='yDmH0d']/div/div/div[2]/span/div/div[1]/div[3]/div[1]/div[1]/div/div[1]/div/div[1]/input"));
            element3.SendKeys(className + "\n");
            
            driver.Close();
            calDriver.Close();

        }
    }
}
