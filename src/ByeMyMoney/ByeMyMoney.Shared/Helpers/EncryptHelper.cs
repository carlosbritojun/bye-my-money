using System.Text;

namespace ByeMyMoney.Shared.Helpers
{
    public static class EncryptHelper
    {
        public static string Cypher(string text, string privateKey)
        {
            if (string.IsNullOrEmpty(text)) return "";
            var textWithPrivateKey = (text += privateKey);
            var md5 = System.Security.Cryptography.MD5.Create();
            var data = md5.ComputeHash(Encoding.Default.GetBytes(textWithPrivateKey));
            var sbString = new StringBuilder();
            foreach (var t in data)
                sbString.Append(t.ToString("x2"));

            return sbString.ToString();
        }
    }
}
