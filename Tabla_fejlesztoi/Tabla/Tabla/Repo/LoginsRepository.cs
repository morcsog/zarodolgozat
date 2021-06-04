using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabla.Model;

namespace Tabla.Repo
{
    partial class Repository
    {
        public int loginedTeacherID { get; set; }
        private string loginedUsername;
        private string loginedPw;
        public void setRegPanel(bool kell, ComboBox regNameBox)
        {

            string query = "";
            Debug.WriteLine(kell);
            if (kell == true)
            {
                query = "SELECT tanarok.Nev as lekertNev FROM tanarok WHERE tanarok.regisztralt IS NULL";
            }
            else
            {
                query = "SELECT diakok.Nev as lekertNev FROM diakok WHERE diakok.regisztralt IS NULL";
            }

            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    regNameBox.Items.Add(reader["lekertNev"].ToString());
                }
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }

        }

        public void insertReg(bool kell, ComboBox regNameBox, TextBox userNameBox, TextBox pwBox, int rendszergazda)
        {
            string query = "";
            string username = userNameBox.Text;
            string pw = hashPw(pwBox.Text);
            string name = regNameBox.Text;
            int teacherID = 0;
            int studentID = 0;
            if (kell)
            {
                teacherID = getTeacherID(name);
                if (rendszergazda == 1)
                {                     
                    query = "INSERT INTO `login` (`ID`, `DiakID`, `TanarID`, `RendszergazdaE`, `username`, `password`) VALUES (NULL, NULL, '"+teacherID+"', '"+rendszergazda+"', '"+username+"', '"+pw+"');" +
                        "UPDATE `tanarok` SET `regisztralt` = '1' WHERE `tanarok`.`ID` = '"+teacherID+"';";
                }                
                query = "INSERT INTO `login` (`ID`, `DiakID`, `TanarID`, `RendszergazdaE`, `username`, `password`) VALUES (NULL, NULL, '" + teacherID + "', NULL, '" + username+"', '"+pw+"');" +
                    "UPDATE `tanarok` SET `regisztralt` = '1' WHERE `tanarok`.`ID` = '" + teacherID + "';";
            }
            else
            {
                studentID = getDiakID(name);
                query = "INSERT INTO `login` (`ID`, `DiakID`, `TanarID`, `RendszergazdaE`, `username`, `password`) VALUES (NULL, '"+studentID+"', NULL, NULL, '"+username+"', '"+pw+"');" +
                    "UPDATE `diakok` SET `regisztralt` = '1' WHERE `diakok`.`ID` = '"+studentID+"';";
            }
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
                MessageBox.Show("Sikeresen regisztráltad a felhasználót!");

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
                MessageBox.Show("Sikertelenül regisztráltad a felhasználót!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            regNameBox.Items.Clear();
            userNameBox.Clear();
            pwBox.Clear();
        }

        public string hashPw(string pw)
        {
            SHA1CryptoServiceProvider sha1 = new SHA1CryptoServiceProvider();
            byte[] pwByte = Encoding.ASCII.GetBytes(pw);
            byte[] encryptedByte = sha1.ComputeHash(pwByte);            
            return Convert.ToBase64String(encryptedByte);

        }

        public string Login(TextBox usernameBox, TextBox pwBox)
        {
            string pw = hashPw(pwBox.Text);
            string username = usernameBox.Text;
            MySqlConnection connect = new MySqlConnection(getSqlConnection());            
            string query = "";
            bool tanarE = false;
            bool successfulLogin = false;            
            string returnValue = "";
            int rendszergazda = -1;

            tanarE = true;
            query = "SELECT login.username as felhasznaloNev, login.password as jelszo, login.RendszergazdaE as rendszergazda, login.TanarID as tanarID FROM login WHERE login.username = '" + username + "' AND login.password = '" + pw + "'";
            try
            {
                connect.Open();
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                while (reader.Read())
                {
                    successfulLogin = true;
                    tanarE = true;
                    loginedTeacherID = Convert.ToInt32(reader["tanarID"]);
                    string loginedWhileUsername = reader["felhasznaloNev"].ToString();
                    string loginedWhilePw = reader["jelszo"].ToString();
                    if (!reader.IsDBNull(2))
                    {
                        rendszergazda = 1;
                    }
                    else
                    {
                        rendszergazda = 0;
                    }
                }
                connect.Close();
                if (successfulLogin)
                {
                    setLogined(loginedTeacherID, true);
                    if (rendszergazda == 1)
                    {
                        returnValue = "Rendszergazda";
                    }
                    else
                    {
                        returnValue = "Tanár";
                    }
                }
                else
                {                    
                    MessageBox.Show("Hibás felhasználónév vagy jelszó!", "Hiba", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }

            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);                
            }            
            return returnValue;
        }

        public void setLogined(int teacherID, bool isLogined)
        {            
            MySqlConnection connect = new MySqlConnection(getSqlConnection());
            string query = "";
            try
            {
                connect.Open();
                if (isLogined)
                {
                    query = "UPDATE `tanarok` SET `logined` = '1' WHERE `tanarok`.`ID` = '" + teacherID + "'";
                }
                else
                {
                    query = "UPDATE `tanarok` SET `logined` = '0' WHERE `tanarok`.`ID` = '" + teacherID + "'";
                }
                
                MySqlCommand cmd = new MySqlCommand(query, connect);
                cmd.ExecuteNonQuery();
                connect.Close();
            }
            catch (Exception e)
            {
                Debug.WriteLine(e.Message);
            }
            
        }    
        
        public int getLoginedTeacherID()
        {
            int id = -1;            
            try
            {
                MySqlConnection connect = new MySqlConnection(getSqlConnection());               
                connect.Open();
                string query = "SELECT login.TanarID as tanarID FROM login LEFT JOIN tanarok ON tanarok.ID = login.TanarID WHERE tanarok.logined = 1;";
                MySqlCommand cmd = new MySqlCommand(query, connect);
                MySqlDataReader reader = cmd.ExecuteReader();
                
                while (reader.Read())
                {
                    id = Convert.ToInt32(reader["tanarID"]);
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
