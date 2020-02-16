namespace LoggerAnalysisTool
{
    partial class SearchTextDialog
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
            this.logsComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.searchKeyWordTextBox = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.FindButton = new System.Windows.Forms.Button();
            this.FindNextButton = new System.Windows.Forms.Button();
            this.closeButton = new System.Windows.Forms.Button();
            this.searchFromLabel = new System.Windows.Forms.Label();
            this.searchFromTopRadioButton = new System.Windows.Forms.RadioButton();
            this.searchFromBottomRadioButton = new System.Windows.Forms.RadioButton();
            this.NumberOfOccurencesLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // logsComboBox
            // 
            this.logsComboBox.FormattingEnabled = true;
            this.logsComboBox.Location = new System.Drawing.Point(106, 12);
            this.logsComboBox.Name = "logsComboBox";
            this.logsComboBox.Size = new System.Drawing.Size(165, 21);
            this.logsComboBox.TabIndex = 0;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 15);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(88, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Select Log Box : ";
            // 
            // searchKeyWordTextBox
            // 
            this.searchKeyWordTextBox.Location = new System.Drawing.Point(106, 39);
            this.searchKeyWordTextBox.Name = "searchKeyWordTextBox";
            this.searchKeyWordTextBox.Size = new System.Drawing.Size(102, 20);
            this.searchKeyWordTextBox.TabIndex = 2;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 42);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(94, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Search Keyword : ";
            // 
            // FindButton
            // 
            this.FindButton.Location = new System.Drawing.Point(12, 99);
            this.FindButton.Name = "FindButton";
            this.FindButton.Size = new System.Drawing.Size(101, 23);
            this.FindButton.TabIndex = 4;
            this.FindButton.Text = "Find";
            this.FindButton.UseVisualStyleBackColor = true;
            this.FindButton.Click += new System.EventHandler(this.FindButton_Click);
            // 
            // FindNextButton
            // 
            this.FindNextButton.Location = new System.Drawing.Point(119, 99);
            this.FindNextButton.Name = "FindNextButton";
            this.FindNextButton.Size = new System.Drawing.Size(89, 23);
            this.FindNextButton.TabIndex = 5;
            this.FindNextButton.Text = "Next >>";
            this.FindNextButton.UseVisualStyleBackColor = true;
            this.FindNextButton.Click += new System.EventHandler(this.FindNextButton_Click);
            // 
            // closeButton
            // 
            this.closeButton.Location = new System.Drawing.Point(214, 99);
            this.closeButton.Name = "closeButton";
            this.closeButton.Size = new System.Drawing.Size(59, 23);
            this.closeButton.TabIndex = 8;
            this.closeButton.Text = "Close";
            this.closeButton.UseVisualStyleBackColor = true;
            this.closeButton.Click += new System.EventHandler(this.closeButton_Click);
            // 
            // searchFromLabel
            // 
            this.searchFromLabel.AutoSize = true;
            this.searchFromLabel.Location = new System.Drawing.Point(12, 68);
            this.searchFromLabel.Name = "searchFromLabel";
            this.searchFromLabel.Size = new System.Drawing.Size(76, 13);
            this.searchFromLabel.TabIndex = 9;
            this.searchFromLabel.Text = "Search From : ";
            // 
            // searchFromTopRadioButton
            // 
            this.searchFromTopRadioButton.AutoSize = true;
            this.searchFromTopRadioButton.Location = new System.Drawing.Point(106, 68);
            this.searchFromTopRadioButton.Name = "searchFromTopRadioButton";
            this.searchFromTopRadioButton.Size = new System.Drawing.Size(44, 17);
            this.searchFromTopRadioButton.TabIndex = 10;
            this.searchFromTopRadioButton.TabStop = true;
            this.searchFromTopRadioButton.Text = "Top";
            this.searchFromTopRadioButton.UseVisualStyleBackColor = true;
            // 
            // searchFromBottomRadioButton
            // 
            this.searchFromBottomRadioButton.AutoSize = true;
            this.searchFromBottomRadioButton.Location = new System.Drawing.Point(167, 68);
            this.searchFromBottomRadioButton.Name = "searchFromBottomRadioButton";
            this.searchFromBottomRadioButton.Size = new System.Drawing.Size(58, 17);
            this.searchFromBottomRadioButton.TabIndex = 11;
            this.searchFromBottomRadioButton.TabStop = true;
            this.searchFromBottomRadioButton.Text = "Bottom";
            this.searchFromBottomRadioButton.UseVisualStyleBackColor = true;
            // 
            // NumberOfOccurencesLabel
            // 
            this.NumberOfOccurencesLabel.AutoSize = true;
            this.NumberOfOccurencesLabel.Location = new System.Drawing.Point(22, 125);
            this.NumberOfOccurencesLabel.Name = "NumberOfOccurencesLabel";
            this.NumberOfOccurencesLabel.Size = new System.Drawing.Size(0, 13);
            this.NumberOfOccurencesLabel.TabIndex = 12;
            // 
            // SearchTextDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(283, 144);
            this.ControlBox = false;
            this.Controls.Add(this.NumberOfOccurencesLabel);
            this.Controls.Add(this.searchFromBottomRadioButton);
            this.Controls.Add(this.searchFromTopRadioButton);
            this.Controls.Add(this.searchFromLabel);
            this.Controls.Add(this.closeButton);
            this.Controls.Add(this.FindNextButton);
            this.Controls.Add(this.FindButton);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.searchKeyWordTextBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.logsComboBox);
            this.MaximizeBox = false;
            this.MinimizeBox = false;
            this.Name = "SearchTextDialog";
            this.ShowIcon = false;
            this.ShowInTaskbar = false;
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterParent;
            this.Text = "Find Text";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.ComboBox logsComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox searchKeyWordTextBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button FindButton;
        private System.Windows.Forms.Button FindNextButton;
        private System.Windows.Forms.Button closeButton;
        private System.Windows.Forms.Label searchFromLabel;
        private System.Windows.Forms.RadioButton searchFromTopRadioButton;
        private System.Windows.Forms.RadioButton searchFromBottomRadioButton;
        private System.Windows.Forms.Label NumberOfOccurencesLabel;
    }
}