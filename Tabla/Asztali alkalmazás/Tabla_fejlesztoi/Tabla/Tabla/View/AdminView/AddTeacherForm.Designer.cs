
namespace Tabla
{
    partial class AddTeacherForm
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
            this.addBtn = new System.Windows.Forms.Button();
            this.teacherNameBox = new System.Windows.Forms.TextBox();
            this.osztalyfonokEBox = new System.Windows.Forms.CheckBox();
            this.label3 = new System.Windows.Forms.Label();
            this.subjectsBox = new System.Windows.Forms.ComboBox();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.rendszergazdaEBox = new System.Windows.Forms.CheckBox();
            this.SuspendLayout();
            // 
            // cancelBtn
            // 
            this.cancelBtn.Location = new System.Drawing.Point(228, 223);
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
            this.label2.Location = new System.Drawing.Point(89, 135);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(44, 13);
            this.label2.TabIndex = 10;
            this.label2.Text = "Osztály:";
            // 
            // classComboBox
            // 
            this.classComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBox.FormattingEnabled = true;
            this.classComboBox.Location = new System.Drawing.Point(92, 151);
            this.classComboBox.Name = "classComboBox";
            this.classComboBox.Size = new System.Drawing.Size(211, 21);
            this.classComboBox.TabIndex = 9;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(89, 29);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(59, 13);
            this.label1.TabIndex = 8;
            this.label1.Text = "Teljes név:";
            // 
            // addBtn
            // 
            this.addBtn.Location = new System.Drawing.Point(92, 223);
            this.addBtn.Name = "addBtn";
            this.addBtn.Size = new System.Drawing.Size(75, 23);
            this.addBtn.TabIndex = 7;
            this.addBtn.Text = "Hozzáad";
            this.addBtn.UseVisualStyleBackColor = true;
            this.addBtn.Click += new System.EventHandler(this.addBtn_Click);
            // 
            // teacherNameBox
            // 
            this.teacherNameBox.Location = new System.Drawing.Point(92, 45);
            this.teacherNameBox.Name = "teacherNameBox";
            this.teacherNameBox.Size = new System.Drawing.Size(211, 20);
            this.teacherNameBox.TabIndex = 6;
            // 
            // osztalyfonokEBox
            // 
            this.osztalyfonokEBox.AutoSize = true;
            this.osztalyfonokEBox.Location = new System.Drawing.Point(166, 188);
            this.osztalyfonokEBox.Name = "osztalyfonokEBox";
            this.osztalyfonokEBox.Size = new System.Drawing.Size(15, 14);
            this.osztalyfonokEBox.TabIndex = 12;
            this.osztalyfonokEBox.UseVisualStyleBackColor = true;
            this.osztalyfonokEBox.CheckedChanged += new System.EventHandler(this.osztalyfonokEBox_CheckedChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(89, 82);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(52, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Tantárgy:";
            // 
            // subjectsBox
            // 
            this.subjectsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectsBox.FormattingEnabled = true;
            this.subjectsBox.Location = new System.Drawing.Point(92, 98);
            this.subjectsBox.Name = "subjectsBox";
            this.subjectsBox.Size = new System.Drawing.Size(211, 21);
            this.subjectsBox.TabIndex = 13;
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(89, 188);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(71, 13);
            this.label4.TabIndex = 15;
            this.label4.Text = "Osztályfőnök:";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(201, 189);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(81, 13);
            this.label5.TabIndex = 17;
            this.label5.Text = "Rendszergazda";
            // 
            // rendszergazdaEBox
            // 
            this.rendszergazdaEBox.AutoSize = true;
            this.rendszergazdaEBox.Location = new System.Drawing.Point(288, 188);
            this.rendszergazdaEBox.Name = "rendszergazdaEBox";
            this.rendszergazdaEBox.Size = new System.Drawing.Size(15, 14);
            this.rendszergazdaEBox.TabIndex = 16;
            this.rendszergazdaEBox.UseVisualStyleBackColor = true;
            // 
            // AddTeacherForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(393, 303);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.rendszergazdaEBox);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.subjectsBox);
            this.Controls.Add(this.osztalyfonokEBox);
            this.Controls.Add(this.cancelBtn);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.classComboBox);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.addBtn);
            this.Controls.Add(this.teacherNameBox);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(409, 342);
            this.MinimumSize = new System.Drawing.Size(409, 342);
            this.Name = "AddTeacherForm";
            this.Text = "Tanár feltöltése";
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button cancelBtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox classComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button addBtn;
        private System.Windows.Forms.TextBox teacherNameBox;
        private System.Windows.Forms.CheckBox osztalyfonokEBox;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox subjectsBox;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.CheckBox rendszergazdaEBox;
    }
}