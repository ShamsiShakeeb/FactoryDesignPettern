﻿using Entity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace DAL
{
    public class DatabaseContext : IdentityDbContext<ApplicationUser>
    {
        public DatabaseContext(DbContextOptions<DatabaseContext> options) : base(options)
        {
        }
        public DbSet<Student> Student { set; get; }
        public DbSet<Teacher> Teacher { set; get; }
        public DbSet<StudentTeacher> Student_Teacher { set; get; }
    }
}
