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
            BLL.Models.Project getProject = new BLL.Models.Project(2);
            // verifies conditions in unit test using true/ false propositions
            Assert.IsTrue(getProject.Id == 2);
        }

        [TestMethod]
        public void CreateProject()
        {
            // create project instance
            BLL.Models.Project addProject = new BLL.Models.Project("Placement Dashboard");

            Assert.IsTrue(addProject.ProjectName == "Placement Dashboard");

        }

        [TestMethod]
        public void DeleteProject()
        {

            BLL.Models.Project delProject = new BLL.Models.Project(24);


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
            BLL.Models.Project editProject = new BLL.Models.Project(31);
            // make a name change and assert method returns true
            Assert.IsTrue(editProject.editProject("Testing edit method"));
            // delete project
            // editProject.deleteProject();
        }

        [TestMethod]
        public void testCalcBillDays()
    {

            //Arrange
        BLL.Models.Consultant_Project calc = new BLL.Models.Consultant_Project(1);

            //Act
        var actual = calc.calcBillDaysYTD(20);
            
            //Assert
        Assert.AreEqual(20, actual);
    }
    }
}
