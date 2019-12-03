using MySql.Data.MySqlClient;
using S03.EFCoreCodeFirstMySql.Model;
using System;
using System.Linq;

namespace S03.EFCoreCodeFirstMySql
{
    class Program
    {
        static void Main(string[] args)
        {
            //Add();

            MySqlConnectUsed();

            Console.ReadKey();
        }
        //public void dd2()
        //{
        //    using (var connection = new MySqlConnection("..."))
        //    using (var command = new MySqlCommand("SELECT id FROM ...", connection))
        //    using (var reader = command.ExecuteReader())
        //    {
        //        while (reader.Read())
        //        {
        //            var idToUpdate = reader.GetValue(0);
        //            connection.Execute("UPDATE ... SET ..."); // don't do this
        //        }
        //    }
        //}
        static void MySqlConnectUsed()
        {
            using (var db = new RicoCodeFristDb())
            {
                //var menu = db.Set<Menu>().FirstOrDefault(a => a.Id == 1);
                //menu.Name = "Name";
                var menus = db.Menus.Select(a => a.Name);
                var random = new Random();
                foreach (var item in menus)
                {
                    var user = new User();
                    user.UserName = "ricolee_" + item + "_" + random.Next(1, 100);
                    db.Users.Add(user);
                    //db.SaveChanges();
                }
                db.SaveChanges();
            }
        }
        static void Add()
        {
            using (var db = new RicoCodeFristDb())
            {
                var name = "ricolee_codefirst_mysql3";
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

                    Console.WriteLine(" 菜单添加成功！");
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
        }


    }
}
