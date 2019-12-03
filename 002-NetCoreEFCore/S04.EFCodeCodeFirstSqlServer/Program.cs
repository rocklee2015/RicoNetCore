using S04.EFCodeCodeFirstSqlServer.Model;
using System;
using System.Linq;

namespace S04.EFCodeCodeFirstSqlServer
{
    class Program
    {
        static void Main(string[] args)
        {
            AddUser();
        }
        static void AddUser()
        {
            using (var db = new RicoCodeFristDb())
            {
                var name = "efcore_codefirst_sqlserver_";
                for (int i = 0; i < 5; i++)
                {
                    var menu = new Menu();
                    menu.Name = name + i;
                    db.Menus.Add(menu);
                    db.SaveChanges();
                }
            }
        }
    }
}
