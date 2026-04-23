namespace events
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            components = new System.ComponentModel.Container();
            pbMain = new PictureBox();
            timer1 = new System.Windows.Forms.Timer(components);
            txtLog = new RichTextBox();
            lblScore = new Label();
            coutdownTimer = new System.Windows.Forms.Timer(components);
            ((System.ComponentModel.ISupportInitialize)pbMain).BeginInit();
            SuspendLayout();
            // 
            // pbMain
            // 
            pbMain.Location = new Point(2, 12);
            pbMain.Name = "pbMain";
            pbMain.Size = new Size(597, 325);
            pbMain.TabIndex = 0;
            pbMain.TabStop = false;
            pbMain.Click += pbMain_Click;
            pbMain.Paint += pbMain_paint;
            pbMain.MouseClick += pbMain_MouseClick;
            // 
            // timer1
            // 
            timer1.Enabled = true;
            timer1.Interval = 30;
            timer1.Tick += timer1_Tick;
            // 
            // txtLog
            // 
            txtLog.Location = new Point(605, 12);
            txtLog.Name = "txtLog";
            txtLog.Size = new Size(168, 325);
            txtLog.TabIndex = 1;
            txtLog.Text = "";
            // 
            // lblScore
            // 
            lblScore.AutoSize = true;
            lblScore.Location = new Point(510, 22);
            lblScore.Name = "lblScore";
            lblScore.Size = new Size(51, 20);
            lblScore.TabIndex = 2;
            lblScore.Text = "Очки: ";
            lblScore.Click += label1_Click;
            // 
            // coutdownTimer
            // 
            coutdownTimer.Enabled = true;
            coutdownTimer.Interval = 60;
            coutdownTimer.Tick += coutdownTimer_Tick;
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(780, 355);
            Controls.Add(lblScore);
            Controls.Add(txtLog);
            Controls.Add(pbMain);
            Name = "Form1";
            Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)pbMain).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private PictureBox pbMain;
        private System.Windows.Forms.Timer timer1;
        private RichTextBox txtLog;
        private Label lblScore;
        private System.Windows.Forms.Timer coutdownTimer;
    }
}
