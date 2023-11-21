namespace DoAnNet.Views.Invoices
{
    partial class saleInvoices
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
            this.txt_search = new System.Windows.Forms.TextBox();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.date_time = new System.Windows.Forms.Label();
            this.txt_idSalesOrders = new System.Windows.Forms.TextBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_pay = new System.Windows.Forms.Button();
            this.btn_add = new System.Windows.Forms.Button();
            this.dgv_SalesOrders = new System.Windows.Forms.DataGridView();
            this.btn_delete = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.number_amount = new System.Windows.Forms.NumericUpDown();
            this.cmb_product = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.dgv_SalesOrderDetails = new System.Windows.Forms.DataGridView();
            this.btn_insert = new System.Windows.Forms.Button();
            this.date_dateInvoice = new System.Windows.Forms.DateTimePicker();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label5 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesOrders)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.number_amount)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesOrderDetails)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_search.Location = new System.Drawing.Point(248, 26);
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(338, 33);
            this.txt_search.TabIndex = 176;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // date_time
            // 
            this.date_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.date_time.Location = new System.Drawing.Point(1232, 0);
            this.date_time.Name = "date_time";
            this.date_time.Size = new System.Drawing.Size(310, 23);
            this.date_time.TabIndex = 174;
            this.date_time.Text = "Time + date";
            // 
            // txt_idSalesOrders
            // 
            this.txt_idSalesOrders.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idSalesOrders.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_idSalesOrders.Location = new System.Drawing.Point(146, 606);
            this.txt_idSalesOrders.Name = "txt_idSalesOrders";
            this.txt_idSalesOrders.Size = new System.Drawing.Size(322, 33);
            this.txt_idSalesOrders.TabIndex = 170;
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_reset.Location = new System.Drawing.Point(482, 685);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(137, 33);
            this.btn_reset.TabIndex = 169;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_pay
            // 
            this.btn_pay.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_pay.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_pay.Location = new System.Drawing.Point(633, 685);
            this.btn_pay.Name = "btn_pay";
            this.btn_pay.Size = new System.Drawing.Size(137, 33);
            this.btn_pay.TabIndex = 168;
            this.btn_pay.Text = "Thanh toán";
            this.btn_pay.UseVisualStyleBackColor = true;
            this.btn_pay.Click += new System.EventHandler(this.btn_pay_Click);
            // 
            // btn_add
            // 
            this.btn_add.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_add.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_add.Location = new System.Drawing.Point(482, 642);
            this.btn_add.Name = "btn_add";
            this.btn_add.Size = new System.Drawing.Size(137, 33);
            this.btn_add.TabIndex = 166;
            this.btn_add.Text = "Thêm";
            this.btn_add.UseVisualStyleBackColor = true;
            this.btn_add.Click += new System.EventHandler(this.btn_add_Click);
            // 
            // dgv_SalesOrders
            // 
            this.dgv_SalesOrders.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_SalesOrders.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SalesOrders.Location = new System.Drawing.Point(16, 69);
            this.dgv_SalesOrders.Name = "dgv_SalesOrders";
            this.dgv_SalesOrders.RowHeadersWidth = 51;
            this.dgv_SalesOrders.RowTemplate.Height = 24;
            this.dgv_SalesOrders.Size = new System.Drawing.Size(684, 560);
            this.dgv_SalesOrders.TabIndex = 142;
            this.dgv_SalesOrders.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SalesOrders_CellClick);
            this.dgv_SalesOrders.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_SalesOrders_CellFormatting);
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_delete.Location = new System.Drawing.Point(525, 647);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(175, 33);
            this.btn_delete.TabIndex = 167;
            this.btn_delete.Text = "Xóa hóa đơn";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(32, 695);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 26);
            this.label1.TabIndex = 165;
            this.label1.Text = "Số Lượng:";
            // 
            // number_amount
            // 
            this.number_amount.Location = new System.Drawing.Point(146, 689);
            this.number_amount.Name = "number_amount";
            this.number_amount.Size = new System.Drawing.Size(322, 30);
            this.number_amount.TabIndex = 164;
            // 
            // cmb_product
            // 
            this.cmb_product.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_product.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_product.FormattingEnabled = true;
            this.cmb_product.Location = new System.Drawing.Point(146, 649);
            this.cmb_product.Name = "cmb_product";
            this.cmb_product.Size = new System.Drawing.Size(322, 33);
            this.cmb_product.TabIndex = 163;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(32, 656);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(108, 26);
            this.label3.TabIndex = 162;
            this.label3.Text = "Sản Phẩm:";
            // 
            // dgv_SalesOrderDetails
            // 
            this.dgv_SalesOrderDetails.BackgroundColor = System.Drawing.Color.WhiteSmoke;
            this.dgv_SalesOrderDetails.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_SalesOrderDetails.Location = new System.Drawing.Point(16, 33);
            this.dgv_SalesOrderDetails.Name = "dgv_SalesOrderDetails";
            this.dgv_SalesOrderDetails.RowHeadersWidth = 51;
            this.dgv_SalesOrderDetails.RowTemplate.Height = 24;
            this.dgv_SalesOrderDetails.Size = new System.Drawing.Size(754, 565);
            this.dgv_SalesOrderDetails.TabIndex = 142;
            this.dgv_SalesOrderDetails.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_SalesOrderDetails_CellClick);
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_insert.Location = new System.Drawing.Point(555, 21);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(145, 33);
            this.btn_insert.TabIndex = 167;
            this.btn_insert.Text = "Thêm hóa đơn";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // date_dateInvoice
            // 
            this.date_dateInvoice.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_dateInvoice.Location = new System.Drawing.Point(162, 27);
            this.date_dateInvoice.Name = "date_dateInvoice";
            this.date_dateInvoice.Size = new System.Drawing.Size(380, 27);
            this.date_dateInvoice.TabIndex = 157;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.txt_idSalesOrders);
            this.groupBox2.Controls.Add(this.btn_reset);
            this.groupBox2.Controls.Add(this.btn_pay);
            this.groupBox2.Controls.Add(this.btn_add);
            this.groupBox2.Controls.Add(this.label1);
            this.groupBox2.Controls.Add(this.number_amount);
            this.groupBox2.Controls.Add(this.cmb_product);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.dgv_SalesOrderDetails);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox2.Location = new System.Drawing.Point(737, 26);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(784, 733);
            this.groupBox2.TabIndex = 173;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết hóa đơn";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btn_insert);
            this.groupBox1.Controls.Add(this.date_dateInvoice);
            this.groupBox1.Controls.Add(this.dgv_SalesOrders);
            this.groupBox1.Controls.Add(this.btn_delete);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox1.Location = new System.Drawing.Point(15, 68);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(716, 691);
            this.groupBox1.TabIndex = 172;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Hóa đơn bán";
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label5.Location = new System.Drawing.Point(127, 29);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(115, 26);
            this.label5.TabIndex = 177;
            this.label5.Text = "Tìm kiếm:";
            // 
            // saleInvoices
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.label5);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.date_time);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "saleInvoices";
            this.Size = new System.Drawing.Size(1542, 775);
            this.Load += new System.EventHandler(this.saleInvoices_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesOrders)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.number_amount)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_SalesOrderDetails)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox1.ResumeLayout(false);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label date_time;
        private System.Windows.Forms.TextBox txt_idSalesOrders;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_pay;
        private System.Windows.Forms.Button btn_add;
        private System.Windows.Forms.DataGridView dgv_SalesOrders;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown number_amount;
        private System.Windows.Forms.ComboBox cmb_product;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView dgv_SalesOrderDetails;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.DateTimePicker date_dateInvoice;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label5;
    }
}
