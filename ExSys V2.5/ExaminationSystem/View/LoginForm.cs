using ExaminationSystem.DAL;
using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class LoginForm : Form
    {
        public static string InstId;
        public static string StudentId;
        DBLayer dbl = new DBLayer();

        public LoginForm()
        {
            InitializeComponent();
        }

        private void LoginForm_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (user_typebox.SelectedItem == null)
            {
                MessageBox.Show("Please Select Login User", "Missing Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
            else if (user_typebox.SelectedItem.ToString() == "Student")
            {
                if (dbl.Stored_ProcedureLogin("StudentLogin", txt_id.Text.ToString(), txt_password.Text.ToString()) == 1)
                {
                    StdCrsExamForm stCrExmForm = new StdCrsExamForm();
                    var temp = dbl.select(new SqlCommand($"SELECT St_Id FROM dbo.Student WHERE Email = '{txt_id.Text.ToString()}'"));
                    StudentId = temp.Rows[0].ItemArray[0].ToString();
                    stCrExmForm.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong ID or Password");
                }
            }
            else if (user_typebox.SelectedItem.ToString() == "Instructor")
            {
                if (dbl.Stored_ProcedureLogin("InstructorLogin", txt_id.Text.ToString(), txt_password.Text.ToString()) == 1)
                {
                    InstViewAndGenExamForm InstView= new InstViewAndGenExamForm();
                    var temp = dbl.select(new SqlCommand($"SELECT Ins_Id FROM dbo.Instructor WHERE Email = '{txt_id.Text.ToString()}'"));
                    InstId = temp.Rows[0].ItemArray[0].ToString();
                    InstView.Show();
                    this.Hide();
                }
                else
                {
                    MessageBox.Show("Wrong ID or Password");
                }
            }
        }
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }

        private void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }

        private void label3_Click(object sender, EventArgs e)
        {

        }

        private void panel1_Paint(object sender, PaintEventArgs e)
        {

        }

        private void user_typebox_SelectedIndexChanged(object sender, EventArgs e)
        {

        }
    }
}
