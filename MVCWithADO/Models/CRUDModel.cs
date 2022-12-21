using System;
using System.Data;
using System.Data.SqlClient;

namespace MVCWithADO.Models
{
    public class CRUDModel
    {
        public string strConString = @"Data Source=IN-23D7JL3;Initial Catalog=Student;User Id=sa; Password=sa";
        /// <summary>    
        /// Get all records from the DB    
        /// </summary>    
        /// <returns>Datatable</returns>    
        public DataTable GetAllStudents()
        {
            DataTable dt = new DataTable();

            using (SqlConnection SqlConnection = new SqlConnection(strConString))

            {
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from student", SqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                SqlConnection.Close();
            }
            return dt;
        }

        /// <summary>    
        /// Get student detail by Student id    
        /// </summary>    
        /// <param name="intStudentID"></param>    
        /// <returns></returns>    
        public DataTable GetStudentByID(int intStudentID)
        {
            DataTable dt = new DataTable();

            string strConString = @"Data Source=IN-23D7JL3;Initial Catalog=Student;User Id=sa; Password=sa;Integrated Security= true";

            using (SqlConnection SqlConnection = new SqlConnection(strConString))
            {
                SqlConnection.Open();
                SqlCommand cmd = new SqlCommand("Select * from student where student_id=" + intStudentID, SqlConnection);
                SqlDataAdapter da = new SqlDataAdapter(cmd);
                da.Fill(dt);
                SqlConnection.Close();
            }
            return dt;
        }

        internal int InsertStudent(string name, string gender)
        {
            throw new NotImplementedException();
        }

        /// <summary>    
        /// Update the student details    
        /// </summary>    
        /// <param name="intStudentID"></param>    
        /// <param name="strStudentName"></param>    
        /// <param name="strGender"></param>    
        /// <param name="intAge"></param>    
        /// <returns></returns>    
        public int UpdateStudent(int intStudentID, string strStudentName, string strGender, int intAge)
        {
            string strConString = @"Data Source=IN-23D7JL3;Initial Catalog=Student;User Id=sa; Password=sa;Integrated Security= true";

            using (SqlConnection SqlConnection = new SqlConnection(strConString))
            {
                SqlConnection.Open();
                string query = "Update student SET student_name=@studname, student_age=@studage , student_gender=@gender where student_id=@studid";
                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@gender", strGender);
                cmd.Parameters.AddWithValue("@studid", intStudentID);
                return cmd.ExecuteNonQuery();
                SqlConnection.Close();
            }
        }

        /// <summary>    
        /// Insert Student record into DB    
        /// </summary>    
        /// <param name="strStudentName"></param>    
        /// <param name="strGender"></param>    
        /// <param name="intAge"></param>    
        /// <returns></returns>    
        public int InsertStudent(string strStudentName, string strGender, int intAge)
        {
            string strConString = @"Data Source=IN-23D7JL3;Initial Catalog=Student;User Id=sa; Password=sa;Integrated Security= true";

            using (SqlConnection SqlConnection = new SqlConnection(strConString))
            {
                SqlConnection.Open();
                string query = "Insert into student (student_name, student_age,student_gender) values(@studname, @studage , @gender)";
                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                cmd.Parameters.AddWithValue("@studname", strStudentName);
                cmd.Parameters.AddWithValue("@studage", intAge);
                cmd.Parameters.AddWithValue("@gender", strGender);
                return cmd.ExecuteNonQuery();
                SqlConnection.Close();
            }
        }

        /// <summary>    
        /// Delete student based on ID    
        /// </summary>    
        /// <param name="intStudentID"></param>    
        /// <returns></returns>    
        public int DeleteStudent(int intStudentID)
        {
            string strConString = @"Data Source=IN-23D7JL3;Initial Catalog=Student;User Id=sa; Password=sa;Integrated Security= true";

            using (SqlConnection SqlConnection = new SqlConnection(strConString))
            {
                SqlConnection.Open();
                string query = "Delete from student where student_id=@studid";
                SqlCommand cmd = new SqlCommand(query, SqlConnection);
                cmd.Parameters.AddWithValue("@studid", intStudentID);
                return cmd.ExecuteNonQuery();
                SqlConnection.Close();
            }
        }
    }
}