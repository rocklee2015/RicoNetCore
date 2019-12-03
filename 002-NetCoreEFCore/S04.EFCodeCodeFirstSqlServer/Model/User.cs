using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace S04.EFCodeCodeFirstSqlServer.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
