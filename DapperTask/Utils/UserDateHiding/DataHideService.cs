using System.Collections.Generic;
using System.Linq;
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
            var user = await this.UserRepository.FindAsync(u => u.Email, this.email);

            if (user != null)
            {
                await this.UserRepository.UpdateAsync(new User
                {
                    Id = user.FirstOrDefault().Id,
                    Name = this.replaceBy,
                    Surname = this.replaceBy,
                    Email = this.replaceBy,
                    DateOfBirth = user.FirstOrDefault().DateOfBirth
                });
            }
        }

        public async Task HideMailObjectData()
        {
            var mails = new List<Mail>();

            mails.AddRange(
                await this.MailRepository.FindAsync(m => JsonConvert.DeserializeObject<MailObject>(m.Object).From,
                    this.email));
            mails.AddRange(
                await this.MailRepository.FindAsync(m => JsonConvert.DeserializeObject<MailObject>(m.Object).To,
                    this.email));
            
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

                await this.MailRepository.UpdateAsync(new Mail
                {
                    Id = mail.Id,
                    Object = JsonConvert.SerializeObject(mailObject)
                });
            }
        }
    }
}
