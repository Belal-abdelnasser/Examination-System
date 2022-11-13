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
    public partial class AddQuestionsForm : Form
    {
        public static string questionBody;
        public static string questionCorrectAnswer;
        public static string questionChoice2;
        public static string questionChoice3;
        public static string questionChoice4;
        public static int crsId;
        public static int lastQID;

        DBLayer dbl = new DBLayer();
        public AddQuestionsForm()
        {
            InitializeComponent();
        }

        private void label4_Click(object sender, EventArgs e)
        {

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

        private void AddQuestionsForm_Load(object sender, EventArgs e)
        {
            label1.Text = $"Add Question for: {InstViewAndGenExamForm.Crs_Name}";
        }

        private void label1_Click(object sender, EventArgs e)
        {
       
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (QuestionText.Text.Trim() != "" & CorrectChoice.Text.Trim() != "" & Choice2.Text.Trim() != "" & Choice3.Text.Trim() != "" & Choice4.Text.Trim() != "")
            {
                questionBody = QuestionText.Text.Trim();
                questionCorrectAnswer = CorrectChoice.Text.Trim();
                questionChoice2 = Choice2.Text.Trim();
                questionChoice3 = Choice3.Text.Trim();
                questionChoice4 = Choice4.Text.Trim();
                var temp = dbl.select(new SqlCommand("SELECT Q_Id from dbo.Questions WHERE Q_Id=(select max(Q_Id) from dbo.Questions)"));
                lastQID = (int)(temp.Rows[0].ItemArray[0]) + 1;
                crsId = Convert.ToInt32(InstViewAndGenExamForm.Crs_Id);
                dbl.Stored_ProcedureAddQuestion("insertDataQuestion", lastQID, questionCorrectAnswer, "MCQ", questionBody, crsId);
                dbl.Stored_ProcedureInsertChoices("insertChoices", questionCorrectAnswer, lastQID);
                dbl.Stored_ProcedureInsertChoices("insertChoices", questionChoice2, lastQID);
                dbl.Stored_ProcedureInsertChoices("insertChoices", questionChoice3, lastQID);
                dbl.Stored_ProcedureInsertChoices("insertChoices", questionChoice4, lastQID);

                DialogResult dr = MessageBox.Show("Question Added Successfully. Do you Want To Add Another Question ?", "Success", MessageBoxButtons.YesNo);
                switch (dr)
                {
                    case DialogResult.Yes:
                        QuestionText.Clear();
                        CorrectChoice.Clear();
                        Choice2.Clear();
                        Choice3.Clear();
                        Choice4.Clear();
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


            //MessageBox.Show(questionBody+" "+questionCorrectAnswer+" "+questionChoice2 +" "+questionChoice3+" "+questionChoice4+" "+ lastQID.ToString()+" "+crsId.GetType());

        }

        private void button3_Click(object sender, EventArgs e)
        {
            ChooseQuestionType qType = new ChooseQuestionType();
            this.Hide();
            qType.Show();
        }
    }
}
