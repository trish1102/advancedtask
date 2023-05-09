



namespace AdvanceTask.Pages
{
    public class ManageListing:Commondriver
    {
        public bool listingAdded= false;
       public IWebElement viewButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[last()]/td[8]/div/button[1]/i"));
        public IWebElement title => driver.FindElement(By.XPath("//div[@class='active section']"));
        public IWebElement updateButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]"));
        public IWebElement tagTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div"));
        public IWebElement tagBox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
        public IWebElement updatedTag => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div"));
        public IWebElement deleteButton => driver.FindElement(By.XPath("//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]"));
        public IWebElement acceptButton => driver.FindElement(By.XPath("/html/body/div[2]/div/div[3]/button[2]"));
        public void ViewRecord()
        {
            Global.ExcelLib.PopulateInCollection(@"C:\AdvanceTask\advancedtask\AdvanceTask\AdvanceTask\ExcelReport\ManageListing.xlsx", "UpdateListing");
            viewButton.Click();
             
             Assert.That(title.Text == Global.ExcelLib.ReadData(2, "Title"), "test failed");
        }
        public void UpdateRecord()
        {
            Global.ExcelLib.PopulateInCollection(@"C:\AdvanceTask\advancedtask\AdvanceTask\AdvanceTask\ExcelReport\ManageListing.xlsx", "UpdateListing");
            Wait.WaitForElementToBeClickable(driver,"XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[2]", 10);
            updateButton.Click();
            Wait.TurnOnWait();
            tagTextbox.Click();
            Wait.TurnOnWait();
            tagBox.SendKeys(Global.ExcelLib.ReadData(2, "Tag") + Keys.Enter);
            Wait.WaitForElementTobeExist(driver,"XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]",10);
            saveButton.Click();
            Assert.That(updatedTag.Text.Contains("path"), "Test failed");

        }
        public void DeleteRecord()
        {
            Wait.WaitForElementToBeClickable(driver,"XPath", "//*[@id=\"listing-management-section\"]/div[2]/div[1]/div[1]/table/tbody/tr[1]/td[8]/div/button[3]", 10);
            deleteButton.Click();
            Wait.TurnOnWait();
            acceptButton.Click();

        }
    }
}
