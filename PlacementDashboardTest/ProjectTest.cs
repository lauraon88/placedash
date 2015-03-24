using System;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using BLL;

namespace PlacementDashboardTest
{
    [TestClass]
    public class ProjectTest
    {
        [TestMethod]
        public void GetDBProject()
        {
            // get project ID from DB
            BLL.Models.Project getProject = new BLL.Models.Project(3);
            // verifies conditions in unit test using true/ false propositions
            Assert.IsTrue(getProject.Id == 3);
        }

        [TestMethod]
        public void CreateandDeleteProject()
        {
            // create project instance
            BLL.Models.Project delProject = new BLL.Models.Project("Placement Dashboard");
            if (delProject.Id > 0)
            {
                // delete user instance
                Assert.IsTrue(delProject.deleteProject());
                }
        }

        [TestMethod]
        public void EditDBProject()
        {
            //create a new project
            BLL.Models.Project editProject = new BLL.Models.Project("Internal");
            // make a name change and assert method returns true
            Assert.IsTrue(editProject.editProject("NICOMs Mobile"));
            // delete project
            editProject.deleteProject();
        }
    }
}
