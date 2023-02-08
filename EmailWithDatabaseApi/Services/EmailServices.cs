using AutoMapper;
using EmailWithDatabaseApi.Data;
using EmailWithDatabaseApi.Dto;
using EmailWithDatabaseApi.Model;
using MailKit.Net.Imap;
using MailKit.Net.Smtp;
using MailKit.Security;
using Microsoft.AspNetCore.Mvc;
using MimeKit;
using MimeKit.Text;

namespace EmailWithDatabaseApi.Services
{
    public class EmailServices : IEmailServices
    {
        private readonly Datacontext _context;
        private readonly IConfiguration _config;
        private readonly IMapper _mapper;
      

        public EmailServices(Datacontext context , IConfiguration Config , IMapper mapper)
        {
            _context = context;
            _config = Config;
            _mapper = mapper;
        }
       

        public IConfiguration Config { get; }
        public IMapper Mapper { get; }

        public string GetObject(EmailDto request)
        {
            var emails = _context.Emails.Where(c => c.Email.Contains("@gmail.com")).Select(c => c.Email).ToList();
            foreach (string i in emails)
            {
                var email = new MimeMessage();
                email.From.Add(MailboxAddress.Parse(_config.GetSection("EmailUserName").Value));
                email.To.Add(MailboxAddress.Parse(i));
                email.Subject = request.Subject;
                email.Body = new TextPart(TextFormat.Html) { Text = request.Body };

                using var smtp = new SmtpClient();
                smtp.Connect(_config.GetSection("EmailHost").Value, 587, SecureSocketOptions.StartTls);
                smtp.Authenticate(_config.GetSection("EmailUserName").Value, _config.GetSection("EmailPassword").Value);
                smtp.Send(email);
                smtp.Disconnect(true);

            }
            return "Done";
        }

        public void Post(PostEmailDto newemail)
        {
            _context.Emails.Add(_mapper.Map<Emailbody>(newemail));
            _context.SaveChanges(); 
        }

        public List<string> GetAll()
        {
            var emails = _context.Emails.Where(c => c.Email.Contains("@gmail.com")).Select(c => c.Email).ToList();
            return emails;
        }
    }
}          