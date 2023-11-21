using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DoAnNet.DAO
{
    internal class RevenueDAO
    {
        static private RevenueDAO instance;

        public static RevenueDAO Instance
        {
            get { if (instance == null) instance = new RevenueDAO(); return instance; }
            private set => instance = value;
        }

        private RevenueDAO() { }

        public DataTable Revenue_chartdate(DateTime startdate, DateTime enddate)
        {
            return Connection.Instance.ExecuteOuery(string.Format("SELECT CAST(dateInvoice AS DATE) AS Invoice, SUM(pay) AS TotalRevenue " +
                                    "FROM SalesOrders " +
                                    "WHERE dateInvoice >= '{0}' AND dateInvoice <= '{1}' " +
                                    "GROUP BY CAST(dateInvoice AS DATE) " +
                                    "ORDER BY Invoice", startdate, enddate));
        }

        public DataTable Revenue_chartmonth(DateTime startdate, DateTime enddate)
        {
            return Connection.Instance.ExecuteOuery(string.Format("SELECT FORMAT(dateInvoice, 'MM/yyyy') AS Invoice, " +
                "SUM(pay) AS TotalRevenue " +
                "FROM SalesOrders " +
                "WHERE dateInvoice >= '{0}' AND dateInvoice <= '{1}' " +
                "GROUP BY FORMAT(dateInvoice, 'MM/yyyy') " +
                "ORDER BY Invoice", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd")));
        }
        public DataTable Revenue_chartyear(DateTime startdate, DateTime enddate)
        {
            return Connection.Instance.ExecuteOuery(string.Format("SELECT YEAR(dateInvoice) AS Year, " +
                "SUM(pay) AS TotalRevenue " +
                "FROM SalesOrders " +
                "WHERE dateInvoice >= '{0}' AND dateInvoice <= '{1}' " +
                "GROUP BY YEAR(dateInvoice) " +
                "ORDER BY Year", startdate, enddate));
        }

        public DataTable TotalProfit_day(DateTime startdate, DateTime enddate)
        {
            return Connection.Instance.ExecuteOuery(string.Format("SELECT CAST(dateInvoice AS DATE) AS Invoice, " +
                "SUM(sod.aMount*sod.sellingPrice - sod.aMount*p.costPrice) AS TotalRevenue " +
                "FROM SalesOrderDetails sod " +
                "INNER JOIN SalesOrders so ON sod.idInvoice = so.id " +
                "INNER JOIN Product p ON sod.idProduct = p.id " +
                "WHERE so.dateInvoice >= '{0}' AND so.dateInvoice <= '{1}' " +
                "GROUP BY CAST(dateInvoice AS DATE) " +
                "ORDER BY Invoice", startdate, enddate));
        }

        public DataTable TotalProfit_month(DateTime startdate, DateTime enddate)
        {
            string query = string.Format("SELECT " +
                "FORMAT(so.dateInvoice, 'MM/yyyy') AS Invoice, " +
                "SUM(sod.aMount * sod.sellingPrice - sod.aMount * p.costPrice) AS TotalRevenue " +
                "FROM SalesOrderDetails sod " +
                "INNER JOIN SalesOrders so ON sod.idInvoice = so.id " +
                "INNER JOIN Product p ON sod.idProduct = p.id " +
                "WHERE so.dateInvoice >= '{0}' AND so.dateInvoice <= '{1}' " +
                "GROUP BY FORMAT(so.dateInvoice, 'MM/yyyy') " +
                "ORDER BY Invoice", startdate.ToString("yyyy-MM-dd"), enddate.ToString("yyyy-MM-dd"));

            return Connection.Instance.ExecuteOuery(query);
        }

        public DataTable TotalProfit_year(DateTime startdate, DateTime enddate)
        {
            return Connection.Instance.ExecuteOuery(string.Format("SELECT YEAR(dateInvoice) AS Year, " +
                "SUM(sod.aMount*sod.sellingPrice - sod.aMount*p.costPrice) AS TotalRevenue " +
                "FROM SalesOrderDetails sod " +
                "INNER JOIN SalesOrders so ON sod.idInvoice = so.id " +
                "INNER JOIN Product p ON sod.idProduct = p.id " +
                "WHERE so.dateInvoice >= '{0}' AND so.dateInvoice <= '{1}' " +
                "GROUP BY YEAR(dateInvoice) " +
                "ORDER BY Year", startdate, enddate));
        }
    }
}
