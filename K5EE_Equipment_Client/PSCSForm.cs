using MsSqlManagerLibrary;
using System;
using System.Data;
using System.Drawing;
using System.Reflection;
using System.Timers;
using System.Windows.Forms;
using Excel = Microsoft.Office.Interop.Excel;
using Timer = System.Timers.Timer;

namespace K5EE_Equipment_Client
{
    public partial class PSCSForm : Form
    {
        private Timer displayTimer = new Timer();

        string hostEquipmentInfo = "K5EE_PkgsawCleaningSystem";
        string hostEquipmentInfo_Log = "K5EE_PkgsawCleaningSystemLog";

        string[] strArray = new string[7];

        public PSCSForm()
        {
            InitializeComponent();
        }

        private void PSCSForm_Load(object sender, EventArgs e)
        {
            chartPM1DailyCount.ChartAreas[0].AxisX.Minimum = 1;
            chartPM1DailyCount.ChartAreas[0].AxisX.Maximum = 31;
            chartPM1DailyCount.ChartAreas[0].AxisY.Minimum = 0;
            chartPM1DailyCount.ChartAreas[0].AxisY.Maximum = 30;
            chartPM1DailyCount.ChartAreas[0].AxisY.Interval = 5;
            chartPM1DailyCount.Series["CH1 Daily"].BorderWidth = 1;

            chartPM2DailyCount.ChartAreas[0].AxisX.Minimum = 1;
            chartPM2DailyCount.ChartAreas[0].AxisX.Maximum = 31;
            chartPM2DailyCount.ChartAreas[0].AxisY.Minimum = 0;
            chartPM2DailyCount.ChartAreas[0].AxisY.Maximum = 30;
            chartPM2DailyCount.ChartAreas[0].AxisY.Interval = 5;
            chartPM2DailyCount.Series["CH2 Daily"].BorderWidth = 1;
            
            chartUtilization.ChartAreas[0].AxisX.Minimum = 1;
            chartUtilization.ChartAreas[0].AxisX.Maximum = 31;
            chartUtilization.ChartAreas[0].AxisY.Minimum = 0;
            chartUtilization.ChartAreas[0].AxisY.Maximum = 30;
            chartUtilization.ChartAreas[0].AxisY.Interval = 5;
            chartUtilization.Series["Utilization(%)"].BorderWidth = 1;
            chartUtilization.Series["Utilization(%)"].Color = Color.BlueViolet;

            displayTimer.Interval = 1000;
            displayTimer.Elapsed += new ElapsedEventHandler(_Display);
            displayTimer.Start();
        }

        private void PSCSForm_Activated(object sender, EventArgs e)
        {
            SetDoubleBuffered(chartPM1DailyCount);
            SetDoubleBuffered(chartPM2DailyCount);            
        }

        private void PSCSForm_FormClosing(object sender, FormClosingEventArgs e)
        {
            displayTimer.Stop();
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
            if (labelPM1RecipeName.InvokeRequired)
            {
                labelPM1RecipeName.BeginInvoke(new MethodInvoker(delegate
                {
                    // PM1 =======================================================================================
                    string strPM1RunStatus = HostConnection.Host_Get_RunStatus(hostEquipmentInfo, "PM1");
                    strPM1RunStatus = strPM1RunStatus.Trim();
                    if (strPM1RunStatus == "Idle")
                    {
                        if (labelPM1Idle.ForeColor != Color.Yellow)
                            labelPM1Idle.ForeColor = Color.Yellow;

                        if (labelPM1Process.ForeColor != Color.Silver)
                            labelPM1Process.ForeColor = Color.Silver;

                        if (labelPM1Alarm.ForeColor != Color.Silver)
                            labelPM1Alarm.ForeColor = Color.Silver;
                    }
                    else if (strPM1RunStatus == "Process")
                    {
                        if (labelPM1Idle.ForeColor != Color.Silver)
                            labelPM1Idle.ForeColor = Color.Silver;

                        if (labelPM1Process.ForeColor != Color.Silver)
                            labelPM1Process.ForeColor = Color.Silver;
                        else
                            labelPM1Process.ForeColor = Color.Lime;

                        if (labelPM1Alarm.ForeColor != Color.Silver)
                            labelPM1Alarm.ForeColor = Color.Silver;
                    }
                    else if (strPM1RunStatus == "Alarm")
                    {
                        if (labelPM1Idle.ForeColor != Color.Silver)
                            labelPM1Idle.ForeColor = Color.Silver;

                        if (labelPM1Process.ForeColor != Color.Silver)
                            labelPM1Process.ForeColor = Color.Silver;

                        if (labelPM1Alarm.ForeColor != Color.Silver)
                            labelPM1Alarm.ForeColor = Color.Silver;
                        else
                            labelPM1Alarm.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (labelPM1Idle.ForeColor != Color.Silver)
                            labelPM1Idle.ForeColor = Color.Silver;

                        if (labelPM1Process.ForeColor != Color.Silver)
                            labelPM1Process.ForeColor = Color.Silver;

                        if (labelPM1Alarm.ForeColor != Color.Silver)
                            labelPM1Alarm.ForeColor = Color.Silver;
                    }

                    string strPM1RecipeName = HostConnection.Host_Get_RecipeName(hostEquipmentInfo, "PM1");
                    if ((strPM1RecipeName == null) || (strPM1RecipeName == ""))
                        labelPM1RecipeName.Text = "--";
                    else
                        labelPM1RecipeName.Text = strPM1RecipeName;

                    string strPM1Progress = HostConnection.Host_Get_ProgressTime(hostEquipmentInfo, "PM1");
                    strPM1Progress = strPM1Progress.Trim();
                    if ((strPM1Progress == null) || (strPM1Progress == ""))
                        labelPM1ProcessProgress.Text = "--";
                    else
                        labelPM1ProcessProgress.Text = strPM1Progress;

                    string strPM1ProcessEndTime = HostConnection.Host_Get_ProcessEndTime(hostEquipmentInfo, "PM1");
                    strPM1ProcessEndTime = strPM1ProcessEndTime.Trim();
                    if ((strPM1ProcessEndTime == null) || (strPM1ProcessEndTime == ""))
                        labelPM1ProcessEndTime.Text = "--";
                    else
                        labelPM1ProcessEndTime.Text = strPM1ProcessEndTime;

                    string strPM1AlarmName = HostConnection.Host_Get_AlarmName(hostEquipmentInfo, "PM1");
                    if ((strPM1AlarmName == null) || (strPM1AlarmName == ""))
                    {
                        labelPM1AlarmName.Text = "--";
                        if (labelPM1AlarmName.ForeColor != Color.Aqua)
                            labelPM1AlarmName.ForeColor = Color.Aqua;
                    }
                    else
                    {
                        labelPM1AlarmName.Text = strPM1AlarmName;
                        if (labelPM1AlarmName.ForeColor != Color.Red)
                            labelPM1AlarmName.ForeColor = Color.Red;
                    }
                    //============================================================================================


                    // PM2 =======================================================================================
                    string strPM2RunStatus = HostConnection.Host_Get_RunStatus(hostEquipmentInfo, "PM2");
                    strPM2RunStatus = strPM2RunStatus.Trim();
                    if (strPM2RunStatus == "Idle")
                    {
                        if (labelPM2Idle.ForeColor != Color.Yellow)
                            labelPM2Idle.ForeColor = Color.Yellow;

                        if (labelPM2Process.ForeColor != Color.Silver)
                            labelPM2Process.ForeColor = Color.Silver;

                        if (labelPM2Alarm.ForeColor != Color.Silver)
                            labelPM2Alarm.ForeColor = Color.Silver;
                    }
                    else if (strPM2RunStatus == "Process")
                    {
                        if (labelPM2Idle.ForeColor != Color.Silver)
                            labelPM2Idle.ForeColor = Color.Silver;

                        if (labelPM2Process.ForeColor != Color.Silver)
                            labelPM2Process.ForeColor = Color.Silver;
                        else
                            labelPM2Process.ForeColor = Color.Lime;

                        if (labelPM2Alarm.ForeColor != Color.Silver)
                            labelPM2Alarm.ForeColor = Color.Silver;
                    }
                    else if (strPM2RunStatus == "Alarm")
                    {
                        if (labelPM2Idle.ForeColor != Color.Silver)
                            labelPM2Idle.ForeColor = Color.Silver;

                        if (labelPM2Process.ForeColor != Color.Silver)
                            labelPM2Process.ForeColor = Color.Silver;

                        if (labelPM2Alarm.ForeColor != Color.Silver)
                            labelPM2Alarm.ForeColor = Color.Silver;
                        else
                            labelPM2Alarm.ForeColor = Color.Red;
                    }
                    else
                    {
                        if (labelPM2Idle.ForeColor != Color.Silver)
                            labelPM2Idle.ForeColor = Color.Silver;

                        if (labelPM2Process.ForeColor != Color.Silver)
                            labelPM2Process.ForeColor = Color.Silver;

                        if (labelPM2Alarm.ForeColor != Color.Silver)
                            labelPM2Alarm.ForeColor = Color.Silver;
                    }

                    string strPM2RecipeName = HostConnection.Host_Get_RecipeName(hostEquipmentInfo, "PM2");
                    if ((strPM2RecipeName == null) || (strPM2RecipeName == ""))
                        labelPM2RecipeName.Text = "--";
                    else
                        labelPM2RecipeName.Text = strPM2RecipeName;

                    string strPM2Progress = HostConnection.Host_Get_ProgressTime(hostEquipmentInfo, "PM2");
                    strPM2Progress = strPM2Progress.Trim();
                    if ((strPM2Progress == null) || (strPM2Progress == ""))
                        labelPM2ProcessProgress.Text = "--";
                    else
                        labelPM2ProcessProgress.Text = strPM2Progress;

                    string strPM2ProcessEndTime = HostConnection.Host_Get_ProcessEndTime(hostEquipmentInfo, "PM2");
                    strPM2ProcessEndTime = strPM2ProcessEndTime.Trim();
                    if ((strPM2ProcessEndTime == null) || (strPM2ProcessEndTime == ""))
                        labelPM2ProcessEndTime.Text = "--";
                    else
                        labelPM2ProcessEndTime.Text = strPM2ProcessEndTime;

                    string strPM2AlarmName = HostConnection.Host_Get_AlarmName(hostEquipmentInfo, "PM2");
                    if ((strPM2AlarmName == null) || (strPM2AlarmName == ""))
                    {
                        labelPM2AlarmName.Text = "--";
                        if (labelPM2AlarmName.ForeColor != Color.Aqua)
                            labelPM2AlarmName.ForeColor = Color.Aqua;
                    }
                    else
                    {
                        labelPM2AlarmName.Text = strPM2AlarmName;
                        if (labelPM2AlarmName.ForeColor != Color.Red)
                            labelPM2AlarmName.ForeColor = Color.Red;
                    }                    
                    //============================================================================================                                      
                }));
            }
        }

        private void btnSearch_Click(object sender, EventArgs e)
        {
            DateTime t2 = new DateTime(2023, 08, 01);
            int result = DateTime.Compare(dateTimePickerStart.Value, t2);
            if (result == -1)
            {
                MessageBox.Show("2023년 8월 1일 데이터부터 조회 가능 합니다", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            result = DateTime.Compare(dateTimePickerEnd.Value, dateTimePickerStart.Value);
            if (result == -1)
            {
                MessageBox.Show("날짜 조회 방식이 잘못되었습니다", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            if ((dateTimePickerStart.Value.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd")) ||
                (dateTimePickerEnd.Value.ToString("yyyy-MM-dd") == DateTime.Today.ToString("yyyy-MM-dd")))
            {
                MessageBox.Show("오늘 날짜는 조회 할 수 없습니다", "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                return;
            }

            chartPM1DailyCount.Series["CH1 Daily"].Points.Clear();
            chartPM2DailyCount.Series["CH2 Daily"].Points.Clear();            
            chartUtilization.Series["Utilization(%)"].Points.Clear();

            DataTable dTable = new DataTable();
            dTable.Columns.Add("    Date", typeof(string));
            dTable.Columns.Add("    CH1", typeof(string));
            dTable.Columns.Add("    CH2", typeof(string));
            dTable.Columns.Add("    CH3", typeof(string));
            dTable.Columns.Add(" Util'(Count)", typeof(string));
            dTable.Columns.Add(" TodayRuntime", typeof(string));
            dTable.Columns.Add(" Util'(RealTime)", typeof(string));

            try
            {
                string startDate = dateTimePickerStart.Value.ToString("yyyy-MM-dd");
                string endDate = dateTimePickerEnd.Value.ToString("yyyy-MM-dd");
                TimeSpan diff_Dates = dateTimePickerEnd.Value.Subtract(dateTimePickerStart.Value);
                int j = 1;
                for (int i = 0; i <= diff_Dates.Days; i++)
                {
                    strArray = HostConnection.Host_Get_Log(hostEquipmentInfo_Log, startDate);
                    dTable.Rows.Add(strArray[0], strArray[1], strArray[2], strArray[3], strArray[4], strArray[5], strArray[6]);

                    chartPM1DailyCount.Series["CH1 Daily"].Points.AddXY(strArray[0].Substring(5), strArray[1]);
                    chartPM2DailyCount.Series["CH2 Daily"].Points.AddXY(strArray[0].Substring(5), strArray[2]);                    
                    chartUtilization.Series["Utilization(%)"].Points.AddXY(strArray[0].Substring(5), strArray[6]);

                    startDate = dateTimePickerStart.Value.AddDays(j).ToString("yyyy-MM-dd");
                    j++;
                }
            }
            catch (ArgumentException ae)
            {
                MessageBox.Show(ae.Message, "Notifications", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            finally
            {
                dataGridView1.DataSource = dTable;
            }
        }

        private void btnSubmitExcel_Click(object sender, EventArgs e)
        {
            SaveFileDialog sfd = new SaveFileDialog();
            sfd.Title = "Save as Excel File";
            sfd.Filter = "Excel Files(2003)|*.xls|Excel Files(2007)|*.xlsx";
            sfd.FileName = "";
            if (sfd.ShowDialog() == DialogResult.OK)
            {
                HistoryGridView_ExportToExcel(sfd.FileName, dataGridView1);
            }
        }

        private void HistoryGridView_ExportToExcel(string fileName, DataGridView dgv)
        {
            Excel.Application excelApp = new Excel.Application();
            if (excelApp == null)
            {
                MessageBox.Show("엑셀이 설치되지 않았습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            Excel.Workbook wb = excelApp.Workbooks.Add(true);
            Excel._Worksheet workSheet = wb.Worksheets.get_Item(1) as Excel._Worksheet;
            workSheet.Name = hostEquipmentInfo_Log;

            if (dgv.Rows.Count == 0)
            {
                MessageBox.Show("출력할 데이터가 없습니다.", "알림", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            // 헤더 출력
            for (int i = 0; i < dgv.Columns.Count; i++)
            {
                workSheet.Cells[1, i + 1] = dgv.Columns[i].HeaderText;
            }

            //내용 출력
            for (int r = 0; r < dgv.Rows.Count; r++)
            {
                for (int i = 0; i < dgv.Columns.Count; i++)
                {
                    workSheet.Cells[r + 2, i + 1] = dgv.Rows[r].Cells[i].Value;
                }
            }

            workSheet.Columns.AutoFit(); // 글자 크기에 맞게 셀 크기를 자동으로 조절

            // 엑셀 2003 으로만 저장이 됨
            wb.SaveAs(fileName, Excel.XlFileFormat.xlWorkbookNormal, Type.Missing, Type.Missing, Type.Missing, Type.Missing,
                Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive, Type.Missing, Type.Missing, Type.Missing, Type.Missing, Type.Missing);

            wb.Close(Type.Missing, Type.Missing, Type.Missing);
            excelApp.Quit();
            releaseObject(excelApp);
            releaseObject(workSheet);
            releaseObject(wb);
        }

        #region 메모리해제
        private static void releaseObject(object obj)
        {
            try
            {
                System.Runtime.InteropServices.Marshal.ReleaseComObject(obj);
                obj = null;
            }
            catch (Exception e)
            {
                obj = null;
            }
            finally
            {
                GC.Collect();
            }
        }
        #endregion  
    }
}
