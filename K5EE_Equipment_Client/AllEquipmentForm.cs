using MsSqlManagerLibrary;
using System;
using System.Drawing;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using Timer = System.Timers.Timer;

namespace K5EE_Equipment_Client
{
    public partial class AllEquipmentForm : Form
    {
        private Timer displayTimer = new Timer();

        string hostEquipment_FTCS = "K5EE_FluxtoolCleaningSystem";
        string hostEquipment_PSCS = "K5EE_PkgsawCleaningSystem";

        public AllEquipmentForm()
        {
            InitializeComponent();
        }

        private void AllEquipmentForm_Load(object sender, EventArgs e)
        {           
            displayTimer.Interval = 1000;
            displayTimer.Elapsed += new ElapsedEventHandler(_Display);
            displayTimer.Start();
        }

        private void AllEquipmentForm_Activated(object sender, EventArgs e)
        {
            SetDoubleBuffered(panelFTCS);
            SetDoubleBuffered(panelPSCS);
        }

        private void AllEquipmentForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            Dispose();
        }

        private void SetDoubleBuffered(Control control, bool doubleBuffered = true)
        {
            PropertyInfo propertyInfo = typeof(Control).GetProperty
            (
                "DoubleBuffered",
                BindingFlags.Instance | BindingFlags.NonPublic
            );
            propertyInfo.SetValue(control, doubleBuffered, null);
        }

        private void _Display(object sender, ElapsedEventArgs e)
        {
            // Flux tool cleaning system
            if (panelFTCS_PM1RunStatus.InvokeRequired)
            {
                panelFTCS_PM1RunStatus.BeginInvoke(new MethodInvoker(delegate
                {
                    // PM1
                    string strFTCSPM1RunStatus = HostConnection.Host_Get_RunStatus(hostEquipment_FTCS, "PM1");
                    strFTCSPM1RunStatus = strFTCSPM1RunStatus.Trim();
                    if (strFTCSPM1RunStatus == "Idle")
                    {
                        if (panelFTCS_PM1RunStatus.BackColor != Color.Yellow)
                            panelFTCS_PM1RunStatus.BackColor = Color.Yellow;
                    }
                    else if (strFTCSPM1RunStatus == "Process")
                    {
                        if (panelFTCS_PM1RunStatus.BackColor != Color.Lime)
                            panelFTCS_PM1RunStatus.BackColor = Color.Lime;
                    }
                    else if (strFTCSPM1RunStatus == "Alarm")
                    {
                        if (panelFTCS_PM1RunStatus.BackColor != Color.Red)
                            panelFTCS_PM1RunStatus.BackColor = Color.Red;
                    }
                    else
                    {
                        if (panelFTCS_PM1RunStatus.BackColor != Color.Silver)
                            panelFTCS_PM1RunStatus.BackColor = Color.Silver;
                    }

                    string strFTCSPM1RecipeName = HostConnection.Host_Get_RecipeName(hostEquipment_FTCS, "PM1");
                    if ((strFTCSPM1RecipeName == null) || (strFTCSPM1RecipeName == ""))
                        labelFTCS_PM1RecipeName.Text = "--";
                    else
                        labelFTCS_PM1RecipeName.Text = strFTCSPM1RecipeName;

                    string strFTCSPM1Progress = HostConnection.Host_Get_ProgressTime(hostEquipment_FTCS, "PM1");
                    strFTCSPM1Progress = strFTCSPM1Progress.Trim();
                    if ((strFTCSPM1Progress == null) || (strFTCSPM1Progress == ""))
                        labelFTCS_PM1Progress.Text = "--";
                    else
                        labelFTCS_PM1Progress.Text = strFTCSPM1Progress;
                    

                    // PM2
                    string strFTCSPM2RunStatus = HostConnection.Host_Get_RunStatus(hostEquipment_FTCS, "PM2");
                    strFTCSPM2RunStatus = strFTCSPM2RunStatus.Trim();
                    if (strFTCSPM2RunStatus == "Idle")
                    {
                        if (panelFTCS_PM2RunStatus.BackColor != Color.Yellow)
                            panelFTCS_PM2RunStatus.BackColor = Color.Yellow;
                    }
                    else if (strFTCSPM2RunStatus == "Process")
                    {
                        if (panelFTCS_PM2RunStatus.BackColor != Color.Lime)
                            panelFTCS_PM2RunStatus.BackColor = Color.Lime;
                    }
                    else if (strFTCSPM2RunStatus == "Alarm")
                    {
                        if (panelFTCS_PM2RunStatus.BackColor != Color.Red)
                            panelFTCS_PM2RunStatus.BackColor = Color.Red;
                    }
                    else
                    {
                        if (panelFTCS_PM2RunStatus.BackColor != Color.Silver)
                            panelFTCS_PM2RunStatus.BackColor = Color.Silver;
                    }

                    string strFTCSPM2RecipeName = HostConnection.Host_Get_RecipeName(hostEquipment_FTCS, "PM2");
                    if ((strFTCSPM2RecipeName == null) || (strFTCSPM2RecipeName == ""))
                        labelFTCS_PM2RecipeName.Text = "--";
                    else
                        labelFTCS_PM2RecipeName.Text = strFTCSPM2RecipeName;

                    string strFTCSPM2Progress = HostConnection.Host_Get_ProgressTime(hostEquipment_FTCS, "PM2");
                    strFTCSPM2Progress = strFTCSPM2Progress.Trim();
                    if ((strFTCSPM2Progress == null) || (strFTCSPM2Progress == ""))
                        labelFTCS_PM2Progress.Text = "--";
                    else
                        labelFTCS_PM2Progress.Text = strFTCSPM2Progress;                    


                    // PM3
                    string strFTCSPM3RunStatus = HostConnection.Host_Get_RunStatus(hostEquipment_FTCS, "PM3");
                    strFTCSPM3RunStatus = strFTCSPM3RunStatus.Trim();
                    if (strFTCSPM3RunStatus == "Idle")
                    {
                        if (panelFTCS_PM3RunStatus.BackColor != Color.Yellow)
                            panelFTCS_PM3RunStatus.BackColor = Color.Yellow;
                    }
                    else if (strFTCSPM3RunStatus == "Process")
                    {
                        if (panelFTCS_PM3RunStatus.BackColor != Color.Lime)
                            panelFTCS_PM3RunStatus.BackColor = Color.Lime;
                    }
                    else if (strFTCSPM3RunStatus == "Alarm")
                    {
                        if (panelFTCS_PM3RunStatus.BackColor != Color.Red)
                            panelFTCS_PM3RunStatus.BackColor = Color.Red;
                    }
                    else
                    {
                        if (panelFTCS_PM3RunStatus.BackColor != Color.Silver)
                            panelFTCS_PM3RunStatus.BackColor = Color.Silver;
                    }

                    string strFTCSPM3RecipeName = HostConnection.Host_Get_RecipeName(hostEquipment_FTCS, "PM3");
                    if ((strFTCSPM3RecipeName == null) || (strFTCSPM3RecipeName == ""))
                        labelFTCS_PM3RecipeName.Text = "--";
                    else
                        labelFTCS_PM3RecipeName.Text = strFTCSPM3RecipeName;

                    string strFTCSPM3Progress = HostConnection.Host_Get_ProgressTime(hostEquipment_FTCS, "PM3");
                    strFTCSPM3Progress = strFTCSPM3Progress.Trim();
                    if ((strFTCSPM3Progress == null) || (strFTCSPM3Progress == ""))
                        labelFTCS_PM3Progress.Text = "--";
                    else
                        labelFTCS_PM3Progress.Text = strFTCSPM3Progress;                    
                }));
            }

            
            // Pkg saw-kit cleaning system
            if (panelPSCS_PM1RunStatus.InvokeRequired)
            {
                panelPSCS_PM1RunStatus.BeginInvoke(new MethodInvoker(delegate
                {
                    // PM1
                    string strPSCSPM1RunStatus = HostConnection.Host_Get_RunStatus(hostEquipment_PSCS, "PM1");
                    strPSCSPM1RunStatus = strPSCSPM1RunStatus.Trim();
                    if (strPSCSPM1RunStatus == "Idle")
                    {
                        if (panelPSCS_PM1RunStatus.BackColor != Color.Yellow)
                            panelPSCS_PM1RunStatus.BackColor = Color.Yellow;
                    }
                    else if (strPSCSPM1RunStatus == "Process")
                    {
                        if (panelPSCS_PM1RunStatus.BackColor != Color.Lime)
                            panelPSCS_PM1RunStatus.BackColor = Color.Lime;
                    }
                    else if (strPSCSPM1RunStatus == "Alarm")
                    {
                        if (panelPSCS_PM1RunStatus.BackColor != Color.Red)
                            panelPSCS_PM1RunStatus.BackColor = Color.Red;
                    }
                    else
                    {
                        if (panelPSCS_PM1RunStatus.BackColor != Color.Silver)
                            panelPSCS_PM1RunStatus.BackColor = Color.Silver;
                    }

                    string strPSCSPM1RecipeName = HostConnection.Host_Get_RecipeName(hostEquipment_PSCS, "PM1");
                    if ((strPSCSPM1RecipeName == null) || (strPSCSPM1RecipeName == ""))
                        labelPSCS_PM1RecipeName.Text = "--";
                    else
                        labelPSCS_PM1RecipeName.Text = strPSCSPM1RecipeName;

                    string strPSCSPM1Progress = HostConnection.Host_Get_ProgressTime(hostEquipment_PSCS, "PM1");
                    strPSCSPM1Progress = strPSCSPM1Progress.Trim();
                    if ((strPSCSPM1Progress == null) || (strPSCSPM1Progress == ""))
                        labelPSCS_PM1Progress.Text = "--";
                    else
                        labelPSCS_PM1Progress.Text = strPSCSPM1Progress;


                    // PM2
                    
                    string strPSCSPM2RunStatus = HostConnection.Host_Get_RunStatus(hostEquipment_PSCS, "PM2");
                    strPSCSPM2RunStatus = strPSCSPM2RunStatus.Trim();
                    if (strPSCSPM2RunStatus == "Idle")
                    {
                        if (panelPSCS_PM2RunStatus.BackColor != Color.Yellow)
                            panelPSCS_PM2RunStatus.BackColor = Color.Yellow;
                    }
                    else if (strPSCSPM2RunStatus == "Process")
                    {
                        if (panelPSCS_PM2RunStatus.BackColor != Color.Lime)
                            panelPSCS_PM2RunStatus.BackColor = Color.Lime;
                    }
                    else if (strPSCSPM2RunStatus == "Alarm")
                    {
                        if (panelPSCS_PM2RunStatus.BackColor != Color.Red)
                            panelPSCS_PM2RunStatus.BackColor = Color.Red;
                    }
                    else
                    {
                        if (panelPSCS_PM2RunStatus.BackColor != Color.Silver)
                            panelPSCS_PM2RunStatus.BackColor = Color.Silver;
                    }

                    string strPSCSPM2RecipeName = HostConnection.Host_Get_RecipeName(hostEquipment_PSCS, "PM2");
                    if ((strPSCSPM2RecipeName == null) || (strPSCSPM2RecipeName == ""))
                        labelPSCS_PM2RecipeName.Text = "--";
                    else
                        labelPSCS_PM2RecipeName.Text = strPSCSPM2RecipeName;

                    string strPSCSPM2Progress = HostConnection.Host_Get_ProgressTime(hostEquipment_PSCS, "PM2");
                    strPSCSPM2Progress = strPSCSPM2Progress.Trim();
                    if ((strPSCSPM2Progress == null) || (strPSCSPM2Progress == ""))
                        labelPSCS_PM2Progress.Text = "--";
                    else
                        labelPSCS_PM2Progress.Text = strPSCSPM2Progress;  
                }));                   
            }
        }                
    }
}
