using ExaminationSystem.DAL;
using System;
using System.Collections.Generic;
using System.Data;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class StdQuestionsForm : Form
    {
        DataTable choices;
        ComboBox[] myComboBoxes;
        Label[] myQuestionsLabels;
        List<string> stAns = new List<string>();
        List<int> QId = new List<int>();
        DBLayer dbl = new DBLayer();
 
        public StdQuestionsForm()
        {
            InitializeComponent();
        }
       
        private void StdQuestionsForm_Load(object sender, EventArgs e)
        {
            
            var question = dbl.Stored_QuestionsList("getQuestionList", Convert.ToInt32(LoginForm.StudentId), Convert.ToInt32(StdCrsExamForm.CrsId));
            myComboBoxes = new ComboBox[] { QCombo0, QCombo1, QCombo2, QCombo3, QCombo4, QCombo5, QCombo6, QCombo7, QCombo8, QCombo9 };
            myQuestionsLabels = new Label[] { label11 , label12 , label13 , label14 , label15 , label16, label17, label18, label19, label20};
            for (int i = 0; i < 10; i++)
            {
                int id = Convert.ToInt32(question.Rows[i].ItemArray[0].ToString());
                myQuestionsLabels[i].Text = question.Rows[i].ItemArray[1].ToString().Trim();
                choices = dbl.Stored_ProcedureQuestionChoices("questionChoices", id);
                myComboBoxes[i].DataSource = choices;
                myComboBoxes[i].DisplayMember = "Choice";
                myComboBoxes[i].ValueMember = "Q_Id";
                
                
            }
        }

        private void label2_Click(object sender, EventArgs e)
        {
        }

        private void button1_Click(object sender, EventArgs e)
        {
            for (int i = 0; i < 10; i++)
            {
                stAns.Add(myComboBoxes[i].GetItemText(myComboBoxes[i].SelectedItem));
                QId.Add(Convert.ToInt32(myComboBoxes[i].GetItemText(myComboBoxes[i].SelectedValue)));
                dbl.Stored_AnswerQuestion("answerQuestion",QId[i], Convert.ToInt32(LoginForm.StudentId), Convert.ToInt32(StdCrsExamForm.CrsId), stAns[i]);
            }
            //Correction
            dbl.Stored_AnswerCorrection("AnswerCorrection", Convert.ToInt32(LoginForm.StudentId), Convert.ToInt32(StdCrsExamForm.CrsId));
            MessageBox.Show("Your Answers Has Been Submited!");
            //var stdGrade = dbl.Stored_StCrsGrade("getCrsGrade", Convert.ToInt32(LoginForm.StudentId), Convert.ToInt32(StdCrsExamForm.CrsId));
            //stdGrade.Rows[0].ItemArray[0].ToString();
            View.StdCrsGrade toGradeFrm = new View.StdCrsGrade();
            toGradeFrm.Show();
            this.Hide();

        }

        private void label11_Click(object sender, EventArgs e)
        {

        }
    }
}
