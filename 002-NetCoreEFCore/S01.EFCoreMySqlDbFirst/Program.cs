using S01.EFCoreMySqlDbFirst.Models;
using System;
using System.Linq;

namespace S01.EFCoreMySqlDbFirst
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RicoTestDbContext())
            {
                if (db.Menu.Count(a => a.Name == "管理员" && !a.IsDeleted.Value) <= 0)
                {
                    var menu = new Menu();
                    menu.Name = "管理员";
                    menu.Url = "www.baidu.com";
                    menu.Icon = "hehe";
                    menu.CreateBy = 119;
                    menu.CreateOn = DateTime.Now;
                    menu.IsDeleted = false;
                    db.Menu.Add(menu);
                    db.SaveChanges();

                    Console.WriteLine(" 管理员添加成功！");
                }
                else
                {
                    var menu = db.Menu.Single(a => a.Name == "管理员" && !a.IsDeleted.Value);
                    if (menu != null)
                    {
                        menu.Icon = "default-btn";
                        menu.ModifyBy = 110;
                        menu.ModifyOn = DateTime.Now;
                        menu.IsDeleted = true;
                        db.Menu.Update(menu);
                        db.SaveChanges();
                    }
                    
                }

            }
            Console.WriteLine("Hello World!");
        }
    }
}
