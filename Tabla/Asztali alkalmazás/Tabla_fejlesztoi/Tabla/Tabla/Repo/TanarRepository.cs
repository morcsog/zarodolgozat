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

namespace Tabla.Repo
{
    public partial class Repository
    {
        List<Tanar> tanarList;

        public void setTanarList(List<Tanar> tanarList)
        {
            this.tanarList = tanarList;
        }
        public List<Tanar> getTeacherList()
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());            
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(getTeacherForDT(), connect);                
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    string nev = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    int tanarID = Convert.ToInt32(reader["tanarID"]);                    
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    Tanar teacher = new Tanar(tanarID, nev, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);


                }                
                connect.Close();                
                
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            
            //tanarList.AddRange(ofNelkuliLista);
            return tanarList;
        }

        /// <summary>
        /// A tanár neve alapján visszaadja a tanár listát.
        /// </summary>
        /// <param name="nev">A tanár neve.</param>
        /// <returns></returns>
        public List<Tanar> getTeacherList(string nev)
        {            
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(nev);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();                
                while (reader.Read())
                {                    
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        //Csak tanár ID alapján ad vissza.
        public List<Tanar> getTeacherList(int teacherID)
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(teacherID);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        //Csak tantárgy alapján ad vissza
        public List<Tanar> getTeacherList(string subject, bool kell)
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(subject, true, true);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        //ID és név alapján ad vissza
        public List<Tanar> getTeacherList(int teacherID, string teacherName)
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(teacherID, teacherName);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        //ID, név és tantárgy alapján ad vissza
        public List<Tanar> getTeacherList(int teacherID, string teacherName, string subjectName)
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(subjectName, teacherID, teacherName);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        //ID és tantárgy alapján ad vissza
        public List<Tanar> getTeacherList(int teacherID, string subjectName, bool kell)
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(subjectName, teacherID);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        //Név és tantárgy alapján ad vissza
        public List<Tanar> getTeacherList(string teacherName, string subjectName)
        {
            List<Tanar> tanarList = new List<Tanar>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = searchQueryForTeacher(subjectName, teacherName, true);
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonokE = Convert.ToInt32(reader["osztalyfonokE"]);
                    int tanarID = Convert.ToInt32(reader["tanarID"]);
                    string osztalyNev = reader["OsztalyNev"].ToString();
                    List<string> tanitja = new List<string>();
                    tanitja.Add(reader["tantargyNev"].ToString());
                    Tanar teacher = new Tanar(tanarID, name, osztalyNev, tanitja, osztalyfonokE);
                    tanarList.Add(teacher);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return tanarList;
        }
        public int getNumberofSubejcts()
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            string query = "SELECT COUNT(tantargyak.Nev) as tantargyakSzama FROM tantargyak";
            int numberOfSubject = 0;
            try
            {                
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    numberOfSubject += Convert.ToInt32(reader["tantargyakSzama"]);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }
            return numberOfSubject;
        }

        public void fillSubjectComboBox(ComboBox subjectBox)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int numberOfSubjects = getNumberofSubejcts();
            try
            {                
                connect.Open();
                string query = "SELECT tantargyak.Nev as tantargyNev FROM tantargyak";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {   
                    if(subjectBox.Items.Count < numberOfSubjects)
                    {
                        subjectBox.Items.Add(reader["tantargyNev"]);
                    }
                    
                }

                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
        }

        public void searchResultTeacher(DataTable tanarDT, DataGridView dataGridView1, TextBox idBox, TextBox nameBox, ComboBox subjectNameBox)
        {
            try
            {
                //Csak ID alapján keresés
                if (idBox.Text.Length > 0 && nameBox.Text.Length == 0 && subjectNameBox.Text.Length == 0)
                {
                    int id = Convert.ToInt32(idBox.Text);
                    tanarList = getTeacherList(id);
                }
                //Csak név alapján keresés
                else if (nameBox.Text.Length > 0 && idBox.Text.Length == 0 && subjectNameBox.Text.Length == 0)
                {
                    string name = nameBox.Text;
                    tanarList = getTeacherList(name);
                }
                //Csak tantárgy alapján keres
                else if (subjectNameBox.Text.Length > 0 && idBox.Text.Length == 0 && nameBox.Text.Length == 0)
                {
                    string subjectName = subjectNameBox.Text;
                    tanarList = getTeacherList(subjectName, true);
                }
                //ID és név alapján keresés
                else if (idBox.Text.Length > 0 && nameBox.Text.Length > 0 && subjectNameBox.Text.Length == 0)
                {
                    int id = Convert.ToInt32(idBox.Text);
                    string name = nameBox.Text;
                    tanarList = getTeacherList(id, name);
                }
                //ID, név és tantárgy név alapján keresés
                else if (idBox.Text.Length > 0 && nameBox.Text.Length > 0 && subjectNameBox.Text.Length > 0)
                {
                    int id = Convert.ToInt32(idBox.Text);
                    string name = nameBox.Text;
                    string subjectName = subjectNameBox.Text;
                    tanarList = getTeacherList(id, name, subjectName);
                }
                //ID és tantárgy név alapján keresés
                else if (idBox.Text.Length > 0 && subjectNameBox.Text.Length > 0 && nameBox.Text.Length == 0)
                {
                    int id = Convert.ToInt32(idBox.Text);
                    string subjectName = subjectNameBox.Text;
                    tanarList = getTeacherList(id, subjectName, true);

                }
                //Név és tantárgy név alapján keresés
                else if (idBox.Text.Length == 0 && subjectNameBox.Text.Length > 0 && nameBox.Text.Length > 0)
                {
                    string name = nameBox.Text;
                    string subjectName = subjectNameBox.Text;
                    tanarList = getTeacherList(name, subjectName);
                }
                //Ha valamit elront a felhasználó - nekem nem sikerült semmit - vagy üres keresést indít.
                else
                {
                    tanarList = getTeacherList();
                }
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Hiba!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            setDiaklist(diakList);
            tanarDT = createDataTable(tanarList);
            dataGridView1.DataSource = tanarDT;

        }
        /// <summary>
        /// Egy stringet készít abból, hogy mit tanítanak a tanárok.
        /// </summary>
        /// <param name="tanitjaLista">Egy list ami tárolja, hogy egy adott tanár mely tantárgyakat tanítja.</param>
        /// <returns></returns>
        public string getSubjectsString(List<string> tanitjaLista)
        {
            string subjectsString = "";
            if (tanitjaLista != null)
            {                
                for (int i = 0; i < tanitjaLista.Count; i++)
                {
                    subjectsString = tanitjaLista.ElementAt(i)+ ", ";
                }
            }
            
            return subjectsString;
        }

        public int getNextTeacherID()
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int maxID = -1;
            try
            {
                connect.Open();
                string query = "SELECT tanarok.ID as tanarID from tanarok";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    if(Convert.ToInt32(reader["tanarID"]) > maxID)
                    {
                        maxID = Convert.ToInt32(reader["tanarID"]);
                    }
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return maxID + 1;
        }

        public void uploadTeacherForm()
        {
            try
            {
                AddTeacherForm atf = new AddTeacherForm();
                atf.Show();
            }
            catch (Exception ex)
            {

                Debug.WriteLine(ex.Message);
            }
        }

        public void updateTeacherForm()
        {
            try
            {
                UpdateTeacherForm utf = new UpdateTeacherForm();
                utf.Show();
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }
        }
        public void insertTeacher(TextBox nameBox, ComboBox subjectBox, ComboBox classBox, CheckBox osztalyfonokEBox)
        {

            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int teacherID = getNextTeacherID();
            string name = nameBox.Text;
            string subject = subjectBox.Text;
            int subjectID = getTantargyakID(subject);
            int osztalyfonokE = Convert.ToInt32(osztalyfonokEBox.Checked);
            string query;
            if (osztalyfonokE == 1)
            {                
                string className = classBox.Text;
                int classID = getClassID(className);
                query = insertTeacherQuery(name, osztalyfonokE, subjectID, teacherID, classID);
            }
            else
            {
                query = insertTeacherQuery(name, osztalyfonokE, subjectID, teacherID);
            }
            try
            {
                connect.Open();                
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Sikeres feltöltés!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }
        }

        public DataTable createDataTable(List<Tanar> tanarList)
        {            
            DataTable tanarDT = new DataTable();
            tanarDT.Columns.Add("azon", typeof(int));
            tanarDT.Columns.Add("name", typeof(string));
            tanarDT.Columns.Add("className", typeof(string));
            tanarDT.Columns.Add("osztalyfonokE", typeof(bool));
            tanarDT.Columns.Add("subjectName", typeof(string));
            
            foreach (var item in tanarList)
            {                
                string subjectsString = getSubjectsString(item.tanitjaLista);                
                tanarDT.Rows.Add(item.id, item.nev, item.sajatOsztaly, item.osztalyfonokE, subjectsString);                
            }
            return tanarDT;
        }

        public void fillTeacherNameComboBox(ComboBox teacherNameBox)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            string query = "SELECT tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE FROM tanarok";
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    string name = reader["tanarNev"].ToString();
                    int osztalyfonok = Convert.ToInt32(reader["osztalyfonokE"]);
                    teacherNameBox.Items.Add(name);                    
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        
        public void updateTeacher(string name, string subject, int osztalyfonokE, int rendszergazdaE, string newName, string className)
        {
            int teacherID = getTeacherID(name);
            int subjectID = getTantargyakID(subject);
            int classID = getClassID(className);
            int tanitjaID = getTanitjaID(teacherID);
            Debug.WriteLine("Subject ID : " + subjectID);
            Debug.WriteLine("Teacher ID: " + teacherID);
            Debug.WriteLine("Kapott név: " + name);
            string query = "";
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            if(tanitjaID > 0)
            {
                query = "UPDATE `tanarok` SET `Nev` = '" + newName + "', `OsztalyfonokE` = '" + osztalyfonokE + "' WHERE `tanarok`.`ID` = '" + teacherID + "';" +
                           "UPDATE tanitja SET TantargyID = '" + subjectID + "', TanarID = '" + teacherID + "' WHERE tanitja.ID = '" + tanitjaID + "';" +
                           "UPDATE osztalyok SET OsztalyfonokID = " + teacherID + " WHERE osztalyok.ID = " + classID + ";";
            }
            else
            {
                query = "UPDATE `tanarok` SET `Nev` = '" + newName + "', `OsztalyfonokE` = '" + osztalyfonokE + "' WHERE `tanarok`.`ID` = '" + teacherID + "';" +
                           "UPDATE tanitja SET TantargyID = '" + subjectID + "', TanarID = '" + teacherID + "' WHERE tanitja.ID = '" + tanitjaID + "';" +
                           "INSERT INTO `tanitja` (`ID`, `TantargyID`, `TanarID`) VALUES (NULL, '"+subjectID+"', '"+teacherID+"');";
            }
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Sikeres módosítás!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Sikertelen módosítás!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void fillOfBox(ComboBox ofBox)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                string query = "SELECT tanarok.Nev as tanarNev FROM tanarok WHERE tanarok.OsztalyfonokE = 1";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ofBox.Items.Add(reader["tanarNev"].ToString());
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
