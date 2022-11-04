
namespace WinFormsServer.Views
{
    partial class FormStreet
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
            this.btnSaveStreet = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtNameStreet = new System.Windows.Forms.TextBox();
            this.lstStreets = new System.Windows.Forms.ListBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.txtCurrentIndex = new System.Windows.Forms.TextBox();
            this.SuspendLayout();
            // 
            // btnSaveStreet
            // 
            this.btnSaveStreet.Location = new System.Drawing.Point(29, 214);
            this.btnSaveStreet.Name = "btnSaveStreet";
            this.btnSaveStreet.Size = new System.Drawing.Size(135, 23);
            this.btnSaveStreet.TabIndex = 0;
            this.btnSaveStreet.Text = "Сохранить улицу";
            this.btnSaveStreet.UseVisualStyleBackColor = true;
            this.btnSaveStreet.Click += new System.EventHandler(this.btnSaveStreet_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 66);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(98, 15);
            this.label1.TabIndex = 1;
            this.label1.Text = "Название улицы";
            // 
            // txtNameStreet
            // 
            this.txtNameStreet.Location = new System.Drawing.Point(29, 98);
            this.txtNameStreet.Name = "txtNameStreet";
            this.txtNameStreet.Size = new System.Drawing.Size(135, 23);
            this.txtNameStreet.TabIndex = 2;
            // 
            // lstStreets
            // 
            this.lstStreets.FormattingEnabled = true;
            this.lstStreets.ItemHeight = 15;
            this.lstStreets.Location = new System.Drawing.Point(260, 98);
            this.lstStreets.Name = "lstStreets";
            this.lstStreets.Size = new System.Drawing.Size(120, 139);
            this.lstStreets.TabIndex = 3;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(260, 66);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(78, 15);
            this.label2.TabIndex = 4;
            this.label2.Text = "Список улиц";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(29, 13);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(97, 15);
            this.label3.TabIndex = 5;
            this.label3.Text = "Текущий индекс";
            // 
            // txtCurrentIndex
            // 
            this.txtCurrentIndex.Enabled = false;
            this.txtCurrentIndex.Location = new System.Drawing.Point(29, 31);
            this.txtCurrentIndex.Name = "txtCurrentIndex";
            this.txtCurrentIndex.Size = new System.Drawing.Size(100, 23);
            this.txtCurrentIndex.TabIndex = 6;
            // 
            // FormStreet
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.txtCurrentIndex);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.lstStreets);
            this.Controls.Add(this.txtNameStreet);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.btnSaveStreet);
            this.Name = "FormStreet";
            this.Text = "FormStreet";
            this.Load += new System.EventHandler(this.FormStreet_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveStreet;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtNameStreet;
        private System.Windows.Forms.ListBox lstStreets;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.TextBox txtCurrentIndex;
    }
}