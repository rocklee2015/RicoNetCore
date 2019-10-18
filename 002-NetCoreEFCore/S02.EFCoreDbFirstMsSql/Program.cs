using S02.EFCoreDbFirstMsSql.Models;
using S02.EFCoreDbFirstSqlServer.Models;
using System;
using System.Linq;

namespace S02.EFCoreDbFirstMsSql
{
    class Program
    {
        static void Main(string[] args)
        {

            using (var db = new RicoSqlServerDbContext())
            {
                var name = "ricolee_dbfirst_sqlserver";
                if (db.Menu.Count(a => a.Name == name && !a.IsDeleted.Value) <= 0)
                {
                    var menu = new Menu();
                    menu.Name = name;
                    menu.Url = "www.baidu.com";
                    menu.Icon = "hehe";
                    menu.CreateOn = DateTime.Now;
                    menu.IsDeleted = true;
                    db.Menu.Add(menu);
                    db.SaveChanges();

                    Console.WriteLine(" 添加成功！");
                }
                else
                {
                    var menu = db.Menu.Single(a => a.Name == name && !a.IsDeleted.Value);
                    if (menu != null)
                    {
                        menu.Icon = "default-btn";
                        //menu.ModifyBy = 110;
                        menu.ModifyOn = DateTime.Now;
                        db.Menu.Update(menu);
                        db.SaveChanges();
                        Console.WriteLine(" 修改成功！");
                    }
                }

            }
            Console.WriteLine("Hello World!");
        }
    }
}
