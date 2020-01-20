using System;
using System.Collections.Generic;
using System.Text;
using Compendia.Model.Base;

namespace Compendia.Model
{
    public class DbLogIn : TableModel
    {
        public string name { get; set; }
        public string password { get; set; }

        public DbLogIn()
        {

        }
        public DbLogIn(string name_, string password_)
        {
            name = name_;
            password = password_;

        }

    }

  
}
