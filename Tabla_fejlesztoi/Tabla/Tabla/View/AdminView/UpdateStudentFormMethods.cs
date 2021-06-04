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
    public partial class UpdateStudentForm : Form
    {        
        /// <summary>
        /// A módosít gomb metódusai.
        /// </summary>        
        private void updateBtn_Click(object sender, EventArgs e)
        {
            repo.updateStudent(selectedComboBox, classComboBox, nameBox);
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            this.Close();
        }
    }
}
