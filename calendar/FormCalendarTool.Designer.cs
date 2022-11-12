namespace calendar {
    partial class frmCalendarTool {
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
            this.txtYear = new System.Windows.Forms.TextBox();
            this.lblYear = new System.Windows.Forms.Label();
            this.btnGenerate = new System.Windows.Forms.Button();
            this.progressGenerate = new System.Windows.Forms.ProgressBar();
            this.lblStatus = new System.Windows.Forms.Label();
            this.panelStatus = new System.Windows.Forms.Panel();
            this.radioSinglePage = new System.Windows.Forms.RadioButton();
            this.groupFormats = new System.Windows.Forms.GroupBox();
            this.radioDoubleSided = new System.Windows.Forms.RadioButton();
            this.panelStatus.SuspendLayout();
            this.groupFormats.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtYear
            // 
            this.txtYear.Location = new System.Drawing.Point(60, 11);
            this.txtYear.Name = "txtYear";
            this.txtYear.Size = new System.Drawing.Size(248, 23);
            this.txtYear.TabIndex = 0;
            // 
            // lblYear
            // 
            this.lblYear.AutoSize = true;
            this.lblYear.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblYear.Location = new System.Drawing.Point(17, 14);
            this.lblYear.Name = "lblYear";
            this.lblYear.Size = new System.Drawing.Size(29, 15);
            this.lblYear.TabIndex = 1;
            this.lblYear.Text = "Jahr";
            // 
            // btnGenerate
            // 
            this.btnGenerate.Location = new System.Drawing.Point(233, 107);
            this.btnGenerate.Name = "btnGenerate";
            this.btnGenerate.Size = new System.Drawing.Size(75, 23);
            this.btnGenerate.TabIndex = 3;
            this.btnGenerate.Text = "Generate";
            this.btnGenerate.UseVisualStyleBackColor = true;
            this.btnGenerate.Click += new System.EventHandler(this.btnGenerate_Click);
            // 
            // progressGenerate
            // 
            this.progressGenerate.Location = new System.Drawing.Point(17, 107);
            this.progressGenerate.Name = "progressGenerate";
            this.progressGenerate.Size = new System.Drawing.Size(210, 23);
            this.progressGenerate.TabIndex = 4;
            // 
            // lblStatus
            // 
            this.lblStatus.AutoSize = true;
            this.lblStatus.Font = new System.Drawing.Font("Segoe UI Semibold", 9F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point);
            this.lblStatus.Location = new System.Drawing.Point(34, 4);
            this.lblStatus.Name = "lblStatus";
            this.lblStatus.Size = new System.Drawing.Size(27, 15);
            this.lblStatus.TabIndex = 5;
            this.lblStatus.Text = "Idle";
            // 
            // panelStatus
            // 
            this.panelStatus.BackColor = System.Drawing.Color.White;
            this.panelStatus.BorderStyle = System.Windows.Forms.BorderStyle.FixedSingle;
            this.panelStatus.Controls.Add(this.lblStatus);
            this.panelStatus.Location = new System.Drawing.Point(-18, 136);
            this.panelStatus.Name = "panelStatus";
            this.panelStatus.Size = new System.Drawing.Size(361, 31);
            this.panelStatus.TabIndex = 6;
            // 
            // radioSinglePage
            // 
            this.radioSinglePage.AutoSize = true;
            this.radioSinglePage.Location = new System.Drawing.Point(43, 26);
            this.radioSinglePage.Name = "radioSinglePage";
            this.radioSinglePage.Size = new System.Drawing.Size(86, 19);
            this.radioSinglePage.TabIndex = 7;
            this.radioSinglePage.TabStop = true;
            this.radioSinglePage.Text = "Single Page";
            this.radioSinglePage.UseVisualStyleBackColor = true;
            // 
            // groupFormats
            // 
            this.groupFormats.Controls.Add(this.radioDoubleSided);
            this.groupFormats.Controls.Add(this.radioSinglePage);
            this.groupFormats.Location = new System.Drawing.Point(17, 40);
            this.groupFormats.Name = "groupFormats";
            this.groupFormats.Size = new System.Drawing.Size(291, 61);
            this.groupFormats.TabIndex = 8;
            this.groupFormats.TabStop = false;
            this.groupFormats.Text = "Format";
            // 
            // radioDoubleSided
            // 
            this.radioDoubleSided.AutoSize = true;
            this.radioDoubleSided.Location = new System.Drawing.Point(153, 26);
            this.radioDoubleSided.Name = "radioDoubleSided";
            this.radioDoubleSided.Size = new System.Drawing.Size(95, 19);
            this.radioDoubleSided.TabIndex = 8;
            this.radioDoubleSided.TabStop = true;
            this.radioDoubleSided.Text = "Double Sided";
            this.radioDoubleSided.UseVisualStyleBackColor = true;
            // 
            // frmCalendarTool
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(324, 161);
            this.Controls.Add(this.groupFormats);
            this.Controls.Add(this.panelStatus);
            this.Controls.Add(this.progressGenerate);
            this.Controls.Add(this.btnGenerate);
            this.Controls.Add(this.lblYear);
            this.Controls.Add(this.txtYear);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "frmCalendarTool";
            this.Text = "Calendar To PDF";
            this.panelStatus.ResumeLayout(false);
            this.panelStatus.PerformLayout();
            this.groupFormats.ResumeLayout(false);
            this.groupFormats.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private TextBox txtYear;
        private Label lblYear;
        private Button btnGenerate;
        private ProgressBar progressGenerate;
        private Label lblStatus;
        private Panel panelStatus;
        private RadioButton radioSinglePage;
        private GroupBox groupFormats;
        private RadioButton radioDoubleSided;
    }
}