using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace S03.EFCoreCodeFirstMySql.Model
{
    public class User
    {
        [Key]
        public int Id { get; set; }

        public string UserName { get; set; }
    }
}
