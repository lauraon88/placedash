using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Models
{
    public partial class Consultant
    {
        #region properties

        private int _id;
        private string _FirstName;
        private string _Surname;
        private string _Email;
        private string _PhoneNumber;
        public int Id
        {
            get { return _id; }
        }

        public string FirstName
        {
            get { return _FirstName; }
            set { _FirstName = value; }
        }

        public string Surname
        {
            get { return _Surname; }
            set { _Surname = value; }
        }

        public string Email
        {
            get { return _Email; }
            set { _Email = value; }
        }
        public string PhoneNumber
        {
            get { return _PhoneNumber; }
            set { _PhoneNumber = value; }
        }
        public virtual ICollection<Consultant_Project> Consultant_Project { get; set; }

        #endregion

        #region ConsultantMethod
        public Consultant()
        {
            this.Consultant_Project = new List<Consultant_Project>();
        }
        #endregion

    }
}
