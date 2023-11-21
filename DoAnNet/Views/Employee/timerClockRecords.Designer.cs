namespace DoAnNet.Views.Employee
{
    partial class timerClockRecords
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
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.dgv_TimeClockRecord = new System.Windows.Forms.DataGridView();
            this.btn_reset = new System.Windows.Forms.Button();
            this.btn_timeout = new System.Windows.Forms.Button();
            this.txt_link = new System.Windows.Forms.TextBox();
            this.txt_timeout = new System.Windows.Forms.TextBox();
            this.label8 = new System.Windows.Forms.Label();
            this.cmb_employee = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.date_work = new System.Windows.Forms.DateTimePicker();
            this.label7 = new System.Windows.Forms.Label();
            this.txt_timein = new System.Windows.Forms.TextBox();
            this.label6 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.btn_delete = new System.Windows.Forms.Button();
            this.txt_late = new System.Windows.Forms.TextBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.btn_timein = new System.Windows.Forms.Button();
            this.txt_shift = new System.Windows.Forms.TextBox();
            this.txt_totalhours = new System.Windows.Forms.TextBox();
            this.label10 = new System.Windows.Forms.Label();
            this.btn_fulltime = new System.Windows.Forms.Button();
            this.btn_ca3 = new System.Windows.Forms.Button();
            this.btn_ca2 = new System.Windows.Forms.Button();
            this.btn_ca1 = new System.Windows.Forms.Button();
            this.grb_shift = new System.Windows.Forms.GroupBox();
            this.txt_search = new System.Windows.Forms.TextBox();
            this.label9 = new System.Windows.Forms.Label();
            this.timer1 = new System.Windows.Forms.Timer(this.components);
            this.date_time = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pic_employee = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimeClockRecord)).BeginInit();
            this.groupBox4.SuspendLayout();
            this.grb_shift.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_employee)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            this.SuspendLayout();
            // 
            // label2
            // 
            this.label2.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label2.Location = new System.Drawing.Point(1079, 416);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(103, 26);
            this.label2.TabIndex = 176;
            this.label2.Text = "Đi muộn:";
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.dgv_TimeClockRecord);
            this.groupBox1.Font = new System.Drawing.Font("Times New Roman", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox1.Location = new System.Drawing.Point(29, 59);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(755, 696);
            this.groupBox1.TabIndex = 174;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Dữ liệu";
            // 
            // dgv_TimeClockRecord
            // 
            this.dgv_TimeClockRecord.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dgv_TimeClockRecord.Location = new System.Drawing.Point(16, 27);
            this.dgv_TimeClockRecord.Name = "dgv_TimeClockRecord";
            this.dgv_TimeClockRecord.RowHeadersWidth = 51;
            this.dgv_TimeClockRecord.RowTemplate.Height = 24;
            this.dgv_TimeClockRecord.Size = new System.Drawing.Size(722, 652);
            this.dgv_TimeClockRecord.TabIndex = 142;
            this.dgv_TimeClockRecord.CellClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.dgv_TimeClockRecord_CellClick);
            this.dgv_TimeClockRecord.CellFormatting += new System.Windows.Forms.DataGridViewCellFormattingEventHandler(this.dgv_TimeClockRecord_CellFormatting);
            // 
            // btn_reset
            // 
            this.btn_reset.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_reset.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_reset.Location = new System.Drawing.Point(43, 149);
            this.btn_reset.Name = "btn_reset";
            this.btn_reset.Size = new System.Drawing.Size(145, 39);
            this.btn_reset.TabIndex = 3;
            this.btn_reset.Text = "Reset";
            this.btn_reset.UseVisualStyleBackColor = true;
            this.btn_reset.Click += new System.EventHandler(this.btn_reset_Click);
            // 
            // btn_timeout
            // 
            this.btn_timeout.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_timeout.Location = new System.Drawing.Point(43, 96);
            this.btn_timeout.Name = "btn_timeout";
            this.btn_timeout.Size = new System.Drawing.Size(145, 39);
            this.btn_timeout.TabIndex = 2;
            this.btn_timeout.Text = "Chấm về";
            this.btn_timeout.UseVisualStyleBackColor = true;
            this.btn_timeout.Click += new System.EventHandler(this.btn_timeout_Click);
            // 
            // txt_link
            // 
            this.txt_link.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_link.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_link.Location = new System.Drawing.Point(818, 430);
            this.txt_link.Name = "txt_link";
            this.txt_link.Size = new System.Drawing.Size(234, 33);
            this.txt_link.TabIndex = 168;
            // 
            // txt_timeout
            // 
            this.txt_timeout.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timeout.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_timeout.Location = new System.Drawing.Point(1188, 331);
            this.txt_timeout.Name = "txt_timeout";
            this.txt_timeout.Size = new System.Drawing.Size(322, 33);
            this.txt_timeout.TabIndex = 166;
            // 
            // label8
            // 
            this.label8.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label8.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label8.Location = new System.Drawing.Point(1074, 338);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(89, 26);
            this.label8.TabIndex = 165;
            this.label8.Text = "Giờ về:";
            // 
            // cmb_employee
            // 
            this.cmb_employee.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.cmb_employee.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.cmb_employee.FormattingEnabled = true;
            this.cmb_employee.Location = new System.Drawing.Point(1188, 167);
            this.cmb_employee.Name = "cmb_employee";
            this.cmb_employee.Size = new System.Drawing.Size(322, 33);
            this.cmb_employee.TabIndex = 164;
            // 
            // label1
            // 
            this.label1.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label1.Location = new System.Drawing.Point(1074, 174);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(108, 26);
            this.label1.TabIndex = 163;
            this.label1.Text = "Nhân viên:";
            // 
            // date_work
            // 
            this.date_work.CalendarFont = new System.Drawing.Font("Microsoft Sans Serif", 10.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.date_work.Location = new System.Drawing.Point(1188, 215);
            this.date_work.Name = "date_work";
            this.date_work.Size = new System.Drawing.Size(322, 22);
            this.date_work.TabIndex = 162;
            // 
            // label7
            // 
            this.label7.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label7.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label7.Location = new System.Drawing.Point(1072, 213);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(103, 26);
            this.label7.TabIndex = 161;
            this.label7.Text = "Ngày làm:";
            // 
            // txt_timein
            // 
            this.txt_timein.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_timein.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_timein.Location = new System.Drawing.Point(1188, 292);
            this.txt_timein.Name = "txt_timein";
            this.txt_timein.Size = new System.Drawing.Size(322, 33);
            this.txt_timein.TabIndex = 160;
            // 
            // label6
            // 
            this.label6.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label6.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label6.Location = new System.Drawing.Point(1074, 299);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(89, 26);
            this.label6.TabIndex = 159;
            this.label6.Text = "Giờ đến:";
            // 
            // label4
            // 
            this.label4.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label4.Location = new System.Drawing.Point(1074, 259);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(89, 26);
            this.label4.TabIndex = 158;
            this.label4.Text = "Ca làm:";
            // 
            // btn_delete
            // 
            this.btn_delete.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_delete.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_delete.Location = new System.Drawing.Point(43, 201);
            this.btn_delete.Name = "btn_delete";
            this.btn_delete.Size = new System.Drawing.Size(145, 39);
            this.btn_delete.TabIndex = 1;
            this.btn_delete.Text = "Xóa";
            this.btn_delete.UseVisualStyleBackColor = true;
            this.btn_delete.Click += new System.EventHandler(this.btn_delete_Click);
            // 
            // txt_late
            // 
            this.txt_late.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_late.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_late.Location = new System.Drawing.Point(1188, 409);
            this.txt_late.Name = "txt_late";
            this.txt_late.Size = new System.Drawing.Size(322, 33);
            this.txt_late.TabIndex = 177;
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.btn_reset);
            this.groupBox4.Controls.Add(this.btn_timeout);
            this.groupBox4.Controls.Add(this.btn_delete);
            this.groupBox4.Controls.Add(this.btn_timein);
            this.groupBox4.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.groupBox4.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.groupBox4.Location = new System.Drawing.Point(1273, 473);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(224, 263);
            this.groupBox4.TabIndex = 169;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "Chức năng";
            // 
            // btn_timein
            // 
            this.btn_timein.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btn_timein.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.btn_timein.Location = new System.Drawing.Point(43, 44);
            this.btn_timein.Name = "btn_timein";
            this.btn_timein.Size = new System.Drawing.Size(145, 39);
            this.btn_timein.TabIndex = 0;
            this.btn_timein.Text = "Chấm đến";
            this.btn_timein.UseVisualStyleBackColor = true;
            this.btn_timein.Click += new System.EventHandler(this.btn_timein_Click);
            // 
            // txt_shift
            // 
            this.txt_shift.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_shift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_shift.Location = new System.Drawing.Point(1188, 252);
            this.txt_shift.Name = "txt_shift";
            this.txt_shift.Size = new System.Drawing.Size(322, 33);
            this.txt_shift.TabIndex = 172;
            // 
            // txt_totalhours
            // 
            this.txt_totalhours.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_totalhours.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_totalhours.Location = new System.Drawing.Point(1188, 370);
            this.txt_totalhours.Name = "txt_totalhours";
            this.txt_totalhours.Size = new System.Drawing.Size(322, 33);
            this.txt_totalhours.TabIndex = 171;
            // 
            // label10
            // 
            this.label10.Font = new System.Drawing.Font("Times New Roman", 13.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label10.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label10.Location = new System.Drawing.Point(1074, 377);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(103, 26);
            this.label10.TabIndex = 170;
            this.label10.Text = "Tổng giờ:";
            // 
            // btn_fulltime
            // 
            this.btn_fulltime.Location = new System.Drawing.Point(39, 135);
            this.btn_fulltime.Name = "btn_fulltime";
            this.btn_fulltime.Size = new System.Drawing.Size(342, 78);
            this.btn_fulltime.TabIndex = 6;
            this.btn_fulltime.Text = "Fulltime";
            this.btn_fulltime.UseVisualStyleBackColor = true;
            this.btn_fulltime.Click += new System.EventHandler(this.btn_fulltime_Click);
            // 
            // btn_ca3
            // 
            this.btn_ca3.Location = new System.Drawing.Point(283, 39);
            this.btn_ca3.Name = "btn_ca3";
            this.btn_ca3.Size = new System.Drawing.Size(98, 78);
            this.btn_ca3.TabIndex = 2;
            this.btn_ca3.Text = "Ca tối";
            this.btn_ca3.UseVisualStyleBackColor = true;
            this.btn_ca3.Click += new System.EventHandler(this.btn_ca3_Click);
            // 
            // btn_ca2
            // 
            this.btn_ca2.Location = new System.Drawing.Point(163, 39);
            this.btn_ca2.Name = "btn_ca2";
            this.btn_ca2.Size = new System.Drawing.Size(98, 78);
            this.btn_ca2.TabIndex = 1;
            this.btn_ca2.Text = "Ca chiều";
            this.btn_ca2.UseVisualStyleBackColor = true;
            this.btn_ca2.Click += new System.EventHandler(this.btn_ca2_Click);
            // 
            // btn_ca1
            // 
            this.btn_ca1.Location = new System.Drawing.Point(39, 39);
            this.btn_ca1.Name = "btn_ca1";
            this.btn_ca1.Size = new System.Drawing.Size(98, 78);
            this.btn_ca1.TabIndex = 0;
            this.btn_ca1.Text = "Ca sáng";
            this.btn_ca1.UseVisualStyleBackColor = true;
            this.btn_ca1.Click += new System.EventHandler(this.btn_ca1_Click);
            // 
            // grb_shift
            // 
            this.grb_shift.Controls.Add(this.btn_fulltime);
            this.grb_shift.Controls.Add(this.btn_ca3);
            this.grb_shift.Controls.Add(this.btn_ca2);
            this.grb_shift.Controls.Add(this.btn_ca1);
            this.grb_shift.Font = new System.Drawing.Font("Times New Roman", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.grb_shift.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.grb_shift.Location = new System.Drawing.Point(807, 500);
            this.grb_shift.Name = "grb_shift";
            this.grb_shift.Size = new System.Drawing.Size(423, 238);
            this.grb_shift.TabIndex = 173;
            this.grb_shift.TabStop = false;
            this.grb_shift.Text = "Ca làm việc";
            // 
            // txt_search
            // 
            this.txt_search.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.txt_search.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.txt_search.Location = new System.Drawing.Point(220, 17);
            this.txt_search.Multiline = true;
            this.txt_search.Name = "txt_search";
            this.txt_search.Size = new System.Drawing.Size(289, 36);
            this.txt_search.TabIndex = 156;
            this.txt_search.TextChanged += new System.EventHandler(this.txt_search_TextChanged);
            // 
            // label9
            // 
            this.label9.Font = new System.Drawing.Font("Times New Roman", 13.8F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label9.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(40)))), ((int)(((byte)(83)))));
            this.label9.Location = new System.Drawing.Point(103, 20);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(111, 23);
            this.label9.TabIndex = 157;
            this.label9.Text = "Tìm kiếm: ";
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
            this.date_time.TabIndex = 154;
            this.date_time.Text = "Time + date";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Image = global::DoAnNet.Properties.Resources.logo;
            this.pictureBox1.Location = new System.Drawing.Point(1102, 33);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(149, 97);
            this.pictureBox1.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox1.TabIndex = 175;
            this.pictureBox1.TabStop = false;
            // 
            // pic_employee
            // 
            this.pic_employee.BackColor = System.Drawing.Color.LightGray;
            this.pic_employee.Location = new System.Drawing.Point(818, 149);
            this.pic_employee.Name = "pic_employee";
            this.pic_employee.Size = new System.Drawing.Size(234, 275);
            this.pic_employee.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pic_employee.TabIndex = 167;
            this.pic_employee.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.Image = global::DoAnNet.Properties.Resources.main;
            this.pictureBox2.Location = new System.Drawing.Point(544, 3);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(103, 58);
            this.pictureBox2.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.pictureBox2.TabIndex = 178;
            this.pictureBox2.TabStop = false;
            // 
            // timerClockRecords
            // 
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.None;
            this.BackColor = System.Drawing.Color.White;
            this.Controls.Add(this.pictureBox2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.pictureBox1);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.txt_link);
            this.Controls.Add(this.pic_employee);
            this.Controls.Add(this.txt_timeout);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.cmb_employee);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.date_work);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.txt_timein);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.txt_late);
            this.Controls.Add(this.groupBox4);
            this.Controls.Add(this.txt_shift);
            this.Controls.Add(this.txt_totalhours);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.grb_shift);
            this.Controls.Add(this.txt_search);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.date_time);
            this.Name = "timerClockRecords";
            this.Size = new System.Drawing.Size(1542, 775);
            this.Load += new System.EventHandler(this.timerClockRecords_Load);
            this.groupBox1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.dgv_TimeClockRecord)).EndInit();
            this.groupBox4.ResumeLayout(false);
            this.grb_shift.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pic_employee)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.DataGridView dgv_TimeClockRecord;
        private System.Windows.Forms.Button btn_reset;
        private System.Windows.Forms.Button btn_timeout;
        private System.Windows.Forms.TextBox txt_link;
        private System.Windows.Forms.PictureBox pic_employee;
        private System.Windows.Forms.TextBox txt_timeout;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.ComboBox cmb_employee;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.DateTimePicker date_work;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.TextBox txt_timein;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Button btn_delete;
        private System.Windows.Forms.TextBox txt_late;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Button btn_timein;
        private System.Windows.Forms.TextBox txt_shift;
        private System.Windows.Forms.TextBox txt_totalhours;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.Button btn_fulltime;
        private System.Windows.Forms.Button btn_ca3;
        private System.Windows.Forms.Button btn_ca2;
        private System.Windows.Forms.Button btn_ca1;
        private System.Windows.Forms.GroupBox grb_shift;
        private System.Windows.Forms.TextBox txt_search;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Timer timer1;
        private System.Windows.Forms.Label date_time;
        private System.Windows.Forms.PictureBox pictureBox2;
    }
}
