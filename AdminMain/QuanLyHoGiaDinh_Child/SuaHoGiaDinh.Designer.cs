
namespace TramYTe.AdminMain.QuanLyHoGiaDinh_Child
{
    partial class SuaHoGiaDinh
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
            this.panel1 = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panel3 = new System.Windows.Forms.Panel();
            this.buttonXemDanhSach = new System.Windows.Forms.Button();
            this.buttonTimKiem = new System.Windows.Forms.PictureBox();
            this.textBoxTimKiem = new System.Windows.Forms.TextBox();
            this.buttonXacNhan = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            this.panel2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panel3.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTimKiem)).BeginInit();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.Controls.Add(this.panel2);
            this.panel1.Controls.Add(this.panel3);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(916, 583);
            this.panel1.TabIndex = 1;
            // 
            // panel2
            // 
            this.panel2.AutoScroll = true;
            this.panel2.Controls.Add(this.DGV);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(916, 536);
            this.panel2.TabIndex = 3;
            // 
            // DGV
            // 
            this.DGV.AutoSizeColumnsMode = System.Windows.Forms.DataGridViewAutoSizeColumnsMode.Fill;
            this.DGV.AutoSizeRowsMode = System.Windows.Forms.DataGridViewAutoSizeRowsMode.AllCells;
            this.DGV.BackgroundColor = System.Drawing.Color.White;
            this.DGV.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.DGV.Dock = System.Windows.Forms.DockStyle.Fill;
            this.DGV.GridColor = System.Drawing.Color.White;
            this.DGV.Location = new System.Drawing.Point(0, 0);
            this.DGV.Name = "DGV";
            this.DGV.RowHeadersWidth = 51;
            this.DGV.RowTemplate.Height = 24;
            this.DGV.Size = new System.Drawing.Size(916, 536);
            this.DGV.TabIndex = 0;
            this.DGV.CellContentClick += new System.Windows.Forms.DataGridViewCellEventHandler(this.DGV_CellContentClick);
            // 
            // panel3
            // 
            this.panel3.Controls.Add(this.buttonXemDanhSach);
            this.panel3.Controls.Add(this.buttonTimKiem);
            this.panel3.Controls.Add(this.textBoxTimKiem);
            this.panel3.Controls.Add(this.buttonXacNhan);
            this.panel3.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel3.Location = new System.Drawing.Point(0, 536);
            this.panel3.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.panel3.Name = "panel3";
            this.panel3.Size = new System.Drawing.Size(916, 47);
            this.panel3.TabIndex = 2;
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
            this.buttonXemDanhSach.Location = new System.Drawing.Point(12, 8);
            this.buttonXemDanhSach.Name = "buttonXemDanhSach";
            this.buttonXemDanhSach.Size = new System.Drawing.Size(162, 30);
            this.buttonXemDanhSach.TabIndex = 5;
            this.buttonXemDanhSach.Text = "Xem danh sách";
            this.buttonXemDanhSach.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonXemDanhSach.UseVisualStyleBackColor = true;
            this.buttonXemDanhSach.Click += new System.EventHandler(this.buttonXemDanhSach_Click);
            // 
            // buttonTimKiem
            // 
            this.buttonTimKiem.Cursor = System.Windows.Forms.Cursors.Hand;
            this.buttonTimKiem.Image = global::TramYTe.Properties.Resources.search;
            this.buttonTimKiem.Location = new System.Drawing.Point(453, 14);
            this.buttonTimKiem.Name = "buttonTimKiem";
            this.buttonTimKiem.Size = new System.Drawing.Size(22, 22);
            this.buttonTimKiem.SizeMode = System.Windows.Forms.PictureBoxSizeMode.Zoom;
            this.buttonTimKiem.TabIndex = 16;
            this.buttonTimKiem.TabStop = false;
            this.buttonTimKiem.Click += new System.EventHandler(this.buttonTimKiem_Click);
            // 
            // textBoxTimKiem
            // 
            this.textBoxTimKiem.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.textBoxTimKiem.Location = new System.Drawing.Point(180, 11);
            this.textBoxTimKiem.Name = "textBoxTimKiem";
            this.textBoxTimKiem.Size = new System.Drawing.Size(267, 27);
            this.textBoxTimKiem.TabIndex = 15;
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
            this.buttonXacNhan.Location = new System.Drawing.Point(780, 8);
            this.buttonXacNhan.Name = "buttonXacNhan";
            this.buttonXacNhan.Size = new System.Drawing.Size(117, 30);
            this.buttonXacNhan.TabIndex = 14;
            this.buttonXacNhan.Text = "Xác nhận";
            this.buttonXacNhan.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonXacNhan.UseVisualStyleBackColor = true;
            this.buttonXacNhan.Click += new System.EventHandler(this.buttonXacNhan_Click);
            // 
            // SuaHoGiaDinh
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(916, 583);
            this.Controls.Add(this.panel1);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedToolWindow;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "SuaHoGiaDinh";
            this.Text = "Sửa hộ gia đình";
            this.Load += new System.EventHandler(this.SuaHoGiaDinh_Load);
            this.panel1.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panel3.ResumeLayout(false);
            this.panel3.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.buttonTimKiem)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panel3;
        private System.Windows.Forms.Button buttonXemDanhSach;
        private System.Windows.Forms.PictureBox buttonTimKiem;
        private System.Windows.Forms.TextBox textBoxTimKiem;
        private System.Windows.Forms.Button buttonXacNhan;
    }
}