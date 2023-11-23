
namespace K5EE_Equipment_Client
{
    partial class MainForm
    {
        /// <summary>
        /// 필수 디자이너 변수입니다.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// 사용 중인 모든 리소스를 정리합니다.
        /// </summary>
        /// <param name="disposing">관리되는 리소스를 삭제해야 하면 true이고, 그렇지 않으면 false입니다.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form 디자이너에서 생성한 코드

        /// <summary>
        /// 디자이너 지원에 필요한 메서드입니다. 
        /// 이 메서드의 내용을 코드 편집기로 수정하지 마세요.
        /// </summary>
        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MainForm));
            this.panel2 = new System.Windows.Forms.Panel();
            this.btnExit = new System.Windows.Forms.Button();
            this.panelAllnavi = new System.Windows.Forms.Panel();
            this.btnAll = new System.Windows.Forms.Button();
            this.panelPSCSnavi = new System.Windows.Forms.Panel();
            this.panelFTCSnavi = new System.Windows.Forms.Panel();
            this.btnPSCS = new System.Windows.Forms.Button();
            this.btnFTCS = new System.Windows.Forms.Button();
            this.panel1 = new System.Windows.Forms.Panel();
            this.laTime = new System.Windows.Forms.Label();
            this.laDate = new System.Windows.Forms.Label();
            this.labelPjtName = new System.Windows.Forms.Label();
            this.panel2.SuspendLayout();
            this.panel1.SuspendLayout();
            this.SuspendLayout();
            // 
            // panel2
            // 
            this.panel2.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel2.Controls.Add(this.btnExit);
            this.panel2.Controls.Add(this.panelAllnavi);
            this.panel2.Controls.Add(this.btnAll);
            this.panel2.Controls.Add(this.panelPSCSnavi);
            this.panel2.Controls.Add(this.panelFTCSnavi);
            this.panel2.Controls.Add(this.btnPSCS);
            this.panel2.Controls.Add(this.btnFTCS);
            this.panel2.Dock = System.Windows.Forms.DockStyle.Left;
            this.panel2.Location = new System.Drawing.Point(0, 100);
            this.panel2.Name = "panel2";
            this.panel2.Size = new System.Drawing.Size(200, 941);
            this.panel2.TabIndex = 18;
            // 
            // btnExit
            // 
            this.btnExit.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnExit.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnExit.FlatAppearance.BorderSize = 0;
            this.btnExit.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnExit.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnExit.ForeColor = System.Drawing.Color.White;
            this.btnExit.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnExit.ImageIndex = 0;
            this.btnExit.Location = new System.Drawing.Point(21, 887);
            this.btnExit.Name = "btnExit";
            this.btnExit.Size = new System.Drawing.Size(179, 42);
            this.btnExit.TabIndex = 23;
            this.btnExit.Tag = "";
            this.btnExit.Text = "EXIT";
            this.btnExit.UseVisualStyleBackColor = false;
            this.btnExit.Click += new System.EventHandler(this.btnExit_Click);
            // 
            // panelAllnavi
            // 
            this.panelAllnavi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelAllnavi.Location = new System.Drawing.Point(3, 164);
            this.panelAllnavi.Name = "panelAllnavi";
            this.panelAllnavi.Size = new System.Drawing.Size(12, 42);
            this.panelAllnavi.TabIndex = 22;
            // 
            // btnAll
            // 
            this.btnAll.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnAll.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnAll.FlatAppearance.BorderSize = 0;
            this.btnAll.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnAll.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAll.ForeColor = System.Drawing.Color.White;
            this.btnAll.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnAll.ImageIndex = 0;
            this.btnAll.Location = new System.Drawing.Point(21, 164);
            this.btnAll.Name = "btnAll";
            this.btnAll.Size = new System.Drawing.Size(179, 42);
            this.btnAll.TabIndex = 21;
            this.btnAll.Tag = "";
            this.btnAll.Text = "ALL";
            this.btnAll.UseVisualStyleBackColor = false;
            this.btnAll.Click += new System.EventHandler(this.btnAll_Click);
            // 
            // panelPSCSnavi
            // 
            this.panelPSCSnavi.Location = new System.Drawing.Point(3, 260);
            this.panelPSCSnavi.Name = "panelPSCSnavi";
            this.panelPSCSnavi.Size = new System.Drawing.Size(12, 42);
            this.panelPSCSnavi.TabIndex = 20;
            // 
            // panelFTCSnavi
            // 
            this.panelFTCSnavi.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panelFTCSnavi.Location = new System.Drawing.Point(3, 212);
            this.panelFTCSnavi.Name = "panelFTCSnavi";
            this.panelFTCSnavi.Size = new System.Drawing.Size(12, 42);
            this.panelFTCSnavi.TabIndex = 19;
            // 
            // btnPSCS
            // 
            this.btnPSCS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnPSCS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnPSCS.FlatAppearance.BorderSize = 0;
            this.btnPSCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnPSCS.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnPSCS.ForeColor = System.Drawing.Color.White;
            this.btnPSCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnPSCS.ImageIndex = 0;
            this.btnPSCS.Location = new System.Drawing.Point(21, 260);
            this.btnPSCS.Name = "btnPSCS";
            this.btnPSCS.Size = new System.Drawing.Size(179, 42);
            this.btnPSCS.TabIndex = 18;
            this.btnPSCS.Tag = "";
            this.btnPSCS.Text = "PKG SAW";
            this.btnPSCS.UseVisualStyleBackColor = false;
            this.btnPSCS.Click += new System.EventHandler(this.btnPSCS_Click);
            // 
            // btnFTCS
            // 
            this.btnFTCS.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.btnFTCS.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            this.btnFTCS.FlatAppearance.BorderSize = 0;
            this.btnFTCS.FlatStyle = System.Windows.Forms.FlatStyle.Flat;
            this.btnFTCS.Font = new System.Drawing.Font("Nirmala UI", 15.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnFTCS.ForeColor = System.Drawing.Color.White;
            this.btnFTCS.ImageAlign = System.Drawing.ContentAlignment.MiddleLeft;
            this.btnFTCS.ImageIndex = 0;
            this.btnFTCS.Location = new System.Drawing.Point(21, 212);
            this.btnFTCS.Name = "btnFTCS";
            this.btnFTCS.Size = new System.Drawing.Size(179, 42);
            this.btnFTCS.TabIndex = 17;
            this.btnFTCS.Tag = "";
            this.btnFTCS.Text = "FLUX TOOL";
            this.btnFTCS.UseVisualStyleBackColor = false;
            this.btnFTCS.Click += new System.EventHandler(this.btnFTCS_Click);
            // 
            // panel1
            // 
            this.panel1.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(24)))), ((int)(((byte)(30)))), ((int)(((byte)(54)))));
            this.panel1.Controls.Add(this.laTime);
            this.panel1.Controls.Add(this.laDate);
            this.panel1.Controls.Add(this.labelPjtName);
            this.panel1.Dock = System.Windows.Forms.DockStyle.Top;
            this.panel1.Location = new System.Drawing.Point(0, 0);
            this.panel1.Name = "panel1";
            this.panel1.Size = new System.Drawing.Size(1904, 100);
            this.panel1.TabIndex = 17;
            // 
            // laTime
            // 
            this.laTime.AutoSize = true;
            this.laTime.BackColor = System.Drawing.Color.Transparent;
            this.laTime.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laTime.ForeColor = System.Drawing.SystemColors.Window;
            this.laTime.Location = new System.Drawing.Point(1784, 59);
            this.laTime.Name = "laTime";
            this.laTime.Size = new System.Drawing.Size(88, 25);
            this.laTime.TabIndex = 30;
            this.laTime.Text = "00:00:00";
            // 
            // laDate
            // 
            this.laDate.AutoSize = true;
            this.laDate.BackColor = System.Drawing.Color.Transparent;
            this.laDate.Font = new System.Drawing.Font("Nirmala UI", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.laDate.ForeColor = System.Drawing.SystemColors.Window;
            this.laDate.Location = new System.Drawing.Point(1784, 28);
            this.laDate.Name = "laDate";
            this.laDate.Size = new System.Drawing.Size(110, 25);
            this.laDate.TabIndex = 29;
            this.laDate.Text = "0000.00.00";
            // 
            // labelPjtName
            // 
            this.labelPjtName.BackColor = System.Drawing.Color.Transparent;
            this.labelPjtName.Font = new System.Drawing.Font("Nirmala UI", 21.75F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.labelPjtName.ForeColor = System.Drawing.Color.White;
            this.labelPjtName.Location = new System.Drawing.Point(540, 28);
            this.labelPjtName.Name = "labelPjtName";
            this.labelPjtName.Size = new System.Drawing.Size(833, 42);
            this.labelPjtName.TabIndex = 15;
            this.labelPjtName.Text = "K5EE Equipment client";
            this.labelPjtName.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1904, 1041);
            this.Controls.Add(this.panel2);
            this.Controls.Add(this.panel1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.IsMdiContainer = true;
            this.Name = "MainForm";
            this.Text = "K5EE Equipment Client";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainForm_FormClosing);
            this.Load += new System.EventHandler(this.MainForm_Load);
            this.panel2.ResumeLayout(false);
            this.panel1.ResumeLayout(false);
            this.panel1.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Panel panel2;
        private System.Windows.Forms.Button btnFTCS;
        private System.Windows.Forms.Panel panel1;
        public System.Windows.Forms.Label laTime;
        public System.Windows.Forms.Label laDate;
        private System.Windows.Forms.Label labelPjtName;
        private System.Windows.Forms.Button btnPSCS;
        private System.Windows.Forms.Panel panelPSCSnavi;
        private System.Windows.Forms.Panel panelFTCSnavi;
        private System.Windows.Forms.Panel panelAllnavi;
        private System.Windows.Forms.Button btnAll;
        private System.Windows.Forms.Button btnExit;
    }
}

