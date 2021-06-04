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
       

        public Exception RepositoryException { get; private set; }
        private MySqlConnectionStringBuilder mscb = new MySqlConnectionStringBuilder();
        public string getSqlConnection()
        {
            mscb.Server = "localhost";
            mscb.Database = "tablaenaplo";
            mscb.UserID = "root";
            mscb.Password = "";
            mscb.Port = 3306;
            mscb.SslMode = MySqlSslMode.None;
            return mscb.ToString();
        }
        public string getLogins()
        {
            return "SELECT * FROM felhasznalok";
        }

        public string getAllDiakData()
        {
            return "SELCET * FROM diakok";
        }

        public string getDiakForDT()
        {
            return "SELECT Nev, OsztalyID, ID FROM diakok";
        }

        public string getDiakForTeacherForm(int classID)
        {
            return "SELECT diakok.Nev as diakNev FROM diakok WHERE diakok.OsztalyID = '"+classID+"'";
        }

        public string getTeacherForDT()
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID ORDER BY tanarok.ID ";
        }

        public string getClassForDT()
        {
            return "SELECT osztalyok.OsztalyNev as osztalyNev, osztalyok.ID as osztalyID FROM osztalyok";
        }

        public string getTeacherForDT(bool kell)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, tantargyak.Nev as tantargyNev FROM tanarok INNER JOIN tanitja ON tanarok.ID = tanitja.TanarID INNER JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID";
        }

        public string getSubjectID(int teacherID)
        {
            return "SELECT TantargyID FROM tanitja WHERE TanarID = '" + teacherID + "'";
        }

        public string getSubjectID(string subjectName)
        {
            return "SELECT tantargyak.ID as tantargyID FROM tantargyak WHERE tantargyak.Nev = '"+subjectName+"'";
        }

        public string getSubjectNameQuery(int teacherID)
        {
            return "SELECT Nev FROM tantargyak INNER JOIN tanitja ON tantargyak.ID = tanitja.TantargyID INNER JOIN tanarok ON tanarok.ID = tanitja.TanarID WHERE tanarok.ID = '" + teacherID + "'";
        }
        
        //ID alapján keres
        public string searchQuery(int id)
        {
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.ID = '" + id + "'";
        }
        //Osztály név alapján keres
        public string searchQuery(string className, bool kell)
        {
            int classID = getClassID(className);
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.OsztalyID = '" + classID + "'";
        }
        //Név alapján keres
        public string searchQuery(string name)
        {
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.Nev = '" + name + "'";
        }
        //ID és név alapján keres
        public string searchQuery(int id, string name)
        {
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.ID = '" + id + "' AND diakok.Nev = '" + name + "'";
        }
        //ID, név és osztály név alapján kérdez le.
        public string searchQuery(int id, string name, string className)
        {
            int classID = getClassID(className);
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.ID = '" + id + "' AND diakok.Nev = '" + name + "' AND diakok.OsztalyID = '" + classID + "'";
        }
        //ID és osztály név alapján kérdez le.
        public string searchQuery(int id, string className, bool kell)
        {
            int classID = getClassID(className);
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.ID = '" + id + "' AND diakok.OsztalyID = '" + classID + "'";
        }
        //Név és osztály név alapján kérdez le
        public string searchQuery(string name, string className)
        {
            int classID = getClassID(className);
            return "SELECT diakok.Nev, diakok.OsztalyID, diakok.ID FROM diakok WHERE diakok.OsztalyID = '" + classID + "' AND diakok.Nev = '" + name + "'";
        }
        
        //ID alapján keres
        public string searchQueryForTeacher(int id)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tanarok.ID = '" + id + "' ORDER BY tanarok.ID";
        }
        //Osztály név alapján visszadja, hogy ki tanítja az osztályt.
        public string searchQueryForTeacher(string className, bool kell)
        {
            int classID = getClassID(className);
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE osztalyok.ID = '" + classID + "' ORDER BY tanarok.ID";
        }
        //Név alapján keres, visszadja majd, a listát tanár alapján.
        public string searchQueryForTeacher(string name)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tanarok.Nev = '" + name + "' ORDER BY tanarok.ID";
        }
        //Megnézi, hogy az ID és a név egyenlő-e, ha igen visszaadja az adott lekérdezést.
        public string searchQueryForTeacher(int id, string name)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tanarok.ID = '" + id + "' AND tanarok.Nev = '" + name + "' ORDER BY tanarok.ID";
        }
        //ID, tanár név és osztály név alapján visszaadja majd a listát.
        public string searchQueryForTeacher(int id, string name, string className)
        {
            int classID = getClassID(className);
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tanarok.ID = '" + id + "' AND tanarok.Nev = '" + name + "' AND osztalyok.ID = '" + classID + "' ORDER BY tanarok.ID ";
        }
        //Tanár ID és osztály név alapján visszaadja a listát.
        public string searchQueryForTeacher(int id, string className, bool kell)
        {
            int classID = getClassID(className);
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztayok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tanarok.ID = '" + id + "' AND osztalyok.ID = '" + classID + "' ORDER BY tanarok.ID";
        }
        //Tanár név és osztály név alapján adja vissza a listát.
        public string searchQueryForTeacher(string name, string className)
        {
            int classID = getClassID(className);
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE osztalyok.ID = '" + classID + "' AND tanarok.Nev = '" + name + "' ORDER BY tanarok.ID";
        }
        //Tantárgy név alapján listázza ki a tanárokat.
        public string searchQueryForTeacher(string subjectName, bool kell, bool kell1)
        {            
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tantargyak.Nev = '" + subjectName + "' ORDER BY tanarok.ID";
        }

        //Tantárgy név, Tanár ID alapján listázza ki a tanárokat.
        public string searchQueryForTeacher(string subjectName, int teacherID)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tantargyak.Nev = '" + subjectName + "' AND tanarok.ID = '" + teacherID + "' ORDER BY tanarok.ID";
        }

        //Tantárgy név, Tanár név alapján listázza ki a tanárokat.
        public string searchQueryForTeacher(string subjectName, string teacherName, bool kell)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tantargyak.Nev = '" + subjectName + "' AND tanarok.Nev = '" + teacherName + "' ORDER BY tanarok.ID";
        }

        //Tantárgy név, Tanár ID, Tanár Név alapján listázza ki a tanárokat.
        public string searchQueryForTeacher(string subjectName, int teacherID, string teacherName)
        {
            return "SELECT tanarok.ID as tanarID, tanarok.Nev as tanarNev, tanarok.OsztalyfonokE as osztalyfonokE, osztalyok.OsztalyNev as OsztalyNev, tantargyak.Nev as tantargyNev FROM tanarok LEFT JOIN osztalyok ON tanarok.ID = osztalyok.OsztalyfonokID LEFT JOIN tanitja ON tanarok.ID = tanitja.TanarID LEFT JOIN tantargyak ON tantargyak.ID = tanitja.TantargyID WHERE tantargyak.Nev = '" + subjectName + "' AND tanarok.ID = '" + teacherID + "' AND tanarok.Nev = '" + teacherName + "' ORDER BY tanarok.ID";
        }
        //Visszaadja az osztály ID-t osztálynév alapján, ez csak egy query.
        public string getClassIDQuery(string className)
        {
            return "SELECT osztalyok.ID FROM osztalyok WHERE osztalyok.OsztalyNev = '" + className + "'";
        }

        public string getTeacherClassNameQuery(int teacherID)
        {
            return "SELECT osztalyok.OsztalyNev FROM osztalyok INNER JOIN tanarok ON tanarok.ID = osztalyok.OsztalyfonokID WHERE osztalyok.OsztalyfonokID = '" + teacherID + "'";
        }

        /// <summary>
        /// Visszadja az összes ID a diákok listából. Ez csak az SQL utasítás.
        /// </summary>
        /// <returns>String, a diákok ID-ja.</returns>
        public string getAllIDQuery()
        {
            return "SELECT diakok.ID FROM diakok";
        }
        /// <summary>
        /// Feltölti a tanulót a megadott paraméterek alapján, ez csak az SQL utasítás.
        /// </summary>
        /// <param name="nev">A diák neve</param>
        /// <param name="classID">Az osztály ID-ja amiben a diák van./param>
        /// <returns>Egy stringet, az SQL utasítást adja vissza.</returns>
        public string insertStudentQuery(string nev, int classID)
        {
            return "INSERT INTO `diakok` (`ID`, `Nev`, `OsztalyID`, `logined`, `regisztralt`) VALUES (NULL, '"+ nev + "', '" + classID + "', NULL, NULL);";
        }
        /// <summary>
        /// A tanuoló modosításának az SQL utasítása.
        /// </summary>
        /// <param name="id">A diák ID-ja.</param>
        /// <param name="name">A diák neve.</param>
        /// <param name="classID">Az osztály ID-ja.</param>
        /// <returns>Visszaadja az SQL utasítást String formájában.</returns>
        public string updateStudentQuery(int id, string name, int classID)
        {
            return "UPDATE `diakok` SET `Nev` = '" + name + "', `OsztalyID` = '" + classID + "' WHERE `diakok`.`ID` = '" + id + "' ";
        }

        public string insertTeacherQuery(string name, int osztalyfonokE, int tantargyID, int teacherID, int classID)
        {
            return "INSERT INTO `tanarok` (`ID`, `Nev`, `OsztalyfonokE`, `logined`, `regisztralt`) VALUES (NULL, '" + name + "', '" + osztalyfonokE + "', NULL, NULL); " +
                   "INSERT INTO `tanitja` (`ID`, `TantargyID`, `TanarID`) VALUES (NULL, '" + tantargyID + "', '" + teacherID + "'); " +
                   "UPDATE `osztalyok` SET `OsztalyfonokID` = '5' WHERE `osztalyok`.`ID` = '" + classID + "';";
        }

        public string insertTeacherQuery(string name, int osztalyfonokE, int tantargyID, int teacherID)
        {
            return "INSERT INTO `tanarok` (`ID`, `Nev`, `OsztalyfonokE`, `logined`, `regisztralt`) VALUES (NULL, '" + name + "', '" + osztalyfonokE + "', NULL, NULL); " +
                   "INSERT INTO `tanitja` (`ID`, `TantargyID`, `TanarID`) VALUES (NULL, '" + tantargyID + "', '" + teacherID + "'); ";                   
        }


        //Visszaadja az osztályt ID-t név alapján.
        public string getClassName(string osztalyID)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            string className = "";
            try
            {
                connect.Open();
                string query = "SELECT osztalyok.OsztalyNev as osztalyNev FROM osztalyok WHERE ID = '" + osztalyID + "'";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();                
                while (reader.Read())
                {
                    className = reader["osztalyNev"].ToString();
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                className = "Valamit elrontottál.";
            }

            return className;
        }
        public int getTeacherID(string name)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int id = -1;
            string query = "SELECT tanarok.ID as tanarokID FROM tanarok WHERE tanarok.Nev = '" + name + "'";
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["tanarokID"]);
                    Debug.WriteLine(id);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return id;
        }

        public string getTeacherClassName(int teacherID)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            MySqlCommand cmd = new MySqlCommand(getTeacherClassNameQuery(teacherID), connect);
            string className = "";
            try
            {
                connect.Open();
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    className = reader["osztalyok.OsztalyNev"].ToString();
                }
                connect.Close();
            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            return className;
        }
        
        public int getNumberOfClasses()
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int numberOfClasses = 0;
            try
            {
                connect.Open();
                string query = "SELECT COUNT(osztalyok.OsztalyNev) as darab FROM osztalyok";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    numberOfClasses += Convert.ToInt32(reader["darab"]);
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            return numberOfClasses;
        }

        public List<Osztalyok> getAllClassNameList()
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            List<Osztalyok> nameList = new List<Osztalyok>();
            int darab = getNumberOfClasses();
            try
            {                
                connect.Open();
                string query = "SELECT osztalyok.OsztalyNev as osztalyNev, osztalyok.ID as osztalyID, osztalyok.OsztalyfonokID as ofID FROM osztalyok";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();                
                while (reader.Read())
                {
                    string className = reader["osztalyNev"].ToString();
                    int classID = Convert.ToInt32(reader["osztalyID"]);
                    int ofID;
                    if (reader.IsDBNull(2))
                    {
                        ofID = 0;
                    }
                    else
                    {
                        ofID = Convert.ToInt32(reader["ofID"]);                        
                    }
                    Osztalyok osztaly = new Osztalyok(classID, className, ofID);
                    nameList.Add(osztaly);
                }                
                connect.Close();                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }
            return nameList;
        }
        // Megadja az osztály ID-t az osztály név alapján
        public int getClassID(string nev)
        {
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            int id = -1;
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(getClassIDQuery(nev), connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                }
                connect.Close();

            }
            catch (Exception e)
            {

                Debug.WriteLine(e.Message);
            }
            return id;
        }

        public int getNextID()
        {
            MySqlConnection connect = new MySqlConnection(mscb.ToString());
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(getAllIDQuery(), connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                int id = -1;
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["ID"]);
                }
                connect.Close();
                return id;
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                return 0;
            }
        }
        /// <summary>
        /// Feltölt egy diákot az adatbázisba.
        /// </summary>
        /// <param name="nev">A diák neve</param>
        /// <param name="classComboBox">A ComboBox amiből kiválaszthatja a rendszergazda az osztályt amelyikbe szeretné a diákot helyezni.</param>
        public void insertStudent(TextBox nev, ComboBox classComboBox)
        {
            MySqlConnection connection = new MySqlConnection(getSqlConnection());
            Diak student = new Diak();
            try
            {
                string name = nev.Text;
                string className = classComboBox.Text;
                int classID = getClassID(className);
                student = new Diak(getNextID(), name, className);
                connection.Open();
                MySqlCommand cmd = new MySqlCommand(insertStudentQuery(name, classID),connection);
                cmd.ExecuteNonQuery();
                connection.Close();
                try
                {
                    addStudentToList(student);
                }
                catch (Exception e)
                {

                    Debug.WriteLine(e.Message);
                }
                var result = MessageBox.Show("Sikeres feltöltés!", "Sikeres feltöltés!", MessageBoxButtons.OK);
                
                
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                var result = MessageBox.Show("Ellenőrízd, hogy megfelelően adtad-e meg az adatokat! \nHa helyesen adtad meg az adatokat akkor, kérlek jelezd a fejlesztőnek a hibát!", "Végzetes hiba!!!", MessageBoxButtons.OK, MessageBoxIcon.Error);              
            }
        }

        public void updateStudent(int id, string name, int classID)
        {            
            try
            {
                MySqlConnection connect = new MySqlConnection(getSqlConnection());
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(updateStudentQuery(id, name, classID), connect);
                cmd.ExecuteNonQuery();
                MessageBox.Show("Sikeres feltöltés!");
                connect.Close();
            }
            catch (Exception e)
            {
                MessageBox.Show("Sikertelen feltöltés!", "Hiba!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                Debug.WriteLine(e.Message);
            }
        }
    }
}
