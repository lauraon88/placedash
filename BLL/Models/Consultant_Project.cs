using System;
using System.Collections.Generic;
using DAL;

namespace BLL.Models
{
    public partial class Consultant_Project
    {

        #region properties

        private int _Id;
        private DateTime _ProjStartDate;
        private DateTime _ProjEndDate;
        private bool _BillableStatus;
        private Nullable<int> _BillableDaysMonth;

        private Nullable<int> _BillableDaysYTD;
        private int _ProjectId;
        private int _ConsultantId;

        public int Id
        {
            get { return _Id; }
        }
        public System.DateTime ProjStartDate
        {
            get { return _ProjStartDate; }//get must include a return statement
            set { _ProjStartDate = value; }//set implementation receives the implicit argument 'value'
        }
        public System.DateTime ProjEndDate
        {
            get { return _ProjEndDate; }
            set { _ProjEndDate = value; }
        }
        public bool BillableStatus             ///This can also be written as:
        {                                      ///public bool BillableStatus {get;set;}
            get { return _BillableStatus; }    ///in shortcut syntax
            set { _BillableStatus = value; }
        }

        public Nullable<int> BillableDaysMonth
        {
            get { return _BillableDaysMonth; }
            set { _BillableDaysMonth = value; }
        }
        public Nullable<int> BillableDaysYTD
        {
            get { return _BillableDaysYTD; }
            set { _BillableDaysYTD = value; }
        }
        public int ConsultantId
        {
            get { return _ConsultantId; }
            set { _ConsultantId = value; }
        }
        public int ProjectId
        {
            get { return _ProjectId; }
            set { _ProjectId = value; }
        }
        public virtual Consultant Consultant { get; set; }//virtual modifier tells the compiler that when any class derived from
        //the main class, an override method should be called
        public virtual Project Project { get; set; }

        #endregion
    }
}
//virtual property allows the EF to create a proxy around the virtual property so that the property can support
//lazy loading and more efficient change tracking
//private virtual classses cannot be declared in c# 
//virtual methods are an implementation of type based polymorphism - it gives an entry point for derived classes to use base class type