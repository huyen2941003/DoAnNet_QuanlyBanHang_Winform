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
    public partial class provider : UserControl
    {
        public provider()
        {
            InitializeComponent();
            timer1.Start();
            txt_idprovider.Enabled = false;
        }
        public void Clear()
        {
            txt_idprovider.Text = "";
            txt_nameprovider.Text = "";
            txt_address.Text = "";
            txt_phone.Text = "";
            txt_mail.Text = "";

            btn_delete.Enabled = false;
            btn_update.Enabled = false;
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            date_time.Text = DateTime.Now.ToLongTimeString() + "  -  " + DateTime.Now.ToLongDateString();
        }

        private void provider_Load(object sender, EventArgs e)
        {
            btn_delete.Enabled = false;
            btn_update.Enabled = false;

            dgv_provider.DataSource = ProviderDAO.Instance.getlistProvider();
            dgv_provider.AutoSizeColumnsMode = DataGridViewAutoSizeColumnsMode.Fill;
            dgv_provider.ReadOnly = true;
            dgv_provider.Columns["iD"].HeaderText = "Mã nhà cung cấp";
            dgv_provider.Columns["nameProvider"].HeaderText = "Tên nhà cung cấp";
            dgv_provider.Columns["address"].HeaderText = "Địa chỉ";
            dgv_provider.Columns["telephone"].HeaderText = "Số điện thoại";
            dgv_provider.Columns["email"].HeaderText = "Email";
        }
        bool DeleteProvider(string id)
        {
            return ProviderDAO.Instance.DeleteProvider(id);
        }
        private void btn_delete_Click(object sender, EventArgs e)
        {
            string id = txt_idprovider.Text;
            string name = txt_nameprovider.Text;
            if (ProviderDAO.Instance.SetDeleteProduct(id).Count > 0)
            {
                MessageBox.Show("Không được xóa nhà cung cấp này!", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else
            {
                if (DeleteProvider(id))
                {
                    MessageBox.Show("Xóa thành công!");
                    Clear();
                    dgv_provider.DataSource = ProviderDAO.Instance.getlistProvider();
                }
                else
                {
                    MessageBox.Show("Xóa thất bại!");
                }
            }
        }

        private void btn_insert_Click(object sender, EventArgs e)
        {
            Views.Provider.frm_insert frm = new Views.Provider.frm_insert();
            frm.ShowDialog();
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
            dgv_provider.DataSource = ProviderDAO.Instance.getlistProvider();
        }
        bool UpdateProvider(string id, string nameProvider, string address, string telephone, string email)
        {
            return ProviderDAO.Instance.UpdateProvider(id, nameProvider, address, telephone, email);
        }
        private void btn_update_Click(object sender, EventArgs e)
        {
            string id = txt_idprovider.Text;
            string nameProvider = txt_nameprovider.Text;
            string address = txt_address.Text;
            string telephone = txt_phone.Text;
            string email = txt_mail.Text;

            if (ProviderDAO.Instance.SetInsertName(nameProvider).Count > 0)
            {
                MessageBox.Show("Tên nhà cung cấp này đã tồn tại! Vui lòng kiểm tra lại", "Thông báo",
                    MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
            else
            {
                if (UpdateProvider(id, nameProvider, address, telephone, email))
                {
                    MessageBox.Show("Sửa thông tin thành công!");
                    Clear();
                    dgv_provider.DataSource = ProviderDAO.Instance.getlistProvider();
                }
                else
                {
                    MessageBox.Show("Sửa thất bại! Vui lòng kiểm tra lại dữ liệu");
                }
            }
        }

        private void dgv_provider_CellClick(object sender, DataGridViewCellEventArgs e)
        {
            string id = txt_idprovider.Text;
            int r = e.RowIndex;
            if (r >= 0)
            {
                btn_delete.Enabled = true;
                btn_update.Enabled = true;
                txt_idprovider.Enabled = false;

                txt_idprovider.Text = dgv_provider.Rows[r].Cells["ID"].Value.ToString();
                txt_nameprovider.Text = dgv_provider.Rows[r].Cells["NameProvider"].Value.ToString();
                txt_address.Text = dgv_provider.Rows[r].Cells["Address"].Value.ToString();
                txt_phone.Text = dgv_provider.Rows[r].Cells["Telephone"].Value.ToString();
                txt_mail.Text = dgv_provider.Rows[r].Cells["Email"].Value.ToString();
            }
        }

        private void txt_search_TextChanged(object sender, EventArgs e)
        {
            if (cmb_search.SelectedItem == null || string.IsNullOrEmpty(cmb_search.SelectedItem.ToString()))
            {
                MessageBox.Show("Vui lòng nhập thông tin cần tìm kiếm!");
            }
            else
            {
                string searchdtb = txt_search.Text.Trim();
                if (cmb_search.SelectedItem.ToString() == "Tên sản phẩm")
                {
                    dgv_provider.DataSource = ProviderDAO.Instance.SearchProvider_nameProduct(searchdtb);
                }
                else if (cmb_search.SelectedItem.ToString() == "Tên nhà cung cấp")
                {
                    dgv_provider.DataSource = ProviderDAO.Instance.SearchProvider_nameProvider(searchdtb);
                }
                else if (ProviderDAO.Instance.SearchProvider_nameProduct(searchdtb).Count == 0 && ProviderDAO.Instance.SearchProvider_nameProvider(searchdtb).Count == 0)
                {
                    MessageBox.Show("Không tìm thấy!");
                }
            }
        }
    }
}
