using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLDotNetInternshipTraining.AdoDotNet
{
    public class AdoSample
    {
        private readonly SqlConnectionStringBuilder builder = new SqlConnectionStringBuilder()
        {
            DataSource = ".",
            InitialCatalog = "SSLDotNetInternshipTraining",
            UserID = "sa",
            Password = "sasa@123",
            TrustServerCertificate = true
        };

        public void Read()
        {
            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            String query = @"SELECT TOP (1000) [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [SSLDotNetInternshipTraining].[dbo].[Tbl_Student]Where [IsDelete] = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();
            foreach (DataRow dr in dt.Rows)
            {
                Student student = new Student()
                {
                    StudentId = Convert.ToInt32(dr["StudentId"]),
                    StudentNo = dr["StudentNo"].ToString(),
                    StudentName = dr["StudentName"].ToString(),
                    FatherName = dr["FatherName"].ToString(),
                    Address = dr["Address"].ToString(),
                    DateOfBirth = Convert.ToDateTime(dr["DateOfBirth"]),
                    IsDelete = Convert.ToBoolean(dr["IsDelete"]),
                    CreatedDateTime = Convert.ToDateTime(dr["CreatedDateTime"]),
                    CreatedBy = Convert.ToInt32(dr["CreatedBy"]),
                    ModifiedDateTime = dr["ModifiedDateTime"] == DBNull.Value ? null : Convert.ToDateTime(dr["ModifiedDateTime"]),
                    ModifiedBy = dr["ModifiedBy"] == DBNull.Value ? null : Convert.ToInt32(dr["ModifiedBy"])
                };

                Console.WriteLine($"{student.StudentNo} - {student.StudentName}");
            }

        }

        public void Edit()
        {
            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            int id = 2;
            String query = @"SELECT TOP (1000) [StudentId]
      ,[StudentNo]
      ,[StudentName]
      ,[FatherName]
      ,[Address]
      ,[DateOfBirth]
      ,[IsDelete]
      ,[CreatedDateTime]
      ,[CreatedBy]
      ,[ModifiedDateTime]
      ,[ModifiedBy]
  FROM [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] WHERE [StudentId] = @StudentId and [IsDelete] = 0";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentId", id);
            SqlDataAdapter adapter = new SqlDataAdapter(cmd);
            DataTable dt = new DataTable();
            adapter.Fill(dt);
            conn.Close();

            Student student = new Student()
            {
                StudentId = Convert.ToInt32(dt.Rows[0]["StudentId"]),
                StudentNo = dt.Rows[0]["StudentNo"].ToString(),
                StudentName = dt.Rows[0]["StudentName"].ToString(),
                FatherName = dt.Rows[0]["FatherName"].ToString(),
                Address = dt.Rows[0]["Address"].ToString(),
                DateOfBirth = Convert.ToDateTime(dt.Rows[0]["DateOfBirth"]),
                IsDelete = Convert.ToBoolean(dt.Rows[0]["IsDelete"]),
                CreatedDateTime = Convert.ToDateTime(dt.Rows[0]["CreatedDateTime"]),
                CreatedBy = Convert.ToInt32(dt.Rows[0]["CreatedBy"]),
                ModifiedDateTime = dt.Rows[0]["ModifiedDateTime"] == DBNull.Value ? null : Convert.ToDateTime(dt.Rows[0]["ModifiedDateTime"]),
                ModifiedBy = dt.Rows[0]["ModifiedBy"] == DBNull.Value ? null : Convert.ToInt32(dt.Rows[0]["ModifiedBy"])
            };

            Console.WriteLine(student.StudentName);
        }

        public void Update()
        {
            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            int id = 2;
            String query = @"UPDATE [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] SET [StudentNo] = @StudentNo, [StudentName] = @StudentName, [FatherName] = @FatherName, [Address] = @Address, [DateOfBirth] = @DateOfBirth, [ModifiedDateTime] = @ModifiedDateTime, [ModifiedBy] = @ModifiedBy WHERE [StudentId] = @StudentId";
            SqlCommand cmd = new SqlCommand(query, conn);
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@StudentNo", "S002");
            cmd.Parameters.AddWithValue("@StudentName", "John Doe");
            cmd.Parameters.AddWithValue("@FatherName", "Jane Doe");
            cmd.Parameters.AddWithValue("@Address", "123 Main St");
            cmd.Parameters.AddWithValue("@DateOfBirth", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", 1);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            String message = result > 0 ? "Update successful" : "Update failed";
            Console.WriteLine(message);

        }

        public void Create()
        {
            Student student = new Student()
            {
                StudentNo = "S003",
                StudentName = "Jane Doe",
                FatherName = "John Doe",
                Address = "456 Main St",
                DateOfBirth = DateTime.Now,
                IsDelete = false,
                CreatedDateTime = DateTime.Now,
                CreatedBy = 1
            };
            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            SqlCommand cmd = new SqlCommand("INSERT INTO [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] ([StudentNo], [StudentName], [FatherName], [Address], [DateOfBirth], [IsDelete], [CreatedDateTime], [CreatedBy]) VALUES (@StudentNo, @StudentName, @FatherName, @Address, @DateOfBirth, @IsDelete, @CreatedDateTime, @CreatedBy)", conn);
            cmd.Parameters.AddWithValue("@StudentNo", student.StudentNo);
            cmd.Parameters.AddWithValue("@StudentName", student.StudentName);
            cmd.Parameters.AddWithValue("@FatherName", student.FatherName);
            cmd.Parameters.AddWithValue("@Address", student.Address);
            cmd.Parameters.AddWithValue("@DateOfBirth", student.DateOfBirth);
            cmd.Parameters.AddWithValue("@IsDelete", student.IsDelete);
            cmd.Parameters.AddWithValue("@CreatedDateTime", student.CreatedDateTime);
            cmd.Parameters.AddWithValue("@CreatedBy", student.CreatedBy);
            int result = cmd.ExecuteNonQuery();
            String message = result > 0 ? "Insert successful" : "Insert failed";
            Console.WriteLine(message);
            conn.Close();
        }

        public void Delete()
        {
            SqlConnection conn = new SqlConnection(builder.ConnectionString);
            conn.Open();
            int id = 2;
            SqlCommand cmd = new SqlCommand("UPDATE [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] SET [IsDelete] = 1, [ModifiedDateTime] = @ModifiedDateTime, [ModifiedBy] = @ModifiedBy WHERE [StudentId] = @StudentId", conn);
            cmd.Parameters.AddWithValue("@StudentId", id);
            cmd.Parameters.AddWithValue("@ModifiedDateTime", DateTime.Now);
            cmd.Parameters.AddWithValue("@ModifiedBy", 1);
            int result = cmd.ExecuteNonQuery();
            conn.Close();
            String message = result > 0 ? "Delete successful" : "Delete failed";
            Console.WriteLine(message);
        }
    }
}
