﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestUngDung.Common
{
    public class Encryptor
    {
        public static string EncryptMD5(string sToEncryt)
        {
            try
            {
                System.Text.UTF8Encoding ue = new System.Text.UTF8Encoding();
                byte[] bytes = ue.GetBytes(sToEncryt);
                System.Security.Cryptography.MD5CryptoServiceProvider md5 = new System.Security.Cryptography.MD5CryptoServiceProvider();
                byte[] hashBytes = md5.ComputeHash(bytes);
                string hashString = "";
                for (int i = 0; i < hashBytes.Length; i++)
                {
                    hashString += Convert.ToString(hashBytes[i], 16).PadLeft(2, '0');

                }
                return hashString.PadLeft(32, '0');
            }
            catch (Exception e)
            {
                Console.Write(e);
                return null;
            }

        }
    }
}