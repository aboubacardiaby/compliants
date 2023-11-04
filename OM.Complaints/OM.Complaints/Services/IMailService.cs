using OM.Complaints.Models;

namespace OM.Complaints.Services
{
    public interface IMailService
    {
        bool SendMail(MailData mailData);
    }
}
