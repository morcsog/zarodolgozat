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
using Tabla.Model;
using Tabla.Repo;

namespace Tabla
{
    public partial class MainAdmin : Form
    {
        private DataTable diakDT = new DataTable();
        private Repository repo = new Repository();
        private DataTable tanarDT = new DataTable();
        private DataTable classDT = new DataTable();
        private int isAdmin = 0;        
        public Form formRefToLogin { get; set; }

        private void teacherUpdateBtn_Click(object sender, EventArgs e)
        {
            repo.updateTeacherForm();
        }
        private void scrPanelBtn_Click(object sender, EventArgs e)
        {
            srcPanel.Visible = true;
            loadBtn.Visible = false;
            updatePanel.Visible = false;
            uploadPanel.Visible = false;
        }

        public void studentOnLoad()
        {
            srcPanel.Visible = false;
            uploadPanel.Visible = false;
            updatePanel.Visible = false;
            srcActionPanel.Visible = false;
            refreshPanel.Visible = false;
        }

        public void teacherOnLoad()
        {
            teacherSrcPanel.Visible = false;
            teacherSrcActionPanel.Visible = false;
            teacherUploadPanel.Visible = false;
            teacherUpdatePanel.Visible = false;
            teacherRefreshPanel.Visible = false;
        }

        public void classOnLoad()
        {
            updateClassActionPanel.Visible = false;
            uploadClassActionPanel.Visible = false;
            uploadClassPanel.Visible = false;
            updateClassPanel.Visible = false;                       
            loadClassActionPanel.Visible = true;

        }
        private void srcBtn_Click(object sender, EventArgs e)
        {
            repo.searchResult(diakDT, studentDataGridView, idBox, nameBox, classBox);                       
        }

        private void cancelBtn_Click(object sender, EventArgs e)
        {
            uploadPanel.Visible = true;
            updatePanel.Visible = true;
            srcActionPanel.Visible = true;
            srcPanel.Visible = false;
        }
        
        /// <summary>
        /// Feltöltést vezérlő elemek
        /// </summary>

        private void uploadBtn_Click(object sender, EventArgs e)
        {
            repo.uploadStudentForm();

        }
        private void refreshBtn_Click(object sender, EventArgs e)
        {
            reloadStudentDTG();
        }
        /// <summary>
        /// Betöltés gomb működése.
        /// </summary>

        private void loadBtn_Click(object sender, EventArgs e)
        {

            List<Diak> diakList = repo.getDiakList();
            if (diakList.Count == 0)
            {
                srcPanel.Visible = false;
                uploadPanel.Visible = true;
                updatePanel.Visible = false;
                srcActionPanel.Visible = false;
                refreshPanel.Visible = false;
            }
            else
            {
                uploadPanel.Visible = true;
                updatePanel.Visible = true;
                srcActionPanel.Visible = true;
                refreshPanel.Visible = true;
                loadPanel.Visible = false;
            }
            repo.setDiaklist(diakList);
            diakDT = repo.createDataTable(diakList);
            studentDataGridView.DataSource = diakDT;
            setDataGridView();

        }

        private void teacherUploadBtn_Click(object sender, EventArgs e)
        {
            repo.uploadTeacherForm();            
        }

        /// <summary>
        /// A tanári panelen a kereső gombra hívja elő a kereső felületet.
        /// </summary>        
        private void teacherSrcPanelBtn_Click(object sender, EventArgs e)
        {
            teacherSrcPanel.Visible = true;
            repo.fillSubjectComboBox(subjectBox);
        }
        /// <summary>
        /// A keresést végzi el a tanári keresőben.
        /// </summary>

        private void teacherSrcBtn_Click(object sender, EventArgs e)
        {
            repo.searchResultTeacher(tanarDT, teacherDataGridView, teacherIDBox, teacherNameBox, subjectBox);
        }
        //Bezárja a kereső panelt.
        private void teacherCancelBtn_Click(object sender, EventArgs e)
        {
            teacherSrcPanel.Visible = false;
        }

        /// <summary>
        /// Újratölti a DataGridView-t.
        /// </summary>
        public void reloadStudentDTG()
        {
            List<Diak> diakList = repo.getDiakList();
            diakDT = repo.createDataTable(diakList);
            studentDataGridView.DataSource = diakDT;

        }

        public void reloadTeacherDTG()
        {
            List<Tanar> tanarList = repo.getTeacherList();
            tanarDT = repo.createDataTable(tanarList);
            teacherDataGridView.DataSource = tanarDT;

        }

        public void reloadClassDTG(DataTable classDT, DataGridView classDataGridView)
        {
            List<Osztalyok> osztalyList = repo.getClassList();
            classDT = repo.createClassDataTable(osztalyList);
            classDataGridView.DataSource = classDT;

        }
        /// <summary>
        /// Beállítja a DataGridView-t.
        /// </summary>
        public void setDataGridView()
        {
            studentDataGridView.Columns["azon"].HeaderText = "Azonosító";
            studentDataGridView.Columns["name"].HeaderText = "Név";
            studentDataGridView.Columns["classname"].HeaderText = "Osztály név";
            studentDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            studentDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void setTeacherDataGridView()
        {
            teacherDataGridView.Columns["azon"].HeaderText = "Azonosító";
            teacherDataGridView.Columns["name"].HeaderText = "Név";
            teacherDataGridView.Columns["classname"].HeaderText = "Osztály név";
            teacherDataGridView.Columns["osztalyfonokE"].HeaderText = "Osztályfőnök-e";
            teacherDataGridView.Columns["subjectName"].HeaderText = "Tanított tárgy neve:";
            teacherDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            teacherDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }

        public void setClassDataGridView()
        {
            classDataGridView.Columns["azon"].HeaderText = "Azonosító";
            classDataGridView.Columns["name"].HeaderText = "Név";
            classDataGridView.Columns["ofName"].HeaderText = "Osztályfőnök neve";
            classDataGridView.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            classDataGridView.DefaultCellStyle.Alignment = DataGridViewContentAlignment.MiddleCenter;
        }
        /// <summary>
        /// A módosít gomb működése.
        /// </summary>

        private void updateBtn_Click(object sender, EventArgs e)
        {
            repo.updateStudentForm();
        }
        /// <summary>
        /// A tanárokat tölti be.
        /// </summary>

        private void teacherLoadBtn_Click(object sender, EventArgs e)
        {
            List<Tanar> tanarLista = new List<Tanar>();
            tanarLista = repo.getTeacherList();           

            Debug.WriteLine("TanarList tartalmának száma: " + tanarLista.Count);            
            if (tanarLista.Count == 0)
            {
                teacherSrcPanel.Visible = false;
                teacherSrcActionPanel.Visible = false;
                teacherUploadPanel.Visible = false;
                teacherUpdatePanel.Visible = false;
                teacherRefreshPanel.Visible = false;
            }
            else
            {
                teacherSrcPanel.Visible = false;
                teacherSrcActionPanel.Visible = true;
                teacherUploadPanel.Visible = true;
                teacherUpdatePanel.Visible = true;
                teacherRefreshPanel.Visible = true;
                teacherLoadPanel.Visible = false;
            }
            repo.setTanarList(tanarLista);
            tanarDT = repo.createDataTable(tanarLista);
            teacherDataGridView.DataSource = tanarDT;
            setTeacherDataGridView();
        }

        private void teacherRefreshBtn_Click(object sender, EventArgs e)
        {
            reloadTeacherDTG();
        }
        
        private void loadClassBtn_Click(object sender, EventArgs e)
        {
            List<Osztalyok> osztalyList = new List<Osztalyok>();
            osztalyList = repo.getClassList();

            Debug.WriteLine("TanarList tartalmának száma: " + osztalyList.Count);
            if (osztalyList.Count == 0)
            {
                updateClassActionPanel.Visible = false;
                uploadClassActionPanel.Visible = false;
                uploadClassPanel.Visible = false;
                updatePanel.Visible = false;                
            }
            else
            {
                updateClassActionPanel.Visible = true;
                uploadClassActionPanel.Visible = true;
                uploadClassPanel.Visible = false;
                updateClassPanel.Visible = false;                
                loadClassActionPanel.Visible = false;
            }
            repo.setClassList(osztalyList);
            classDT = repo.createClassDataTable(osztalyList);
            classDataGridView.DataSource = classDT;
            setClassDataGridView();
        }
        private void uploadClassPanelBtn_Click(object sender, EventArgs e)
        {
            uploadClassPanel.Visible = true;
            repo.fillOfBox(ofBox);
        }

        private void cancelClassBtn_Click(object sender, EventArgs e)
        {
            uploadClassPanel.Visible = false;
        }

        private void uploadClassBtn_Click(object sender, EventArgs e)
        {
            repo.uploadClass(classNameTextBox, ofBox, classDT, classDataGridView);
        }
        private void updateClassPanelBtn_Click(object sender, EventArgs e)
        {
            updateClassPanel.Visible = true;
            repo.listaFeltolt(classUpdateBox);
        }
        private void cancelUpdateClassBtn_Click(object sender, EventArgs e)
        {
            updateClassPanel.Visible = false;
        }
        private void button6_Click(object sender, EventArgs e)
        {
            repo.updateClass(classUpdateBox, newClassNameBox, classDT, classDataGridView);
        }


        /// <summary>
        /// Regisztrálással kapcsolatos metódusok
        /// </summary>
        /// 

        public void regOnLoad()
        {
            registrationPanel.Visible = false;
        }

        private void teacherCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if(teacherCheckBox.CheckState == CheckState.Checked)
            {
                studentCheckBox.Enabled = false;
                registrationPanel.Visible = true;
                adminCheckBoxPanel.Visible = true;
                regNameBox.Items.Clear();
                repo.setRegPanel(true, regNameBox);
            }
            else
            {
                studentCheckBox.Enabled = true;
                registrationPanel.Visible = false;
            }

        }

        private void studentCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (studentCheckBox.CheckState == CheckState.Checked)
            {
                teacherCheckBox.Enabled = false;
                registrationPanel.Visible = true;
                adminCheckBoxPanel.Visible = false;
                regNameBox.Items.Clear();
                repo.setRegPanel(false, regNameBox);

            }
            else
            {
                teacherCheckBox.Enabled = true;
                registrationPanel.Visible = false;
            }
        }
        private void insertRegBtn_Click(object sender, EventArgs e)
        {
            if(teacherCheckBox.CheckState == CheckState.Checked)
            {
                repo.insertReg(true, regNameBox, regUsernameBox, regPwBox, isAdmin);                
            }
            else if (studentCheckBox.CheckState == CheckState.Checked)
            {
                repo.insertReg(false, regNameBox, regUsernameBox, regPwBox, isAdmin);
            }
            else
            {
                Debug.WriteLine("Itten valami nagyon nincsen rendben.");
            }

        }
        private void adminCheckBox_CheckedChanged(object sender, EventArgs e)
        {
            if (adminCheckBox.Checked)
            {
                isAdmin = 1;
            }
            else
            {
                isAdmin = 0;
            }
        }
        // Ha bezárja a felhasználó a formot.
        private void MainAdmin_FormClosing(object sender, FormClosingEventArgs e)
        {                        
            if (e.CloseReason == CloseReason.UserClosing)
            {
                int loginedTeacherID = repo.getLoginedTeacherID();
                repo.setLogined(loginedTeacherID, false);
                this.formRefToLogin.Show();
                e.Cancel = true;
                this.Hide();
            }
        }

    }
}
