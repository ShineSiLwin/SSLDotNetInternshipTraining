using Dapper;
using Microsoft.Data.SqlClient;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLDotNetInternshipTraining.Dapper
{
    public class DapperSample
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
            using(IDbConnection  connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
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
  FROM [SSLDotNetInternshipTraining].[dbo].[Tbl_Student]";
                List<Student> students = connection.Query<Student>(query).ToList();
                foreach (Student student in students)
                {
                    Console.WriteLine($"Student Name: {student.StudentName} Student No: {student.StudentNo}" );
                   
                }
            }
        }

        public void Edit()
        {
            using (IDbConnection connection = new SqlConnection(builder.ConnectionString))
            {
               
                connection.Open();
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
                Student student = connection.Query<Student>(query,  new Student { StudentId = 11 }).FirstOrDefault();

                string message = student != null ? $"Student Name: {student.StudentName}" : "Student not found.";
                Console.WriteLine(message);
            }

        }

        public void Create()
        {
            using (IDbConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Student stu = new Student()
                {
                    StudentNo = "STU-007",
                    StudentName = "Naing Lin Aung",
                    FatherName = "U Aung Kyaw",
                    Address = "Yangon",
                    DateOfBirth = new DateTime(1995, 5, 20),
                    IsDelete = false,
                    CreatedDateTime = DateTime.Now,
                    CreatedBy = 1

                };

                String query = @"INSERT INTO [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] ([StudentNo], [StudentName], [FatherName], [Address], [DateOfBirth], [IsDelete], [CreatedDateTime], [CreatedBy]) VALUES (@StudentNo, @StudentName, @FatherName, @Address, @DateOfBirth, @IsDelete, @CreatedDateTime, @CreatedBy)";
                int result = connection.Execute(query, stu);
                String message = result > 0 ? "Student created successfully." : "Failed to create student.";
                Console.WriteLine(message);
            }
        }


        public void Update()
        {
            using (IDbConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Student stu = new Student()
                {
                    StudentId = 11,
                    StudentNo = "STU -008",
                    StudentName = "Naing Lin",
                    FatherName = "U Aung Kyaw",
                    Address = "Yangon",
                    DateOfBirth = new DateTime(1995, 5, 20),
                    IsDelete = false,
                    CreatedDateTime = DateTime.Now,
                    CreatedBy = 1
                };
                String query = @"UPDATE [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] SET [StudentNo] = @StudentNo, [StudentName] = @StudentName, [FatherName] = @FatherName, [Address] = @Address, [DateOfBirth] = @DateOfBirth, [IsDelete] = @IsDelete, [CreatedDateTime] = @CreatedDateTime, [CreatedBy] = @CreatedBy WHERE [StudentId] = @StudentId";
                int result = connection.Execute(query, stu);
                String message = result > 0 ? "Student updated successfully." : "Failed to update student.";
                Console.WriteLine(message);
            }
        }

        public void Delete()
        {
            using (IDbConnection connection = new SqlConnection(builder.ConnectionString))
            {
                connection.Open();
                Student stu = new Student()
                {
                    StudentId = 11,
                    IsDelete = true,
                    ModifiedDateTime = DateTime.Now,
                    ModifiedBy = 1
                };
                String query = @"UPDATE [SSLDotNetInternshipTraining].[dbo].[Tbl_Student] SET [IsDelete] = @IsDelete, [ModifiedDateTime] = @ModifiedDateTime, [ModifiedBy] = @ModifiedBy WHERE [StudentId] = @StudentId";
                int result = connection.Execute(query, stu);
                String message = result > 0 ? "Student deleted successfully." : "Failed to delete student.";
                Console.WriteLine(message);
            }
        }

    }
}
