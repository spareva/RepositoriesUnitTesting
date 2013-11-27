﻿using StudentsDatabase.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SchoolDatabase.DataLayer
{
    public class StudentsDatabaseContext : DbContext
    {
        public StudentsDatabaseContext()
            : base("SchoolDatabase")
        {
            Database.SetInitializer(new MigrateDatabaseToLatestVersion<StudentsDatabaseContext, SchoolDatabase.DataLayer.Migrations.Configuration>());
        }

        public DbSet<Grade> Grades { get; set; }
        public DbSet<School> Schools { get; set; }
        public DbSet<Student> Students { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }

}