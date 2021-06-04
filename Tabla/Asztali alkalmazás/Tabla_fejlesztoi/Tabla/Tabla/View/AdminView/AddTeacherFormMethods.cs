using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Tabla
{
    public partial class AddTeacherForm : Form
    {

        private void addBtn_Click(object sender, EventArgs e)
        {
            repo.insertTeacher(teacherNameBox, subjectsBox, classComboBox, osztalyfonokEBox);
        }

        private void osztalyfonokEBox_CheckedChanged(object sender, EventArgs e)
        {
            if (osztalyfonokEBox.Checked)
            {
                repo.listaFeltolt(classComboBox, true);
            }
            else
            {
                classComboBox.Items.Clear();
            }
        }
        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
