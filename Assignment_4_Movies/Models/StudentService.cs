//using Assignment_4_Movies.Models;
//using Microsoft.EntityFrameworkCore;
//using System;
//using System.Collections.Generic;
//using System.Linq;
//using System.Threading.Tasks;

//namespace WebDevApplication.Models
//{
//    public class StudentServices
//    {
//        private StudentFormContext dbContext;

//        public StudentServices(StudentFormContext dbContext)
//        {
//            this.dbContext = dbContext;
//        }


//        public async Task<List<StudentModel>> GetStudentAsync()
//        {
//            return await dbContext.StudentModel.ToListAsync();
//        }

//        public async Task<StudentModel> AddStudentAsync(StudentModel student)
//        {
//            try
//            {
//                dbContext.StudentModel.Add(student);
//                await dbContext.SaveChangesAsync();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            return student;
//        }
//        public async Task<StudentModel> UpdateStudentAsync(StudentModel student)
//        {
//            try
//            {
//                var productExist = dbContext.StudentModel.FirstOrDefault(p => p.student_id == student.student_id);
//                if (productExist != null)
//                {
//                    dbContext.Update(student);
//                    await dbContext.SaveChangesAsync();
//                }
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//            return student;
//        }
//        public async Task DeleteStudentAsync(StudentModel student)
//        {
//            try
//            {
//                dbContext.StudentModel.Remove(student);
//                await dbContext.SaveChangesAsync();
//            }
//            catch (Exception)
//            {
//                throw;
//            }
//        }
//    }
//}