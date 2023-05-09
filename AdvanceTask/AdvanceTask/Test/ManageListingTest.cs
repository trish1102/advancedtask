




[TestFixture]
public class ManageListingTest : Commondriver
{
    SignIn singninObj = new SignIn();
     ProfilePage profilepageObj = new ProfilePage();
    ManageListing managelistingObj = new ManageListing();

    [Test,Order(1)]
    public void ViewListing()
    {
        test1 = extent.CreateTest("View Listing");
        test1.Log(Status.Pass, "test started");
        singninObj.SignInAction();
        test1.Log(Status.Info, "SignIn successfully");
        profilepageObj.ManageListing();
        test1.Log(Status.Pass, "Click on ManageListing successfully");
        Wait.TurnOnWait();
        managelistingObj.ViewRecord();
        test1.Log(Status.Pass, "ViewRecord function worked successfully");


    }
    [Test,Order(2)]
    public void UpdateListing()
    {
        test1 = extent.CreateTest("Update Listing");
        singninObj.SignInAction();
        test1.Log(Status.Info, "SignIn successfully");
        profilepageObj.ManageListing();
        Wait.TurnOnWait();
        test1.Log(Status.Pass, "Click on ManageListing successfully");
        managelistingObj.UpdateRecord();
        test1.Log(Status.Pass, "UpdateRecord function worked successfully");

    }
    [Test,Order(3)]
    public void DeleteListing()
    {
        test1 = extent.CreateTest("Delete Listing");
        singninObj.SignInAction();
        test1.Log(Status.Info, "SignIn successfully");
        profilepageObj.ManageListing();
        test1.Log(Status.Pass, "Click on ManageListing successfully");
        managelistingObj.DeleteRecord();
        test1.Log(Status.Pass, "Record Deleted successfully");

    }
}