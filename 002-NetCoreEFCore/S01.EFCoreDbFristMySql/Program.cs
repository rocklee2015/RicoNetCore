using S01.EFCoreDbFristMySql.Models;
using System;
using System.Linq;

namespace S01.EFCoreDbFristMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            //using (var db = new RicoDbFirstMysqlDb())
            //{
            //    var name = "ricolee_dbfirst_mysql";
            //    if (db.Menu.Count(a => a.Name == "ricolee_dbfirst_mysql" && !a.IsDeleted.Value) <= 0)
            //    {
            //        var menu = new Menu();
            //        menu.Name = name;
            //        menu.Url = "http://www.baidu.com";
            //        menu.Icon = "hehe";
            //        menu.CreateBy = 119;
            //        menu.CreateOn = DateTime.Now;
            //        db.Menu.Add(menu);
            //        db.SaveChanges();

            //        Console.WriteLine(name+" 添加成功！");
            //    }
            //    else
            //    {
            //        var menu = db.Menu.Single(a => a.Name == name && !a.IsDeleted.Value);
            //        if (menu != null)
            //        {
            //            menu.Icon = "default-btn";
            //            menu.ModifyBy = 110;
            //            menu.ModifyOn = DateTime.Now;
            //            db.Menu.Update(menu);
            //            db.SaveChanges();
            //        }

            //    }

            //}
        }
    }
}
