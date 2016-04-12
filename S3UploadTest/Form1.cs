using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace S3UploadTest
{
    public partial class Form1 : Form
    {
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
            S3TestHarness harness = new S3TestHarness()
            {
                AccessKey = accessKeyText.Text.Trim(),
                SecretKey = secretKeyText.Text.Trim(),
                Endpoint = endpointText.Text.Trim(),
                ObjectCount = int.Parse(objectCountText.Text.Trim()),
                ObjectSize = int.Parse(objectSizeText.Text.Trim()),
                ThreadCount = int.Parse(threadCountText.Text.Trim()),
                Parent = this
            };
            if(bufferSizeCheck.Checked)
            {
                harness.BufferSize = int.Parse(bufferSizeText.Text.Trim());
            }

            startButton.Enabled = false;

            VoidDelegate d = new VoidDelegate(harness.Start);
            d.BeginInvoke(new AsyncCallback(runComplete), null);
        }

        private void runComplete(IAsyncResult result)
        {
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
            if(outputText.InvokeRequired)
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
    }
}
