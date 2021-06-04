using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabla.Model;

namespace Tabla.Repo
{
    partial class Repository
    {
        public void insertGrades(ComboBox studentNameBox, ComboBox subjectBox, ComboBox gradeBox)
        {
            
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                DateTime dateTime = DateTime.Now;
                string date = dateTime.ToString("yyyy-mm-dd");
                int teacherID = getLoginedTeacherID();
                int studentID = getDiakID(studentNameBox.Text);
                int subjectID = getTantargyakID(subjectBox.Text);                
                string grade = gradeBox.Text;
                string query = "INSERT INTO `jegyek` (`ID`, `Datum`, `TantargyID`, `TanarID`, `DiakID`, `Jegy`) VALUES (NULL, '"+ DateTime.Now.ToString("yyyy-MM-dd")+ "', '"+subjectID+"', '"+teacherID+"', '"+studentID+"', '"+grade+"');";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Sikeresen rögzítette a jegyet!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Sikertelenül rögzítette a jegyet!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
