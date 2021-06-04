using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabla.Model;
using Tabla.Repo;

namespace Tabla.Repo
{
    public partial class Repository
    {             
        List<Diak> diakList;
        public List<Diak> getDiakList()
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = getDiakForDT();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    string className = getClassName(classID);
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //Csak tanuló név alapján adja vissza.
        public List<Diak> getDiakList(string nev)
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQuery(nev);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //Csak tanuló ID alapján ad vissza.
        public List<Diak> getDiakList(int studentID)
        {            
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {               
                connect.Open();
                string query = searchQuery(studentID);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }                
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //Csak osztály név alapján ad vissza
        public List<Diak> getDiakList(string srcClassName, bool kell)
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQuery(srcClassName, kell);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //ID és név alapján ad vissza
        public List<Diak> getDiakList(int studentID, string studentName)
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQuery(studentID, studentName);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //ID, név és osztály név alapján ad vissza
        public List<Diak> getDiakList(int studentID, string studentName, string className)
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQuery(studentID, studentName, className);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //ID és osztály név alapján ad vissza
        public List<Diak> getDiakList(int studentID, string srcClassName, bool kell)
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQuery(studentID, srcClassName, kell);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }
        //Név és osztály név alapján ad vissza
        public List<Diak> getDiakList(string studentName, string className)
        {
            List<Diak> diakList = new List<Diak>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQuery(className, studentName);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    int id = Convert.ToInt32(reader["ID"]);
                    string name = reader["Nev"].ToString();
                    string classID = reader["OsztalyID"].ToString();
                    Diak diak = new Diak(id, name, classID);
                    diakList.Add(diak);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            connect.Close();
            return diakList;
        }

        /// <summary>
        /// Megadja a tanulók nevét egy listában.
        /// </summary>
        /// <returns>String listával tér vissza az összes tanuló nevével.</returns>
        public List<string> getAllStudentName()
        {            
            List<string> nameList = new List<string>();
            try
            {
                MySqlConnection connect = new MySqlConnection(getSqlConnection());
                connect.Open();
                string query = "SELECT diakok.ID, diakok.Nev, diakok.OsztalyID FROM diakok";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    string classID = Convert.ToString(reader["OsztalyID"]);
                    nameList.Add(Convert.ToString(reader["ID"]) + " - " + Convert.ToString(reader["Nev"]) + " - " + getClassName(classID));
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }
            return nameList;
        }

        public void setDiaklist(List<Diak> diakList)
        {
            this.diakList = diakList;
        }
                

        public DataTable createDataTable(List<Diak> diakList)
        {
            DataTable diakDt = new DataTable();            
            diakDt.Columns.Add("azon", typeof(int));
            diakDt.Columns.Add("name", typeof(string));
            diakDt.Columns.Add("className", typeof(string));
            foreach (Diak item in diakList)
            {                
                diakDt.Rows.Add(item.id, item.nev, getClassName(item.osztalyId));
            }
            return diakDt;
        }

        public void searchResult(DataTable diakDT, DataGridView dataGridView1, TextBox idBox, TextBox nameBox, TextBox classBox)
        {
            //Csak ID alapján keresés
            if(idBox.Text.Length > 0 && nameBox.Text.Length == 0 && classBox.Text.Length == 0)
            {
                int id = Convert.ToInt32(idBox.Text);
                diakList = getDiakList(id);
            }
            //Csak név alapján keresés
            else if (nameBox.Text.Length > 0 && idBox.Text.Length == 0 && classBox.Text.Length == 0)
            {
                string name = nameBox.Text;
                diakList = getDiakList(name);
            }
            //Csak osztály név alapján keresés
            else if (classBox.Text.Length > 0 && idBox.Text.Length == 0 && nameBox.Text.Length == 0)
            {
                string className = classBox.Text;
                diakList = getDiakList(className, true);                
            }
            //ID és név alapján keresés
            else if(idBox.Text.Length > 0 && nameBox.Text.Length > 0 && classBox.Text.Length == 0)
            {
                int id = Convert.ToInt32(idBox.Text);
                string name = nameBox.Text;
                diakList = getDiakList(id, name);
            }
            //ID, név és osztály név alapján keresés
            else if (idBox.Text.Length > 0 && nameBox.Text.Length > 0 && classBox.Text.Length > 0)
            {
                int id = Convert.ToInt32(idBox.Text);
                string name = nameBox.Text;
                string className = classBox.Text;
                diakList = getDiakList(id, name, className);
            }
            //ID és osztály név alapján keresés
            else if (idBox.Text.Length > 0 && classBox.Text.Length > 0 && nameBox.Text.Length == 0)
            {
                int id = Convert.ToInt32(idBox.Text);
                string className = classBox.Text;
                diakList = getDiakList(id, className);

            }
            //Név és osztály név alapján keresés
            else if (idBox.Text.Length == 0 && classBox.Text.Length > 0 && nameBox.Text.Length > 0)
            {
                string name = nameBox.Text;
                string className = classBox.Text;
                diakList = getDiakList(name, className);
            }
            //Ha valamit elront a felhasználó, nekem nem sikerült semmit.
            else
            {                
                diakList = getDiakList();
            }
            setDiaklist(diakList);
            diakDT = createDataTable(diakList);
            dataGridView1.DataSource = diakDT;            
            
        }

        public void addStudentToList(Diak student)
        {
            Repository repos = new Repository();
            diakList = new List<Diak>();
            try
            {
                diakList.Add(student);
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }
        /// <summary>
        /// Meghívja a tanuló feltöltése formot.
        /// </summary>
        public void uploadStudentForm()
        {
            try
            {
                AddStudentForm asf = new AddStudentForm();
                asf.Show();                  



            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }
        /// <summary>
        /// Meghívja a tanuló módosítása formot.
        /// </summary>
        public void updateStudentForm()
        {
            try
            {
                UpdateStudentForm usf = new UpdateStudentForm();                
                usf.Show();                                                 
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }

        public void listaFeltoltDiakOsztaly(ComboBox classComboBox)
        {
            
            List<string> studentName = getAllStudentName();

            foreach (var s in studentName)
            {
                classComboBox.Items.Add(s);
            }
        }

        public void updateStudent(ComboBox selectedComboBox, ComboBox classComboBox, TextBox nameBox)
        {
            List<string> segedList = getAllStudentName();
            int selectedIndex = selectedComboBox.SelectedIndex;
            string[] seged = segedList[selectedIndex].Split(' ');
            int id = Convert.ToInt32(seged[0]);
            int classID = getClassID(classComboBox.Text);
            string name = nameBox.Text;
            updateStudent(id, name, classID);
        }        

        public int getDiakID(string name)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int id = 0;
            try
            {
                connect.Open();
                string query = "SELECT diakok.ID as diakID FROM diakok WHERE diakok.Nev = '" + name + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["diakID"]);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return id;
        }
    }

      
}
