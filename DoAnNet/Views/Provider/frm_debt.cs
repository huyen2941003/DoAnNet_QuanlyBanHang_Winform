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

namespace DoAnNet.Views.Provider
{
    public partial class frm_debt : Form
    {
        public frm_debt()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            LoadCmbProvider();
        }
        void LoadCmbProvider()
        {
            List<DTO.Provider> provider = ProviderDAO.Instance.getlistProvider();
            cmb_provider.DataSource = provider;
            cmb_provider.DisplayMember = "nameProvider";
        }

        private void frm_debt_Load(object sender, EventArgs e)
        {
            dgv_debt.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
            dgv_debt.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_debt.ReadOnly = true;
            dgv_debt.Columns["id"].HeaderText = "Mã hóa đơn";
            dgv_debt.Columns["dateInvoice"].HeaderText = "Ngày nhập";
            dgv_debt.Columns["idProvider"].HeaderText = "Nhà cung cấp";
            dgv_debt.Columns["pay"].HeaderText = "Nợ";
            dgv_debt.Columns["orderStatus"].HeaderText = "Trạng thái hóa đơn";
        }

        private void btn_search_Click(object sender, EventArgs e)
        {
            if (cmb_search.SelectedItem == null)
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                string search = cmb_search.SelectedItem.ToString();
                string idProvider = ((DTO.Provider)cmb_provider.SelectedItem).NameProvider;
                if (search == "Đã thanh toán hết")
                {
                    dgv_debt.DataSource = InputInvoicesDAO.Instance.Search_Debt0(idProvider);
                }
                else if (search == "Chưa thanh toán hết")
                {
                    dgv_debt.DataSource = InputInvoicesDAO.Instance.Search_Debt1(idProvider);
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            dgv_debt.DataSource = InputInvoicesDAO.Instance.getlistInputInvoices();
        }

        private void dgv_debt_CellFormatting(object sender, DataGridViewCellFormattingEventArgs e)
        {
            if (e.ColumnIndex == dgv_debt.Columns["orderStatus"].Index && e.Value != null)
            {
                if (int.TryParse(e.Value.ToString(), out int orderStatus))
                {
                    string statusText = GetOrderStatusText(orderStatus);
                    e.Value = statusText;
                    e.FormattingApplied = true;
                }
            }
        }
        private string GetOrderStatusText(int orderStatus)
        {
            switch (orderStatus)
            {
                case 0:
                    return "Đã thanh toán";
                case 1:
                    return "Chưa thanh toán hết";
                default:
                    return "Chưa xuất đơn";
            }
        }
    }
}
