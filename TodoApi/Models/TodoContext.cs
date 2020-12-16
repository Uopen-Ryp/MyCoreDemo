using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TodoApi.Models
{/// <summary>
/// 
/// </summary>
    public class TodoContext : DbContext
    {/// <summary>
    /// 
    /// </summary>
    /// <param name="options"></param>
        public TodoContext(DbContextOptions options) : base(options)
        {
        }
        /// <summary>
        /// 
        /// </summary>
        public virtual DbSet<TodoItem> TodoItems { get; set; }
        /// <summary>
        /// 
        /// </summary>
        /// <param name="modelBuilder"></param>
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
        }
    }
}
