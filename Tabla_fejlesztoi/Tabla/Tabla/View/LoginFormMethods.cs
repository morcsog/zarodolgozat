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
using Tabla.Repo;

namespace Tabla
{
    public partial class LoginForm : Form
    {
        Repository repo = new Repository();        
        private void loginBtn_Click(object sender, EventArgs e)
        {
            string login = repo.Login(usernameBox, pwBox);            
            if(login == "Tanár")
            {
                MainTeacher mt = new MainTeacher();
                mt.formRefToLogin = this;
                mt.Show();
                this.Hide();                
            }
            else if(login == "Rendszergazda"){
                MainAdmin ma = new MainAdmin();
                ma.formRefToLogin = this;
                ma.Show();
                this.Hide();     
            }            
        }
    }
}
