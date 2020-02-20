using Compendia.Database.Base;
using Compendia.Model;
using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Database
{
    public class MaskRepository : TableRepository<DBMask>
    {
        public MaskRepository(DatabaseContext context) : base(context)
        {

        }
    }
}
