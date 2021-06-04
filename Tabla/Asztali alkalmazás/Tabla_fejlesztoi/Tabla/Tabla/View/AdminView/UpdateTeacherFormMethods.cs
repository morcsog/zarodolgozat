using MySql.Data.MySqlClient;
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
    public partial class UpdateTeacherForm : Form
    {
        private int osztalyfonok = 0;
        private int rendszergazda = 0;
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        private void addBtn_Click(object sender, EventArgs e)
        {
            string name = nameComboBox.Text;
            string subjectName = repo.getSubjectNameForTeacherUpdate(name);
            string newName = nameComboBox.Text;
            string className = classComboBox.Text;
            if(subjectsBox.Text.Length > 0)
            {
                subjectName = subjectsBox.Text;
            }
            if(nameBox.Text.Length > 0)
            {
                newName = nameBox.Text;
            }
            repo.updateTeacher(name, subjectName, osztalyfonok, rendszergazda, newName, className);
        }

        private void osztalyfonokEBox_CheckedChanged(object sender, EventArgs e)
        {
            if (osztalyfonokEBox.Checked)
            {
                osztalyfonok = 1;
            }
            else
            {
                osztalyfonok = 0;
            }            
        }

        private void rendszergazdaEBox_CheckedChanged(object sender, EventArgs e)
        {
            if (rendszergazdaEBox.Checked)
            {
                rendszergazda = 1;
            }
            else
            {
                rendszergazda = 0;
            }            
        }
    }
}
