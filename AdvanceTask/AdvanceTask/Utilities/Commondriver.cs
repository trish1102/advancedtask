


namespace AdvanceTask.Utilities
{
    public class Commondriver
    {
        public static IWebDriver driver;
        public static ExtentReports extent;
        public static ExtentTest test1;
        [SetUp]
        public void ExtentStart()
        {
            System.Text.Encoding.RegisterProvider(System.Text.CodePagesEncodingProvider.Instance);
            driver = new ChromeDriver();
            extent = new ExtentReports();
            var htmlreporter = new ExtentHtmlReporter(@"C:\AdvanceTask\advancedtask\AdvanceTask\AdvanceTask\ExtentReport\" + DateTime.Now.ToString("_MMddyyyy_hhmmtt") + ".html");
            extent.AttachReporter(htmlreporter);

        }


       
        [TearDown]
        public void ExtentClose()
        {
            Thread.Sleep(1000);
            string png = SaveScreenShotClass.SaveScreenshot(driver, "Report");
            test1.Log(Status.Info, "Snapshot below: " + test1.AddScreenCaptureFromPath(png));

            extent.Flush();
            driver.Close();
            driver.Quit();
        }
        



    }
}
