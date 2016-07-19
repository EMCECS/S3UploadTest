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
namespace S3UploadTest
{
    partial class Form1
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
            this.components = new System.ComponentModel.Container();
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea4 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea5 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.ChartArea chartArea6 = new System.Windows.Forms.DataVisualization.Charting.ChartArea();
            System.Windows.Forms.DataVisualization.Charting.Legend legend2 = new System.Windows.Forms.DataVisualization.Charting.Legend();
            System.Windows.Forms.DataVisualization.Charting.Series series4 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series5 = new System.Windows.Forms.DataVisualization.Charting.Series();
            System.Windows.Forms.DataVisualization.Charting.Series series6 = new System.Windows.Forms.DataVisualization.Charting.Series();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.bufferSizeCheck = new System.Windows.Forms.CheckBox();
            this.label6 = new System.Windows.Forms.Label();
            this.accessKeyText = new System.Windows.Forms.TextBox();
            this.secretKeyText = new System.Windows.Forms.TextBox();
            this.endpointText = new System.Windows.Forms.TextBox();
            this.objectSizeText = new System.Windows.Forms.TextBox();
            this.objectCountText = new System.Windows.Forms.TextBox();
            this.threadCountText = new System.Windows.Forms.TextBox();
            this.bufferSizeText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.outputText = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.minThreadCheck = new System.Windows.Forms.CheckBox();
            this.maxConnectionCheck = new System.Windows.Forms.CheckBox();
            this.maxConnectionText = new System.Windows.Forms.TextBox();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            this.label9 = new System.Windows.Forms.Label();
            this.label10 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.currentThreads = new System.Windows.Forms.Label();
            this.threadUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.useVhostCheck = new System.Windows.Forms.CheckBox();
            this.noCleanupCheck = new System.Windows.Forms.CheckBox();
            this.performanceData = new System.Data.DataSet();
            this.performance = new System.Data.DataTable();
            this.time = new System.Data.DataColumn();
            this.bandwidth = new System.Data.DataColumn();
            this.tps = new System.Data.DataColumn();
            this.errorRate = new System.Data.DataColumn();
            this.chart1 = new System.Windows.Forms.DataVisualization.Charting.Chart();
            this.graphUpdateTimer = new System.Windows.Forms.Timer(this.components);
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceData)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.performance)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).BeginInit();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(44, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Key ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(62, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Secret Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(72, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Endpoint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 114);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Object Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(52, 137);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Object Count";
            // 
            // bufferSizeCheck
            // 
            this.bufferSizeCheck.AutoSize = true;
            this.bufferSizeCheck.Location = new System.Drawing.Point(13, 196);
            this.bufferSizeCheck.Name = "bufferSizeCheck";
            this.bufferSizeCheck.Size = new System.Drawing.Size(77, 17);
            this.bufferSizeCheck.TabIndex = 5;
            this.bufferSizeCheck.Text = "Buffer Size";
            this.bufferSizeCheck.UseVisualStyleBackColor = true;
            this.bufferSizeCheck.CheckedChanged += new System.EventHandler(this.checkBox1_CheckedChanged);
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(29, 171);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(92, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Min Thread Count";
            // 
            // accessKeyText
            // 
            this.accessKeyText.Location = new System.Drawing.Point(127, 10);
            this.accessKeyText.Name = "accessKeyText";
            this.accessKeyText.Size = new System.Drawing.Size(196, 20);
            this.accessKeyText.TabIndex = 8;
            this.accessKeyText.Text = "jason";
            // 
            // secretKeyText
            // 
            this.secretKeyText.Location = new System.Drawing.Point(127, 36);
            this.secretKeyText.Name = "secretKeyText";
            this.secretKeyText.Size = new System.Drawing.Size(196, 20);
            this.secretKeyText.TabIndex = 9;
            this.secretKeyText.Text = "shs3LuAXVsIp6JfkqKsoterd9sCkdxGsRmhJ3CoD";
            // 
            // endpointText
            // 
            this.endpointText.Location = new System.Drawing.Point(127, 61);
            this.endpointText.Name = "endpointText";
            this.endpointText.Size = new System.Drawing.Size(196, 20);
            this.endpointText.TabIndex = 10;
            this.endpointText.Text = resources.GetString("endpointText.Text");
            // 
            // objectSizeText
            // 
            this.objectSizeText.Location = new System.Drawing.Point(127, 111);
            this.objectSizeText.Name = "objectSizeText";
            this.objectSizeText.Size = new System.Drawing.Size(196, 20);
            this.objectSizeText.TabIndex = 11;
            this.objectSizeText.Text = "1048576";
            // 
            // objectCountText
            // 
            this.objectCountText.Location = new System.Drawing.Point(127, 134);
            this.objectCountText.Name = "objectCountText";
            this.objectCountText.Size = new System.Drawing.Size(196, 20);
            this.objectCountText.TabIndex = 12;
            this.objectCountText.Text = "2000";
            // 
            // threadCountText
            // 
            this.threadCountText.Location = new System.Drawing.Point(127, 168);
            this.threadCountText.Name = "threadCountText";
            this.threadCountText.Size = new System.Drawing.Size(196, 20);
            this.threadCountText.TabIndex = 13;
            this.threadCountText.Text = "25";
            // 
            // bufferSizeText
            // 
            this.bufferSizeText.Location = new System.Drawing.Point(127, 194);
            this.bufferSizeText.Name = "bufferSizeText";
            this.bufferSizeText.Size = new System.Drawing.Size(100, 20);
            this.bufferSizeText.TabIndex = 14;
            this.bufferSizeText.Text = "131072";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.outputText);
            this.groupBox1.Location = new System.Drawing.Point(13, 272);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(478, 392);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left)));
            this.outputText.Location = new System.Drawing.Point(3, 20);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.outputText.Size = new System.Drawing.Size(469, 366);
            this.outputText.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(12, 243);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // minThreadCheck
            // 
            this.minThreadCheck.AutoSize = true;
            this.minThreadCheck.Location = new System.Drawing.Point(13, 171);
            this.minThreadCheck.Name = "minThreadCheck";
            this.minThreadCheck.Size = new System.Drawing.Size(15, 14);
            this.minThreadCheck.TabIndex = 17;
            this.minThreadCheck.UseVisualStyleBackColor = true;
            // 
            // maxConnectionCheck
            // 
            this.maxConnectionCheck.AutoSize = true;
            this.maxConnectionCheck.Location = new System.Drawing.Point(13, 223);
            this.maxConnectionCheck.Name = "maxConnectionCheck";
            this.maxConnectionCheck.Size = new System.Drawing.Size(15, 14);
            this.maxConnectionCheck.TabIndex = 20;
            this.maxConnectionCheck.UseVisualStyleBackColor = true;
            // 
            // maxConnectionText
            // 
            this.maxConnectionText.Location = new System.Drawing.Point(127, 220);
            this.maxConnectionText.Name = "maxConnectionText";
            this.maxConnectionText.Size = new System.Drawing.Size(196, 20);
            this.maxConnectionText.TabIndex = 19;
            this.maxConnectionText.Text = "100";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(29, 223);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(89, 13);
            this.label7.TabIndex = 18;
            this.label7.Text = "Max Connections";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(330, 223);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(57, 13);
            this.label8.TabIndex = 21;
            this.label8.Text = "default: 50";
            // 
            // label9
            // 
            this.label9.AutoSize = true;
            this.label9.Location = new System.Drawing.Point(330, 196);
            this.label9.Name = "label9";
            this.label9.Size = new System.Drawing.Size(69, 13);
            this.label9.TabIndex = 22;
            this.label9.Text = "default: 8192";
            // 
            // label10
            // 
            this.label10.AutoSize = true;
            this.label10.Location = new System.Drawing.Point(330, 171);
            this.label10.Name = "label10";
            this.label10.Size = new System.Drawing.Size(72, 13);
            this.label10.TabIndex = 23;
            this.label10.Text = "default: CPUs";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.currentThreads);
            this.groupBox2.Location = new System.Drawing.Point(363, 10);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(128, 68);
            this.groupBox2.TabIndex = 24;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Current Threads";
            // 
            // currentThreads
            // 
            this.currentThreads.AutoSize = true;
            this.currentThreads.Font = new System.Drawing.Font("Microsoft Sans Serif", 14.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.currentThreads.Location = new System.Drawing.Point(7, 26);
            this.currentThreads.Name = "currentThreads";
            this.currentThreads.Size = new System.Drawing.Size(0, 24);
            this.currentThreads.TabIndex = 0;
            // 
            // threadUpdateTimer
            // 
            this.threadUpdateTimer.Enabled = true;
            this.threadUpdateTimer.Interval = 2000;
            this.threadUpdateTimer.Tick += new System.EventHandler(this.threadUpdateTimer_Tick);
            // 
            // useVhostCheck
            // 
            this.useVhostCheck.AutoSize = true;
            this.useVhostCheck.Location = new System.Drawing.Point(127, 88);
            this.useVhostCheck.Name = "useVhostCheck";
            this.useVhostCheck.Size = new System.Drawing.Size(113, 17);
            this.useVhostCheck.TabIndex = 25;
            this.useVhostCheck.Text = "use vhost buckets";
            this.useVhostCheck.UseVisualStyleBackColor = true;
            // 
            // noCleanupCheck
            // 
            this.noCleanupCheck.AutoSize = true;
            this.noCleanupCheck.Location = new System.Drawing.Point(333, 137);
            this.noCleanupCheck.Name = "noCleanupCheck";
            this.noCleanupCheck.Size = new System.Drawing.Size(82, 17);
            this.noCleanupCheck.TabIndex = 26;
            this.noCleanupCheck.Text = "No Cleanup";
            this.noCleanupCheck.UseVisualStyleBackColor = true;
            // 
            // performanceData
            // 
            this.performanceData.DataSetName = "Performance Data";
            this.performanceData.Tables.AddRange(new System.Data.DataTable[] {
            this.performance});
            // 
            // performance
            // 
            this.performance.Columns.AddRange(new System.Data.DataColumn[] {
            this.time,
            this.bandwidth,
            this.tps,
            this.errorRate});
            this.performance.TableName = "Performance";
            // 
            // time
            // 
            this.time.ColumnName = "Time";
            this.time.DataType = typeof(System.DateTime);
            this.time.DateTimeMode = System.Data.DataSetDateTime.Utc;
            // 
            // bandwidth
            // 
            this.bandwidth.ColumnName = "Bandwidth";
            this.bandwidth.DataType = typeof(long);
            // 
            // tps
            // 
            this.tps.ColumnName = "TPS";
            this.tps.DataType = typeof(int);
            // 
            // errorRate
            // 
            this.errorRate.ColumnName = "ErrorRate";
            this.errorRate.DataType = typeof(double);
            // 
            // chart1
            // 
            this.chart1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            chartArea4.Name = "BandwidthArea";
            chartArea5.Name = "TPSArea";
            chartArea6.AxisY.Maximum = 100D;
            chartArea6.AxisY.Minimum = 0D;
            chartArea6.Name = "ErrorRateArea";
            this.chart1.ChartAreas.Add(chartArea4);
            this.chart1.ChartAreas.Add(chartArea5);
            this.chart1.ChartAreas.Add(chartArea6);
            legend2.Name = "Legend1";
            this.chart1.Legends.Add(legend2);
            this.chart1.Location = new System.Drawing.Point(497, 10);
            this.chart1.Name = "chart1";
            series4.ChartArea = "BandwidthArea";
            series4.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series4.Legend = "Legend1";
            series4.Name = "Bandwidth";
            series4.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series5.ChartArea = "TPSArea";
            series5.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series5.Legend = "Legend1";
            series5.Name = "TPS";
            series5.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            series6.ChartArea = "ErrorRateArea";
            series6.ChartType = System.Windows.Forms.DataVisualization.Charting.SeriesChartType.Line;
            series6.Legend = "Legend1";
            series6.Name = "Error Rate";
            series6.XValueType = System.Windows.Forms.DataVisualization.Charting.ChartValueType.Time;
            this.chart1.Series.Add(series4);
            this.chart1.Series.Add(series5);
            this.chart1.Series.Add(series6);
            this.chart1.Size = new System.Drawing.Size(541, 648);
            this.chart1.TabIndex = 27;
            this.chart1.Text = "chart1";
            // 
            // graphUpdateTimer
            // 
            this.graphUpdateTimer.Interval = 10000;
            this.graphUpdateTimer.Tick += new System.EventHandler(this.graphUpdateTimer_Tick);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1050, 676);
            this.Controls.Add(this.chart1);
            this.Controls.Add(this.noCleanupCheck);
            this.Controls.Add(this.useVhostCheck);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.label10);
            this.Controls.Add(this.label9);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.maxConnectionCheck);
            this.Controls.Add(this.maxConnectionText);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.minThreadCheck);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.bufferSizeText);
            this.Controls.Add(this.threadCountText);
            this.Controls.Add(this.objectCountText);
            this.Controls.Add(this.objectSizeText);
            this.Controls.Add(this.endpointText);
            this.Controls.Add(this.secretKeyText);
            this.Controls.Add(this.accessKeyText);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.bufferSizeCheck);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "S3 Upload Test";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.performanceData)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.performance)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.chart1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox bufferSizeCheck;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.TextBox accessKeyText;
        private System.Windows.Forms.TextBox secretKeyText;
        private System.Windows.Forms.TextBox endpointText;
        private System.Windows.Forms.TextBox objectSizeText;
        private System.Windows.Forms.TextBox objectCountText;
        private System.Windows.Forms.TextBox threadCountText;
        private System.Windows.Forms.TextBox bufferSizeText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox outputText;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox minThreadCheck;
        private System.Windows.Forms.CheckBox maxConnectionCheck;
        private System.Windows.Forms.TextBox maxConnectionText;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
        private System.Windows.Forms.Label label9;
        private System.Windows.Forms.Label label10;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Label currentThreads;
        private System.Windows.Forms.Timer threadUpdateTimer;
        private System.Windows.Forms.CheckBox useVhostCheck;
        private System.Windows.Forms.CheckBox noCleanupCheck;
        private System.Data.DataSet performanceData;
        private System.Data.DataTable performance;
        private System.Data.DataColumn time;
        private System.Data.DataColumn bandwidth;
        private System.Data.DataColumn tps;
        private System.Data.DataColumn errorRate;
        private System.Windows.Forms.DataVisualization.Charting.Chart chart1;
        private System.Windows.Forms.Timer graphUpdateTimer;
    }
}

