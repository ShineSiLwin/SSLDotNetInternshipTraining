using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SSLDotNetInternshipTraining.EFCore.Model
{
    public class EFCoreModel
    {
        private readonly AppDbContext _context;

        public EFCoreModel()
        {
            _context = new AppDbContext();
        }

        public void Read()
        {
            List<Student> students = _context.Students.Where(s => s.IsDelete == false).ToList();
            foreach (Student student in students)
            {
                Console.WriteLine($"Student Name: {student.StudentName} Student No: {student.StudentNo}");
            }
        }

        public void Edit()
        {
            Student student = _context.Students.Where(s => s.StudentId == 1).FirstOrDefault();
            if (student is null)
            {
                Console.WriteLine("Student not found");

            }
            Console.WriteLine($"Edit Student Name: {student.StudentName} Edit Student No: {student.StudentNo}");
        }

        public void Create()
        {
            Student student = new Student()
            {
                StudentNo = "S0113",
                StudentName = "Shine Si Lwin",
                FatherName = "John Doe",
                Address = "123 Main St",
                DateOfBirth = DateTime.Now,
                IsDelete = false,
                CreatedDateTime = DateTime.Now,
                CreatedBy = 1
            };
            _context.Students.Add(student);
            int result = _context.SaveChanges();
            string message = result > 0 ? "Create successful" : "Create failed";
            Console.WriteLine(message);
        }

        public void Update()
        {
            Student student = _context.Students.Where(s => s.StudentId == 1).FirstOrDefault();
            if (student is null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            student.StudentNo = "S001";
            student.StudentName = "Kyaw Gyi";
            student.FatherName = "Jane Doe";
            student.Address = "123 Main St";
            student.DateOfBirth = DateTime.Now;
            student.ModifiedDateTime = DateTime.Now;
            student.ModifiedBy = 1;
            int result = _context.SaveChanges();
            string message = result > 0 ? "Update successful" : "Update failed";
            Console.WriteLine(message);
        }

        public void Delete()
        {
            Student student = _context.Students.Where(s => s.StudentId == 1).FirstOrDefault();
            if (student is null)
            {
                Console.WriteLine("Student not found");
                return;
            }
            student.IsDelete = true;
            student.ModifiedDateTime = DateTime.Now;
            student.ModifiedBy = 1;
            int result = _context.SaveChanges();
            string message = result > 0 ? "Delete successful" : "Delete failed";
            Console.WriteLine(message);
        }

    }
}
