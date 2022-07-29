
namespace BusPath
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
            this.filePathTextBox = new System.Windows.Forms.TextBox();
            this.filePathLabel = new System.Windows.Forms.Label();
            this.filePathDialogButton = new System.Windows.Forms.Button();
            this.openFileDialog = new System.Windows.Forms.OpenFileDialog();
            this.startStopListBox = new System.Windows.Forms.ListBox();
            this.endStopListBox = new System.Windows.Forms.ListBox();
            this.startTimeLable = new System.Windows.Forms.Label();
            this.calculateButton = new System.Windows.Forms.Button();
            this.startTimeDateTimePicker = new System.Windows.Forms.DateTimePicker();
            this.resultTextBox = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // filePathTextBox
            // 
            this.filePathTextBox.Location = new System.Drawing.Point(125, 23);
            this.filePathTextBox.Name = "filePathTextBox";
            this.filePathTextBox.Size = new System.Drawing.Size(349, 27);
            this.filePathTextBox.TabIndex = 0;
            // 
            // filePathLabel
            // 
            this.filePathLabel.AutoSize = true;
            this.filePathLabel.Location = new System.Drawing.Point(13, 26);
            this.filePathLabel.Name = "filePathLabel";
            this.filePathLabel.Size = new System.Drawing.Size(106, 20);
            this.filePathLabel.TabIndex = 1;
            this.filePathLabel.Text = "Schedule path:";
            // 
            // filePathDialogButton
            // 
            this.filePathDialogButton.Location = new System.Drawing.Point(480, 22);
            this.filePathDialogButton.Name = "filePathDialogButton";
            this.filePathDialogButton.Size = new System.Drawing.Size(94, 29);
            this.filePathDialogButton.TabIndex = 2;
            this.filePathDialogButton.Text = "Open";
            this.filePathDialogButton.UseVisualStyleBackColor = true;
            this.filePathDialogButton.Click += new System.EventHandler(this.filePathDialogButton_Click);
            // 
            // openFileDialog
            // 
            this.openFileDialog.FileName = "openFileDialog";
            // 
            // startStopListBox
            // 
            this.startStopListBox.FormattingEnabled = true;
            this.startStopListBox.ItemHeight = 20;
            this.startStopListBox.Location = new System.Drawing.Point(13, 71);
            this.startStopListBox.Name = "startStopListBox";
            this.startStopListBox.Size = new System.Drawing.Size(183, 144);
            this.startStopListBox.TabIndex = 3;
            this.startStopListBox.SelectedIndexChanged += new System.EventHandler(this.startStopListBox_SelectedIndexChanged);
            // 
            // endStopListBox
            // 
            this.endStopListBox.FormattingEnabled = true;
            this.endStopListBox.ItemHeight = 20;
            this.endStopListBox.Location = new System.Drawing.Point(202, 71);
            this.endStopListBox.Name = "endStopListBox";
            this.endStopListBox.Size = new System.Drawing.Size(183, 144);
            this.endStopListBox.TabIndex = 4;
            // 
            // startTimeLable
            // 
            this.startTimeLable.AutoSize = true;
            this.startTimeLable.Location = new System.Drawing.Point(391, 75);
            this.startTimeLable.Name = "startTimeLable";
            this.startTimeLable.Size = new System.Drawing.Size(76, 20);
            this.startTimeLable.TabIndex = 6;
            this.startTimeLable.Text = "StartTime:";
            // 
            // calculateButton
            // 
            this.calculateButton.Location = new System.Drawing.Point(480, 186);
            this.calculateButton.Name = "calculateButton";
            this.calculateButton.Size = new System.Drawing.Size(94, 29);
            this.calculateButton.TabIndex = 7;
            this.calculateButton.Text = "Calculate";
            this.calculateButton.UseVisualStyleBackColor = true;
            this.calculateButton.Click += new System.EventHandler(this.calculateButton_Click);
            // 
            // startTimeDateTimePicker
            // 
            this.startTimeDateTimePicker.Format = System.Windows.Forms.DateTimePickerFormat.Time;
            this.startTimeDateTimePicker.Location = new System.Drawing.Point(391, 98);
            this.startTimeDateTimePicker.Name = "startTimeDateTimePicker";
            this.startTimeDateTimePicker.Size = new System.Drawing.Size(183, 27);
            this.startTimeDateTimePicker.TabIndex = 8;
            // 
            // resultTextBox
            // 
            this.resultTextBox.Enabled = false;
            this.resultTextBox.Location = new System.Drawing.Point(13, 248);
            this.resultTextBox.Multiline = true;
            this.resultTextBox.Name = "resultTextBox";
            this.resultTextBox.Size = new System.Drawing.Size(561, 112);
            this.resultTextBox.TabIndex = 9;
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 20F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(591, 374);
            this.Controls.Add(this.resultTextBox);
            this.Controls.Add(this.startTimeDateTimePicker);
            this.Controls.Add(this.calculateButton);
            this.Controls.Add(this.startTimeLable);
            this.Controls.Add(this.endStopListBox);
            this.Controls.Add(this.startStopListBox);
            this.Controls.Add(this.filePathDialogButton);
            this.Controls.Add(this.filePathLabel);
            this.Controls.Add(this.filePathTextBox);
            this.Name = "Form1";
            this.Text = "Bus Path";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox filePathTextBox;
        private System.Windows.Forms.Label filePathLabel;
        private System.Windows.Forms.Button filePathDialogButton;
        private System.Windows.Forms.OpenFileDialog openFileDialog;
        private System.Windows.Forms.ListBox startStopListBox;
        private System.Windows.Forms.ListBox endStopListBox;
        private System.Windows.Forms.Label startTimeLable;
        private System.Windows.Forms.Button calculateButton;
        private System.Windows.Forms.DateTimePicker startTimeDateTimePicker;
        private System.Windows.Forms.TextBox resultTextBox;
    }
}

