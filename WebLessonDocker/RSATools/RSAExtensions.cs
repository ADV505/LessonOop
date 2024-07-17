using System.Security.Cryptography;

namespace WebLessonDocker.RSATools
{
    public class RSAExtensions
    {
        public static RSA GeneratePrivateKey()
        {
            var key = File.ReadAllText(@"../rivate_key.pem");
            var rsa = RSA.Create();
            rsa.ImportFromPem(key);
            return rsa;
        }

        public static RSA GeneratePublicKey()
        {
            var key = File.ReadAllText(@"../rivate_key.pem");
            var rsa = RSA.Create();
            rsa.ImportFromPem(key);
            return rsa;
        }

    }
}
