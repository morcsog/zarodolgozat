using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
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
        Repository repo = new Repository();
        public UpdateStudentForm()
        {
            InitializeComponent();
            repo.listaFeltoltDiakOsztaly(selectedComboBox);
            repo.listaFeltolt(classComboBox);
        }

    }
}
