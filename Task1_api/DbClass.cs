using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Task1_api
{
    public class DbClass:DbContext
    {
       
        public DbClass(DbContextOptions<DbClass> options) : base(options)
        {

        }
        
        public DbSet<Todo_list> todo { get; set; }

        public DbSet<tasks_list> tasks { get; set; }

    }
}
