using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;

namespace ExaminationSystem
{
    public partial class ChooseQuestionType : Form
    {
        public ChooseQuestionType()
        {
            InitializeComponent();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            InstViewAndGenExamForm instView = new InstViewAndGenExamForm();
            this.Hide();
            instView.Show();
        }

        private void button2_Click(object sender, EventArgs e)
        {

            AddQuestionsForm qMCQ = new AddQuestionsForm();
            this.Hide();
            qMCQ.Show();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            AddTFQuestionForm addTF = new AddTFQuestionForm();
            this.Hide();
            addTF.Show();
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

        private void ChooseQuestionType_Load(object sender, EventArgs e)
        {
            label1.Text = $"Add Question for: {InstViewAndGenExamForm.Crs_Name}";
        }
    }
}
