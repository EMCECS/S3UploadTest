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

        delegate void VoidDelegate();
        private void startButton_Click(object sender, EventArgs e)
        {
            clearOutput();
            LogCreate("Starting run...");
            S3TestHarness harness = new S3TestHarness()
            {
                AccessKey = accessKeyText.Text.Trim(),
                SecretKey = secretKeyText.Text.Trim(),
                Endpoint = endpointVdc1Text.Text.Trim(),
                ObjectCount = 0,
                ObjectSize = int.Parse(objectSizeText.Text.Trim()),
                Parent = this,
                UseVhostBuckets = useVhostCheck.Checked,
                NoCleanup = true
            };


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
        public void LogCreate(string v)
        {
            // Make sure it runs on the event thread.
            if(createText.InvokeRequired)
            {
                createText.Invoke(new LogOutputDelegate(LogCreate), v);
            }
            else
            {
                string s = string.Format("{0:u} - {1}\r\n", DateTime.UtcNow, v);
                createText.AppendText(s);
            }
        }

        public void LogReplicate(string v)
        {
            // Make sure it runs on the event thread.
            if (createText.InvokeRequired)
            {
                replicateText.Invoke(new LogOutputDelegate(LogReplicate), v);
            }
            else
            {
                string s = string.Format("{0:u} - {1}\r\n", DateTime.UtcNow, v);
                replicateText.AppendText(s);
            }
        }

        public void LogRead(string v)
        {
            // Make sure it runs on the event thread.
            if (createText.InvokeRequired)
            {
                readText.Invoke(new LogOutputDelegate(LogRead), v);
            }
            else
            {
                string s = string.Format("{0:u} - {1}\r\n", DateTime.UtcNow, v);
                readText.AppendText(s);
            }
        }

        private void clearOutput()
        {
            createText.Text = "";
            replicateText.Text = "";
            readText.Text = "";
        }

        private void objectSizeText_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
