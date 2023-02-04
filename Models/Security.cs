using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

using System.Security.Cryptography;
using System.Text;

namespace NAVY4U.Models
{
    public class Security
    {
        public static string encryption(string pass)
        {
            MD5 md5 = new MD5CryptoServiceProvider();
            byte[] encrypt = Encoding.UTF8.GetBytes(pass);
            byte[] decrypt = md5.ComputeHash(encrypt);
            string encryptData = null;

            for (var i = 0; i < decrypt.Length; i++)
            {
                encryptData += decrypt[i].ToString("x2");
            }
            return encryptData;
        }
    }
}