﻿using Microsoft.EntityFrameworkCore;
using HelloMvcTemplate.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HelloMvcTemplate.Data {
    public class MvcMovieContext : DbContext {
        public MvcMovieContext(DbContextOptions<MvcMovieContext> options) : base(options) { }

        public DbSet<Movie> Movie { get; set; }
    }
}
