namespace TestDriver
{
    partial class MainForm
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
            this.buttonStartRunEstimate = new System.Windows.Forms.Button();
            this.richTextBox1 = new System.Windows.Forms.RichTextBox();
            this.buttonStartDel = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // buttonStartRunEstimate
            // 
            this.buttonStartRunEstimate.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Bottom | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.buttonStartRunEstimate.Location = new System.Drawing.Point(157, 397);
            this.buttonStartRunEstimate.Name = "buttonStartRunEstimate";
            this.buttonStartRunEstimate.Size = new System.Drawing.Size(156, 23);
            this.buttonStartRunEstimate.TabIndex = 0;
            this.buttonStartRunEstimate.Text = "Тестирование RunEstimate";
            this.buttonStartRunEstimate.UseVisualStyleBackColor = true;
            this.buttonStartRunEstimate.Click += new System.EventHandler(this.buttonStart_Click);
            // 
            // richTextBox1
            // 
            this.richTextBox1.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom)
                        | System.Windows.Forms.AnchorStyles.Left)
                        | System.Windows.Forms.AnchorStyles.Right)));
            this.richTextBox1.Location = new System.Drawing.Point(12, 12);
            this.richTextBox1.Name = "richTextBox1";
            this.richTextBox1.Size = new System.Drawing.Size(546, 379);
            this.richTextBox1.TabIndex = 1;
            this.richTextBox1.Text = "";
            // 
            // buttonStartDel
            // 
            this.buttonStartDel.Location = new System.Drawing.Point(12, 397);
            this.buttonStartDel.Name = "buttonStartDel";
            this.buttonStartDel.Size = new System.Drawing.Size(139, 35);
            this.buttonStartDel.TabIndex = 2;
            this.buttonStartDel.Text = "Тестирование дел с ост";
            this.buttonStartDel.UseVisualStyleBackColor = true;
            this.buttonStartDel.Click += new System.EventHandler(this.buttonStartDel_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(570, 432);
            this.Controls.Add(this.buttonStartDel);
            this.Controls.Add(this.richTextBox1);
            this.Controls.Add(this.buttonStartRunEstimate);
            this.MinimumSize = new System.Drawing.Size(578, 466);
            this.Name = "MainForm";
            this.ShowIcon = false;
            this.Text = "Тестовый драйвер для калькулятора";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button buttonStartRunEstimate;
        private System.Windows.Forms.RichTextBox richTextBox1;
        private System.Windows.Forms.Button buttonStartDel;
    }
}

