using S03.EFCoreCodeFirstMySql.Model;
using System;
using System.Linq;

namespace S03.EFCoreCodeFirstMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RicoCodeFristDb())
            {
                var name = "ricolee_codefirst_mysql";
                if (db.Menus.Count(a => a.Name == name && !a.IsDeleted.Value) <= 0)
                {
                    var menu = new Menu();
                    menu.Name = name;
                    menu.Url = "www.baidu.com";
                    menu.Icon = "hehe";
                    menu.CreateBy = 119;
                    menu.CreateOn = DateTime.Now;
                    menu.IsDeleted = false;
                    db.Menus.Add(menu);
                    db.SaveChanges();

                    Console.WriteLine(" 管理员添加成功！");
                }
                else
                {
                    var menu = db.Menus.Single(a => a.Name == name && !a.IsDeleted.Value);
                    if (menu != null)
                    {
                        menu.Icon = "default-btn";
                        menu.ModifyBy = 110;
                        menu.ModifyOn = DateTime.Now;
                        db.Menus.Update(menu);
                        db.SaveChanges();
                    }

                }

            }
            
         
            Console.ReadKey();
        }
    }
}
