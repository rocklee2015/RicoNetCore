using System;

namespace S08.NetEmailConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            //NetEmailStandard.EmailHelper emailHelper = new NetEmailStandard.EmailHelper();
            //emailHelper.SendMail();

            var emailManager = new EmailManager();
            Console.WriteLine("发送邮件...");
           var task= emailManager.SendMailAsync(
                "system@cstpia.com",
                "rocklee0420@163.com",
                "system@cstpia.com",
                "741Tsc963",
                "smtp.exmail.qq.com",
                465,
                "测试标题",
                "测试内容");
            var result = task.Result;
            Console.WriteLine("发送邮件结束");
            Console.ReadLine();
           
        }
    }
}
