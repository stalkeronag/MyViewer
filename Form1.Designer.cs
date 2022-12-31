using MyViewer.ClientHost;
using MyViewer.Core;

namespace MyViewer
{
    partial class Form1
    {
        /// <summary>
        /// Обязательная переменная конструктора.
        /// </summary>
        private System.ComponentModel.IContainer components = null;


        /// <summary>
        /// Освободить все используемые ресурсы.
        /// </summary>
        /// <param name="disposing">истинно, если управляемый ресурс должен быть удален; иначе ложно.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }
        
        #region Код, автоматически созданный конструктором форм Windows

        /// <summary>
        /// Требуемый метод для поддержки конструктора — не изменяйте 
        /// содержимое этого метода с помощью редактора кода.
        /// </summary>
        private void InitializeComponent()
        {
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.IpEndPoint = new System.Windows.Forms.TextBox();
            this.Port = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.button3 = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(665, 12);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(206, 93);
            this.button1.TabIndex = 1;
            this.button1.Text = "RemoteMode";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.RemoteMode);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(665, 123);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(206, 77);
            this.button2.TabIndex = 2;
            this.button2.Text = "HostMode";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.HostMode);
            // 
            // IpEndPoint
            // 
            this.IpEndPoint.Location = new System.Drawing.Point(665, 241);
            this.IpEndPoint.Name = "IpEndPoint";
            this.IpEndPoint.Size = new System.Drawing.Size(206, 22);
            this.IpEndPoint.TabIndex = 3;
            // 
            // Port
            // 
            this.Port.Location = new System.Drawing.Point(665, 299);
            this.Port.Name = "Port";
            this.Port.Size = new System.Drawing.Size(206, 22);
            this.Port.TabIndex = 4;
            this.Port.TextChanged += new System.EventHandler(this.Port_TextChanged);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(724, 222);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 16);
            this.label1.TabIndex = 5;
            this.label1.Text = "IpEndPoint";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(749, 280);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(31, 16);
            this.label2.TabIndex = 6;
            this.label2.Text = "Port";
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(3, 4);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(637, 538);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.MouseClick += new System.Windows.Forms.MouseEventHandler(this.OnMouseClick);
            // 
            // button3
            // 
            this.button3.Location = new System.Drawing.Point(665, 376);
            this.button3.Name = "button3";
            this.button3.Size = new System.Drawing.Size(206, 58);
            this.button3.TabIndex = 7;
            this.button3.Text = "Stop";
            this.button3.UseVisualStyleBackColor = true;
            this.button3.Click += new System.EventHandler(this.Disconnect);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Location = new System.Drawing.Point(665, 458);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(206, 116);
            this.richTextBox1.TabIndex = 8;
            this.richTextBox1.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(883, 617);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.button3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.Port);
            this.Controls.Add(this.IpEndPoint);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.pictureBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.TextBox IpEndPoint;
        private System.Windows.Forms.TextBox Port;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button button3;
        private System.Windows.Forms.RichTextBox richTextBox1;
    }
}

