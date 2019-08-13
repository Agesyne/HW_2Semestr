namespace CW_3._3_1
{
    partial class Background
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
            this.ProgressBar = new System.Windows.Forms.ProgressBar();
            this.ProgressBarStartButton = new System.Windows.Forms.Button();
            this.Timer = new System.Windows.Forms.Timer(this.components);
            this.CloseButton = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // ProgressBar
            // 
            this.ProgressBar.Location = new System.Drawing.Point(12, 12);
            this.ProgressBar.Name = "ProgressBar";
            this.ProgressBar.Size = new System.Drawing.Size(156, 23);
            this.ProgressBar.Step = 1;
            this.ProgressBar.TabIndex = 0;
            // 
            // ProgressBarStartButton
            // 
            this.ProgressBarStartButton.Location = new System.Drawing.Point(12, 41);
            this.ProgressBarStartButton.Name = "ProgressBarStartButton";
            this.ProgressBarStartButton.Size = new System.Drawing.Size(75, 23);
            this.ProgressBarStartButton.TabIndex = 1;
            this.ProgressBarStartButton.Text = "Start!";
            this.ProgressBarStartButton.UseVisualStyleBackColor = true;
            this.ProgressBarStartButton.Click += new System.EventHandler(this.ProgressBarStartButton_Click);
            // 
            // Timer
            // 
            this.Timer.Interval = 40;
            this.Timer.Tick += new System.EventHandler(this.Timer_Tick);
            // 
            // CloseButton
            // 
            this.CloseButton.Location = new System.Drawing.Point(93, 41);
            this.CloseButton.Name = "CloseButton";
            this.CloseButton.Size = new System.Drawing.Size(75, 23);
            this.CloseButton.TabIndex = 2;
            this.CloseButton.Text = "Close";
            this.CloseButton.UseVisualStyleBackColor = true;
            this.CloseButton.Visible = false;
            this.CloseButton.Click += new System.EventHandler(this.CloseButton_Click);
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(184, 86);
            this.Controls.Add(this.CloseButton);
            this.Controls.Add(this.ProgressBarStartButton);
            this.Controls.Add(this.ProgressBar);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Background";
            this.Text = "Progress Bar";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.ProgressBar ProgressBar;
        private System.Windows.Forms.Button ProgressBarStartButton;
        private System.Windows.Forms.Timer Timer;
        private System.Windows.Forms.Button CloseButton;
    }
}

