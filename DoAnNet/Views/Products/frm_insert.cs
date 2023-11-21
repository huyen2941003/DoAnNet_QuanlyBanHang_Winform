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
    public partial class frm_insert : Form
    {
        public frm_insert()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
            loadCmbDistribute();
            loadCmbProvider();
        }
        void loadCmbDistribute()
        {
            List<DTO.Distribute> distribute = CategoryDAO.Instance.getlistDistribute();
            cmb_distribute.DataSource = distribute;
            cmb_distribute.DisplayMember = "nameDistribute";
        }
        void loadCmbProvider()
        {
            List<DTO.Provider> provider = ProviderDAO.Instance.getlistProvider();
            cmb_provider.DataSource = provider;
            cmb_provider.DisplayMember = "nameProvider";
        }
        public void Clear()
        {
            txt_idproduct.Text = "";
            txt_nameproduct.Text = "";
            cmb_distribute.SelectedIndex = 0;
            cmb_provider.SelectedIndex = 0;
            txt_cost.Text = "";
            txt_sale.Text = "";
        }
        bool InsertProduct(string iD, string nameProduct, string idDistribute, string idProvider, float costPrice, float rate)
        {
            return ProductDAO.Instance.InsertProduct(iD, nameProduct, idDistribute, idProvider, costPrice, rate);
        }
        private void btn_insertproduct_Click(object sender, EventArgs e)
        {
            string iD = txt_idproduct.Text;
            string name = txt_nameproduct.Text;
            string distribute = ((DTO.Distribute)cmb_distribute.SelectedItem).NameDistribute;
            string provider = ((DTO.Provider)cmb_provider.SelectedItem).NameProvider;
            if (!float.TryParse(txt_cost.Text, out float cost) || !float.TryParse(txt_sale.Text, out float rate) || string.IsNullOrEmpty(iD) || string.IsNullOrEmpty(name))
            {
                MessageBox.Show("Vui lòng nhập giá trị hợp lệ và đầy đủ các giá trị.");
                return;
            }
            if (ProductDAO.Instance.SetInsert(iD).Count > 0)
            {
                MessageBox.Show("Mã hàng này đã tồn tại! Vui lòng kiểm tra lại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
                txt_idproduct.Text = "";
            }
            else
            {
                if (InsertProduct(iD, name, distribute, provider, cost, rate))
                {
                    MessageBox.Show("Thêm thành công!");
                    Clear();
                }
                else
                {
                    MessageBox.Show("Thêm thất bại, vui lòng kiểm tra lại dữ liệu!");
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
