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
    public partial class MainTeacher : Form
    {
        Repository repo = new Repository();
        public MainTeacher()
        {
            InitializeComponent();
            repo.listaFeltolt(classComboBoxGrade);
            repo.listaFeltolt(absenceComboBox);
            repo.fillSubjectBox(subjectsBox, repo.getLoginedTeacherID());
        }
    }
}
