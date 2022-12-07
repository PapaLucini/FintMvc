using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Fint.Web.Constants
{
    public static class Labels
    {
        public struct Index
        {
            public struct TableHeaders
            {
                public static string GasTableHeader => "Gas";
                public static string CarMaintenainceTableHeader => "Car Maintenaince";
                public static string DailyLivingTableHeader => "Daily Living";
                public static string OtherTableHeader => "Other";
                public static string FixedMonthlyExpensesHeader => "Fixed Monthly Expenses";
            }
            public struct ColumnHeaders
            {
                public static string Number => "#";
                public static string Name => "Name";
                public static string Ammount => "Ammount";
                public static string DayDue => "Day Due";
            }

        }
    }
}