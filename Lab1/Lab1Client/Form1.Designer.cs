namespace Lab1Client
{
    partial class Form1
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
            this.SendButton = new System.Windows.Forms.Button();
            this.XInput = new System.Windows.Forms.TextBox();
            this.YInput = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.ResultLabel = new System.Windows.Forms.Label();
            this.SuspendLayout();
            //
            // SendButton
            //
            this.SendButton.Location = new System.Drawing.Point(62, 224);
            this.SendButton.Name = "SendButton";
            this.SendButton.Size = new System.Drawing.Size(395, 96);
            this.SendButton.TabIndex = 0;
            this.SendButton.Text = "Send";
            this.SendButton.UseVisualStyleBackColor = true;
            this.SendButton.Click += new System.EventHandler(this.SendButton_Click);
            //
            // XInput
            //
            this.XInput.Location = new System.Drawing.Point(91, 142);
            this.XInput.Name = "XInput";
            this.XInput.Size = new System.Drawing.Size(129, 22);
            this.XInput.TabIndex = 1;
            //
            // YInput
            //
            this.YInput.Location = new System.Drawing.Point(313, 142);
            this.YInput.Name = "YInput";
            this.YInput.Size = new System.Drawing.Size(131, 22);
            this.YInput.TabIndex = 2;
            //
            // label1
            //
            this.label1.Location = new System.Drawing.Point(49, 143);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(36, 21);
            this.label1.TabIndex = 3;
            this.label1.Text = "X: ";
            //
            // label2
            //
            this.label2.Location = new System.Drawing.Point(271, 142);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(36, 21);
            this.label2.TabIndex = 4;
            this.label2.Text = "Y: ";
            //
            // label3
            //
            this.label3.Location = new System.Drawing.Point(518, 142);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(56, 20);
            this.label3.TabIndex = 5;
            this.label3.Text = "Result: ";
            //
            // ResultLabel
            //
            this.ResultLabel.Location = new System.Drawing.Point(595, 142);
            this.ResultLabel.Name = "ResultLabel";
            this.ResultLabel.Size = new System.Drawing.Size(63, 20);
            this.ResultLabel.TabIndex = 6;
            this.ResultLabel.Text = "0";
            //
            // Form1
            //
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ResultLabel);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.YInput);
            this.Controls.Add(this.XInput);
            this.Controls.Add(this.SendButton);
            this.Name = "Form1";
            this.Text = "Form1";
            this.ResumeLayout(false);
            this.PerformLayout();
        }

        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label ResultLabel;

        private System.Windows.Forms.TextBox XInput;
        private System.Windows.Forms.TextBox YInput;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;

        private System.Windows.Forms.Button SendButton;

        #endregion
    }
}