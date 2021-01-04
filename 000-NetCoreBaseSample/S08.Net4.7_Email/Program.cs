﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mail;

namespace S08.Net4._7_Email
{
    class Program
    {
        [Obsolete]
        static void Main(string[] args)
        {
            string subject = "测试邮件";
            string body = "测试内容";
            string from = "system@cstpia.com";
            string to = "rocklee0420@163.com";
            string userName = "system@cstpia.com";
            string password = "741Tsc963";
            string smtpServer = "smtp.exmail.qq.com";
            string port = "465";
            bool ssl =true;

            MailMessage mmsg = new MailMessage();
            //邮件主题
            mmsg.Subject = subject;
            mmsg.BodyFormat = MailFormat.Html;
            //邮件正文
            mmsg.Body = body;
            //正文编码
            mmsg.BodyEncoding = Encoding.UTF8;
            //优先级
            mmsg.Priority = MailPriority.Normal;
            //发件者邮箱地址
            mmsg.From = from;
            //收件人收箱地址
            mmsg.To = to;

            mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpauthenticate", "1");
            //用户名
            mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendusername", userName);
            //密码
            mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/sendpassword", password);
            //端口 
            mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpserverport", port);
            //是否ssl
            mmsg.Fields.Add("http://schemas.microsoft.com/cdo/configuration/smtpusessl", ssl ? "true" : "false");
            //Smtp服务器
            System.Web.Mail.SmtpMail.SmtpServer = smtpServer;

            try
            {
                SmtpMail.Send(mmsg);
                Console.WriteLine("发送成功");
                Console.ReadLine();
            }
            catch (Exception ex)
            {
                Console.WriteLine("发送失败，失败原因：" + ex.Message);
            }
        }
    }
}
