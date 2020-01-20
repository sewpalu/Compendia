using System;
using System.Collections.Generic;
using System.Text;

namespace Compendia.Database.Base
{
    public abstract class BaseRepository
    {
        protected readonly DatabaseContext DatabaseContext;

        protected BaseRepository(DatabaseContext context)
        {
            this.DatabaseContext = context;
        }

    }
}
