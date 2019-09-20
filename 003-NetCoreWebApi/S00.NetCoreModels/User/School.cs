using System;
using System.Collections.Generic;
using System.Text;

namespace S00.NetCoreModels.User
{
    public class School
    {
        public string SchoolName { get; set; }

        public List<SchoolClass> Classes { get; set; }
    }
    public class SchoolClass
    {
        public string ClassName { get; set; }

        public int Num { get; set; }
    }
}
