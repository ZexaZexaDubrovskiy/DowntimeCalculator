namespace DowntimeCalculator
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
            WidthTextBox = new TextBox();
            WidthLabel = new Label();
            HeightLabel = new Label();
            HeightTextBox = new TextBox();
            SpeedTextBox = new TextBox();
            SpeedLabel = new Label();
            ChangeAccountUnitButton = new Button();
            RemoveAllDowntimeButton = new Button();
            TimeSpawnTextBox = new TextBox();
            TimeSpawnLabel = new Label();
            SuspendLayout();
            // 
            // WidthTextBox
            // 
            WidthTextBox.Location = new Point(12, 27);
            WidthTextBox.Name = "WidthTextBox";
            WidthTextBox.Size = new Size(100, 23);
            WidthTextBox.TabIndex = 0;
            WidthTextBox.KeyPress += WidthTextBox_KeyPress;
            // 
            // WidthLabel
            // 
            WidthLabel.AutoSize = true;
            WidthLabel.Location = new Point(12, 9);
            WidthLabel.Name = "WidthLabel";
            WidthLabel.Size = new Size(52, 15);
            WidthLabel.TabIndex = 1;
            WidthLabel.Text = "Ширина";
            // 
            // HeightLabel
            // 
            HeightLabel.AutoSize = true;
            HeightLabel.Location = new Point(118, 9);
            HeightLabel.Name = "HeightLabel";
            HeightLabel.Size = new Size(47, 15);
            HeightLabel.TabIndex = 2;
            HeightLabel.Text = "Высота";
            // 
            // HeightTextBox
            // 
            HeightTextBox.Location = new Point(118, 27);
            HeightTextBox.Name = "HeightTextBox";
            HeightTextBox.Size = new Size(100, 23);
            HeightTextBox.TabIndex = 3;
            HeightTextBox.KeyPress += HeightTextBox_KeyPress;
            // 
            // SpeedTextBox
            // 
            SpeedTextBox.Location = new Point(224, 27);
            SpeedTextBox.Name = "SpeedTextBox";
            SpeedTextBox.Size = new Size(100, 23);
            SpeedTextBox.TabIndex = 5;
            SpeedTextBox.KeyPress += SpeedTextBox_KeyPress;
            // 
            // SpeedLabel
            // 
            SpeedLabel.AutoSize = true;
            SpeedLabel.Location = new Point(224, 9);
            SpeedLabel.Name = "SpeedLabel";
            SpeedLabel.Size = new Size(59, 15);
            SpeedLabel.TabIndex = 4;
            SpeedLabel.Text = "Скорость";
            // 
            // ChangeAccountUnitButton
            // 
            ChangeAccountUnitButton.Location = new Point(12, 56);
            ChangeAccountUnitButton.Name = "ChangeAccountUnitButton";
            ChangeAccountUnitButton.Size = new Size(206, 41);
            ChangeAccountUnitButton.TabIndex = 6;
            ChangeAccountUnitButton.Text = "Применить изменения";
            ChangeAccountUnitButton.UseVisualStyleBackColor = true;
            ChangeAccountUnitButton.Click += ChangeAccountUnitButton_Click;
            // 
            // RemoveAllDowntimeButton
            // 
            RemoveAllDowntimeButton.Location = new Point(224, 56);
            RemoveAllDowntimeButton.Name = "RemoveAllDowntimeButton";
            RemoveAllDowntimeButton.Size = new Size(212, 41);
            RemoveAllDowntimeButton.TabIndex = 7;
            RemoveAllDowntimeButton.Text = "Удалить простои";
            RemoveAllDowntimeButton.UseVisualStyleBackColor = true;
            RemoveAllDowntimeButton.Click += RemoveAllDowntimeButton_Click;
            // 
            // TimeSpawnTextBox
            // 
            TimeSpawnTextBox.Location = new Point(330, 27);
            TimeSpawnTextBox.Name = "TimeSpawnTextBox";
            TimeSpawnTextBox.Size = new Size(100, 23);
            TimeSpawnTextBox.TabIndex = 9;
            // 
            // TimeSpawnLabel
            // 
            TimeSpawnLabel.AutoSize = true;
            TimeSpawnLabel.Location = new Point(330, 9);
            TimeSpawnLabel.Name = "TimeSpawnLabel";
            TimeSpawnLabel.Size = new Size(83, 15);
            TimeSpawnLabel.TabIndex = 8;
            TimeSpawnLabel.Text = "Время спавна";
            // 
            // Form1
            // 
            AutoScaleDimensions = new SizeF(7F, 15F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(884, 611);
            Controls.Add(TimeSpawnTextBox);
            Controls.Add(TimeSpawnLabel);
            Controls.Add(RemoveAllDowntimeButton);
            Controls.Add(ChangeAccountUnitButton);
            Controls.Add(SpeedTextBox);
            Controls.Add(SpeedLabel);
            Controls.Add(HeightTextBox);
            Controls.Add(HeightLabel);
            Controls.Add(WidthLabel);
            Controls.Add(WidthTextBox);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            MaximizeBox = false;
            Name = "Form1";
            StartPosition = FormStartPosition.CenterScreen;
            Text = "DowntimeCalculator";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private TextBox WidthTextBox;
        private Label WidthLabel;
        private Label HeightLabel;
        private TextBox HeightTextBox;
        private TextBox SpeedTextBox;
        private Label SpeedLabel;
        private Button ChangeAccountUnitButton;
        private Button RemoveAllDowntimeButton;
        private TextBox TimeSpawnTextBox;
        private Label TimeSpawnLabel;
    }
}
