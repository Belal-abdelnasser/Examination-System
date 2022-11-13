using System;
using System.Collections.Generic;
using System.Text;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
namespace ExaminationSystem.DAL
{
    class DBLayer
    {
        public int Stored_ProcedureLogin(string LoginType, string email,string pw)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(LoginType, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@Email", SqlDbType.VarChar).Value = email.ToString();
            cmd.Parameters.Add("@PW", SqlDbType.VarChar).Value = pw.ToString();
            int outp = (int)cmd.ExecuteScalar();
            conn.Close();
            return outp;
        }

       
        public DataTable Stored_ProcedureAddQuestion(string Sp, int QId, string correctAns, string Type, string questionBody, int crsId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = QId;
            cmd.Parameters.Add("@grade", SqlDbType.Int).Value = 5;
            cmd.Parameters.Add("@answer", SqlDbType.VarChar).Value = correctAns;
            cmd.Parameters.Add("@type", SqlDbType.VarChar).Value = Type;
            cmd.Parameters.Add("@body", SqlDbType.VarChar).Value = questionBody;
            cmd.Parameters.Add("@Crs_Id", SqlDbType.Int).Value = crsId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_ProcedureInsertChoices(string Sp, string choice, int QId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@choice", SqlDbType.VarChar).Value = choice;
            cmd.Parameters.Add("@id", SqlDbType.Int).Value = QId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_ProcedureInsertExamList(string Sp, int examDuration, int CrsId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@examDuration", SqlDbType.Int).Value = examDuration;
            cmd.Parameters.Add("@CrsID", SqlDbType.Int).Value = CrsId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public DataTable Stored_ExamGen(string Sp, int stID, int CrsId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = stID;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = CrsId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public DataTable Stored_QuestionsList(string Sp, int stID, int CrsId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = stID;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = CrsId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_ProcedureSelectView(string Sp,string Id)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@InsID", SqlDbType.Int).Value = Id.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_ProcedureStdCrs(string Sp, string Id)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@StID", SqlDbType.Int).Value = Id.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_ProcedureStdgrades(string Sp, string Id)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@ST_id", SqlDbType.Int).Value = Id.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_ProcedureQuestionChoices(string Sp, int Id)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QID", SqlDbType.Int).Value = Id.ToString();
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_AnswerQuestion(string Sp, int QID, int stID, int CrsId, string Ans)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@QID", SqlDbType.Int).Value = QID;
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = stID;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = CrsId;
            cmd.Parameters.Add("@Ans", SqlDbType.VarChar).Value = Ans;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public DataTable Stored_AnswerCorrection(string Sp,int stID, int CrsId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = stID;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = CrsId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable Stored_StCrsGrade(string Sp, int stID, int CrsId)
        {
            SqlConnection conn = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            conn.Open();
            SqlCommand cmd = new SqlCommand(Sp, conn);
            cmd.Connection = conn;
            cmd.CommandType = CommandType.StoredProcedure;
            cmd.Parameters.Add("@SID", SqlDbType.Int).Value = stID;
            cmd.Parameters.Add("@CID", SqlDbType.Int).Value = CrsId;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }

        public DataTable select(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            cmd.Connection = con;
            DataTable dt = new DataTable();
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            adapter.Fill(dt);
            return dt;
        }
        public static int dml(SqlCommand cmd)
        {
            SqlConnection con = new SqlConnection("Data Source=.;Initial Catalog=ExaminationsDB;Integrated Security=True");
            cmd.Connection = con;
            con.Open();
            int roweffect = cmd.ExecuteNonQuery();
            con.Close();
            return roweffect;
        }
    }
}
