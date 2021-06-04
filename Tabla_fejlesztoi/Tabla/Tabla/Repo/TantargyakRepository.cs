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
        List<Tantargyak> tantargyakList;       
        
        public int getTantargyakID(string subjectName)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int id = -1;
            try
            {
                connect.Open();
                string query = getSubjectID(subjectName);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["tantargyID"]);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }            
            return id;
        }

        public int getTanitjaID(int teacherID)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int tanitjaID = -1;
            try
            {
                connect.Open();
                string query = "SELECT tanitja.ID as tanitjaID FROM tanitja WHERE TanarID = '" + teacherID + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    tanitjaID = Convert.ToInt32(reader["tanitjaID"]);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }
            return tanitjaID;
        }

        public string getSubjectNameForTeacherUpdate(string teacherName)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            string subjectName = "";
            int teacherID = getTeacherID(teacherName);
            try
            {
                connect.Open();
                string query = "SELECT tantargyak.Nev as tantargyNev FROM tantargyak LEFT JOIN tanitja ON tanitja.TantargyID = tantargyak.ID WHERE tanitja.TanarID = '"+teacherID+"'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subjectName = reader["tantargyNev"].ToString();
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return subjectName;
        }

        public void fillSubjectBox(ComboBox subjectBox, int teacherID)
        {
            try
            {
                MySqlConnection connect = new MySqlConnection(getSqlConnection());
                connect.Open();
                string query = "SELECT tantargyak.Nev as tantargyNev FROM tantargyak LEFT JOIN tanitja ON tanitja.TantargyID = tantargyak.ID WHERE tanitja.TanarID = '" + teacherID + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    subjectBox.Items.Add(reader["tantargyNev"].ToString());
                }
                connect.Close();
                       
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
    }
}
