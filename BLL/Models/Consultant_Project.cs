using System;
using System.Collections.Generic;
using DAL;
using System.Data.Entity;
using System.Linq;
using System.ComponentModel.DataAnnotations;

namespace BLL.Models
{
    public partial class Consultant_Project
    {

        #region properties

        private int _id;
        private DateTime _ProjStartDate;
        private DateTime _ProjEndDate;
        private bool _BillableStatus;
        private TimeSpan _BillableDaysMonth;

        private Nullable<int> _BillableDaysYTD;
        private int _ProjectId;
        private int _ConsultantId;

        public int Id
        {
            get { return _id; }
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

        public TimeSpan ConvertIntToTSDays(int? numIn)
        {
            //method to convert the int back to a timespan 
            TimeSpan result = new TimeSpan((int)numIn, 0, 0, 0);
            return result;
        }

        public TimeSpan BillableDaysMonth
        {
            set { _BillableDaysMonth = (_ProjEndDate.Subtract(_ProjStartDate)); }
            get { return _BillableDaysMonth; }
        }
        public int? BillDaysValue()
        {
            //method to convert Timespan BillableDaysMonth to an int called 'NrOfDaysInt'
            TimeSpan BillableDays_Month = BillableDaysMonth;
            double NrofDays = BillableDaysMonth.TotalDays;
            int? NrofDaysInt = Convert.ToInt32(NrofDays);
            return NrofDaysInt;

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
        //virtual property allows the EF to create a proxy around the virtual property so that the property can support
        //lazy loading and more efficient change tracking
        //private virtual classses cannot be declared in c# 
        //virtual methods are an implementation of type based polymorphism - it gives an entry point for derived classes to use base class type
        #endregion

        #region constructors
        /// <summary>
        /// This method allows user to ***READ***
        /// </summary>
        /// <param name="idIN"></param>
        public Consultant_Project(int idIN)
        {
            try
            {
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    DAL.Consultant_Project DBConsultantProj = (from cp in DB.Consultant_Project where cp.Id == idIN select cp).FirstOrDefault();

                    if (DBConsultantProj.Id != 0)
                    {
                        this._id = DBConsultantProj.Id;
                        this._ProjStartDate = DBConsultantProj.ProjStartDate;
                        this._ProjEndDate = DBConsultantProj.ProjEndDate;


                        this._BillableStatus = DBConsultantProj.BillableStatus;
                        //this instance of the timespan 'billable days month' = Billable days month int in the database converted back to a timespan
                        this._BillableDaysMonth = ConvertIntToTSDays(DBConsultantProj.BillableDaysMonth);

                        this._BillableDaysYTD = DBConsultantProj.BillableDaysYTD;

                        this._ProjectId = DBConsultantProj.ProjectId;
                        this._ConsultantId = DBConsultantProj.ConsultantId;
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error " + e);
            }
        }
        /// <summary>
        /// This is the method to ***ADD*** values into the consultant project table
        /// </summary>
        /// <param name="ProjectStartDateIN"></param>
        /// <param name="ProjectEndDateIN"></param>
        /// <param name="BillableStatusIN"></param>
        /// <param name="billableDaysMonthIN"></param>
        /// <param name="billableDaysYtdIN"></param>
        public Consultant_Project(DateTime ProjectStartDateIN, DateTime ProjectEndDateIN, bool BillableStatusIN,
             int? billableDaysYtdIN)
        {

            try
            {
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    DAL.Consultant_Project newDBConsultantProj = new DAL.Consultant_Project();

                    newDBConsultantProj.ProjStartDate = ProjectStartDateIN;
                    newDBConsultantProj.ProjEndDate = ProjectEndDateIN;
                    newDBConsultantProj.BillableStatus = BillableStatusIN;

                    //if (BillableDaysMonth == null)
                    //{
                    //    //if the billable days month is null then set the new value for consultant project to null
                    //    newDBConsultantProj.BillableDaysMonth = default(int)  ;

                    //}
                    //else
                    //{
                    //    //otherwise set the billable days month to the new value entered for billable days month
                    //    newDBConsultantProj.BillableDaysMonth = billableDaysMonthIN;
                    //}

                    //if (BillableDaysYTD == null)
                    //{
                    //    newDBConsultantProj.BillableDaysYTD = default(int);
                    //}
                    //else
                    //{
                    //    newDBConsultantProj.BillableDaysYTD = billableDaysYtdIN;
                    //}


                    DB.Consultant_Project.Add(newDBConsultantProj);
                    DB.SaveChanges();

                    this._ProjStartDate = newDBConsultantProj.ProjStartDate;
                    this._ProjEndDate = newDBConsultantProj.ProjEndDate;
                    this._BillableStatus = newDBConsultantProj.BillableStatus;

                    this._BillableDaysYTD = newDBConsultantProj.BillableDaysYTD;
                    this._ProjectId = newDBConsultantProj.ProjectId;
                    this._ConsultantId = newDBConsultantProj.ConsultantId;


                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
        }
        #endregion

        #region public methods

        /// <summary>
        /// This method enables the user to ***EDIT*** the consultant project table
        /// </summary>
        /// <param name="updateProjStartDate"></param>
        /// <param name="updateProjEndDate"></param>
        /// <param name="updateBillableStatus"></param>
        /// <param name="updateBillableDaysMonth"></param>
        /// <param name="updateBillableDaysYTD"></param>
        /// <returns></returns>
        public Boolean editConsultantProject(DateTime updateProjStartDate, DateTime updateProjEndDate, bool updateBillableStatus,
          int updateBillableDaysYTD)
        {
            Boolean editStatus = false;

            try
            {
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    DAL.Consultant_Project DBConsultantProj = (from b in DB.Consultant_Project where b.Id == _id select b).FirstOrDefault();

                    if (DBConsultantProj.Id != 0)
                    {
                        DBConsultantProj.ProjStartDate = updateProjStartDate;
                        DBConsultantProj.ProjEndDate = updateProjEndDate;
                        DBConsultantProj.BillableStatus = updateBillableStatus;
                        this._BillableDaysMonth = ConvertIntToTSDays(DBConsultantProj.BillableDaysMonth);

                        DBConsultantProj.BillableDaysYTD = updateBillableDaysYTD;


                        DB.SaveChanges();
                        editStatus = true;

                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            return editStatus;
        }

        public Boolean deleteConsultanProj()
        {
            Boolean deleteStatus = false;

            try
            {
                using (DAL.DashboardModelContainer DB = new DashboardModelContainer())
                {
                    if (this.Id != 0)
                    {
                        DAL.Consultant_Project DBConsultantProj = (from d in DB.Consultant_Project where d.Id == _id select d).FirstOrDefault();
                        if (DBConsultantProj.Id != 0)
                        {
                            DB.Consultant_Project.Remove(DBConsultantProj);
                            DB.SaveChanges();

                            deleteStatus = true;
                        }
                    }
                }
            }
            catch (Exception e)
            {
                Console.WriteLine("Error: " + e);
            }
            return deleteStatus;

        }
        #endregion
        #region calculation methods
        /// <summary>
        /// calculation
        /// </summary>
        public void calcBillDaysYTD()
        {
            int? BillDaysYTD = (BillDaysValue()/365)*100;
            Console.WriteLine(BillableDaysYTD);
        }
        #endregion


    }
}
