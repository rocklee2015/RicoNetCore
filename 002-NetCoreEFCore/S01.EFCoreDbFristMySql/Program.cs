using S01.EFCoreDbFristMySql.Models;
using System;
using System.Linq;

namespace S01.EFCoreDbFristMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var db = new RicoDbFirstMysqlDb())
            {
                var name = "ricolee_dbfirst_mysql" + DateTime.Now.TimeOfDay;

                MenuStatusEnum menuStatusEnum = MenuStatusEnum.Step1;
                var temp = db.Menu.Where(a => a.StatusEnum == menuStatusEnum).ToList();

                int menuStatusEnum2 =1;
                var temp2 = db.Menu.Where(a => a.Status == menuStatusEnum2).ToList();

                Console.WriteLine($"{temp.Count}");

                if (db.Menu.Count(a => a.Name == name && !a.IsDeleted) <= 0)
                {
                    var menu = new Menu();
                    menu.Name = name;
                    menu.Url = "http://www.baidu.com";
                    menu.Icon = "hehe";
                    menu.CreateBy = 119;
                    menu.CreateOn = DateTime.Now;
                    menu.StatusEnum = MenuStatusEnum.Step2;
                    db.Menu.Add(menu);
                    db.SaveChanges();

                    Console.WriteLine(name + " 添加成功！");
                }
            }
        }
    }
}
