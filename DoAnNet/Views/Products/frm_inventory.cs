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

namespace DoAnNet.Views.Products
{
    public partial class frm_inventory : Form
    {
        public frm_inventory()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        private void frm_inventory_Load(object sender, EventArgs e)
        {
            dgv_inventory.DataSource = InventoryDAO.Instance.getlistInventory();
            dgv_inventory.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_inventory.ReadOnly = true;
            dgv_inventory.Columns["idProduct"].HeaderText = "Sản phẩm";
            dgv_inventory.Columns["amount"].HeaderText = "Hàng còn";
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            string search = txt_search.Text;
            if (!string.IsNullOrEmpty(search))
            {
                dgv_inventory.DataSource = InventoryDAO.Instance.search(search);
            }
            else
            {
                dgv_inventory.DataSource = InventoryDAO.Instance.getlistInventory();
            }

        }
    }
}
