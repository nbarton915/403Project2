﻿using Project2.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace Project2.DAL
{
    public class Project2Context : DbContext
    {
        public Project2Context() : base("Project2Context")
        {

        }

        public DbSet<Missions> Mission { get; set; }
        public DbSet<Users> User { get; set; }
        public DbSet<missionQuestions> MissionQuestion { get; set; }
    }
}