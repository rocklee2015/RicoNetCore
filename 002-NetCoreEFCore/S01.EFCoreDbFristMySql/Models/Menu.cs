using System;
using System.Collections.Generic;

namespace S01.EFCoreDbFristMySql.Models
{
    public partial class Menu
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Url { get; set; }
        public string Icon { get; set; }
        public int? Parent { get; set; }
        public DateTime CreateOn { get; set; }
        public int CreateBy { get; set; }
        public DateTime ModifyOn { get; set; }
        public int ModifyBy { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsA { get; set; }
        public int Status { get; set; }
    }
}
