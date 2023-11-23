using MsSqlManagerLibrary;
using System;
using System.Drawing;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace K5EE_Equipment_Client
{
    public enum Page
    {
        AllPage = 0,
        FTCSPage,
        PSCSPage,        
    }

    public partial class MainForm : Form
    {
        AllEquipmentForm m_allEquipmentForm;
        FTCSForm m_FTCSForm;
        PSCSForm m_PSCSForm;

        byte iPageNum;

        private Timer displayTimer = new Timer();        

        public MainForm()
        {
            InitializeComponent();

            SubFormCreate();
        }

        private void MainForm_Load(object sender, EventArgs e)
        {           
            displayTimer.Interval = 100;
            displayTimer.Elapsed += new ElapsedEventHandler(_Display);
            displayTimer.Start();

            SubFormShow((byte)Page.AllPage);

            string strRtn = HostConnection.Connect();
            if (strRtn != "OK")
            {
                MessageBox.Show("EE 서버 접속에 실패했습니다", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void MainForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            displayTimer.Stop();
            Dispose();
        }

        private void SubFormCreate()
        {
            m_allEquipmentForm = new AllEquipmentForm();
            m_allEquipmentForm.MdiParent = this;
            m_allEquipmentForm.Dock = DockStyle.Fill;
            m_allEquipmentForm.Show();

            m_FTCSForm = new FTCSForm();
            m_FTCSForm.MdiParent = this;
            m_FTCSForm.Dock = DockStyle.Fill;
            m_FTCSForm.Show();

            m_PSCSForm = new PSCSForm();
            m_PSCSForm.MdiParent = this;
            m_PSCSForm.Dock = DockStyle.Fill;
            m_PSCSForm.Show();
        }

        public void SubFormShow(byte PageNum)
        {
            try
            {
                iPageNum = PageNum;

                switch (PageNum)
                {
                    case (byte)Page.AllPage:
                        {
                            m_allEquipmentForm.Activate();
                            m_allEquipmentForm.BringToFront();
                        }
                        break;

                    case (byte)Page.FTCSPage:
                        {
                            m_FTCSForm.Activate();
                            m_FTCSForm.BringToFront();                            
                        }
                        break;

                    case (byte)Page.PSCSPage:
                        {
                            m_PSCSForm.Activate();
                            m_PSCSForm.BringToFront();                            
                        }
                        break;
                }
            }
            catch
            {
                MessageBox.Show("폼 양식을 가져오는 도중 오류가 발생했습니다.", "Notification", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void _Display(object sender, ElapsedEventArgs e)
        {
            if (laDate.InvokeRequired)
            {
                laDate.BeginInvoke(new MethodInvoker(delegate
                {
                    laDate.Text = DateTime.Today.ToShortDateString();
                    laTime.Text = DateTime.Now.ToLongTimeString();

                    if (iPageNum == (byte)Page.AllPage)
                    {
                        btnAll.BackColor = Color.FromArgb(46, 51, 73);
                        btnFTCS.BackColor = Color.FromArgb(24, 30, 54);
                        btnPSCS.BackColor = Color.FromArgb(24, 30, 54);                        

                        panelAllnavi.BackColor = Color.Aqua;
                        panelFTCSnavi.BackColor = Color.FromArgb(24, 30, 54);
                        panelPSCSnavi.BackColor = Color.FromArgb(24, 30, 54);                        
                    }
                    else if (iPageNum == (byte)Page.FTCSPage)
                    {
                        btnAll.BackColor = Color.FromArgb(24, 30, 54);
                        btnFTCS.BackColor = Color.FromArgb(46, 51, 73);
                        btnPSCS.BackColor = Color.FromArgb(24, 30, 54);                        

                        panelAllnavi.BackColor = Color.FromArgb(24, 30, 54);
                        panelFTCSnavi.BackColor = Color.Aqua;
                        panelPSCSnavi.BackColor = Color.FromArgb(24, 30, 54);                        
                    }
                    else if (iPageNum == (byte)Page.PSCSPage)
                    {
                        btnAll.BackColor = Color.FromArgb(24, 30, 54);
                        btnFTCS.BackColor = Color.FromArgb(24, 30, 54);
                        btnPSCS.BackColor = Color.FromArgb(46, 51, 73);                        

                        panelAllnavi.BackColor = Color.FromArgb(24, 30, 54);
                        panelFTCSnavi.BackColor = Color.FromArgb(24, 30, 54);
                        panelPSCSnavi.BackColor = Color.Aqua;                        
                    }
                    else
                    {
                        btnAll.BackColor = Color.FromArgb(24, 30, 54);
                        btnFTCS.BackColor = Color.FromArgb(24, 30, 54);
                        btnPSCS.BackColor = Color.FromArgb(24, 30, 54);                        

                        panelAllnavi.BackColor = Color.FromArgb(24, 30, 54);
                        panelFTCSnavi.BackColor = Color.FromArgb(24, 30, 54);
                        panelPSCSnavi.BackColor = Color.FromArgb(24, 30, 54);                        
                    }
                }));
            }
        }

        private void btnAll_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.AllPage);
        }

        private void btnFTCS_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.FTCSPage);
        }

        private void btnPSCS_Click(object sender, EventArgs e)
        {
            SubFormShow((byte)Page.PSCSPage);
        }

        private void btnExit_Click(object sender, EventArgs e)
        {            
            if (MessageBox.Show("프로그램을 종료 하겠습니까?", "Notifications", MessageBoxButtons.OKCancel, MessageBoxIcon.Question) == DialogResult.OK)
            {
                Dispose();
                //Application.Exit();
                Application.ExitThread();
                Environment.Exit(0);
            }            
        }
    }
}
