using System.Threading.Tasks;

namespace MultiShopIdentityServer.Services;

public interface IEmailSender
{
    Task SendEmail(string email, string subject, string message, string toUsername);
}
