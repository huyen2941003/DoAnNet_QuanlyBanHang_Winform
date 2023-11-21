namespace DoAnNet.Views.Invoices
{
    partial class inputInvoices
    {
        /// <summary> 
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary> 
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Component Designer generated code

        /// <summary> 
        /// Required method for Designer support - do not modify 
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.components = new System.ComponentModel.Container();
            this.cmb_provider = new System.Windows.Forms.ComboBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.btn_insert = new System.Windows.Forms.Button();
            this.date_dateInvoice = new System.Windows.Forms.DateTimePicker();
            this.dgv_InputInvoices = new System.Windows.Forms.DataGridView();
            this.btn_delete = new System.Windows.Forms.Button();
            this.btn_deletedetail = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.txt_costPrice = new System.Windows.Forms.TextBox();
            this.btn_out = new System.Windows.Forms.Button();
            this.txt_idInputInvoices = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_pay = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.number_amount = new System.Windows.Forms.NumericUpDown();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.cmb_product = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_InputInvoicesDetails = new System.Windows.Forms.DataGridView();
            this.date_time = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InputInvoices)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.number_amount)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InputInvoicesDetails)).BeginInit();
            this.SuspendLayout();
            // 
            // cmb_provider
            // 
            this.cmb_provider.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_provider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_provider.FormattingEnabled = true;
            this.cmb_provider.Location = new System.Drawing.Point(110, 66);
            this.cmb_provider.Name = "cmb_provider";
            this.cmb_provider.Size = new System.Drawing.Size(394, 33);
            this.cmb_provider.TabIndex = 168;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.cmb_provider);
            this.groupBox1.Controls.Add(this.btn_insert);
            this.groupBox1.Controls.Add(this.date_dateInvoice);
            this.groupBox1.Controls.Add(this.dgv_InputInvoices);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(682, 691);
            this.groupBox1.TabIndex = 177;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn nhập hàng";
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(35, 72);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(69, 26);
            this.label2.TabIndex = 169;
            this.label2.Text = "NCC:";
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_insert.Location = new System.Drawing.Point(518, 59);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(145, 39);
            this.btn_insert.TabIndex = 167;
            this.btn_insert.Text = "Thêm hóa đơn";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // date_dateInvoice
            // 
            this.date_dateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_dateInvoice.Location = new System.Drawing.Point(110, 33);
            this.date_dateInvoice.Name = "date_dateInvoice";
            this.date_dateInvoice.Size = new System.Drawing.Size(394, 27);
            this.date_dateInvoice.TabIndex = 157;
            // 
            // dgv_InputInvoices
            // 
            this.dgv_InputInvoices.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_InputInvoices.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InputInvoices.Location = new System.Drawing.Point(16, 111);
            this.dgv_InputInvoices.Name = "dgv_InputInvoices";
            this.dgv_InputInvoices.RowHeadersWidth = 51;
            this.dgv_InputInvoices.RowTemplate.Height = 24;
            this.dgv_InputInvoices.Size = new System.Drawing.Size(647, 518);
            this.dgv_InputInvoices.TabIndex = 142;
            this.dgv_InputInvoices.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_InputInvoices_CellClick);
            this.dgv_InputInvoices.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_InputInvoices_CellFormatting);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_delete.Location = new System.Drawing.Point(488, 637);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(175, 39);
            this.btn_delete.TabIndex = 167;
            this.btn_delete.Text = "Xóa hóa đơn";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // btn_deletedetail
            // 
            this.btn_deletedetail.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deletedetail.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_deletedetail.Location = new System.Drawing.Point(486, 631);
            this.btn_deletedetail.Name = "btn_deletedetail";
            this.btn_deletedetail.Size = new System.Drawing.Size(145, 39);
            this.btn_deletedetail.TabIndex = 175;
            this.btn_deletedetail.Text = "Xóa";
            this.btn_deletedetail.UseVisualStyleBackColor = true;
            this.btn_deletedetail.Click += new System.EventHandler(this.btn_deletedetail_Click);
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label4.Location = new System.Drawing.Point(33, 650);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(108, 26);
            this.label4.TabIndex = 173;
            this.label4.Text = "Giá nhập:";
            // 
            // txt_costPrice
            // 
            this.txt_costPrice.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_costPrice.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_costPrice.Location = new System.Drawing.Point(147, 647);
            this.txt_costPrice.Name = "txt_costPrice";
            this.txt_costPrice.Size = new System.Drawing.Size(322, 33);
            this.txt_costPrice.TabIndex = 172;
            // 
            // btn_out
            // 
            this.btn_out.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_out.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_out.Location = new System.Drawing.Point(656, 632);
            this.btn_out.Name = "btn_out";
            this.btn_out.Size = new System.Drawing.Size(113, 39);
            this.btn_out.TabIndex = 171;
            this.btn_out.Text = "Xuất đơn";
            this.btn_out.UseVisualStyleBackColor = true;
            this.btn_out.Click += new System.EventHandler(this.btn_out_Click);
            // 
            // txt_idInputInvoices
            // 
            this.txt_idInputInvoices.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idInputInvoices.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_idInputInvoices.Location = new System.Drawing.Point(147, 567);
            this.txt_idInputInvoices.Name = "txt_idInputInvoices";
            this.txt_idInputInvoices.Size = new System.Drawing.Size(322, 33);
            this.txt_idInputInvoices.TabIndex = 170;
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_reset.Location = new System.Drawing.Point(486, 677);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(145, 39);
            this.btn_reset.TabIndex = 169;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_pay
            // 
            this.btn_pay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_pay.Location = new System.Drawing.Point(656, 677);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(145, 39);
            this.btn_pay.TabIndex = 168;
            this.btn_pay.Text = "Thanh toán";
            this.btn_pay.UseVisualStyleBackColor = true;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_add.Location = new System.Drawing.Point(486, 586);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(145, 39);
            this.btn_add.TabIndex = 166;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(33, 690);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 26);
            this.label1.TabIndex = 165;
            this.label1.Text = "Số Lượng:";
            // 
            // number_amount
            // 
            this.number_amount.Location = new System.Drawing.Point(147, 686);
            this.number_amount.Name = "number_amount";
            this.number_amount.Size = new System.Drawing.Size(322, 30);
            this.number_amount.TabIndex = 164;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_deletedetail);
            this.groupBox2.Controls.Add(this.label4);
            this.groupBox2.Controls.Add(this.txt_costPrice);
            this.groupBox2.Controls.Add(this.btn_out);
            this.groupBox2.Controls.Add(this.txt_idInputInvoices);
            this.groupBox2.Controls.Add(this.btn_reset);
            this.groupBox2.Controls.Add(this.btn_pay);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.number_amount);
            this.groupBox2.Controls.Add(this.cmb_product);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dgv_InputInvoicesDetails);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox2.Location = new System.Drawing.Point(703, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(818, 733);
            this.groupBox2.TabIndex = 178;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết hóa đơn";
            // 
            // cmb_product
            // 
            this.cmb_product.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_product.FormattingEnabled = true;
            this.cmb_product.Location = new System.Drawing.Point(147, 606);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Size = new System.Drawing.Size(322, 33);
            this.cmb_product.TabIndex = 163;
            this.cmb_product.SelectedIndexChanged += new System.EventHandler(this.cmb_product_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(33, 613);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 26);
            this.label3.TabIndex = 162;
            this.label3.Text = "Sản Phẩm:";
            // 
            // dgv_InputInvoicesDetails
            // 
            this.dgv_InputInvoicesDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_InputInvoicesDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_InputInvoicesDetails.Location = new System.Drawing.Point(16, 33);
            this.dgv_InputInvoicesDetails.Name = "dgv_InputInvoicesDetails";
            this.dgv_InputInvoicesDetails.RowHeadersWidth = 51;
            this.dgv_InputInvoicesDetails.RowTemplate.Height = 24;
            this.dgv_InputInvoicesDetails.Size = new System.Drawing.Size(785, 498);
            this.dgv_InputInvoicesDetails.TabIndex = 142;
            this.dgv_InputInvoicesDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_InputInvoicesDetails_CellClick);
            // 
            // date_time
            // 
            this.date_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.date_time.Location = new System.Drawing.Point(1232, 0);
            this.date_time.Name = "date_time";
            this.date_time.Size = new System.Drawing.Size(310, 23);
            this.date_time.TabIndex = 179;
            this.date_time.Text = "Time + date";
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_search.Location = new System.Drawing.Point(213, 20);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(383, 33);
            this.txt_search.TabIndex = 181;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label5.Location = new System.Drawing.Point(92, 23);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 26);
            this.label5.TabIndex = 170;
            this.label5.Text = "Tìm kiếm:";
            // 
            // inputInvoices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.date_time);
            this.Controls.Add(this.txt_search);
            this.Name = "inputInvoices";
            this.Size = new System.Drawing.Size(1542, 775);
            this.Load += new System.EventHandler(this.inputInvoices_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InputInvoices)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.number_amount)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_InputInvoicesDetails)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox cmb_provider;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.DateTimePicker date_dateInvoice;
        private System.Windows.Forms.DataGridView dgv_InputInvoices;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Button btn_deletedetail;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox txt_costPrice;
        private System.Windows.Forms.Button btn_out;
        private System.Windows.Forms.TextBox txt_idInputInvoices;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown number_amount;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ComboBox cmb_product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_InputInvoicesDetails;
        private System.Windows.Forms.Label date_time;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label5;
    }
}
