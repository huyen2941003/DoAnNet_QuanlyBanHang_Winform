namespace DoAnNet.Views.Products
{
    partial class product
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
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.dgv_details = new System.Windows.Forms.DataGridView();
            this.btn_insertdetails = new System.Windows.Forms.Button();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_resetdetails = new System.Windows.Forms.Button();
            this.btn_choose = new System.Windows.Forms.Button();
            this.cmb_color = new System.Windows.Forms.ComboBox();
            this.cmb_size = new System.Windows.Forms.ComboBox();
            this.label11 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.date_time = new System.Windows.Forms.Label();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.label12 = new System.Windows.Forms.Label();
            this.cmb_search = new System.Windows.Forms.ComboBox();
            this.cmb_provider = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.txt_price = new System.Windows.Forms.TextBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_insertproduct = new System.Windows.Forms.Button();
            this.btn_updateproduct = new System.Windows.Forms.Button();
            this.btn_deleteproduct = new System.Windows.Forms.Button();
            this.label6 = new System.Windows.Forms.Label();
            this.txt_cost = new System.Windows.Forms.TextBox();
            this.label5 = new System.Windows.Forms.Label();
            this.cmb_distribute = new System.Windows.Forms.ComboBox();
            this.label3 = new System.Windows.Forms.Label();
            this.txt_nameproduct = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.txt_idproduct = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_sale = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label1 = new System.Windows.Forms.Label();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_product = new System.Windows.Forms.PictureBox();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.groupBox3.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_product)).BeginInit();
            this.SuspendLayout();
            // 
            // dgv_product
            // 
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.Location = new System.Drawing.Point(18, 27);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowHeadersWidth = 51;
            this.dgv_product.RowTemplate.Height = 24;
            this.dgv_product.Size = new System.Drawing.Size(682, 608);
            this.dgv_product.TabIndex = 0;
            this.dgv_product.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellClick);
            // 
            // timer1
            // 
            this.timer1.Tick += new System.EventHandler(this.timer1_Tick);
            // 
            // dgv_details
            // 
            this.dgv_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_details.Location = new System.Drawing.Point(18, 27);
            this.dgv_details.Name = "dgv_details";
            this.dgv_details.RowHeadersWidth = 51;
            this.dgv_details.RowTemplate.Height = 24;
            this.dgv_details.Size = new System.Drawing.Size(410, 337);
            this.dgv_details.TabIndex = 0;
            this.dgv_details.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_details_CellClick);
            // 
            // btn_insertdetails
            // 
            this.btn_insertdetails.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insertdetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_insertdetails.Location = new System.Drawing.Point(18, 72);
            this.btn_insertdetails.Name = "btn_insertdetails";
            this.btn_insertdetails.Size = new System.Drawing.Size(295, 39);
            this.btn_insertdetails.TabIndex = 5;
            this.btn_insertdetails.Text = "Thêm chi tiết";
            this.btn_insertdetails.UseVisualStyleBackColor = true;
            this.btn_insertdetails.Click += new System.EventHandler(this.btn_insertdetails_Click);
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_resetdetails);
            this.groupBox4.Controls.Add(this.btn_choose);
            this.groupBox4.Controls.Add(this.btn_insertdetails);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox4.Location = new System.Drawing.Point(1202, 612);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(337, 120);
            this.groupBox4.TabIndex = 130;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức năng";
            // 
            // btn_resetdetails
            // 
            this.btn_resetdetails.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_resetdetails.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_resetdetails.Location = new System.Drawing.Point(19, 27);
            this.btn_resetdetails.Name = "btn_resetdetails";
            this.btn_resetdetails.Size = new System.Drawing.Size(144, 39);
            this.btn_resetdetails.TabIndex = 6;
            this.btn_resetdetails.Text = "Reset";
            this.btn_resetdetails.UseVisualStyleBackColor = true;
            this.btn_resetdetails.Click += new System.EventHandler(this.btn_resetdetails_Click);
            // 
            // btn_choose
            // 
            this.btn_choose.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_choose.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_choose.Location = new System.Drawing.Point(169, 27);
            this.btn_choose.Name = "btn_choose";
            this.btn_choose.Size = new System.Drawing.Size(144, 39);
            this.btn_choose.TabIndex = 4;
            this.btn_choose.Text = "Chọn ảnh";
            this.btn_choose.UseVisualStyleBackColor = true;
            this.btn_choose.Click += new System.EventHandler(this.btn_choose_Click);
            // 
            // cmb_color
            // 
            this.cmb_color.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_color.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_color.FormattingEnabled = true;
            this.cmb_color.Location = new System.Drawing.Point(1253, 564);
            this.cmb_color.Name = "cmb_color";
            this.cmb_color.Size = new System.Drawing.Size(286, 30);
            this.cmb_color.TabIndex = 154;
            // 
            // cmb_size
            // 
            this.cmb_size.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_size.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_size.FormattingEnabled = true;
            this.cmb_size.Location = new System.Drawing.Point(1253, 528);
            this.cmb_size.Name = "cmb_size";
            this.cmb_size.Size = new System.Drawing.Size(286, 30);
            this.cmb_size.TabIndex = 153;
            // 
            // label11
            // 
            this.label11.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label11.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label11.Location = new System.Drawing.Point(1200, 571);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(53, 26);
            this.label11.TabIndex = 149;
            this.label11.Text = "Màu:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label4.Location = new System.Drawing.Point(1200, 532);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(53, 26);
            this.label4.TabIndex = 147;
            this.label4.Text = "Size:";
            // 
            // groupBox3
            // 
            this.groupBox3.Controls.Add(this.dgv_details);
            this.groupBox3.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox3.Location = new System.Drawing.Point(749, 372);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(445, 385);
            this.groupBox3.TabIndex = 128;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Chi tiết sản phẩm";
            // 
            // date_time
            // 
            this.date_time.Font = new System.Drawing.Font("Microsoft Sans Serif", 10.2F, System.Drawing.FontStyle.Italic, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_time.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.date_time.Location = new System.Drawing.Point(1232, 0);
            this.date_time.Name = "date_time";
            this.date_time.Size = new System.Drawing.Size(310, 23);
            this.date_time.TabIndex = 152;
            this.date_time.Text = "Time + date";
            // 
            // txt_link
            // 
            this.txt_link.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_link.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_link.Location = new System.Drawing.Point(782, 323);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(234, 30);
            this.txt_link.TabIndex = 151;
            // 
            // label12
            // 
            this.label12.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label12.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label12.Location = new System.Drawing.Point(37, 25);
            this.label12.Name = "label12";
            this.label12.Size = new System.Drawing.Size(99, 23);
            this.label12.TabIndex = 150;
            this.label12.Text = "Tìm theo:";
            // 
            // cmb_search
            // 
            this.cmb_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_search.FormattingEnabled = true;
            this.cmb_search.Items.AddRange(new object[] {
            "Tên sản phẩm",
            "Tên nhà cung cấp"});
            this.cmb_search.Location = new System.Drawing.Point(142, 18);
            this.cmb_search.Name = "cmb_search";
            this.cmb_search.Size = new System.Drawing.Size(406, 30);
            this.cmb_search.TabIndex = 148;
            // 
            // cmb_provider
            // 
            this.cmb_provider.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_provider.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_provider.FormattingEnabled = true;
            this.cmb_provider.Location = new System.Drawing.Point(1202, 187);
            this.cmb_provider.Name = "cmb_provider";
            this.cmb_provider.Size = new System.Drawing.Size(337, 30);
            this.cmb_provider.TabIndex = 146;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label9.Location = new System.Drawing.Point(1058, 190);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(136, 26);
            this.label9.TabIndex = 145;
            this.label9.Text = "Nhà Cung Cấp:";
            // 
            // txt_price
            // 
            this.txt_price.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_price.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_price.Location = new System.Drawing.Point(1202, 304);
            this.txt_price.Name = "txt_price";
            this.txt_price.Size = new System.Drawing.Size(337, 30);
            this.txt_price.TabIndex = 144;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btn_reset);
            this.groupBox2.Controls.Add(this.btn_insertproduct);
            this.groupBox2.Controls.Add(this.btn_updateproduct);
            this.groupBox2.Controls.Add(this.btn_deleteproduct);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox2.Location = new System.Drawing.Point(1202, 363);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(337, 128);
            this.groupBox2.TabIndex = 129;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chức năng";
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_reset.Location = new System.Drawing.Point(179, 25);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(128, 39);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_insertproduct
            // 
            this.btn_insertproduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insertproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_insertproduct.Location = new System.Drawing.Point(34, 70);
            this.btn_insertproduct.Name = "btn_insertproduct";
            this.btn_insertproduct.Size = new System.Drawing.Size(129, 39);
            this.btn_insertproduct.TabIndex = 2;
            this.btn_insertproduct.Text = "Thêm mới";
            this.btn_insertproduct.UseVisualStyleBackColor = true;
            this.btn_insertproduct.Click += new System.EventHandler(this.btn_insertproduct_Click);
            // 
            // btn_updateproduct
            // 
            this.btn_updateproduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_updateproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_updateproduct.Location = new System.Drawing.Point(34, 25);
            this.btn_updateproduct.Name = "btn_updateproduct";
            this.btn_updateproduct.Size = new System.Drawing.Size(129, 39);
            this.btn_updateproduct.TabIndex = 1;
            this.btn_updateproduct.Text = "Sửa";
            this.btn_updateproduct.UseVisualStyleBackColor = true;
            this.btn_updateproduct.Click += new System.EventHandler(this.btn_updateproduct_Click);
            // 
            // btn_deleteproduct
            // 
            this.btn_deleteproduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_deleteproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_deleteproduct.Location = new System.Drawing.Point(179, 70);
            this.btn_deleteproduct.Name = "btn_deleteproduct";
            this.btn_deleteproduct.Size = new System.Drawing.Size(128, 39);
            this.btn_deleteproduct.TabIndex = 0;
            this.btn_deleteproduct.Text = "Xóa";
            this.btn_deleteproduct.UseVisualStyleBackColor = true;
            this.btn_deleteproduct.Click += new System.EventHandler(this.btn_deleteproduct_Click);
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label6.Location = new System.Drawing.Point(1058, 268);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(136, 26);
            this.label6.TabIndex = 141;
            this.label6.Text = "Tỷ lệ chênh giá:";
            // 
            // txt_cost
            // 
            this.txt_cost.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_cost.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_cost.Location = new System.Drawing.Point(1202, 226);
            this.txt_cost.Name = "txt_cost";
            this.txt_cost.Size = new System.Drawing.Size(337, 30);
            this.txt_cost.TabIndex = 140;
            // 
            // label5
            // 
            this.label5.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label5.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label5.Location = new System.Drawing.Point(1058, 228);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(88, 26);
            this.label5.TabIndex = 139;
            this.label5.Text = "Giá Nhập:";
            // 
            // cmb_distribute
            // 
            this.cmb_distribute.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_distribute.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_distribute.FormattingEnabled = true;
            this.cmb_distribute.Location = new System.Drawing.Point(1202, 151);
            this.cmb_distribute.Name = "cmb_distribute";
            this.cmb_distribute.Size = new System.Drawing.Size(337, 30);
            this.cmb_distribute.TabIndex = 138;
            // 
            // label3
            // 
            this.label3.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label3.Location = new System.Drawing.Point(1058, 154);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(88, 26);
            this.label3.TabIndex = 137;
            this.label3.Text = "Loại:";
            // 
            // txt_nameproduct
            // 
            this.txt_nameproduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_nameproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_nameproduct.Location = new System.Drawing.Point(1202, 112);
            this.txt_nameproduct.Name = "txt_nameproduct";
            this.txt_nameproduct.Size = new System.Drawing.Size(337, 30);
            this.txt_nameproduct.TabIndex = 136;
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(1058, 115);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(136, 26);
            this.label2.TabIndex = 135;
            this.label2.Text = "Tên Sản Phẩm:";
            // 
            // txt_idproduct
            // 
            this.txt_idproduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_idproduct.Location = new System.Drawing.Point(1202, 73);
            this.txt_idproduct.Name = "txt_idproduct";
            this.txt_idproduct.Size = new System.Drawing.Size(337, 30);
            this.txt_idproduct.TabIndex = 134;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label7.Location = new System.Drawing.Point(1058, 307);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(88, 26);
            this.label7.TabIndex = 143;
            this.label7.Text = "Giá Bán:";
            // 
            // txt_sale
            // 
            this.txt_sale.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_sale.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_sale.Location = new System.Drawing.Point(1202, 265);
            this.txt_sale.Name = "txt_sale";
            this.txt_sale.Size = new System.Drawing.Size(337, 30);
            this.txt_sale.TabIndex = 142;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label8.Location = new System.Drawing.Point(1058, 76);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(126, 26);
            this.label8.TabIndex = 133;
            this.label8.Text = "Mã Sản Phẩm:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_product);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox1.Location = new System.Drawing.Point(20, 101);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(711, 656);
            this.groupBox1.TabIndex = 126;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu";
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(37, 64);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(131, 23);
            this.label1.TabIndex = 132;
            this.label1.Text = "Nhập thông tin:";
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_search.Location = new System.Drawing.Point(174, 61);
            this.txt_search.Multiline = true;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(374, 30);
            this.txt_search.TabIndex = 131;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackColor = System.Drawing.Color.LightGray;
            this.pictureBox1.Image = global::DoAnNet.Properties.Resources.main;
            this.pictureBox1.Location = new System.Drawing.Point(570, 18);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(150, 73);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 155;
            this.pictureBox1.TabStop = false;
            // 
            // pic_product
            // 
            this.pic_product.BackColor = System.Drawing.Color.LightGray;
            this.pic_product.Location = new System.Drawing.Point(782, 42);
            this.pic_product.Name = "pic_product";
            this.pic_product.Size = new System.Drawing.Size(234, 275);
            this.pic_product.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_product.TabIndex = 127;
            this.pic_product.TabStop = false;
            // 
            // product
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.cmb_color);
            this.Controls.Add(this.cmb_size);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.date_time);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.label12);
            this.Controls.Add(this.cmb_search);
            this.Controls.Add(this.cmb_provider);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.txt_price);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.txt_cost);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.cmb_distribute);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.txt_nameproduct);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txt_idproduct);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_sale);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.pic_product);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txt_search);
            this.Name = "product";
            this.Size = new System.Drawing.Size(1542, 775);
            this.Load += new System.EventHandler(this.product_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.groupBox3.ResumeLayout(false);
            this.groupBox2.ResumeLayout(false);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_product)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.DataGridView dgv_product;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.DataGridView dgv_details;
        private System.Windows.Forms.Button btn_insertdetails;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_resetdetails;
        private System.Windows.Forms.ComboBox cmb_color;
        private System.Windows.Forms.ComboBox cmb_size;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Label date_time;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.Label label12;
        private System.Windows.Forms.ComboBox cmb_search;
        private System.Windows.Forms.ComboBox cmb_provider;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.TextBox txt_price;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_choose;
        private System.Windows.Forms.Button btn_insertproduct;
        private System.Windows.Forms.Button btn_updateproduct;
        private System.Windows.Forms.Button btn_deleteproduct;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox txt_cost;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox cmb_distribute;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txt_nameproduct;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox txt_idproduct;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_sale;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.PictureBox pic_product;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txt_search;
    }
}
