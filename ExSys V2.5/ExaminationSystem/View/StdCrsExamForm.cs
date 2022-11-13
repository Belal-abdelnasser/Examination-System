using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using ExaminationSystem.DAL;
using System.Data.SqlClient;

namespace ExaminationSystem
{
    public partial class StdCrsExamForm : Form
    {
        public static string CrsId;
        DBLayer dbl = new DBLayer();
        public StdCrsExamForm()
        {
            InitializeComponent();
        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();

            this.Hide();
            loginfrm.Show();
        }

        private void StdCrsExamForm_Load(object sender, EventArgs e)
        {

            var courses = dbl.Stored_ProcedureStdCrs("StudentCrsNew", LoginForm.StudentId);
            var crsBS = new BindingSource(courses, "");
            stdCrsComboBox.DataSource = crsBS;
            stdCrsComboBox.DisplayMember = "Crs_Name";
            stdCrsComboBox.ValueMember = "Crs_Id";
            //CrsId = stdCrsComboBox.SelectedValue.ToString();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //crsCombo.GetItemText(crsCombo.SelectedItem)
            //crsCombo.GetItemText(crsCombo.SelectedValue)
            if (stdCrsComboBox.SelectedItem == null)
            {
                MessageBox.Show("You Don't Have Exams To Take !", "No Exams!", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                LoginForm exloginForm = new LoginForm();
                this.Hide();
                exloginForm.Show();
            }
            else { 
            var qtest = dbl.select(new SqlCommand($"SELECT * FROM Questions Where Crs_Id ={Convert.ToInt32(stdCrsComboBox.SelectedValue.ToString())} "));
            if (qtest.Rows.Count != 0)
            {
                var rowsEffected = dbl.Stored_ProcedureInsertExamList("ExamCreate", 60, Convert.ToInt32(stdCrsComboBox.SelectedValue.ToString()));
                    CrsId = stdCrsComboBox.SelectedValue.ToString();
                    // DBLayer.dml(new SqlCommand($"delete from St_Answer where St_Id={Convert.ToInt32(LoginForm.StudentId)}"));
                    var examGen = dbl.Stored_ExamGen("ExamGeneration", Convert.ToInt32(LoginForm.StudentId), Convert.ToInt32(StdCrsExamForm.CrsId));
                    StdQuestionsForm exStdForm = new StdQuestionsForm();
                    this.Hide();
                    exStdForm.Show();

                }
            else
            {
                MessageBox.Show("There is No Questions for this course, Please Refere to the Instructor!!", "Exam Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
            
            
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();

            this.Hide();
            loginfrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            View.StdCrsGrade toGradeFrm = new View.StdCrsGrade();
            toGradeFrm.Show();
            this.Hide();
        }
    }
}
