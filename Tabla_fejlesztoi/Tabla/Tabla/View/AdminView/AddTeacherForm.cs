﻿using System;
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
    public partial class AddTeacherForm : Form
    {
        Repository repo = new Repository();
        public AddTeacherForm()
        {
            InitializeComponent();
            repo.fillSubjectComboBox(subjectsBox);
        }
        
    }
}
