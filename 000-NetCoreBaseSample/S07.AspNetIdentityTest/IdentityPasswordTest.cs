using Microsoft.AspNetCore.Identity;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Security.Principal;

namespace S07.AspNetIdentityTest
{
    [TestClass]
    public class IdentityPassword
    {
        [TestMethod]
        public void PasswordVerify()
        {
            var password = "Z8o*-/X9RWkg";
            password = password.MD5().ToLower();
            var hashPassword = Crypto.HashPassword(password);
            var desHasPassoword = "AQAAAAEAACcQAAAAEGNLzkjU1tjMzkgmH5t8N3wIWrMO06aIS7Rp0z8MkloZ5LbC6qi369p4esJg0w7Z4w==";
            //var desHasPassoword = "EGNLzkjU1tjMzkgmH5t8N3wIWrMO06aIS7Rp0z8MkloZ5LbC6qi369p4esJg0w7Z4w==";
            var result = Crypto.VerifyHashedPassword(desHasPassoword, password);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void PasswordVerify_2()
        {
            var password = "Z8o*-/X9RWkg";
            password = password.MD5().ToLower();
            var hashPassword = Crypto.HashPassword(password);
            //var desHasPassoword = "AQAAAAEAACcQAAAAEGNLzkjU1tjMzkgmH5t8N3wIWrMO06aIS7Rp0z8MkloZ5LbC6qi369p4esJg0w7Z4w==";
            var desHasPassoword = "EGNLzkjU1tjMzkgmH5t8N3wIWrMO06aIS7Rp0z8MkloZ5LbC6qi369p4esJg0w7Z4w==";
            var result = Crypto.VerifyHashedPassword(desHasPassoword, password);
            Assert.IsTrue(result);
        }

        [TestMethod]
        public void PasswordVerify_3()
        {
            var password = "*Ricolee_1";
            password = password.MD5().ToLower();
            var hashPassword = Crypto.HashPassword(password);
            var desHasPassoword = "ALTX6z0xVke5UubycuShg5GO6AmVWZc3c0620aUggqWRUKgypphvq27J3MqUR80bLg==";
            var result = Crypto.VerifyHashedPassword(desHasPassoword, password);
            Assert.IsTrue(result);
        }
        [TestMethod]
        public void PasswordVerify_5()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();

            var ph = new PasswordHasher<WindowsIdentity>();

            Console.WriteLine(ph.HashPassword(wi, "test"));

            Console.WriteLine(ph.VerifyHashedPassword(wi, "AQAAAAEAACcQAAAAEA5S5X7dmbx/NzTk6ixCX+bi8zbKqBUjBhID3Dg1teh+TRZMkAy3CZC5yIfbLqwk2A==", "test"));
        }
        [TestMethod]
        public void PasswordVerify_6()
        {
            WindowsIdentity wi = WindowsIdentity.GetCurrent();

            var ph = new PasswordHasher<WindowsIdentity>();
           
            Console.WriteLine(ph.HashPassword(wi, "Z8o*-/X9RWkg"));

            Console.WriteLine(ph.VerifyHashedPassword(wi, "AQAAAAEAACcQAAAAEGNLzkjU1tjMzkgmH5t8N3wIWrMO06aIS7Rp0z8MkloZ5LbC6qi369p4esJg0w7Z4w==", "Z8o*-/X9RWkg"));
        }
        [TestMethod]
        public void PasswordVerify_6_1()
        {
            var user = new User();

            var ph = new PasswordHasher<User>();

            Console.WriteLine(ph.HashPassword(user, "Z8o*-/X9RWkg"));

            Console.WriteLine(ph.VerifyHashedPassword(user, "AQAAAAEAACcQAAAAEGNLzkjU1tjMzkgmH5t8N3wIWrMO06aIS7Rp0z8MkloZ5LbC6qi369p4esJg0w7Z4w==", "Z8o*-/X9RWkg"));
        }

        [TestMethod]
        public void PasswordVerify_7()
        {
            var password = "*Ricolee_1";
            var user = new User();
            var ph = new PasswordHasher<User>();

            Console.WriteLine(ph.HashPassword(user, "*Ricolee_1"));
            
            Console.WriteLine(ph.VerifyHashedPassword(user, "AQAAAAEAACcQAAAAEELvm+/dWOfPkCopZkE3lBXl7w5Pp++M+2IJ+e4fQKGtMY8L83+MOFo1Z4iYOVRIfg==", password));
        }
        [TestMethod]
        public void PasswordVerify_4()
        {
            var password = "*Ricolee_1";
            //password = password.MD5().ToLower();
            var hashPassword = Crypto.HashPassword(password);
            Console.WriteLine(hashPassword);
        }
    }
    public class User
    {
        
    }
}
