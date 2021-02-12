using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Encodings.Web;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;
using DapperTask.Interfaces;
using DapperTask.Models;
using Newtonsoft.Json;

namespace DapperTask.Utils.UserDateHiding
{
    public class DataHideService
    {
        private readonly string replaceBy;
        private readonly string email;

        public IRepository<User> UserRepository { get; set; }
        public IRepository<Mail> MailRepository { get; set; }

        public DataHideService(string email, string replaceBy = "hidden")
        {
            this.email = email;
            this.replaceBy = replaceBy;
        }

        public async Task HideUserData()
        {
            var users = await this.UserRepository.GetAll();
            var user = users.FirstOrDefault(u => u.Email == this.email);

            if (user != null)
            {
                await this.UserRepository.Update(new User
                {
                    Id = user.Id,
                    Name = this.replaceBy,
                    Surname = this.replaceBy,
                    Email = this.replaceBy,
                    DateOfBirth = user.DateOfBirth
                });
            }
        }

        public async Task HideMailObjectData()
        {
            var allMails = await this.MailRepository.GetAll();
            var mails = allMails.Where(m =>
                JsonConvert.DeserializeObject<MailObject>(m.Object).From == email ||
                JsonConvert.DeserializeObject<MailObject>(m.Object).To == email);

            foreach (var mail in mails)
            {
                var mailObject = JsonConvert.DeserializeObject<MailObject>(mail.Object);

                if (mailObject.From == email)
                {
                    mailObject.From = replaceBy;
                }

                if (mailObject.To == email)
                {
                    mailObject.To = replaceBy;
                }

                await this.MailRepository.Update(new Mail
                {
                    Id = mail.Id,
                    Object = JsonConvert.SerializeObject(mailObject)
                });
            }
        }
    }
}
