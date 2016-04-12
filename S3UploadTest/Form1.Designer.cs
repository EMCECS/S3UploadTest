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
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(13, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(77, 13);
            this.label1.TabIndex = 0;
            this.label1.Text = "Access Key ID";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(31, 39);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(59, 13);
            this.label2.TabIndex = 1;
            this.label2.Text = "Secret Key";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(41, 64);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(49, 13);
            this.label3.TabIndex = 2;
            this.label3.Text = "Endpoint";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(29, 91);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(61, 13);
            this.label4.TabIndex = 3;
            this.label4.Text = "Object Size";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(21, 118);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(69, 13);
            this.label5.TabIndex = 4;
            this.label5.Text = "Object Count";
            // 
            // bufferSizeCheck
            // 
            this.bufferSizeCheck.AutoSize = true;
            this.bufferSizeCheck.Location = new System.Drawing.Point(13, 171);
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
            this.label6.Location = new System.Drawing.Point(18, 145);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(72, 13);
            this.label6.TabIndex = 6;
            this.label6.Text = "Thread Count";
            // 
            // accessKeyText
            // 
            this.accessKeyText.Location = new System.Drawing.Point(96, 10);
            this.accessKeyText.Name = "accessKeyText";
            this.accessKeyText.Size = new System.Drawing.Size(196, 20);
            this.accessKeyText.TabIndex = 8;
            // 
            // secretKeyText
            // 
            this.secretKeyText.Location = new System.Drawing.Point(96, 36);
            this.secretKeyText.Name = "secretKeyText";
            this.secretKeyText.Size = new System.Drawing.Size(196, 20);
            this.secretKeyText.TabIndex = 9;
            // 
            // endpointText
            // 
            this.endpointText.Location = new System.Drawing.Point(96, 61);
            this.endpointText.Name = "endpointText";
            this.endpointText.Size = new System.Drawing.Size(196, 20);
            this.endpointText.TabIndex = 10;
            // 
            // objectSizeText
            // 
            this.objectSizeText.Location = new System.Drawing.Point(96, 88);
            this.objectSizeText.Name = "objectSizeText";
            this.objectSizeText.Size = new System.Drawing.Size(196, 20);
            this.objectSizeText.TabIndex = 11;
            this.objectSizeText.Text = "1048576";
            // 
            // objectCountText
            // 
            this.objectCountText.Location = new System.Drawing.Point(96, 115);
            this.objectCountText.Name = "objectCountText";
            this.objectCountText.Size = new System.Drawing.Size(196, 20);
            this.objectCountText.TabIndex = 12;
            this.objectCountText.Text = "2000";
            // 
            // threadCountText
            // 
            this.threadCountText.Location = new System.Drawing.Point(96, 142);
            this.threadCountText.Name = "threadCountText";
            this.threadCountText.Size = new System.Drawing.Size(196, 20);
            this.threadCountText.TabIndex = 13;
            this.threadCountText.Text = "100";
            // 
            // bufferSizeText
            // 
            this.bufferSizeText.Location = new System.Drawing.Point(96, 169);
            this.bufferSizeText.Name = "bufferSizeText";
            this.bufferSizeText.Size = new System.Drawing.Size(100, 20);
            this.bufferSizeText.TabIndex = 14;
            this.bufferSizeText.Text = "8192";
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.outputText);
            this.groupBox1.Location = new System.Drawing.Point(13, 195);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(448, 227);
            this.groupBox1.TabIndex = 15;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Output";
            // 
            // outputText
            // 
            this.outputText.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.outputText.Location = new System.Drawing.Point(3, 20);
            this.outputText.Multiline = true;
            this.outputText.Name = "outputText";
            this.outputText.Size = new System.Drawing.Size(439, 201);
            this.outputText.TabIndex = 0;
            // 
            // startButton
            // 
            this.startButton.Location = new System.Drawing.Point(360, 171);
            this.startButton.Name = "startButton";
            this.startButton.Size = new System.Drawing.Size(75, 23);
            this.startButton.TabIndex = 16;
            this.startButton.Text = "Start";
            this.startButton.UseVisualStyleBackColor = true;
            this.startButton.Click += new System.EventHandler(this.startButton_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(473, 434);
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
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
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
    }
}

