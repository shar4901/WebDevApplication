using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Assignment_4_Movies.Models
{
    public class StudentFormContext : DbContext
    {
        public virtual DbSet<StudentModel> student { get; set; }
        //Constructor
        public StudentFormContext(DbContextOptions<StudentFormContext> options) : base(options)
        {
            //leave blank
        }

        //public DbSet<StudentModel> StudentModel { get; set; }

        protected override void OnModelCreating(ModelBuilder mb)
        {
            //put in sample data here
            mb.Entity<StudentModel>().HasData(
            new StudentModel
            {
                student_id = 1,
                first_name = "Spencer",
                last_name = "Harrison",
                street_address = "1466 11150 S",
                city = "South Jordan",
                state = "UT",
                zip = 84095,
                phone_number = "801-915-7986",
                email = "test@test.com",
                category = "full-time"
            });
        }


    }
}
