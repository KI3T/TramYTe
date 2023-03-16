
namespace TramYTe.AdminMain
{
    partial class QuanLyThongBao
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(QuanLyThongBao));
            this.textBoxTenThongBao = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.panelThongTin = new System.Windows.Forms.Panel();
            this.comboBoxMaHo = new System.Windows.Forms.ComboBox();
            this.buttonXacNhan = new System.Windows.Forms.Button();
            this.buttonLamMoi = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.textBoxNoiDung = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.panel1 = new System.Windows.Forms.Panel();
            this.panelControl = new System.Windows.Forms.Panel();
            this.buttonXoa = new System.Windows.Forms.Button();
            this.buttonThem = new System.Windows.Forms.Button();
            this.buttonXemDanhSach = new System.Windows.Forms.Button();
            this.buttonTimKiem = new System.Windows.Forms.PictureBox();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.panelThongBao = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panelThongTin.SuspendLayout();
            this.panel1.SuspendLayout();
            this.panelControl.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTimKiem)).BeginInit();
            this.panelThongBao.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.SuspendLayout();
            // 
            // textBoxTenThongBao
            // 
            this.textBoxTenThongBao.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxTenThongBao.Location = new System.Drawing.Point(35, 36);
            this.textBoxTenThongBao.Name = "textBoxTenThongBao";
            this.textBoxTenThongBao.Size = new System.Drawing.Size(222, 30);
            this.textBoxTenThongBao.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.Location = new System.Drawing.Point(31, 10);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 23);
            this.label1.TabIndex = 0;
            this.label1.Text = "Tiêu đề:";
            // 
            // panelThongTin
            // 
            this.panelThongTin.Controls.Add(this.comboBoxMaHo);
            this.panelThongTin.Controls.Add(this.buttonXacNhan);
            this.panelThongTin.Controls.Add(this.buttonLamMoi);
            this.panelThongTin.Controls.Add(this.label3);
            this.panelThongTin.Controls.Add(this.textBoxNoiDung);
            this.panelThongTin.Controls.Add(this.label2);
            this.panelThongTin.Controls.Add(this.textBoxTenThongBao);
            this.panelThongTin.Controls.Add(this.label1);
            this.panelThongTin.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panelThongTin.Location = new System.Drawing.Point(0, 42);
            this.panelThongTin.Name = "panelThongTin";
            this.panelThongTin.Size = new System.Drawing.Size(1300, 149);
            this.panelThongTin.TabIndex = 1;
            // 
            // comboBoxMaHo
            // 
            this.comboBoxMaHo.Font = new System.Drawing.Font("Segoe UI", 10.2F);
            this.comboBoxMaHo.FormattingEnabled = true;
            this.comboBoxMaHo.Location = new System.Drawing.Point(313, 35);
            this.comboBoxMaHo.Name = "comboBoxMaHo";
            this.comboBoxMaHo.Size = new System.Drawing.Size(222, 31);
            this.comboBoxMaHo.TabIndex = 14;
            // 
            // buttonXacNhan
            // 
            this.buttonXacNhan.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXacNhan.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXacNhan.FlatAppearance.BorderSize = 0;
            this.buttonXacNhan.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXacNhan.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXacNhan.Image = global::TramYTe.Properties.Resources.XacNhan;
            this.buttonXacNhan.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonXacNhan.Location = new System.Drawing.Point(946, 35);
            this.buttonXacNhan.Name = "buttonXacNhan";
            this.buttonXacNhan.Size = new System.Drawing.Size(117, 30);
            this.buttonXacNhan.TabIndex = 13;
            this.buttonXacNhan.Text = "Xác nhận";
            this.buttonXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonXacNhan.UseVisualStyleBackColor = true;
            this.buttonXacNhan.Click += new System.EventHandler(this.buttonXacNhan_Click);
            // 
            // buttonLamMoi
            // 
            this.buttonLamMoi.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonLamMoi.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonLamMoi.FlatAppearance.BorderSize = 0;
            this.buttonLamMoi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonLamMoi.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonLamMoi.Image = global::TramYTe.Properties.Resources.LamMoi;
            this.buttonLamMoi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonLamMoi.Location = new System.Drawing.Point(1126, 36);
            this.buttonLamMoi.Name = "buttonLamMoi";
            this.buttonLamMoi.Size = new System.Drawing.Size(117, 30);
            this.buttonLamMoi.TabIndex = 10;
            this.buttonLamMoi.Text = "Làm mới";
            this.buttonLamMoi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonLamMoi.UseVisualStyleBackColor = true;
            this.buttonLamMoi.Click += new System.EventHandler(this.buttonLamMoi_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.Location = new System.Drawing.Point(309, 10);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(63, 23);
            this.label3.TabIndex = 4;
            this.label3.Text = "Mã hộ:";
            // 
            // textBoxNoiDung
            // 
            this.textBoxNoiDung.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.textBoxNoiDung.Location = new System.Drawing.Point(35, 107);
            this.textBoxNoiDung.Name = "textBoxNoiDung";
            this.textBoxNoiDung.Size = new System.Drawing.Size(1208, 30);
            this.textBoxNoiDung.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.Location = new System.Drawing.Point(31, 81);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(86, 23);
            this.label2.TabIndex = 2;
            this.label2.Text = "Nội dung:";
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panelThongTin);
            this.panel1.Controls.Add(this.panelControl);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 556);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1300, 191);
            this.panel1.TabIndex = 4;
            // 
            // panelControl
            // 
            this.panelControl.Controls.Add(this.buttonXoa);
            this.panelControl.Controls.Add(this.buttonThem);
            this.panelControl.Controls.Add(this.buttonXemDanhSach);
            this.panelControl.Controls.Add(this.buttonTimKiem);
            this.panelControl.Controls.Add(this.textBoxTimKiem);
            this.panelControl.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelControl.Location = new System.Drawing.Point(0, 0);
            this.panelControl.Name = "panelControl";
            this.panelControl.Size = new System.Drawing.Size(1300, 42);
            this.panelControl.TabIndex = 0;
            // 
            // buttonXoa
            // 
            this.buttonXoa.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXoa.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXoa.FlatAppearance.BorderSize = 0;
            this.buttonXoa.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXoa.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXoa.Image = ((System.Drawing.Image)(resources.GetObject("buttonXoa.Image")));
            this.buttonXoa.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonXoa.Location = new System.Drawing.Point(342, 6);
            this.buttonXoa.Name = "buttonXoa";
            this.buttonXoa.Size = new System.Drawing.Size(72, 30);
            this.buttonXoa.TabIndex = 7;
            this.buttonXoa.Text = "Xoá";
            this.buttonXoa.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonXoa.UseVisualStyleBackColor = true;
            this.buttonXoa.Click += new System.EventHandler(this.buttonXoa_Click);
            // 
            // buttonThem
            // 
            this.buttonThem.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonThem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonThem.FlatAppearance.BorderSize = 0;
            this.buttonThem.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonThem.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonThem.Image = global::TramYTe.Properties.Resources.Them;
            this.buttonThem.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonThem.Location = new System.Drawing.Point(223, 6);
            this.buttonThem.Name = "buttonThem";
            this.buttonThem.Size = new System.Drawing.Size(86, 30);
            this.buttonThem.TabIndex = 5;
            this.buttonThem.Text = "Thêm";
            this.buttonThem.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonThem.UseVisualStyleBackColor = true;
            this.buttonThem.Click += new System.EventHandler(this.buttonThem_Click);
            // 
            // buttonXemDanhSach
            // 
            this.buttonXemDanhSach.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonXemDanhSach.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonXemDanhSach.FlatAppearance.BorderSize = 0;
            this.buttonXemDanhSach.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonXemDanhSach.Font = new System.Drawing.Font("Segoe UI", 10.2F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonXemDanhSach.Image = global::TramYTe.Properties.Resources.list;
            this.buttonXemDanhSach.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonXemDanhSach.Location = new System.Drawing.Point(35, 6);
            this.buttonXemDanhSach.Name = "buttonXemDanhSach";
            this.buttonXemDanhSach.Size = new System.Drawing.Size(162, 30);
            this.buttonXemDanhSach.TabIndex = 4;
            this.buttonXemDanhSach.Text = "Xem danh sách";
            this.buttonXemDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonXemDanhSach.UseVisualStyleBackColor = true;
            this.buttonXemDanhSach.Click += new System.EventHandler(this.buttonXemDanhSach_Click);
            // 
            // buttonTimKiem
            // 
            this.buttonTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTimKiem.Image = global::TramYTe.Properties.Resources.search;
            this.buttonTimKiem.Location = new System.Drawing.Point(1221, 10);
            this.buttonTimKiem.Name = "buttonTimKiem";
            this.buttonTimKiem.Size = new System.Drawing.Size(22, 22);
            this.buttonTimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonTimKiem.TabIndex = 3;
            this.buttonTimKiem.TabStop = false;
            this.buttonTimKiem.Click += new System.EventHandler(this.buttonTimKiem_Click);
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(946, 8);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(267, 27);
            this.textBoxTimKiem.TabIndex = 2;
            // 
            // panelThongBao
            // 
            this.panelThongBao.AutoScroll = true;
            this.panelThongBao.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelThongBao.Controls.Add(this.DGV);
            this.panelThongBao.Dock = System.Windows.Forms.DockStyle.Top;
            this.panelThongBao.Location = new System.Drawing.Point(0, 0);
            this.panelThongBao.Name = "panelThongBao";
            this.panelThongBao.Size = new System.Drawing.Size(1300, 550);
            this.panelThongBao.TabIndex = 3;
            // 
            // DGV
            // 
            this.DGV.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.AllCells;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.White;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.GridColor = System.Drawing.Color.White;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 24;
            this.DGV.Size = new System.Drawing.Size(1298, 548);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // QuanLyThongBao
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 747);
            this.Controls.Add(this.panel1);
            this.Controls.Add(this.panelThongBao);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "QuanLyThongBao";
            this.Text = "QuanLyThongBao";
            this.Load += new System.EventHandler(this.QuanLyThongBao_Load);
            this.panelThongTin.ResumeLayout(false);
            this.panelThongTin.PerformLayout();
            this.panel1.ResumeLayout(false);
            this.panelControl.ResumeLayout(false);
            this.panelControl.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTimKiem)).EndInit();
            this.panelThongBao.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonXoa;
        private System.Windows.Forms.Button buttonThem;
        private System.Windows.Forms.PictureBox buttonTimKiem;
        private System.Windows.Forms.Button buttonXacNhan;
        private System.Windows.Forms.Button buttonLamMoi;
        private System.Windows.Forms.Button buttonXemDanhSach;
        private System.Windows.Forms.TextBox textBoxTenThongBao;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel panelThongTin;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panelControl;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Panel panelThongBao;
        private System.Windows.Forms.TextBox textBoxNoiDung;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox comboBoxMaHo;
        private System.Windows.Forms.DataGridView DGV;
    }
}