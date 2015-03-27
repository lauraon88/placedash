using System;
using System.Collections.Generic;
using DAL;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;



namespace BLL.Models
{

    public partial class Project //partial class generated when auto coded, protects data inside
    {

        #region properties
        //creates a collapsable section for the properties of the class
        

        private int _id; //creates a private int called _id
        private string _projectName;

        [Key]
        public int Id //method to get the private value of the public int
        {
            get { return _id; } //dont need a set mutator here as the id is auto generated 
        } //returning the private _int so that it remains protected adn cannot be manipulated
        public string ProjectName
        {
            get { return _projectName; } // get is an accessor
            set { _projectName = value; } //set is a mutator
        }


        public virtual ICollection<Consultant_Project> Consultant_Project { get; set; }

        #endregion
        //end this section of the code

        #region constructors
        /// Constructor in the folowing methods are 'OVERLOADED' which means that in each constructor method, 
        /// the parameters can have different values. i.e. public Project(int idIN), public Project(string projectNameIN)



        /// <summary>
        /// Default constructor -   public Project() this is a parameterless constructor with no internal logic, it is created by the compiler
        /// Constructors are specialised methods - they have no return type. They
        /// create instances of classes and are standard initialisation methods
        /// </summary>

        public Project()
        {
            this.Consultant_Project = new List<Consultant_Project>();
        }
        /// <summary>
        /// This method is the ***READ*** method, allows user to input an id to search 
        /// for a project with that id
        /// </summary>
        /// <param name="idIN"></param>
        public Project(int idIN)
        //overloading the constructor method with the parameter int idIN
        {
            //try catch to catch any input errors and return an error message to the user
            try
            {
                // from the DashboardModelContainer in DAL, create a new 
                //DashboardModelContainer called 'DB'
                //a constructor is invoked with a 'new' keyword
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    //from the project table in the DAL, search the DB for idIN and select the first or default
                    //.first or default means - select the first row and return the default value if there are zero rows
                    //x is a generic
                    DAL.Project DBProject = (from x in DB.Projects where x.Id == idIN select x).FirstOrDefault();

                    //if the project name is not empty then set the _id to the id the user has entered
                    //and the project name to the project name associated with that id
                    if (DBProject.ProjectName != "")
                    {
                        //returns the values of the entered ID to this class instance
                        this._id = idIN;
                        this._projectName = DBProject.ProjectName;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }
        /// <summary>
        /// This is the method to ***ADD*** a new project 
        /// </summary>
        /// <param name="projectNameIN"></param>

        public Project(string projectNameIN)
        {
            try
            {
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    // creates a new project in the database called newDBProject
                    DAL.Project newDBProject = new DAL.Project();
                    //sets the projectNameIn as the new project name in the DB
                    newDBProject.ProjectName = projectNameIN;

                    //adds the new DBproject to the DB and saves the changes
                    DB.Projects.Add(newDBProject);
                    DB.SaveChanges();

                    //saves the values of the DB object to this class instance
                    this._id = newDBProject.Id;
                    this._projectName = newDBProject.ProjectName;
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error" + e);
            }
        }
        #endregion

        #region public methods

        /// <summary>
        /// This method is to ***delete*** an item from the database using a boolean method to either delete or not delete
        /// 
        /// </summary>
        /// <returns></returns>

        public Boolean deleteProject()
        {
            //sets the initial status of the delete to false, it is before the delete occurs
            Boolean delete = false;
            try
            {
                //using the model container from DAL create a new instance of the model container called DB
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    //if the class instance (i.e. the id that the user has selected) is not zero
                    if (this.Id != 0)
                    {
                        //then go to the project in DAL where the class intance (Id) is equivalent/matches the private id (_id)
                        //and select that project (now called DBProject)
                        DAL.Project DBProject = (from x in DB.Projects where x.Id == _id select x).FirstOrDefault();
                        //if the database instance of the Id is not zero then...
                        if (DBProject.Id != 0)
                        {
                            //...remove the DBProject from the database in projects and save the changes
                            DB.Projects.Remove(DBProject);
                            DB.SaveChanges();
                            //this means that the the delete is now true if all the previous steps have been carried out
                            delete = true;
                        }
                    }

                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
            /*returns whether the delete is true or false after the running through the code
             *if the conditions have been met (id is not zero and db id is not zero) then delete is true, so at the return
             * statement the project will be deleted. if the conditions have not been met (Id is zero in either case)
             * then delete is false and the project will not be deleted. */
            return delete;
        }

        /// <summary>
        /// This method is to ***EDIT*** a project item in the database
        /// </summary>
        /// <param name="updateProjectName"></param>
        /// <returns></returns>
        public Boolean editProject(string updateProjectName)
        {
            Boolean edit = false;
            try
            {
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    DAL.Project DBProject = (from x in DB.Projects where x.Id == _id select x).FirstOrDefault();
                    if (DBProject.Id != 0)
                    {
                        DBProject.ProjectName = updateProjectName;
                        DB.SaveChanges();
                        edit = true;
                    }
                }

            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
            return edit;
        }



        #endregion
    }
}


