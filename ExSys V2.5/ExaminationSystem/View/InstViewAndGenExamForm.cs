using ExaminationSystem.DAL;
using System;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;
using System.Diagnostics;

namespace ExaminationSystem
{
    public partial class InstViewAndGenExamForm : Form
    {
        public static int lastQID;
        public static string Crs_Name;
        public static string Crs_Id;
        DBLayer dbl = new DBLayer();
        public InstViewAndGenExamForm()
        {
            InitializeComponent();
        }

        public static void OpenBrowser(string url)
        {
            try
            {
                Process.Start(url);
            }
            catch
            {
                // hack because of this: https://github.com/dotnet/corefx/issues/10361
                if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Windows))
                {
                    url = url.Replace("&", "^&");
                    Process.Start(new ProcessStartInfo("cmd", $"/c start {url}") { CreateNoWindow = true });
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.Linux))
                {
                    Process.Start("xdg-open", url);
                }
                else if (System.Runtime.InteropServices.RuntimeInformation.IsOSPlatform(System.Runtime.InteropServices.OSPlatform.OSX))
                {
                    Process.Start("open", url);
                }
                else
                {
                    throw;
                }
            }
        }

        private void InstViewAndGenExamForm_Load(object sender, EventArgs e)
        {
            var courses = dbl.Stored_ProcedureSelectView("InstructorCrs", LoginForm.InstId);
            var crsBS = new BindingSource(courses,"");
            crsCombo.DataSource = crsBS;
            crsCombo.DisplayMember = "Crs_Name";
            crsCombo.ValueMember = "Crs_Id";  
          
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();
            this.Hide();
            loginfrm.Show();
        }

        private void comboBox1_SelectedIndexChanged(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {

            //var qtest = dbl.select(new SqlCommand($"SELECT * FROM Questions Where Crs_Id ={Convert.ToInt32(crsCombo.SelectedValue.ToString())} "));
            //if (qtest.Rows.Count != 0)
            //{
            //    if (string.IsNullOrWhiteSpace(txt_Duration.Text))
            //    {
            //        MessageBox.Show("Please Enter Duartion");
            //    }
            //    else
            //    {
            //        var rowsEffected = dbl.Stored_ProcedureInsertExamList("ExamCreate", Convert.ToInt32(txt_Duration.Text), Convert.ToInt32(crsCombo.SelectedValue.ToString()));
            //        MessageBox.Show("Exam Generated Successfully!");
            //    }
            //}
            //else
            //{
            //    MessageBox.Show("There is No Questions for this course!!", "Exam Generation Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            //}
        }

        private void examGrid_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }

        private void crsCombo_SelectionChangeCommitted(object sender, EventArgs e)
        {
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();

            this.Hide();
            loginfrm.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Crs_Name = crsCombo.GetItemText(crsCombo.SelectedItem);
            Crs_Id = crsCombo.GetItemText(crsCombo.SelectedValue);
            ChooseQuestionType QType = new ChooseQuestionType();

            this.Hide();
            QType.Show();
        }

        private void button3_Click(object sender, EventArgs e)
        {

            OpenBrowser("http://desktop-c5f2lhd:8080/ReportsBi/browse/Examination_Report2");

        }
    }
}
