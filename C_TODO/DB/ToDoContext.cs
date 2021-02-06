using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using C_TODO.Models;
using Microsoft.EntityFrameworkCore;

namespace C_TODO.DB
{
    public class ToDoContext : DbContext
    {
        public ToDoContext(DbContextOptions<ToDoContext> options)
            : base(options) 
        {

        }

        public DbSet<ToDoList> ToDoList { get; set; }
    }
}
