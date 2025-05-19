using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using Microsoft.EntityFrameworkCore;
using WpfApp1.data;

namespace WpfApp1.Data
{
    public class ApplicationContext : DbContext
    {
            
            public DbSet<User> users { get; set; }
            public DbSet<Order> orders { get; set; }

            public ApplicationContext()
            {
                if (Database.EnsureCreated() == true)
                {
                    users.AddRange(user);
                    orders.AddRange(order);
       
                    users.Load();
                    orders.Load();

                    this.SaveChanges();

               
                }
                else
                {
                    users.Load();
                    orders.Load();
                  
                    Debug.WriteLine("База данных уже существует");
                }

            }
            protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
            {
                optionsBuilder.UseSqlite("Data Source=lolbd1.bd");

            }
              
        
        
            List<User> user = new()
                {
                    new User
                    {
                        login = "123",
                        password = "123",
                        name = "mav",
                        phoneNumber = "8923949249"
                        
                    },
                     new User
                    {
                         login = "lox",
                         password = "lox",
                         name = "jac",
                         phoneNumber = "8923949249"


                    }
                };
            
         
            List<Order> order = new()
                    {
                        new Order
                        {
                           art = "k23232",
                           description = "balbablalbalblblbalablbalbal",
                           type = "car",
                           status = "в процессе",
                           user = new User{ 
                                login = "111",
                                password = "111",
                                name = "mav-jac",
                                phoneNumber = "8923949249"}
                        }

                    };
        }
    }

