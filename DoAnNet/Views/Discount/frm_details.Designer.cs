namespace DoAnNet.Views.Discount
{
    partial class frm_details
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

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(frm_details));
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_product = new System.Windows.Forms.DataGridView();
            this.cmb_discount = new System.Windows.Forms.ComboBox();
            this.label9 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.dgv_details = new System.Windows.Forms.DataGridView();
            this.btn_insert = new System.Windows.Forms.Button();
            this.txt_idproduct = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).BeginInit();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_product);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox1.Location = new System.Drawing.Point(14, 14);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(613, 469);
            this.groupBox1.TabIndex = 158;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Danh sách sản phẩm";
            // 
            // dgv_product
            // 
            this.dgv_product.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_product.Location = new System.Drawing.Point(23, 27);
            this.dgv_product.Name = "dgv_product";
            this.dgv_product.RowHeadersWidth = 51;
            this.dgv_product.RowTemplate.Height = 24;
            this.dgv_product.Size = new System.Drawing.Size(574, 425);
            this.dgv_product.TabIndex = 0;
            this.dgv_product.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_product_CellClick);
            // 
            // cmb_discount
            // 
            this.cmb_discount.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_discount.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_discount.FormattingEnabled = true;
            this.cmb_discount.Location = new System.Drawing.Point(773, 444);
            this.cmb_discount.Name = "cmb_discount";
            this.cmb_discount.Size = new System.Drawing.Size(188, 34);
            this.cmb_discount.TabIndex = 165;
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label9.Location = new System.Drawing.Point(662, 447);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(105, 26);
            this.label9.TabIndex = 164;
            this.label9.Text = "Giảm giá:";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.dgv_details);
            this.groupBox2.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox2.Location = new System.Drawing.Point(642, 91);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(506, 296);
            this.groupBox2.TabIndex = 159;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Chi tiết giảm giá";
            // 
            // dgv_details
            // 
            this.dgv_details.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_details.Location = new System.Drawing.Point(20, 27);
            this.dgv_details.Name = "dgv_details";
            this.dgv_details.RowHeadersWidth = 51;
            this.dgv_details.RowTemplate.Height = 24;
            this.dgv_details.Size = new System.Drawing.Size(467, 249);
            this.dgv_details.TabIndex = 0;
            this.dgv_details.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_details_CellClick);
            // 
            // btn_insert
            // 
            this.btn_insert.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_insert.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_insert.Location = new System.Drawing.Point(978, 441);
            this.btn_insert.Name = "btn_insert";
            this.btn_insert.Size = new System.Drawing.Size(151, 39);
            this.btn_insert.TabIndex = 2;
            this.btn_insert.Text = "Thêm mới";
            this.btn_insert.UseVisualStyleBackColor = true;
            this.btn_insert.Click += new System.EventHandler(this.btn_insert_Click);
            // 
            // txt_idproduct
            // 
            this.txt_idproduct.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_idproduct.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_idproduct.Location = new System.Drawing.Point(773, 408);
            this.txt_idproduct.Name = "txt_idproduct";
            this.txt_idproduct.Size = new System.Drawing.Size(188, 30);
            this.txt_idproduct.TabIndex = 166;
            // 
            // frm_details
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1162, 492);
            this.Controls.Add(this.txt_idproduct);
            this.Controls.Add(this.btn_insert);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.cmb_discount);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.groupBox1);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.Name = "frm_details";
            this.Text = "Thêm sản phẩm vào giảm giá";
            this.Load += new System.EventHandler(this.frm_details_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_product)).EndInit();
            this.groupBox2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_details)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_product;
        private System.Windows.Forms.ComboBox cmb_discount;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.DataGridView dgv_details;
        private System.Windows.Forms.Button btn_insert;
        private System.Windows.Forms.TextBox txt_idproduct;
    }
}