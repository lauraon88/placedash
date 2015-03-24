using System;
using System.Web;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using BLL.Models;
using System.Linq;

namespace BLL.Models
{
  public  class DashboardInitialiser : System.Data.Entity.DropCreateDatabaseIfModelChanges<DashboardInitialiser>
    {
      protected override void Seed(PlacementDashboardContext context)
      {
          
          var consultants = new List <Consultant>
          {
              new Consultant{FirstName="John",Surname="Smyth",Email="john.smyth@sqs.com", PhoneNumber="07712345678"}
          };
          consultants.ForEach(c => context.Consultants.Add(c));
          context.SaveChanges();

         var projects = new List <Project>
         {
             new Project(projectName="P")
         }
          
      }
    }
}
