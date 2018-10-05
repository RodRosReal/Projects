using System;
using System.Security.Cryptography;
using System.Text;
using System.Web;

namespace CollegeBusiness.Util
{
    public class cWebCrypto
    {
        //private static string cryptoKey = "CRYPTO#@$";
        //private static readonly byte[] IV = new byte[8] { 240, 3, 45, 29, 0, 76, 173, 59 };

        public static string Encrypt(string data)
        {
            try
            {
                byte[] bytes = new UTF8Encoding().GetBytes(data);
                return HttpUtility.UrlEncode(Convert.ToBase64String(bytes));

                //byte[] buffer = Encoding.ASCII.GetBytes(data);
                //TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                //MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                //des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                //des.IV = IV;
                //return HttpUtility.UrlEncode(Convert.ToBase64String(des.CreateEncryptor().TransformFinalBlock(buffer, 0, buffer.Length)));
            }
            catch
            {
                return "";
            }
        }

        public static string Decrypt(string data)
        {
            try
            {
                data = HttpUtility.UrlDecode(data);
                byte[] bytes = Convert.FromBase64String(data);
                return new UTF8Encoding().GetString(bytes);

                //byte[] buffer = Convert.FromBase64String(HttpUtility.UrlDecode(data));
                //TripleDESCryptoServiceProvider des = new TripleDESCryptoServiceProvider();
                //MD5CryptoServiceProvider MD5 = new MD5CryptoServiceProvider();
                //des.Key = MD5.ComputeHash(ASCIIEncoding.ASCII.GetBytes(cryptoKey));
                //des.IV = IV;
                //return Encoding.ASCII.GetString(des.CreateDecryptor().TransformFinalBlock(buffer, 0, buffer.Length));
            }
            catch
            {
                return "";
            }
        }
    }
}
