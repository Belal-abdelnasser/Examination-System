using System;
using ExaminationSystem.DAL;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace ExaminationSystem.View
{
    public partial class StdCrsGrade : Form
    {
        DBLayer dbl = new DBLayer();
        public StdCrsGrade()
        {
            InitializeComponent();
        }
        public void gridView()
        {
            //var examGridView = dbl.select(new SqlCommand($"SELECT Ex_Id, Ex_duration, Crs_Id FROM Exam Where Crs_Id = {Convert.ToInt32(crsCombo.SelectedValue.ToString())}"));
            var grades = dbl.Stored_ProcedureStdgrades("GetStGrades", LoginForm.StudentId);
            var stgrades = new BindingSource(grades, "");
            dataGridView1.DataSource = stgrades;
            #region Styling Header of Grid
            DataGridViewCellStyle columnHeaderStyle = new DataGridViewCellStyle();
            columnHeaderStyle.BackColor = Color.LightSkyBlue;
            columnHeaderStyle.Font = new Font("Verdana", 10, FontStyle.Bold);
            dataGridView1.ColumnHeadersDefaultCellStyle = columnHeaderStyle;
            dataGridView1.EnableHeadersVisualStyles = false;
            dataGridView1.SelectionMode = DataGridViewSelectionMode.FullRowSelect;
            #endregion
        }
        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();
            this.Hide();
            loginfrm.Show();
        }

        private void StdCrsGrade_Load(object sender, EventArgs e)
        {
            this.gridView();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();

            this.Hide();
            loginfrm.Show();
        }

        private void label1_Click_1(object sender, EventArgs e)
        {

        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void button3_Click(object sender, EventArgs e)
        {
            StdCrsExamForm stcrs = new StdCrsExamForm();
            this.Hide();
            stcrs.Show();
            
        }
    }
}
