using EnozomFinal.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EnozomFinal.Persistence.Data
{
    internal static class DataSeeder
    {
        public static void Seed(this ModelBuilder modelBuilder)
        {
            List<Student> students = new List<Student>()
            {
                new Student{ Id= 1, StNumber ="1", Name = "Ali",Email = "Ali@Enozom.com", PhoneNumber = "0122224400" },
                new Student{ Id= 2, StNumber ="2", Name = "Mohamed",Email = "Mohamed@Enozom.com", PhoneNumber = "0111155000" },
                new Student{ Id= 3, StNumber ="3", Name = "Ahmed",Email = "Ahmed@Enozom.com", PhoneNumber = "0155553311" },
            };
            List<CopyStatus> copyStatuses = new List<CopyStatus>
            {
                new CopyStatus{Id = 1 , Name = "Good"},
                new CopyStatus{Id = 2 , Name = "Damaged"},
                new CopyStatus{Id = 3 , Name = "Lost"},
                new CopyStatus{Id = 4 , Name = "Borrowed"},
            };
            List<Book> books = new List<Book>
            {
                new Book{ Id = 1, Name = "Clean Code"},
                new Book{ Id = 2, Name = "Algorithms"}
            };
            List<Copy> copies = new List<Copy>()
            {
                new Copy{ Id = 1, BookId = 1 },
                new Copy{ Id = 2, BookId = 2 },
                new Copy{ Id = 3, BookId = 1 }
            };

            modelBuilder.Entity<Student>().HasData(students);
            modelBuilder.Entity<CopyStatus>().HasData(copyStatuses);
            modelBuilder.Entity<Book>().HasData(books);
            modelBuilder.Entity<Copy>().HasData(copies);
        }
    }
}
