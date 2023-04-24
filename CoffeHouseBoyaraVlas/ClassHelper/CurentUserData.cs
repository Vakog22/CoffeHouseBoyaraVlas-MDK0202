using CoffeHouseBoyaraVlas.DB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;

namespace CoffeHouseBoyaraVlas.ClassHelper
{
    internal class CurentUserData    {
      public static DB.Account account { get; set; }


        public static int SearchforId() {
            var isEmployee = EFHelper.Context.Employee.ToList().Where(i => i.IdAccount == account.IdAccount).FirstOrDefault().IdEmployee;
            if (isEmployee == null)
            {
                var isClient = EFHelper.Context.Client.ToList().Where(i => i.IdAccount == account.IdAccount).FirstOrDefault().IdClient;
                if (isClient == null)
                {
                    return 0;
                }
                else
                {
                    return Convert.ToInt32(isClient);
                }
            }
            else
            {
                return Convert.ToInt32(isEmployee);
            }
        }
    }
}
