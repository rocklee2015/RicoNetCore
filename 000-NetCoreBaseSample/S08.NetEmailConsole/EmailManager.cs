using System;
using System.Collections.Generic;
using System.Text;

namespace S08.NetEmailConsole
{
    public class EmailManager
    {
        /// <summary>
        /// 发送邮件
        /// </summary>
        /// <param name="Name">发件人名字</param>
        /// <param name="receive">接收邮箱</param>
        /// <param name="sender">发送邮箱</param>
        /// <param name="password">邮箱密码</param>
        /// <param name="host">邮箱主机</param>
        /// <param name="port">邮箱端口</param>
        /// <param name="subject">邮件主题</param>
        /// <param name="body">邮件内容</param>
        /// <returns></returns>
        public async System.Threading.Tasks.Task<bool> SendMailAsync(string Name, string receive, string sender, string password, string host, int port, string subject, string body)
        {
            try
            {
　　　　　　　　　// MimeMessage代表一封电子邮件的对象
                var message = new MimeKit.MimeMessage();
　　　　　　　　　// 添加发件人地址 Name 发件人名字 sender 发件人邮箱
                message.From.Add(new MimeKit.MailboxAddress(Name, sender));
　　　　　　　　　// 添加收件人地址
                message.To.Add(new MimeKit.MailboxAddress("", receive));
　　　　　　　　　 // 设置邮件主题信息
                message.Subject = subject;
　　　　　　　　　 // 设置邮件内容
                var bodyBuilder = new MimeKit.BodyBuilder() { HtmlBody = body };
                message.Body = bodyBuilder.ToMessageBody();
                using (var client = new MailKit.Net.Smtp.SmtpClient())
                {
                    // For demo-purposes, accept all SSL certificates (in case the server supports STARTTLS)
                    client.ServerCertificateValidationCallback = (s, c, h, e) => true;
                    // Note: since we don't have an OAuth2 token, disable  
                    // the XOAUTH2 authentication mechanism.  
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.CheckCertificateRevocation = false;
                    //client.SslProtocols = System.Security.Authentication.SslProtocols.Tls12;
                    client.Connect(host, port, MailKit.Security.SecureSocketOptions.Auto);
                    // Note: only needed if the SMTP server requires authentication
                    client.Authenticate(sender, password);
                    await client.SendAsync(message);
                    client.Disconnect(true);
                    return true;
                }
            }
            catch (Exception ex)
            {
            }
            return false;
        }
    }
}
