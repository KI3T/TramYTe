
namespace TramYTe.AdminMain
{
    partial class ChamSocTreEm
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
            this.DGV = new System.Windows.Forms.DataGridView();
            this.panelChamSocTreEm = new System.Windows.Forms.Panel();
            this.panel2 = new System.Windows.Forms.Panel();
            this.buttonBeoPhi = new System.Windows.Forms.Button();
            this.buttonKhoeManh = new System.Windows.Forms.Button();
            this.buttonSuyDinhDuong = new System.Windows.Forms.Button();
            this.panel1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).BeginInit();
            this.panelChamSocTreEm.SuspendLayout();
            this.panel2.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel1
            // 
            this.panel1.AutoScroll = true;
            this.panel1.Controls.Add(this.DGV);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Bottom;
            this.panel1.Location = new System.Drawing.Point(0, 77);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1298, 668);
            this.panel1.TabIndex = 0;
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
            this.DGV.Size = new System.Drawing.Size(1298, 668);
            this.DGV.TabIndex = 0;
            // 
            // panelChamSocTreEm
            // 
            this.panelChamSocTreEm.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelChamSocTreEm.Controls.Add(this.panel2);
            this.panelChamSocTreEm.Controls.Add(this.panel1);
            this.panelChamSocTreEm.Dock = System.Windows.Forms.DockStyle.Fill;
            this.panelChamSocTreEm.Location = new System.Drawing.Point(0, 0);
            this.panelChamSocTreEm.Name = "panelChamSocTreEm";
            this.panelChamSocTreEm.Size = new System.Drawing.Size(1300, 747);
            this.panelChamSocTreEm.TabIndex = 3;
            // 
            // panel2
            // 
            this.panel2.Controls.Add(this.buttonBeoPhi);
            this.panel2.Controls.Add(this.buttonKhoeManh);
            this.panel2.Controls.Add(this.buttonSuyDinhDuong);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel2.Location = new System.Drawing.Point(0, 0);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(1298, 73);
            this.panel2.TabIndex = 1;
            // 
            // buttonBeoPhi
            // 
            this.buttonBeoPhi.FlatAppearance.BorderSize = 0;
            this.buttonBeoPhi.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonBeoPhi.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonBeoPhi.Image = global::TramYTe.Properties.Resources.BeoPhi;
            this.buttonBeoPhi.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonBeoPhi.Location = new System.Drawing.Point(710, 6);
            this.buttonBeoPhi.Name = "buttonBeoPhi";
            this.buttonBeoPhi.Size = new System.Drawing.Size(156, 59);
            this.buttonBeoPhi.TabIndex = 2;
            this.buttonBeoPhi.Text = "Trẻ béo phì";
            this.buttonBeoPhi.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonBeoPhi.UseVisualStyleBackColor = true;
            this.buttonBeoPhi.Click += new System.EventHandler(this.buttonBeoPhi_Click);
            // 
            // buttonKhoeManh
            // 
            this.buttonKhoeManh.FlatAppearance.BorderSize = 0;
            this.buttonKhoeManh.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonKhoeManh.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonKhoeManh.Image = global::TramYTe.Properties.Resources.KhoeManh;
            this.buttonKhoeManh.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonKhoeManh.Location = new System.Drawing.Point(400, 6);
            this.buttonKhoeManh.Name = "buttonKhoeManh";
            this.buttonKhoeManh.Size = new System.Drawing.Size(186, 59);
            this.buttonKhoeManh.TabIndex = 1;
            this.buttonKhoeManh.Text = "Trẻ khoẻ mạnh";
            this.buttonKhoeManh.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonKhoeManh.UseVisualStyleBackColor = true;
            this.buttonKhoeManh.Click += new System.EventHandler(this.buttonKhoeManh_Click);
            // 
            // buttonSuyDinhDuong
            // 
            this.buttonSuyDinhDuong.FlatAppearance.BorderSize = 0;
            this.buttonSuyDinhDuong.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.buttonSuyDinhDuong.Font = new System.Drawing.Font("Segoe UI", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.buttonSuyDinhDuong.Image = global::TramYTe.Properties.Resources.SuyDinhDuong;
            this.buttonSuyDinhDuong.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.buttonSuyDinhDuong.Location = new System.Drawing.Point(48, 6);
            this.buttonSuyDinhDuong.Name = "buttonSuyDinhDuong";
            this.buttonSuyDinhDuong.Size = new System.Drawing.Size(226, 59);
            this.buttonSuyDinhDuong.TabIndex = 0;
            this.buttonSuyDinhDuong.Text = "Trẻ suy dinh dưỡng";
            this.buttonSuyDinhDuong.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            this.buttonSuyDinhDuong.UseVisualStyleBackColor = true;
            this.buttonSuyDinhDuong.Click += new System.EventHandler(this.buttonSuyDinhDuong_Click);
            // 
            // ChamSocTreEm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.White;
            this.ClientSize = new System.Drawing.Size(1300, 747);
            this.Controls.Add(this.panelChamSocTreEm);
            this.Font = new System.Drawing.Font("Segoe UI", 9F);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Margin = new System.Windows.Forms.Padding(3, 4, 3, 4);
            this.Name = "ChamSocTreEm";
            this.Text = "ChamSocTreEm";
            this.panel1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.DGV)).EndInit();
            this.panelChamSocTreEm.ResumeLayout(false);
            this.panel2.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel1;
        private System.Windows.Forms.DataGridView DGV;
        private System.Windows.Forms.Panel panelChamSocTreEm;
        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button buttonSuyDinhDuong;
        private System.Windows.Forms.Button buttonKhoeManh;
        private System.Windows.Forms.Button buttonBeoPhi;
    }
}