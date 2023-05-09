
using DocumentFormat.OpenXml.Bibliography;

namespace AdvanceTask.Pages
{
    public class SignIn : Commondriver
    {
        public IWebElement signinButton => driver.FindElement(By.XPath("//a[text()='Sign In']"));
        public IWebElement usernameTextbox => driver.FindElement(By.Name("email"));
        public IWebElement passwordTextbox => driver.FindElement(By.Name("password"));
        public IWebElement loginButton => driver.FindElement(By.XPath("//button[text()='Login']"));
        public void SignInAction()
    
        {
           //open browser
            //goto Url("http://localhost:5000")
            driver.Navigate().GoToUrl("http://localhost:5000");
            driver.Manage().Window.Maximize();
            //click sign in button
            Wait.TurnOnWait();
             signinButton.Click();
            Global.ExcelLib.PopulateInCollection(@"C:\AdvanceTask\advancedtask\AdvanceTask\AdvanceTask\ExcelReport\ManageListing.xlsx", "SignIn");
            //Enter username and password
            usernameTextbox.SendKeys(Global.ExcelLib.ReadData(2,"Email"));
            passwordTextbox.SendKeys(Global.ExcelLib.ReadData(2, "Password"));
            // click on login button
           loginButton.Click();
        }
    }
}
