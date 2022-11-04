
namespace WinFormsServer
{
    partial class FormServer
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
            this.numPort = new System.Windows.Forms.TextBox();
            this.Start = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // numPort
            // 
            this.numPort.Location = new System.Drawing.Point(24, 29);
            this.numPort.Name = "numPort";
            this.numPort.Size = new System.Drawing.Size(100, 23);
            this.numPort.TabIndex = 0;
            this.numPort.Text = "4000";
            // 
            // Start
            // 
            this.Start.Location = new System.Drawing.Point(24, 139);
            this.Start.Name = "Start";
            this.Start.Size = new System.Drawing.Size(75, 23);
            this.Start.TabIndex = 1;
            this.Start.Text = "Добавить данные";
            this.Start.UseVisualStyleBackColor = true;
            this.Start.Click += new System.EventHandler(this.Start_Click);
            // 
            // FormServer
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.Start);
            this.Controls.Add(this.numPort);
            this.Name = "FormServer";
            this.Text = "FormServer";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox numPort;
        private System.Windows.Forms.Button Start;
    }
}

