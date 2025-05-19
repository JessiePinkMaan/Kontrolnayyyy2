using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WpfApp1.data;

namespace WpfApp1.Data
{
    public class cooke
    {
        public User users { get; set; }
        public void RememberUser(User user)
        {
            users = user;
            
        }


    }
}
