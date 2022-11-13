using System;
using ExaminationSystem.DAL;
using System.Data.SqlClient;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationSystem
{
    
    public partial class AddTFQuestionForm : Form
    {
        public static string questionBody;
        public static string questionCorrectAnswer;
        public static string questionChoice1;
        public static string questionChoice2;
        public static int crsId;
        public static int lastQID;
        DBLayer dbl = new DBLayer();
        public AddTFQuestionForm()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QuestionText.Text.Trim() != "")
            {
                questionBody = QuestionText.Text.Trim();
                questionCorrectAnswer = comboBox1.Text;
                questionChoice1 ="True";
                questionChoice2 = "False";
                var temp = dbl.select(new SqlCommand("SELECT Q_Id from dbo.Questions WHERE Q_Id=(select max(Q_Id) from dbo.Questions)"));
                lastQID = (int)(temp.Rows[0].ItemArray[0]) + 1;
                crsId = Convert.ToInt32(InstViewAndGenExamForm.Crs_Id);
                dbl.Stored_ProcedureAddQuestion("insertDataQuestion", lastQID, questionCorrectAnswer, "T/F", questionBody, crsId);
                dbl.Stored_ProcedureInsertChoices("insertChoices", questionChoice1, lastQID);
                dbl.Stored_ProcedureInsertChoices("insertChoices", questionChoice2, lastQID);
                DialogResult dr = MessageBox.Show("Question Added Successfully. Do you Want To Add Another Question ?", "Success", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        QuestionText.Clear();
                        break;
                    case DialogResult.No:
                        InstViewAndGenExamForm instView = new InstViewAndGenExamForm();
                        this.Hide();
                        instView.Show();
                        break;
                }
            }
            else
            {
                MessageBox.Show("Please Enter the Question And the Choices First!");
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();
            this.Hide();
            loginfrm.Show();
        }

        private void pictureBox2_Click(object sender, EventArgs e)
        {
            LoginForm loginfrm = new LoginForm();
            this.Hide();
            loginfrm.Show();
        }

        private void AddTFQuestionForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Add Question for: {InstViewAndGenExamForm.Crs_Name}";
        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseQuestionType qType = new ChooseQuestionType();
            this.Hide();
            qType.Show();
        }
    }
}
