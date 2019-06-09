namespace Calculator
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
            this.ExpressionBox = new System.Windows.Forms.TextBox();
            this.LeftBracketButton = new System.Windows.Forms.Button();
            this.RightBracketButton = new System.Windows.Forms.Button();
            this.ClearButton = new System.Windows.Forms.Button();
            this.Number7Button = new System.Windows.Forms.Button();
            this.Number8Button = new System.Windows.Forms.Button();
            this.Number9Button = new System.Windows.Forms.Button();
            this.Number4Button = new System.Windows.Forms.Button();
            this.Number5Button = new System.Windows.Forms.Button();
            this.Number6Button = new System.Windows.Forms.Button();
            this.Number2Button = new System.Windows.Forms.Button();
            this.Number1Button = new System.Windows.Forms.Button();
            this.Number3Button = new System.Windows.Forms.Button();
            this.PlusButton = new System.Windows.Forms.Button();
            this.MinusButton = new System.Windows.Forms.Button();
            this.MultiplyButton = new System.Windows.Forms.Button();
            this.DivideButton = new System.Windows.Forms.Button();
            this.RestDivideButton = new System.Windows.Forms.Button();
            this.Number0Button = new System.Windows.Forms.Button();
            this.BackspaceButton = new System.Windows.Forms.Button();
            this.CulculateButton = new System.Windows.Forms.Button();
            this.ResultBox = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // ExpressionBox
            // 
            this.ExpressionBox.Location = new System.Drawing.Point(12, 12);
            this.ExpressionBox.Multiline = true;
            this.ExpressionBox.Name = "ExpressionBox";
            this.ExpressionBox.Size = new System.Drawing.Size(178, 50);
            this.ExpressionBox.TabIndex = 0;
            // 
            // LeftBracketButton
            // 
            this.LeftBracketButton.Location = new System.Drawing.Point(12, 68);
            this.LeftBracketButton.Name = "LeftBracketButton";
            this.LeftBracketButton.Size = new System.Drawing.Size(40, 40);
            this.LeftBracketButton.TabIndex = 1;
            this.LeftBracketButton.Text = "(";
            this.LeftBracketButton.UseVisualStyleBackColor = true;
            this.LeftBracketButton.Click += new System.EventHandler(this.LeftBracketButton_Click);
            // 
            // RightBracketButton
            // 
            this.RightBracketButton.Location = new System.Drawing.Point(58, 68);
            this.RightBracketButton.Name = "RightBracketButton";
            this.RightBracketButton.Size = new System.Drawing.Size(40, 40);
            this.RightBracketButton.TabIndex = 2;
            this.RightBracketButton.Text = ")";
            this.RightBracketButton.UseVisualStyleBackColor = true;
            this.RightBracketButton.Click += new System.EventHandler(this.RightBracketButton_Click);
            // 
            // ClearButton
            // 
            this.ClearButton.Location = new System.Drawing.Point(12, 252);
            this.ClearButton.Name = "ClearButton";
            this.ClearButton.Size = new System.Drawing.Size(40, 40);
            this.ClearButton.TabIndex = 3;
            this.ClearButton.Text = "C";
            this.ClearButton.UseVisualStyleBackColor = true;
            this.ClearButton.Click += new System.EventHandler(this.ClearButton_Click);
            // 
            // Number7Button
            // 
            this.Number7Button.Location = new System.Drawing.Point(12, 114);
            this.Number7Button.Name = "Number7Button";
            this.Number7Button.Size = new System.Drawing.Size(40, 40);
            this.Number7Button.TabIndex = 4;
            this.Number7Button.Tag = "7";
            this.Number7Button.Text = "7";
            this.Number7Button.UseVisualStyleBackColor = true;
            this.Number7Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number8Button
            // 
            this.Number8Button.Location = new System.Drawing.Point(58, 114);
            this.Number8Button.Name = "Number8Button";
            this.Number8Button.Size = new System.Drawing.Size(40, 40);
            this.Number8Button.TabIndex = 5;
            this.Number8Button.Tag = "8";
            this.Number8Button.Text = "8";
            this.Number8Button.UseVisualStyleBackColor = true;
            this.Number8Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number9Button
            // 
            this.Number9Button.Location = new System.Drawing.Point(104, 114);
            this.Number9Button.Name = "Number9Button";
            this.Number9Button.Size = new System.Drawing.Size(40, 40);
            this.Number9Button.TabIndex = 6;
            this.Number9Button.Tag = "9";
            this.Number9Button.Text = "9";
            this.Number9Button.UseVisualStyleBackColor = true;
            this.Number9Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number4Button
            // 
            this.Number4Button.Location = new System.Drawing.Point(12, 160);
            this.Number4Button.Name = "Number4Button";
            this.Number4Button.Size = new System.Drawing.Size(40, 40);
            this.Number4Button.TabIndex = 7;
            this.Number4Button.Tag = "4";
            this.Number4Button.Text = "4";
            this.Number4Button.UseVisualStyleBackColor = true;
            this.Number4Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number5Button
            // 
            this.Number5Button.Location = new System.Drawing.Point(58, 160);
            this.Number5Button.Name = "Number5Button";
            this.Number5Button.Size = new System.Drawing.Size(40, 40);
            this.Number5Button.TabIndex = 8;
            this.Number5Button.Tag = "5";
            this.Number5Button.Text = "5";
            this.Number5Button.UseVisualStyleBackColor = true;
            this.Number5Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number6Button
            // 
            this.Number6Button.Location = new System.Drawing.Point(104, 160);
            this.Number6Button.Name = "Number6Button";
            this.Number6Button.Size = new System.Drawing.Size(40, 40);
            this.Number6Button.TabIndex = 9;
            this.Number6Button.Tag = "6";
            this.Number6Button.Text = "6";
            this.Number6Button.UseVisualStyleBackColor = true;
            this.Number6Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number2Button
            // 
            this.Number2Button.Location = new System.Drawing.Point(58, 206);
            this.Number2Button.Name = "Number2Button";
            this.Number2Button.Size = new System.Drawing.Size(40, 40);
            this.Number2Button.TabIndex = 10;
            this.Number2Button.Tag = "2";
            this.Number2Button.Text = "2";
            this.Number2Button.UseVisualStyleBackColor = true;
            this.Number2Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number1Button
            // 
            this.Number1Button.Location = new System.Drawing.Point(12, 206);
            this.Number1Button.Name = "Number1Button";
            this.Number1Button.Size = new System.Drawing.Size(40, 40);
            this.Number1Button.TabIndex = 11;
            this.Number1Button.Tag = "1";
            this.Number1Button.Text = "1";
            this.Number1Button.UseVisualStyleBackColor = true;
            this.Number1Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // Number3Button
            // 
            this.Number3Button.Location = new System.Drawing.Point(104, 206);
            this.Number3Button.Name = "Number3Button";
            this.Number3Button.Size = new System.Drawing.Size(40, 40);
            this.Number3Button.TabIndex = 12;
            this.Number3Button.Tag = "3";
            this.Number3Button.Text = "3";
            this.Number3Button.UseVisualStyleBackColor = true;
            this.Number3Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // PlusButton
            // 
            this.PlusButton.Location = new System.Drawing.Point(150, 252);
            this.PlusButton.Name = "PlusButton";
            this.PlusButton.Size = new System.Drawing.Size(40, 40);
            this.PlusButton.TabIndex = 13;
            this.PlusButton.Tag = "+";
            this.PlusButton.Text = "+";
            this.PlusButton.UseVisualStyleBackColor = true;
            this.PlusButton.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // MinusButton
            // 
            this.MinusButton.Location = new System.Drawing.Point(150, 206);
            this.MinusButton.Name = "MinusButton";
            this.MinusButton.Size = new System.Drawing.Size(40, 40);
            this.MinusButton.TabIndex = 14;
            this.MinusButton.Tag = "-";
            this.MinusButton.Text = "-";
            this.MinusButton.UseVisualStyleBackColor = true;
            this.MinusButton.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // MultiplyButton
            // 
            this.MultiplyButton.Location = new System.Drawing.Point(150, 160);
            this.MultiplyButton.Name = "MultiplyButton";
            this.MultiplyButton.Size = new System.Drawing.Size(40, 40);
            this.MultiplyButton.TabIndex = 15;
            this.MultiplyButton.Tag = "*";
            this.MultiplyButton.Text = "*";
            this.MultiplyButton.UseVisualStyleBackColor = true;
            this.MultiplyButton.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // DivideButton
            // 
            this.DivideButton.Location = new System.Drawing.Point(150, 114);
            this.DivideButton.Name = "DivideButton";
            this.DivideButton.Size = new System.Drawing.Size(40, 40);
            this.DivideButton.TabIndex = 16;
            this.DivideButton.Tag = "/";
            this.DivideButton.Text = "/";
            this.DivideButton.UseVisualStyleBackColor = true;
            this.DivideButton.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // RestDivideButton
            // 
            this.RestDivideButton.Location = new System.Drawing.Point(150, 68);
            this.RestDivideButton.Name = "RestDivideButton";
            this.RestDivideButton.Size = new System.Drawing.Size(40, 40);
            this.RestDivideButton.TabIndex = 17;
            this.RestDivideButton.Tag = "%";
            this.RestDivideButton.Text = "%";
            this.RestDivideButton.UseVisualStyleBackColor = true;
            this.RestDivideButton.Click += new System.EventHandler(this.OperationButton_Click);
            // 
            // Number0Button
            // 
            this.Number0Button.Location = new System.Drawing.Point(58, 252);
            this.Number0Button.Name = "Number0Button";
            this.Number0Button.Size = new System.Drawing.Size(40, 40);
            this.Number0Button.TabIndex = 18;
            this.Number0Button.Tag = "0";
            this.Number0Button.Text = "0";
            this.Number0Button.UseVisualStyleBackColor = true;
            this.Number0Button.Click += new System.EventHandler(this.NumberButton_Click);
            // 
            // BackspaceButton
            // 
            this.BackspaceButton.Location = new System.Drawing.Point(104, 68);
            this.BackspaceButton.Name = "BackspaceButton";
            this.BackspaceButton.Size = new System.Drawing.Size(40, 40);
            this.BackspaceButton.TabIndex = 19;
            this.BackspaceButton.Text = "<=";
            this.BackspaceButton.UseVisualStyleBackColor = true;
            this.BackspaceButton.Click += new System.EventHandler(this.BackspaceButton_Click);
            // 
            // CulculateButton
            // 
            this.CulculateButton.Location = new System.Drawing.Point(104, 252);
            this.CulculateButton.Name = "CulculateButton";
            this.CulculateButton.Size = new System.Drawing.Size(40, 40);
            this.CulculateButton.TabIndex = 20;
            this.CulculateButton.Text = "=";
            this.CulculateButton.UseVisualStyleBackColor = true;
            this.CulculateButton.Click += new System.EventHandler(this.CulculateButton_Click);
            // 
            // ResultBox
            // 
            this.ResultBox.AutoSize = true;
            this.ResultBox.Location = new System.Drawing.Point(12, 49);
            this.ResultBox.Name = "ResultBox";
            this.ResultBox.Size = new System.Drawing.Size(37, 13);
            this.ResultBox.TabIndex = 21;
            this.ResultBox.Text = "Result";
            // 
            // Background
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(202, 301);
            this.Controls.Add(this.ResultBox);
            this.Controls.Add(this.CulculateButton);
            this.Controls.Add(this.BackspaceButton);
            this.Controls.Add(this.Number0Button);
            this.Controls.Add(this.RestDivideButton);
            this.Controls.Add(this.DivideButton);
            this.Controls.Add(this.MultiplyButton);
            this.Controls.Add(this.MinusButton);
            this.Controls.Add(this.PlusButton);
            this.Controls.Add(this.Number3Button);
            this.Controls.Add(this.Number1Button);
            this.Controls.Add(this.Number2Button);
            this.Controls.Add(this.Number6Button);
            this.Controls.Add(this.Number5Button);
            this.Controls.Add(this.Number4Button);
            this.Controls.Add(this.Number9Button);
            this.Controls.Add(this.Number8Button);
            this.Controls.Add(this.Number7Button);
            this.Controls.Add(this.ClearButton);
            this.Controls.Add(this.RightBracketButton);
            this.Controls.Add(this.LeftBracketButton);
            this.Controls.Add(this.ExpressionBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "Background";
            this.Text = "Calculator";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox ExpressionBox;
        private System.Windows.Forms.Button LeftBracketButton;
        private System.Windows.Forms.Button RightBracketButton;
        private System.Windows.Forms.Button ClearButton;
        private System.Windows.Forms.Button Number7Button;
        private System.Windows.Forms.Button Number8Button;
        private System.Windows.Forms.Button Number9Button;
        private System.Windows.Forms.Button Number4Button;
        private System.Windows.Forms.Button Number5Button;
        private System.Windows.Forms.Button Number6Button;
        private System.Windows.Forms.Button Number2Button;
        private System.Windows.Forms.Button Number1Button;
        private System.Windows.Forms.Button Number3Button;
        private System.Windows.Forms.Button PlusButton;
        private System.Windows.Forms.Button MinusButton;
        private System.Windows.Forms.Button MultiplyButton;
        private System.Windows.Forms.Button DivideButton;
        private System.Windows.Forms.Button RestDivideButton;
        private System.Windows.Forms.Button Number0Button;
        private System.Windows.Forms.Button BackspaceButton;
        private System.Windows.Forms.Button CulculateButton;
        private System.Windows.Forms.Label ResultBox;
    }
}

