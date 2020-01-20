using Compendia.Database.Base;
using Compendia.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Database
{
    public class LogInRepository : TableRepository<DbLogIn>
    {

        public LogInRepository(DatabaseContext context) : base(context)
        {

        }


    }
}
