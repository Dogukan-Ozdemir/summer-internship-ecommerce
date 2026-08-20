using System.Security.Cryptography.X509Certificates;

namespace MultiShop.IdentityServer.Services.Certificate
{
    public interface ICertificateService
    {
        X509Certificate2 GetCertificateFromKeyVault(string vaultCertificateName);
    }
}