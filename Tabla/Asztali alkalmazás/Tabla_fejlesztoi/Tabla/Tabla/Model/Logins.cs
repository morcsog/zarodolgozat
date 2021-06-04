using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using Tabla.Repo;

namespace Tabla.Model
{

    class Logins
    {
        private int id;
        private string username;
        private string pw;        
        private Repository repo = new Repository();                

        public Logins(int id, string username, string pw)
        {
            this.id = id;
            this.username = username;
            this.pw = pw;            
        }

        public string getUsername()
        {
            return this.username;
        }
        public string getPw()
        {
            return this.pw;
        }
        
       

        
    }
}
