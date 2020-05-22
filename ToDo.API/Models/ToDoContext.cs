using Microsoft.EntityFrameworkCore;
using MySQL.Data.EntityFrameworkCore.Extensions; 
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ToDo.API.Models
{
    public class ToDoContext : DbContext
    {
        public string ConnectionString { get; set; } // properties or attribute of this class that are defining the connection configuration into the database
        public IConfigurationRoot Configuration { get; set; } // this is to access the default connection string in the appsettings.json 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (Configuration.GetConnectionString("Default") == null || Configuration.GetConnectionString("Default") == "") { //just in case can not get the default settings set it with the correct one
                ConnectionString = "server=localhost;userid=root;password=0ptivA!23;database=todo;SslMode=None";
            } else { //if everything goes well set the connection string with the one in the appsettings.json
                ConnectionString = Configuration.GetConnectionString("Default");
            }
            optionsBuilder.UseMySQL(ConnectionString);
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder) //this is to map the models into the database
        {
            modelBuilder.Entity<ToDoItem>().ToTable("tbl_todo");
            modelBuilder.Entity<ToDoItem>(entity =>
            {
              entity.Property(e => e.id).HasColumnName("id");
              entity.Property(e => e.title).HasColumnName("title");
              entity.Property(e => e.description).HasColumnName("description");
              entity.Property(e => e.expiryDate).HasColumnName("expiry_date");
              entity.Property(e => e.percentCompleted).HasColumnName("percent_complete");
            });
            modelBuilder.Entity<ToDoItem>().HasKey(e => new { e.id });
        }

        public virtual DbSet<ToDoItem> TblToDo { get; set; } //to get and set the values in database
    }
}