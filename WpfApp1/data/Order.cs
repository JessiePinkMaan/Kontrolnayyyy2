using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace WpfApp1.data
{
    public class Order
    {
        public int Id { get; set; }
        public string art {  get; set; }
        public string description { get; set; }
        public string type { get; set; }
        public string status { get; set; }
        public User? user { get; set; }

    }
}
