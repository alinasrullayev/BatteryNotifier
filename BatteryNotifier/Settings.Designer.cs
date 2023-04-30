namespace BatteryNotifier
{
    partial class Settings
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
            tabControl1 = new TabControl();
            tabPage2 = new TabPage();
            resetToDefault = new Button();
            batteryUpperThreshold = new NumericUpDown();
            batteryUpperThresholdLabel = new Label();
            batteryLowerThreshold = new NumericUpDown();
            batteryLowerThresholdLabel = new Label();
            apply = new Button();
            close_restart = new Button();
            tabControl1.SuspendLayout();
            tabPage2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)batteryUpperThreshold).BeginInit();
            ((System.ComponentModel.ISupportInitialize)batteryLowerThreshold).BeginInit();
            SuspendLayout();
            // 
            // tabControl1
            // 
            tabControl1.Controls.Add(tabPage2);
            tabControl1.Location = new Point(12, 12);
            tabControl1.Name = "tabControl1";
            tabControl1.SelectedIndex = 0;
            tabControl1.Size = new Size(528, 252);
            tabControl1.TabIndex = 0;
            // 
            // tabPage2
            // 
            tabPage2.Controls.Add(resetToDefault);
            tabPage2.Controls.Add(batteryUpperThreshold);
            tabPage2.Controls.Add(batteryUpperThresholdLabel);
            tabPage2.Controls.Add(batteryLowerThreshold);
            tabPage2.Controls.Add(batteryLowerThresholdLabel);
            tabPage2.Controls.Add(apply);
            tabPage2.Controls.Add(close_restart);
            tabPage2.Location = new Point(4, 29);
            tabPage2.Name = "tabPage2";
            tabPage2.Padding = new Padding(3);
            tabPage2.Size = new Size(520, 219);
            tabPage2.TabIndex = 1;
            tabPage2.Text = "General";
            tabPage2.UseVisualStyleBackColor = true;
            // 
            // resetToDefault
            // 
            resetToDefault.Location = new Point(383, 149);
            resetToDefault.Name = "resetToDefault";
            resetToDefault.Size = new Size(131, 29);
            resetToDefault.TabIndex = 1;
            resetToDefault.Text = "Reset to Default";
            resetToDefault.UseVisualStyleBackColor = true;
            resetToDefault.Click += resetToDefault_Click;
            // 
            // batteryUpperThreshold
            // 
            batteryUpperThreshold.Location = new Point(182, 45);
            batteryUpperThreshold.Name = "batteryUpperThreshold";
            batteryUpperThreshold.Size = new Size(65, 27);
            batteryUpperThreshold.TabIndex = 6;
            batteryUpperThreshold.ValueChanged += batteryUpperThreshold_ValueChanged;
            batteryUpperThreshold.MouseClick += batteryUpperThreshold_MouseClick;
            // 
            // batteryUpperThresholdLabel
            // 
            batteryUpperThresholdLabel.AutoSize = true;
            batteryUpperThresholdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            batteryUpperThresholdLabel.Location = new Point(6, 47);
            batteryUpperThresholdLabel.Name = "batteryUpperThresholdLabel";
            batteryUpperThresholdLabel.Size = new Size(170, 20);
            batteryUpperThresholdLabel.TabIndex = 5;
            batteryUpperThresholdLabel.Text = "Battery Upper Threshold";
            // 
            // batteryLowerThreshold
            // 
            batteryLowerThreshold.Location = new Point(181, 12);
            batteryLowerThreshold.Name = "batteryLowerThreshold";
            batteryLowerThreshold.Size = new Size(65, 27);
            batteryLowerThreshold.TabIndex = 4;
            batteryLowerThreshold.ValueChanged += batteryLowerThreshold_ValueChanged;
            batteryLowerThreshold.MouseClick += batteryLowerThreshold_MouseClick;
            // 
            // batteryLowerThresholdLabel
            // 
            batteryLowerThresholdLabel.AutoSize = true;
            batteryLowerThresholdLabel.Font = new Font("Segoe UI", 9F, FontStyle.Regular, GraphicsUnit.Point);
            batteryLowerThresholdLabel.Location = new Point(6, 14);
            batteryLowerThresholdLabel.Name = "batteryLowerThresholdLabel";
            batteryLowerThresholdLabel.Size = new Size(169, 20);
            batteryLowerThresholdLabel.TabIndex = 3;
            batteryLowerThresholdLabel.Text = "Battery Lower Threshold";
            // 
            // apply
            // 
            apply.Enabled = false;
            apply.Location = new Point(320, 184);
            apply.Name = "apply";
            apply.Size = new Size(94, 29);
            apply.TabIndex = 1;
            apply.Text = "Apply";
            apply.UseVisualStyleBackColor = true;
            apply.Click += apply_Click;
            // 
            // close_restart
            // 
            close_restart.Location = new Point(420, 184);
            close_restart.Name = "close_restart";
            close_restart.Size = new Size(94, 29);
            close_restart.TabIndex = 0;
            close_restart.Text = "Close";
            close_restart.UseVisualStyleBackColor = true;
            close_restart.Click += CloseWindow;
            // 
            // Settings
            // 
            AutoScaleDimensions = new SizeF(8F, 20F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(552, 276);
            Controls.Add(tabControl1);
            FormBorderStyle = FormBorderStyle.Fixed3D;
            Name = "Settings";
            Text = "Settings";
            tabControl1.ResumeLayout(false);
            tabPage2.ResumeLayout(false);
            tabPage2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)batteryUpperThreshold).EndInit();
            ((System.ComponentModel.ISupportInitialize)batteryLowerThreshold).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private TabControl tabControl1;
        private TabPage tabPage2;
        private Label batteryLowerThresholdLabel;
        private Button apply;
        private Button close_restart;
        private NumericUpDown batteryUpperThreshold;
        private Label batteryUpperThresholdLabel;
        private NumericUpDown batteryLowerThreshold;
        private Button resetToDefault;
    }
}