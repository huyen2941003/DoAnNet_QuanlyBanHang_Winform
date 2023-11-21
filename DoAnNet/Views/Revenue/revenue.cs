using DoAnNet.DAO;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace DoAnNet.Views.Revenue
{
    public partial class revenue : UserControl
    {
        public revenue()
        {
            InitializeComponent();
            timer1.Start();
            InitializeChart();
            chart_revenue.Titles.Add("Biểu đồ doanh thu và lợi nhuận");
        }

        private void btn_revenue_Click(object sender, EventArgs e)
        {
            if (cmb_search.SelectedItem == null)
            {
                MessageBox.Show("Bạn vui lòng điền đầy đủ thông tin tìm kiếm!");
            }
            else
            {
                if (cmb_search.SelectedItem.ToString() == "Thống kê theo ngày")
                {
                    UpdateChart_date();
                }
                else if (cmb_search.SelectedItem.ToString() == "Thống kê theo tháng")
                {
                    UpdateChart_month();
                }
                else if (cmb_search.SelectedItem.ToString() == "Thống kê theo năm")
                {
                    UpdateChart_year();
                }
            }
        }

        private void btn_delete_Click(object sender, EventArgs e)
        {
            chart_revenue.Series["Doanh thu"].Points.Clear();
            chart_revenue.Series["Lợi nhuận"].Points.Clear();
        }
        private void InitializeChart()
        {
            chart_revenue.Series.Clear();
            chart_revenue.Series.Add("Doanh thu");
            chart_revenue.Series.Add("Lợi nhuận");
        }

        private void UpdateChart_date()
        {
            chart_revenue.Titles.Clear();
            chart_revenue.Titles.Add("Biểu đồ doanh thu và lợi nhuận theo ngày");
            DateTime startDate = date_start.Value;
            DateTime endDate = date_end.Value;
            chart_revenue.Series.Clear();
            Series revenueSeries = new Series("Doanh thu");
            revenueSeries.ChartType = SeriesChartType.Column;
            DataTable revenueDataTable = RevenueDAO.Instance.Revenue_chartdate(startDate, endDate);
            List<RevenueData> revenueList = GetRevenueData(revenueDataTable);
            revenueSeries.XValueType = ChartValueType.Date;
            revenueSeries.Color = Color.Blue;
            foreach (var dataPoint in revenueList)
            {
                revenueSeries.Points.AddXY(dataPoint.Invoice, dataPoint.TotalRevenue);
            }

            Series profitSeries = new Series("Lợi nhuận");
            profitSeries.ChartType = SeriesChartType.Column;
            DataTable profitDataTable = RevenueDAO.Instance.TotalProfit_day(startDate, endDate);
            List<ProfitData> profitList = GetProfitData(profitDataTable);
            profitSeries.XValueType = ChartValueType.Date;
            profitSeries.Color = Color.Red;
            foreach (var dataPoint in profitList)
            {
                profitSeries.Points.AddXY(dataPoint.Invoice, dataPoint.TotalProfit);
            }
            chart_revenue.Series.Add(revenueSeries);
            chart_revenue.Series.Add(profitSeries);

        }
        private void UpdateChart_month()
        {
            chart_revenue.Titles.Clear();
            chart_revenue.Titles.Add("Biểu đồ doanh thu và lợi nhuận theo tháng");

            DateTime startDate = date_start.Value;
            DateTime endDate = date_end.Value;

            chart_revenue.Series.Clear();

            Series revenueSeries = new Series("Doanh thu");
            revenueSeries.ChartType = SeriesChartType.Column;
            revenueSeries.Color = Color.Blue;

            Series profitSeries = new Series("Lợi nhuận");
            profitSeries.ChartType = SeriesChartType.Column;
            profitSeries.Color = Color.Red;

            DataTable revenueDataTable = RevenueDAO.Instance.Revenue_chartmonth(startDate, endDate);
            DataTable profitDataTable = RevenueDAO.Instance.TotalProfit_month(startDate, endDate);

            List<RevenueData> revenueList = GetRevenueData(revenueDataTable);
            List<ProfitData> profitList = GetProfitData(profitDataTable);

            chart_revenue.Series.Add(revenueSeries);
            chart_revenue.Series.Add(profitSeries);

            chart_revenue.Series["Doanh thu"].XValueType = ChartValueType.String;
            chart_revenue.Series["Lợi nhuận"].XValueType = ChartValueType.String;

            foreach (var dataPoint in revenueList)
            {
                string monthYear = dataPoint.Invoice.ToString("MM/yyyy");
                chart_revenue.Series["Doanh thu"].Points.AddXY(monthYear, dataPoint.TotalRevenue);
            }

            foreach (var dataPoint in profitList)
            {
                string monthYear = dataPoint.Invoice.ToString("MM/yyyy");
                chart_revenue.Series["Lợi nhuận"].Points.AddXY(monthYear, dataPoint.TotalProfit);
            }
        }

        private void UpdateChart_year()
        {
            chart_revenue.Titles.Clear();
            chart_revenue.Titles.Add("Biểu đồ lợi nhuận và doanh thu theo năm");
            DateTime startDate = date_start.Value;
            DateTime endDate = date_end.Value;

            chart_revenue.Series.Clear();

            Series revenueSeries = new Series("Doanh thu");
            revenueSeries.ChartType = SeriesChartType.Column;
            revenueSeries.Color = Color.Blue;

            Series profitSeries = new Series("Lợi nhuận");
            profitSeries.ChartType = SeriesChartType.Column;
            profitSeries.Color = Color.Red;

            DataTable revenueDataTable = RevenueDAO.Instance.Revenue_chartyear(startDate, endDate);
            DataTable profitDataTable = RevenueDAO.Instance.TotalProfit_year(startDate, endDate);

            if (revenueDataTable != null && profitDataTable != null)
            {
                foreach (DataRow row in revenueDataTable.Rows)
                {
                    if (row["Year"] != DBNull.Value && row["TotalRevenue"] != DBNull.Value)
                    {
                        string year = row["Year"].ToString();
                        float totalRevenue = Convert.ToSingle(row["TotalRevenue"]);
                        revenueSeries.Points.AddXY(year, totalRevenue);
                    }
                }
                foreach (DataRow row in profitDataTable.Rows)
                {
                    if (row["Year"] != DBNull.Value && row["TotalRevenue"] != DBNull.Value)
                    {
                        string year = row["Year"].ToString();
                        float totalProfit = Convert.ToSingle(row["TotalRevenue"]);
                        profitSeries.Points.AddXY(year, totalProfit);
                    }
                }

                chart_revenue.Series.Add(revenueSeries);
                chart_revenue.Series.Add(profitSeries);
            }
            else
            {
                MessageBox.Show("Dữ liệu không hợp lệ. Vui lòng kiểm tra cấu trúc của DataTable.");
            }
        }

        private class RevenueData
        {
            public DateTime Invoice { get; set; }
            public float TotalRevenue { get; set; }
        }
        private List<RevenueData> GetRevenueData(DataTable dataTable)
        {
            List<RevenueData> revenueList = new List<RevenueData>();

            foreach (DataRow row in dataTable.Rows)
            {
                if (row["Invoice"] != DBNull.Value && row["TotalRevenue"] != DBNull.Value)
                {
                    DateTime invoice = Convert.ToDateTime(row["Invoice"]);
                    float totalRevenue = Convert.ToSingle(row["TotalRevenue"]);

                    revenueList.Add(new RevenueData
                    {
                        Invoice = invoice,
                        TotalRevenue = totalRevenue
                    });
                }
            }
            return revenueList;
        }
        private class ProfitData
        {
            public DateTime Invoice { get; set; }
            public float TotalProfit { get; set; }
        }

        private List<ProfitData> GetProfitData(DataTable dataTable)
        {
            List<ProfitData> profitList = new List<ProfitData>();

            foreach (DataRow row in dataTable.Rows)
            {
                DateTime invoice;

                if (row["Invoice"] != DBNull.Value && DateTime.TryParse(row["Invoice"].ToString(), out invoice))
                {
                    float totalProfit = Convert.ToSingle(row["TotalRevenue"]);

                    profitList.Add(new ProfitData
                    {
                        Invoice = invoice,
                        TotalProfit = totalProfit
                    });
                }
            }
            return profitList;
        }
        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void date_start_ValueChanged(object sender, EventArgs e)
        {
            DateTime startSalary = date_start.Value;
            date_end.Value = startSalary;
            MessageBox.Show("Đã chọn Ngày bắt đầu. Ngày kết thúc đã được đặt = Ngày bắt đầu. Vui lòng chọn tiếp ngày kết thúc!", "Thông báo",
                MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void date_end_ValueChanged(object sender, EventArgs e)
        {
            DateTime startSalary = date_start.Value;
            DateTime endSalary = date_end.Value;

            if (endSalary < startSalary)
            {
                date_end.Value = startSalary;
                MessageBox.Show("Ngày kết thúc không được bé hơn ngày bắt đầu. Hệ thống đã tự động đặt Ngày kết thúc = Ngày bắt đầu. Vui lòng chọn lại!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
