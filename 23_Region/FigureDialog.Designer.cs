﻿namespace _23_Region
{
    partial class FigureDialog
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
            this.cancelButton = new System.Windows.Forms.Button();
            this.okButton = new System.Windows.Forms.Button();
            this.textY2 = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.textX2 = new System.Windows.Forms.TextBox();
            this.label4 = new System.Windows.Forms.Label();
            this.textY1 = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.textX1 = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.SuspendLayout();
            // 
            // cancelButton
            // 
            this.cancelButton.Location = new System.Drawing.Point(165, 154);
            this.cancelButton.Name = "cancelButton";
            this.cancelButton.Size = new System.Drawing.Size(75, 23);
            this.cancelButton.TabIndex = 39;
            this.cancelButton.Text = "Cancle";
            this.cancelButton.UseVisualStyleBackColor = true;
            this.cancelButton.Click += new System.EventHandler(this.CancelButton_Click);
            // 
            // okButton
            // 
            this.okButton.Location = new System.Drawing.Point(75, 154);
            this.okButton.Name = "okButton";
            this.okButton.Size = new System.Drawing.Size(75, 23);
            this.okButton.TabIndex = 38;
            this.okButton.Text = "OK";
            this.okButton.UseVisualStyleBackColor = true;
            this.okButton.Click += new System.EventHandler(this.OkButton_Click);
            // 
            // textY2
            // 
            this.textY2.Location = new System.Drawing.Point(195, 95);
            this.textY2.Name = "textY2";
            this.textY2.Size = new System.Drawing.Size(46, 21);
            this.textY2.TabIndex = 37;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(163, 98);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(26, 12);
            this.label3.TabIndex = 36;
            this.label3.Text = "y2 :";
            // 
            // textX2
            // 
            this.textX2.Location = new System.Drawing.Point(92, 95);
            this.textX2.Name = "textX2";
            this.textX2.Size = new System.Drawing.Size(42, 21);
            this.textX2.TabIndex = 35;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(60, 98);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(26, 12);
            this.label4.TabIndex = 34;
            this.label4.Text = "x2 :";
            // 
            // textY1
            // 
            this.textY1.Location = new System.Drawing.Point(195, 58);
            this.textY1.Name = "textY1";
            this.textY1.Size = new System.Drawing.Size(46, 21);
            this.textY1.TabIndex = 33;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(163, 61);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(26, 12);
            this.label2.TabIndex = 32;
            this.label2.Text = "y1 :";
            // 
            // textX1
            // 
            this.textX1.Location = new System.Drawing.Point(92, 58);
            this.textX1.Name = "textX1";
            this.textX1.Size = new System.Drawing.Size(42, 21);
            this.textX1.TabIndex = 31;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(60, 61);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(26, 12);
            this.label1.TabIndex = 30;
            this.label1.Text = "x1 :";
            // 
            // FigureDialog
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 12F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(310, 214);
            this.Controls.Add(this.cancelButton);
            this.Controls.Add(this.okButton);
            this.Controls.Add(this.textY2);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.textX2);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.textY1);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.textX1);
            this.Controls.Add(this.label1);
            this.Name = "FigureDialog";
            this.Text = "FigureDialog";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelButton;
        private System.Windows.Forms.Button okButton;
        private System.Windows.Forms.TextBox textY2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox textX2;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.TextBox textY1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.TextBox textX1;
        private System.Windows.Forms.Label label1;
    }
}