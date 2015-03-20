using System;
using System.Collections.Generic;
using DAL;


namespace BLL.Models
{
    public partial class Project //partial class generated when auto coded, protects data inside
    {

        #region properties 
        //creates a collapsable section for the properties of the class

        private int _id; //creates a private int called _id
        private string _projectName;
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
        public Project()
        {
            this.Consultant_Project = new List<Consultant_Project>();
        } 
    }
}
