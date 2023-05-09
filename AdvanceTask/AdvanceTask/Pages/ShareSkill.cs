


namespace AdvanceTask.Pages
{
    public class ShareSkill:Commondriver
    {

        public  IWebElement titleTextbox => driver.FindElement(By.Name("title"));
        public IWebElement descriptionTextbox => driver.FindElement(By.Name("description"));
        public IWebElement categeryDropbox => driver.FindElement(By.XPath("//option[ text()='Programming & Tech']"));
        public IWebElement subcategeryDropbox => driver.FindElement(By.XPath("//option[ text()='QA']"));
        public IWebElement tagTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div"));
        public IWebElement selecttagbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input"));
        public IWebElement servicetypeButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[5]/div[2]/div[1]/div[2]/div/input"));
        public IWebElement locationtypeButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[6]/div[2]/div/div[2]/div/input"));
        public IWebElement startDate => driver.FindElement(By.Name("startDate"));
        public IWebElement endDate => driver.FindElement(By.Name("endDate"));
        public IWebElement dayCheckbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[7]/div[2]/div/div[3]/div[1]/div/input"));
        public IWebElement starttimeTextbox => driver.FindElement(By.Name("StartTime"));
        public IWebElement finishtimeTextbox => driver.FindElement(By.Name("EndTime"));
        public IWebElement skilltradeButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[2]/div/div[1]/div/input"));
        public IWebElement skillexchangeTextbox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div"));
        public IWebElement selectskillBox => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input"));
        public IWebElement activestatusButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[10]/div[2]/div/div[1]/div/input"));
        public IWebElement saveButton => driver.FindElement(By.XPath("//*[@id=\"service-listing-section\"]/div[2]/div/form/div[11]/div/input[1]"));
       
       
        public void CreateSkill()
        {
             Global.ExcelLib.PopulateInCollection(@"C:\AdvanceTask\advancedtask\AdvanceTask\AdvanceTask\ExcelReport\ManageListing.xlsx", "ShareSkill");
            //get title textbox and send value
            titleTextbox.SendKeys(Global.ExcelLib.ReadData(2, "Title"));
            //get description textbox and send value
            descriptionTextbox.SendKeys(Global.ExcelLib.ReadData(2, "Description"));
            //get categery dropbox and select categery
            categeryDropbox.Click();
            // Thread.Sleep(1000);
            Wait.WaitForElementToBeClickable(driver,"XPath", "//option[ text()='QA']", 10);
            //get subcategery dropbox and select value
             subcategeryDropbox.Click();
            //get tags texbox and send values
            tagTextbox.Click();
            Wait.WaitForElementTobeExist(driver,"XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[4]/div[2]/div/div/div/div/input", 10);
           selecttagbox.SendKeys(Global.ExcelLib.ReadData(2, "Tags") + Keys.Enter);
             //select service type
            servicetypeButton.Click();
            //select location type
            locationtypeButton.Click();
            //select starting date
            startDate.SendKeys(Global.ExcelLib.ReadData(2,"Start-Date"));
            //select end date
             startDate.SendKeys(Global.ExcelLib.ReadData(2, "End-Date"));
            //select days and timing
            dayCheckbox.Click();
            starttimeTextbox.SendKeys("10:30am");
            finishtimeTextbox.SendKeys("02:30am");
            //select skilltrade
            skilltradeButton.Click();
            //select skill exchange
            skillexchangeTextbox.Click();
            Wait.WaitForElementTobeExist(driver,"XPath", "//*[@id=\"service-listing-section\"]/div[2]/div/form/div[8]/div[4]/div/div/div/div/div/input", 10);
            selectskillBox.SendKeys(Global.ExcelLib.ReadData(2, "Skill-Exchange") + Keys.Enter);
            //select active status
           activestatusButton.Click();
            //get save button and click to save data
            saveButton.Click();
            
            

        }
        


    }
}
