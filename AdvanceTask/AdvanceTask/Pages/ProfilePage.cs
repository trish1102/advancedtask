



namespace AdvanceTask.Pages
{
    public class ProfilePage : Commondriver
    {
       public IWebElement shareskillButton => driver.FindElement(By.XPath("//*[@id=\"account-profile-section\"]/div/section[1]/div/div[2]/a"));
       public IWebElement managelistingButton => driver.FindElement(By.XPath("//a[contains(text(),'Manage Listings')]"));

        public void ShareSkill()
        {
            //click on Shareskill
            Wait.TurnOnWait();
            shareskillButton.Click();

        }
        public void ManageListing()
        {
            //click on ManageListing
            
            Wait.WaitForElementToBeClickable(driver, "XPath", "//a[contains(text(),'Manage Listings')]", 10);
            managelistingButton.Click();
        }
    }
}
