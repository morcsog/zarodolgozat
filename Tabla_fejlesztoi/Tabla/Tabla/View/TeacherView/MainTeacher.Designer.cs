
namespace Tabla
{
    partial class MainTeacher
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
            this.tabControl1 = new System.Windows.Forms.TabControl();
            this.tabPage1 = new System.Windows.Forms.TabPage();
            this.label5 = new System.Windows.Forms.Label();
            this.subjectsBox = new System.Windows.Forms.ComboBox();
            this.insertBtn = new System.Windows.Forms.Button();
            this.label3 = new System.Windows.Forms.Label();
            this.studentNameBox = new System.Windows.Forms.ComboBox();
            this.label2 = new System.Windows.Forms.Label();
            this.gradesComboBox = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.classComboBoxGrade = new System.Windows.Forms.ComboBox();
            this.tabPage2 = new System.Windows.Forms.TabPage();
            this.datePicker = new System.Windows.Forms.DateTimePicker();
            this.insertAbsenceBtn = new System.Windows.Forms.Button();
            this.label4 = new System.Windows.Forms.Label();
            this.absenceStudentNameBox = new System.Windows.Forms.ComboBox();
            this.label6 = new System.Windows.Forms.Label();
            this.absenceComboBox = new System.Windows.Forms.ComboBox();
            this.tabControl1.SuspendLayout();
            this.tabPage1.SuspendLayout();
            this.tabPage2.SuspendLayout();
            this.SuspendLayout();
            // 
            // tabControl1
            // 
            this.tabControl1.Controls.Add(this.tabPage1);
            this.tabControl1.Controls.Add(this.tabPage2);
            this.tabControl1.Location = new System.Drawing.Point(12, 12);
            this.tabControl1.Name = "tabControl1";
            this.tabControl1.SelectedIndex = 0;
            this.tabControl1.Size = new System.Drawing.Size(227, 414);
            this.tabControl1.TabIndex = 0;
            // 
            // tabPage1
            // 
            this.tabPage1.Controls.Add(this.label5);
            this.tabPage1.Controls.Add(this.subjectsBox);
            this.tabPage1.Controls.Add(this.insertBtn);
            this.tabPage1.Controls.Add(this.label3);
            this.tabPage1.Controls.Add(this.studentNameBox);
            this.tabPage1.Controls.Add(this.label2);
            this.tabPage1.Controls.Add(this.gradesComboBox);
            this.tabPage1.Controls.Add(this.label1);
            this.tabPage1.Controls.Add(this.classComboBoxGrade);
            this.tabPage1.Location = new System.Drawing.Point(4, 22);
            this.tabPage1.Name = "tabPage1";
            this.tabPage1.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage1.Size = new System.Drawing.Size(219, 388);
            this.tabPage1.TabIndex = 0;
            this.tabPage1.Text = "Osztályzatok";
            this.tabPage1.UseVisualStyleBackColor = true;
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(48, 131);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(52, 13);
            this.label5.TabIndex = 8;
            this.label5.Text = "Tantárgy:";
            // 
            // subjectsBox
            // 
            this.subjectsBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.subjectsBox.FormattingEnabled = true;
            this.subjectsBox.Location = new System.Drawing.Point(48, 150);
            this.subjectsBox.Name = "subjectsBox";
            this.subjectsBox.Size = new System.Drawing.Size(121, 21);
            this.subjectsBox.TabIndex = 7;
            // 
            // insertBtn
            // 
            this.insertBtn.Location = new System.Drawing.Point(48, 240);
            this.insertBtn.Name = "insertBtn";
            this.insertBtn.Size = new System.Drawing.Size(121, 23);
            this.insertBtn.TabIndex = 6;
            this.insertBtn.Text = "Rögzít";
            this.insertBtn.UseVisualStyleBackColor = true;
            this.insertBtn.Click += new System.EventHandler(this.insertBtn_Click);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(48, 75);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(43, 13);
            this.label3.TabIndex = 5;
            this.label3.Text = "Tanuló:";
            // 
            // studentNameBox
            // 
            this.studentNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.studentNameBox.FormattingEnabled = true;
            this.studentNameBox.Location = new System.Drawing.Point(48, 94);
            this.studentNameBox.Name = "studentNameBox";
            this.studentNameBox.Size = new System.Drawing.Size(121, 21);
            this.studentNameBox.TabIndex = 4;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(48, 174);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(58, 13);
            this.label2.TabIndex = 3;
            this.label2.Text = "Osztályzat:";
            // 
            // gradesComboBox
            // 
            this.gradesComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.gradesComboBox.FormattingEnabled = true;
            this.gradesComboBox.Items.AddRange(new object[] {
            "1",
            "2",
            "3",
            "4",
            "5"});
            this.gradesComboBox.Location = new System.Drawing.Point(48, 193);
            this.gradesComboBox.Name = "gradesComboBox";
            this.gradesComboBox.Size = new System.Drawing.Size(121, 21);
            this.gradesComboBox.TabIndex = 2;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(48, 21);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(44, 13);
            this.label1.TabIndex = 1;
            this.label1.Text = "Osztály:";
            // 
            // classComboBoxGrade
            // 
            this.classComboBoxGrade.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.classComboBoxGrade.FormattingEnabled = true;
            this.classComboBoxGrade.Location = new System.Drawing.Point(48, 40);
            this.classComboBoxGrade.Name = "classComboBoxGrade";
            this.classComboBoxGrade.Size = new System.Drawing.Size(121, 21);
            this.classComboBoxGrade.TabIndex = 0;
            this.classComboBoxGrade.SelectedIndexChanged += new System.EventHandler(this.classComboBoxGrade_SelectedIndexChanged);
            // 
            // tabPage2
            // 
            this.tabPage2.Controls.Add(this.datePicker);
            this.tabPage2.Controls.Add(this.insertAbsenceBtn);
            this.tabPage2.Controls.Add(this.label4);
            this.tabPage2.Controls.Add(this.absenceStudentNameBox);
            this.tabPage2.Controls.Add(this.label6);
            this.tabPage2.Controls.Add(this.absenceComboBox);
            this.tabPage2.Location = new System.Drawing.Point(4, 22);
            this.tabPage2.Name = "tabPage2";
            this.tabPage2.Padding = new System.Windows.Forms.Padding(3);
            this.tabPage2.Size = new System.Drawing.Size(219, 388);
            this.tabPage2.TabIndex = 1;
            this.tabPage2.Text = "Hiányzások";
            this.tabPage2.UseVisualStyleBackColor = true;
            // 
            // datePicker
            // 
            this.datePicker.Location = new System.Drawing.Point(21, 142);
            this.datePicker.Name = "datePicker";
            this.datePicker.Size = new System.Drawing.Size(170, 20);
            this.datePicker.TabIndex = 14;
            // 
            // insertAbsenceBtn
            // 
            this.insertAbsenceBtn.Location = new System.Drawing.Point(45, 219);
            this.insertAbsenceBtn.Name = "insertAbsenceBtn";
            this.insertAbsenceBtn.Size = new System.Drawing.Size(121, 23);
            this.insertAbsenceBtn.TabIndex = 13;
            this.insertAbsenceBtn.Text = "Rögzít";
            this.insertAbsenceBtn.UseVisualStyleBackColor = true;
            this.insertAbsenceBtn.Click += new System.EventHandler(this.insertAbsenceBtn_Click);
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(42, 77);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(43, 13);
            this.label4.TabIndex = 12;
            this.label4.Text = "Tanuló:";
            // 
            // absenceStudentNameBox
            // 
            this.absenceStudentNameBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.absenceStudentNameBox.FormattingEnabled = true;
            this.absenceStudentNameBox.Location = new System.Drawing.Point(42, 96);
            this.absenceStudentNameBox.Name = "absenceStudentNameBox";
            this.absenceStudentNameBox.Size = new System.Drawing.Size(121, 21);
            this.absenceStudentNameBox.TabIndex = 11;
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(42, 23);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(44, 13);
            this.label6.TabIndex = 8;
            this.label6.Text = "Osztály:";
            // 
            // absenceComboBox
            // 
            this.absenceComboBox.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.absenceComboBox.FormattingEnabled = true;
            this.absenceComboBox.Location = new System.Drawing.Point(42, 42);
            this.absenceComboBox.Name = "absenceComboBox";
            this.absenceComboBox.Size = new System.Drawing.Size(121, 21);
            this.absenceComboBox.TabIndex = 7;
            this.absenceComboBox.SelectedIndexChanged += new System.EventHandler(this.absenceComboBox_SelectedIndexChanged);
            // 
            // MainTeacher
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(251, 450);
            this.Controls.Add(this.tabControl1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.FixedSingle;
            this.MaximizeBox = false;
            this.Name = "MainTeacher";
            this.Text = "Tanári felület";
            this.FormClosing += new System.Windows.Forms.FormClosingEventHandler(this.MainTeacher_FormClosing);
            this.tabControl1.ResumeLayout(false);
            this.tabPage1.ResumeLayout(false);
            this.tabPage1.PerformLayout();
            this.tabPage2.ResumeLayout(false);
            this.tabPage2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.TabControl tabControl1;
        private System.Windows.Forms.TabPage tabPage1;
        private System.Windows.Forms.TabPage tabPage2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox studentNameBox;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.ComboBox gradesComboBox;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.ComboBox classComboBoxGrade;
        private System.Windows.Forms.Button insertBtn;
        private System.Windows.Forms.Button insertAbsenceBtn;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.ComboBox absenceStudentNameBox;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.ComboBox absenceComboBox;
        private System.Windows.Forms.DateTimePicker datePicker;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.ComboBox subjectsBox;
    }
}