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
    partial class Repository
    {
        List<Osztalyok> osztalyokList;        
        public void listaFeltolt(ComboBox classComboBox)
        {
            int numberOfClasses = getNumberOfClasses();
            List<Osztalyok> osztalyList = getAllClassNameList();
            foreach (var item in osztalyList)
            {                
                if (classComboBox.Items.Count < numberOfClasses)
                    classComboBox.Items.Add(item.nev);
            }
        }

        public void listaFeltolt(ComboBox classComboBox, bool kell)
        {            
            List<Osztalyok> osztalyList = getAllClassNameList();
            foreach (var item in osztalyList)
            {
                
                if (item.osztalyFonokID == 0)
                {
                    classComboBox.Items.Add(item.nev);
                }
            }
        }

        public List<Osztalyok> getClassList()
        {
            List<Osztalyok> classList = new List<Osztalyok>();
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(getClassForDT(), connect);
                MySqlDataReader reader = cmd.ExecuteReader();

                while (reader.Read())
                {
                    string className = reader["osztalyNev"].ToString();                                                           
                    int classID = Convert.ToInt32(reader["osztalyID"]);
                    string ofName = getOfName(classID);
                    int ofID = getTeacherID(ofName);
                    Osztalyok osztaly = new Osztalyok(classID, className, ofID);
                    classList.Add(osztaly);
                }
                connect.Close();

            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }

            //tanarList.AddRange(ofNelkuliLista);
            return classList;
        }

        public string getOfName(int classID)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            string ofName = "";
            try
            {
                connect.Open();
                string query = "SELECT tanarok.Nev as tanarNev from tanarok LEFT JOIN osztalyok ON osztalyok.OsztalyfonokID = tanarok.ID WHERE osztalyok.ID = '" + classID + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    ofName = reader["tanarNev"].ToString();
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }
            return ofName;
        }

        public void setClassList(List<Osztalyok> osztalyokList)
        {
            this.osztalyokList = osztalyokList;
        }

        public DataTable createClassDataTable(List<Osztalyok> osztalyokList)
        {
            DataTable classDT = new DataTable();
            classDT.Columns.Add("azon", typeof(int));
            classDT.Columns.Add("name", typeof(string));
            classDT.Columns.Add("ofName", typeof(string));

            foreach (var item in osztalyokList)
            {
                string ofName = getOfName(item.id);
                classDT.Rows.Add(item.id, item.nev, ofName);
            }
            return classDT;
        }

        public void uploadClass(TextBox classNameBox, ComboBox ofBox, DataTable classDT, DataGridView classDataGridView)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                int teacherID = getTeacherID(ofBox.Text);
                string query = "INSERT INTO `osztalyok` (`ID`, `OsztalyNev`, `OsztalyfonokID`) VALUES (NULL, '"+classNameBox.Text+"', '"+teacherID+"') ";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                reloadClassDTG(classDT, classDataGridView);
                MessageBox.Show("Sikeres feltöltés!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Hiba! Sikertelen feltöltés!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void updateClass(ComboBox classBox, TextBox newClassNameBox, DataTable classDT, DataGridView classDataGridView)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();                
                string newName = newClassNameBox.Text;
                int classID = getClassID(classBox.Text);
                string teacherName = getOfName(classID);
                int teacherID = getTeacherID(teacherName);
                string query = "UPDATE `osztalyok` SET `OsztalyNev` = '" + newName + "', `OsztalyfonokID` = '" + teacherID + "' WHERE `osztalyok`.`ID` = '" + classID + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                reloadClassDTG(classDT, classDataGridView);
                MessageBox.Show("Sikeres feltöltés!");
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Hiba! Sikertelen feltöltés!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        public void reloadClassDTG(DataTable classDT, DataGridView classDataGridView)
        {
            List<Osztalyok> osztalyList = getClassList();
            classDT = createClassDataTable(osztalyList);
            classDataGridView.DataSource = classDT;

        }



    }

}
