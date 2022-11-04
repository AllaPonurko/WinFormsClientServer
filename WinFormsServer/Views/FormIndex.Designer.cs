
namespace WinFormsServer
{
    partial class FormIndex
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
            this.btnSaveIndex = new System.Windows.Forms.Button();
            this.txtIndex = new System.Windows.Forms.TextBox();
            this.label1 = new System.Windows.Forms.Label();
            this.lstIndexs = new System.Windows.Forms.ListBox();
            this.label3 = new System.Windows.Forms.Label();
            this.btnAddStreet = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // btnSaveIndex
            // 
            this.btnSaveIndex.Location = new System.Drawing.Point(35, 116);
            this.btnSaveIndex.Name = "btnSaveIndex";
            this.btnSaveIndex.Size = new System.Drawing.Size(109, 23);
            this.btnSaveIndex.TabIndex = 0;
            this.btnSaveIndex.Text = "Добавить индекс";
            this.btnSaveIndex.UseVisualStyleBackColor = true;
            this.btnSaveIndex.Click += new System.EventHandler(this.btnSave_Click);
            // 
            // txtIndex
            // 
            this.txtIndex.Location = new System.Drawing.Point(35, 45);
            this.txtIndex.Name = "txtIndex";
            this.txtIndex.Size = new System.Drawing.Size(109, 23);
            this.txtIndex.TabIndex = 1;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(35, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(47, 15);
            this.label1.TabIndex = 3;
            this.label1.Text = "Индекс";
            // 
            // lstIndexs
            // 
            this.lstIndexs.FormattingEnabled = true;
            this.lstIndexs.ItemHeight = 15;
            this.lstIndexs.Location = new System.Drawing.Point(180, 45);
            this.lstIndexs.Name = "lstIndexs";
            this.lstIndexs.Size = new System.Drawing.Size(193, 94);
            this.lstIndexs.TabIndex = 5;
            this.lstIndexs.SelectedIndexChanged += new System.EventHandler(this.lstIndexs_SelectedIndexChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(180, 12);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(102, 15);
            this.label3.TabIndex = 6;
            this.label3.Text = "Список индексов";
            // 
            // btnAddStreet
            // 
            this.btnAddStreet.Location = new System.Drawing.Point(431, 115);
            this.btnAddStreet.Name = "btnAddStreet";
            this.btnAddStreet.Size = new System.Drawing.Size(107, 23);
            this.btnAddStreet.TabIndex = 7;
            this.btnAddStreet.Text = "Добавить улицу";
            this.btnAddStreet.UseVisualStyleBackColor = true;
            this.btnAddStreet.Click += new System.EventHandler(this.btnAddStreet_Click);
            // 
            // FormIndex
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.btnAddStreet);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.lstIndexs);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.txtIndex);
            this.Controls.Add(this.btnSaveIndex);
            this.Name = "FormIndex";
            this.Text = "FormIndex";
            this.Load += new System.EventHandler(this.FormIndex_Load);
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button btnSaveIndex;
        private System.Windows.Forms.TextBox txtIndex;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ListBox lstIndexs;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Button btnAddStreet;
    }
}