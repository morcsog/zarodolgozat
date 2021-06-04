
namespace Tabla
{
    partial class UpdateStudentForm
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
            this.cancelBtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.classComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.updateBtn = new System.Windows.Forms.Button();
            this.nameBox = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectedComboBox = new System.Windows.Forms.ComboBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(232, 220);
            this.cancelBtn.Name = "cancelBtn";
            this.cancelBtn.Size = new System.Drawing.Size(75, 23);
            this.cancelBtn.TabIndex = 11;
            this.cancelBtn.Text = "Mégsem";
            this.cancelBtn.UseVisualStyleBackColor = true;
            this.cancelBtn.Click += new System.EventHandler(this.cancelBtn_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(93, 147);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Osztály:";
            // 
            // classComboBox
            // 
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(96, 163);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(211, 21);
            this.classComboBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(93, 105);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Teljes név:";
            // 
            // updateBtn
            // 
            this.updateBtn.Location = new System.Drawing.Point(96, 220);
            this.updateBtn.Name = "updateBtn";
            this.updateBtn.Size = new System.Drawing.Size(75, 23);
            this.updateBtn.TabIndex = 7;
            this.updateBtn.Text = "Módosít";
            this.updateBtn.UseVisualStyleBackColor = true;
            this.updateBtn.Click += new System.EventHandler(this.updateBtn_Click);
            // 
            // nameBox
            // 
            this.nameBox.Location = new System.Drawing.Point(96, 121);
            this.nameBox.Name = "nameBox";
            this.nameBox.Size = new System.Drawing.Size(211, 20);
            this.nameBox.TabIndex = 6;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(93, 49);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(96, 13);
            this.label3.TabIndex = 13;
            this.label3.Text = "Kiválasztott tanuló:";
            // 
            // selectedComboBox
            // 
            this.selectedComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectedComboBox.FormattingEnabled = true;
            this.selectedComboBox.Location = new System.Drawing.Point(96, 72);
            this.selectedComboBox.Name = "selectedComboBox";
            this.selectedComboBox.Size = new System.Drawing.Size(211, 21);
            this.selectedComboBox.TabIndex = 14;
            // 
            // UpdateStudentForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 303);
            this.Controls.Add(this.selectedComboBox);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.updateBtn);
            this.Controls.Add(this.nameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.Name = "UpdateStudentForm";
            this.Text = "Tanuló módosítása";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button updateBtn;
        private System.Windows.Forms.TextBox nameBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectedComboBox;
    }
}