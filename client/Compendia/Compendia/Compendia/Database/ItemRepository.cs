using Compendia.Database.Base;
using Compendia.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Database
{
    public class ItemRepository : TableRepository<DbItem>
    {
        public ItemRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
