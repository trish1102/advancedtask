


namespace AdvanceTask.Test
{
    [TestFixture]
    public class ShareSkillTest:Commondriver
    {
        SignIn singninObj = new SignIn();
        ProfilePage profilepageObj = new ProfilePage();
        ShareSkill skillObj = new ShareSkill();
        ManageListing managelistingObj = new ManageListing();
       


        [Test,Order(1)]
        public void CreateSkillListing()
        {
           
            test1 = extent.CreateTest("CreateSkillListing");
            test1.Log(Status.Info, "test started");
            singninObj.SignInAction();
            test1.Log(Status.Info, "SignIn successfully");
            profilepageObj.ShareSkill();
            
            try
            {
                Wait.TurnOnWait();
                test1.Log(Status.Pass, "successfully clicked on ShareSkill link");
            }
            catch(Exception e)
            {
                test1.Log(Status.Fail, "Fail to click on ShareSkill link");
                throw;

            }
            skillObj.CreateSkill();
            test1.Log(Status.Info,"Listing Created successfully");


            
        }
        
        [Test,Order(2)]
        public void UpdateSkillListing()
        {
            test1 = extent.CreateTest("Update SkillListing");
            singninObj.SignInAction();
            test1.Log(Status.Info, "SignIn successfully");
            profilepageObj.ManageListing();
            Wait.TurnOnWait();
            test1.Log(Status.Pass, "Click on ManageListing successfully");
            managelistingObj.UpdateRecord();
            test1.Log(Status.Pass, "UpdateRecord function worked successfully");
        }
        [Test,Order(3)]
        public void DeleteSkillListing()
        {
            test1 = extent.CreateTest("Delete SkillListing");
            singninObj.SignInAction();
            test1.Log(Status.Info, "SignIn successfully");
            profilepageObj.ManageListing();
            test1.Log(Status.Pass, "Click on ManageListing successfully");
            managelistingObj.DeleteRecord();
            test1.Log(Status.Pass, "Record Deleted successfully");
        }
    }
}
