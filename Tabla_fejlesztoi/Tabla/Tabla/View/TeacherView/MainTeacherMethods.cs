using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabla
{
    public partial class MainTeacher : Form
    {
        public Form formRefToLogin { get; set; }
        public void setStudentNameSelectedChanged(ComboBox classNameBox, ComboBox studentNameBox)
        {
            MySqlConnection connect = new MySqlConnection(repo.getSqlConnection());
            try
            {
                connect.Open();
                string className = classNameBox.Text;
                int classID = repo.getClassID(className);
                string query = repo.getDiakForTeacherForm(classID);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    studentNameBox.Items.Add(reader["diakNev"].ToString());
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        private void classComboBoxGrade_SelectedIndexChanged(object sender, EventArgs e)
        {
            studentNameBox.Items.Clear();
            setStudentNameSelectedChanged(classComboBoxGrade, studentNameBox);
        }

        private void absenceComboBox_SelectedIndexChanged(object sender, EventArgs e)
        {
            absenceStudentNameBox.Items.Clear();
            setStudentNameSelectedChanged(absenceComboBox, absenceStudentNameBox);
        }

        private void insertBtn_Click(object sender, EventArgs e)
        {
            repo.insertGrades(studentNameBox, subjectsBox, gradesComboBox);
        }

        private void MainTeacher_FormClosing(object sender, FormClosingEventArgs e)
        {

            if (e.CloseReason == CloseReason.UserClosing)
            {
                int loginedTeacherID = repo.getLoginedTeacherID();
                repo.setLogined(loginedTeacherID, false);
                this.formRefToLogin.Show();
                e.Cancel = true;
                this.Hide();
            }

        }

        private void insertAbsenceBtn_Click(object sender, EventArgs e)
        {
            repo.uploadAbsence(datePicker, absenceStudentNameBox);
        }
    }
}
