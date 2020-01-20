using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace Compendia.Model.Base
{
    public class TableModel : BaseModel
    {
        [Key]
        public int Id { get; set; }

    }
}
