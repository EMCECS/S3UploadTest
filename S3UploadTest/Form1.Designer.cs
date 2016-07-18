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
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.accessKeyText = new System.Windows.Forms.TextBox();
            this.secretKeyText = new System.Windows.Forms.TextBox();
            this.endpointVdc1Text = new System.Windows.Forms.TextBox();
            this.objectSizeText = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.createText = new System.Windows.Forms.TextBox();
            this.startButton = new System.Windows.Forms.Button();
            this.useVhostCheck = new System.Windows.Forms.CheckBox();
            this.endpointVdc2Text = new System.Windows.Forms.TextBox();
            this.label11 = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.replicateText = new System.Windows.Forms.TextBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.readText = new System.Windows.Forms.TextBox();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.groupBox3.SuspendLayout();
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
            this.label3.Location = new System.Drawing.Point(35, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(86, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Endpoint - VDC1";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 141);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Object Size";
            // 
            // accessKeyText
            // 
            this.accessKeyText.Location = new System.Drawing.Point(127, 10);
            this.accessKeyText.Name = "accessKeyText";
            this.accessKeyText.Size = new System.Drawing.Size(196, 20);
            this.accessKeyText.TabIndex = 8;
            // 
            // secretKeyText
            // 
            this.secretKeyText.Location = new System.Drawing.Point(127, 36);
            this.secretKeyText.Name = "secretKeyText";
            this.secretKeyText.Size = new System.Drawing.Size(196, 20);
            this.secretKeyText.TabIndex = 9;
            // 
            // endpointVdc1Text
            // 
            this.endpointVdc1Text.Location = new System.Drawing.Point(127, 61);
            this.endpointVdc1Text.Name = "endpointVdc1Text";
            this.endpointVdc1Text.Size = new System.Drawing.Size(196, 20);
            this.endpointVdc1Text.TabIndex = 10;
            // 
            // objectSizeText
            // 
            this.objectSizeText.Location = new System.Drawing.Point(127, 138);
            this.objectSizeText.Name = "objectSizeText";
            this.objectSizeText.Size = new System.Drawing.Size(196, 20);
            this.objectSizeText.TabIndex = 11;
            this.objectSizeText.Text = "10485760";
            this.objectSizeText.TextChanged += new System.EventHandler(this.objectSizeText_TextChanged);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.createText);
            this.groupBox1.Location = new System.Drawing.Point(13, 196);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(290, 333);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Create";
            // 
            // createText
            // 
            this.createText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.createText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.createText.Location = new System.Drawing.Point(6, 19);
            this.createText.Multiline = true;
            this.createText.Name = "createText";
            this.createText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.createText.Size = new System.Drawing.Size(281, 307);
            this.createText.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(13, 167);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // useVhostCheck
            // 
            this.useVhostCheck.AutoSize = true;
            this.useVhostCheck.Location = new System.Drawing.Point(127, 115);
            this.useVhostCheck.Name = "useVhostCheck";
            this.useVhostCheck.Size = new System.Drawing.Size(113, 17);
            this.useVhostCheck.TabIndex = 25;
            this.useVhostCheck.Text = "use vhost buckets";
            this.useVhostCheck.UseVisualStyleBackColor = true;
            // 
            // endpointVdc2Text
            // 
            this.endpointVdc2Text.Location = new System.Drawing.Point(127, 87);
            this.endpointVdc2Text.Name = "endpointVdc2Text";
            this.endpointVdc2Text.Size = new System.Drawing.Size(196, 20);
            this.endpointVdc2Text.TabIndex = 28;
            // 
            // label11
            // 
            this.label11.AutoSize = true;
            this.label11.Location = new System.Drawing.Point(35, 90);
            this.label11.Name = "label11";
            this.label11.Size = new System.Drawing.Size(86, 13);
            this.label11.TabIndex = 27;
            this.label11.Text = "Endpoint - VDC2";
            // 
            // groupBox2
            // 
            this.groupBox2.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox2.Controls.Add(this.replicateText);
            this.groupBox2.Location = new System.Drawing.Point(309, 196);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(290, 333);
            this.groupBox2.TabIndex = 29;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Replicate";
            // 
            // replicateText
            // 
            this.replicateText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.replicateText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.replicateText.Location = new System.Drawing.Point(6, 19);
            this.replicateText.Multiline = true;
            this.replicateText.Name = "replicateText";
            this.replicateText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.replicateText.Size = new System.Drawing.Size(281, 307);
            this.replicateText.TabIndex = 0;
            // 
            // groupBox3
            // 
            this.groupBox3.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox3.Controls.Add(this.readText);
            this.groupBox3.Location = new System.Drawing.Point(606, 196);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(290, 333);
            this.groupBox3.TabIndex = 30;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "Read";
            // 
            // readText
            // 
            this.readText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.readText.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.readText.Location = new System.Drawing.Point(6, 19);
            this.readText.Multiline = true;
            this.readText.Name = "readText";
            this.readText.ScrollBars = System.Windows.Forms.ScrollBars.Vertical;
            this.readText.Size = new System.Drawing.Size(281, 307);
            this.readText.TabIndex = 0;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(908, 541);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.endpointVdc2Text);
            this.Controls.Add(this.label11);
            this.Controls.Add(this.useVhostCheck);
            this.Controls.Add(this.startButton);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.objectSizeText);
            this.Controls.Add(this.endpointVdc1Text);
            this.Controls.Add(this.secretKeyText);
            this.Controls.Add(this.accessKeyText);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Name = "Form1";
            this.Text = "S3 Upload Test";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.groupBox3.ResumeLayout(false);
            this.groupBox3.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox accessKeyText;
        private System.Windows.Forms.TextBox secretKeyText;
        private System.Windows.Forms.TextBox endpointVdc1Text;
        private System.Windows.Forms.TextBox objectSizeText;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.TextBox createText;
        private System.Windows.Forms.Button startButton;
        private System.Windows.Forms.CheckBox useVhostCheck;
        private System.Windows.Forms.TextBox endpointVdc2Text;
        private System.Windows.Forms.Label label11;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.TextBox replicateText;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.TextBox readText;
    }
}

