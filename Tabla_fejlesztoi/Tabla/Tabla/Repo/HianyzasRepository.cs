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
        public void uploadAbsence(DateTimePicker dateTime, ComboBox studentName)
        {            
            int studentID = getDiakID(studentName.Text);
            int teacherID = getLoginedTeacherID();
            try
            {
                MySqlConnection connect = new MySqlConnection(getSqlConnection());
                connect.Open();
                string query = "INSERT INTO `hianyzasok` (`ID`, `Datum`, `TanarID`, `DiakID`) VALUES (NULL, '"+ dateTime.Value.ToString("yyyy-MM-dd") + "', '"+teacherID+"', '"+studentID+"') ";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Sikeresen rögzítette a mulasztást!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Hiba a rögzítés közben!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
