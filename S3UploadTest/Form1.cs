/**
Copyright (c) 2016 EMC Corporation

Permission is hereby granted, free of charge, to any person obtaining a copy of this 
software and associated documentation files (the "Software"), to deal in the Software 
without restriction, including without limitation the rights to use, copy, modify, 
merge, publish, distribute, sublicense, and/or sell copies of the Software, and to 
permit persons to whom the Software is furnished to do so, subject to the following 
conditions:

The above copyright notice and this permission notice shall be included in all copies 
or substantial portions of the Software.

THE SOFTWARE IS PROVIDED "AS IS", WITHOUT WARRANTY OF ANY KIND, EXPRESS OR IMPLIED, 
INCLUDING BUT NOT LIMITED TO THE WARRANTIES OF MERCHANTABILITY, FITNESS FOR A PARTICULAR 
PURPOSE AND NONINFRINGEMENT. IN NO EVENT SHALL THE AUTHORS OR COPYRIGHT HOLDERS BE LIABLE 
FOR ANY CLAIM, DAMAGES OR OTHER LIABILITY, WHETHER IN AN ACTION OF CONTRACT, TORT OR 
OTHERWISE, ARISING FROM, OUT OF OR IN CONNECTION WITH THE SOFTWARE OR THE USE OR OTHER 
DEALINGS IN THE SOFTWARE.
*/
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.DataVisualization.Charting;

namespace S3UploadTest
{
    public partial class Form1 : Form
    {
        private S3TestHarness harness;

        public Form1()
        {
            InitializeComponent();
        }

        private void checkBox1_CheckedChanged(object sender, EventArgs e)
        {
            bufferSizeText.Enabled = bufferSizeCheck.Checked;
        }

        delegate void VoidDelegate();
        private void startButton_Click(object sender, EventArgs e)
        {
            clearOutput();
            LogOutput("Starting run...");
            harness = new S3TestHarness()
            {
                AccessKey = accessKeyText.Text.Trim(),
                SecretKey = secretKeyText.Text.Trim(),
                Endpoint = endpointText.Text.Trim(),
                ObjectCount = int.Parse(objectCountText.Text.Trim()),
                ObjectSize = int.Parse(objectSizeText.Text.Trim()),
                Parent = this,
                UseVhostBuckets = useVhostCheck.Checked,
                NoCleanup = noCleanupCheck.Checked
            };
            if (bufferSizeCheck.Checked)
            {
                harness.BufferSize = int.Parse(bufferSizeText.Text.Trim());
            }
            if (minThreadCheck.Checked)
            {
                harness.MinThreads = int.Parse(threadCountText.Text.Trim());
            }
            if (maxConnectionCheck.Checked)
            {
                harness.MaxConnections = int.Parse(maxConnectionText.Text.Trim());
            }

            startButton.Enabled = false;

            // Clear table
            DataTable table = performanceData.Tables["Performance"];
            table.Rows.Clear();

            // Start timer
            graphUpdateTimer.Start();

            VoidDelegate d = new VoidDelegate(harness.Start);
            d.BeginInvoke(new AsyncCallback(runComplete), null);
        }

        private void runComplete(IAsyncResult result)
        {
            // Stop timer
            graphUpdateTimer.Stop();

            harness = null;
            // Re-enable start button
            startButton.Invoke(new VoidDelegate(enableStartButton));

            // End async method
            VoidDelegate d = (VoidDelegate)((AsyncResult)result).AsyncDelegate;
            d.EndInvoke(result);
        }

        private void enableStartButton()
        {
            startButton.Enabled = true;
        }

        private delegate void LogOutputDelegate(string s);
        public void LogOutput(string v)
        {
            // Make sure it runs on the event thread.
            if (outputText.InvokeRequired)
            {
                outputText.Invoke(new LogOutputDelegate(LogOutput), v);
            }
            else
            {
                string s = string.Format("{0:u} - {1}\r\n", DateTime.UtcNow, v);
                outputText.Text += s;
            }
        }

        private void clearOutput()
        {
            outputText.Text = "";
        }

        private void threadUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (currentThreads != null)
            {
                int maxWorker, maxIo, availableWorker, availableIo;
                ThreadPool.GetMaxThreads(out maxWorker, out maxIo);
                ThreadPool.GetAvailableThreads(out availableWorker, out availableIo);
                currentThreads.Text = "" + (maxWorker - availableWorker);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            DataTable table = performanceData.Tables["Performance"];

            for (int i = 0; i < 10; i++)
            {
                DataRow row = table.NewRow();
                row["Time"] = DateTime.Now.AddMinutes(i);
                row["Bandwidth"] = 100L;
                row["TPS"] = 100;
                row["ErrorRate"] = i;
                table.Rows.Add(row);
            }
            //chart1.DataBindTable((table as System.ComponentModel.IListSource).GetList(), "Time");

            //foreach (Series s in chart1.Series)
            //{
            //    s.ChartType = SeriesChartType.Line;
            //}

            chart1.Series["Bandwidth"].Points.DataBind((table as System.ComponentModel.IListSource).GetList(), "Time", "Bandwidth", null);
            chart1.Series["TPS"].Points.DataBind((table as System.ComponentModel.IListSource).GetList(), "Time", "TPS", null);
            chart1.Series["Error Rate"].Points.DataBind((table as System.ComponentModel.IListSource).GetList(), "Time", "TPS", null);


            //chart1.DataSource = performanceData;
            //chart1.Series["Performance"].XValueMember = "Time";
            //chart1.Series["Performance"].YValueMembers = "TPS";

            //chart1.DataBind();

            //chart1.Series[0].YValueMembers = "TPS";
            // Debug.WriteLine(chart1.Series[0].YValueMembers);
        }

        private void graphUpdateTimer_Tick(object sender, EventArgs e)
        {
            if (harness == null) return;

            DataTable table = performanceData.Tables["Performance"];

            DataRow row = table.NewRow();
            row["Time"] = DateTime.Now;
            row["Bandwidth"] = Interlocked.Exchange(ref harness.bytesPerSec, 0);
            int tps = Interlocked.Exchange(ref harness.tps, 0);
            row["TPS"] = tps;
            int errors = Interlocked.Exchange(ref harness.errors, 0);
            int errorRate = 0;
            if(tps > 0) {
                errorRate = errors * 100 / tps;
            }
            row["ErrorRate"] = errorRate;
            table.Rows.Add(row);

            // Update Graph
            chart1.Series["Bandwidth"].Points.DataBind((table as System.ComponentModel.IListSource).GetList(), "Time", "Bandwidth", null);
            chart1.Series["TPS"].Points.DataBind((table as System.ComponentModel.IListSource).GetList(), "Time", "TPS", null);
            chart1.Series["Error Rate"].Points.DataBind((table as System.ComponentModel.IListSource).GetList(), "Time", "ErrorRate", null);

        }
    }
}
