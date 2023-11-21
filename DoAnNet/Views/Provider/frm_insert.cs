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
    public partial class frm_insert : Form
    {
        public frm_insert()
        {
            InitializeComponent();
            this.StartPosition = FormStartPosition.CenterScreen;
        }
        public void Clear()
        {
            txt_idprovider.Text = "";
            txt_nameprovider.Text = "";
            txt_address.Text = "";
            txt_phone.Text = "";
            txt_mail.Text = "";
        }
        bool InsertProvider(string id, string nameProvider, string address, string telephone, string email)
        {
            return ProviderDAO.Instance.InsertProvider(id, nameProvider, address, telephone, email);
        }
        private void btn_insert_Click(object sender, EventArgs e)
        {
            string id = txt_idprovider.Text;
            string nameProvider = txt_nameprovider.Text;
            string address = txt_address.Text;
            string telephone = txt_phone.Text;
            string email = txt_mail.Text;

            if (string.IsNullOrEmpty(id) || string.IsNullOrEmpty(nameProvider) || string.IsNullOrEmpty(address) || string.IsNullOrEmpty(telephone) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Vui lòng điền đầy đủ thông tin");
            }
            else
            {
                if (ProviderDAO.Instance.SetInsertId(id).Count > 0)
                {
                    MessageBox.Show("Mã nhà cung cấp đã tồn tại! Vui lòng nhập mã khác", "Thông báo",
                        MessageBoxButtons.OK, MessageBoxIcon.Error);
                    txt_idprovider.Text = "";
                }
                else
                {
                    if (ProviderDAO.Instance.SetInsertName(nameProvider).Count > 0)
                    {
                        MessageBox.Show("Tên nhà cung cấp này đã tồn tại! Vui lòng kiểm tra lại", "Thông báo",
                            MessageBoxButtons.OK, MessageBoxIcon.Error);
                        txt_nameprovider.Text = "";
                    }
                    else
                    {
                        if (InsertProvider(id, nameProvider, address, telephone, email))
                        {
                            MessageBox.Show("Thêm thông tin thành công!");
                            Clear();
                        }
                        else
                        {
                            MessageBox.Show("Thêm thất bại! Vui lòng kiểm tra lại dữ liệu");
                        }
                    }
                }
            }
        }

        private void btn_reset_Click(object sender, EventArgs e)
        {
            Clear();
        }
    }
}
