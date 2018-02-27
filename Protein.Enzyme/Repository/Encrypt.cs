using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Security.Cryptography;
using System.IO;

namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// 字符串编码加密
    /// </summary>
    public static class Encrypt
    {
        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        //string EncryptStr = EncryptDESString.EncryptDES("aaaaaaaaaa", "ssssssss");  //返回加密后的字符串
        //string DecryptStr = EncryptDESString.DecryptDES(EncryptStr, "ssssssss");//解密字符串
        //加密密钥,要求为8位
        private static string sKey = "l$2*9)kT";


        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="EncryptString">待加密的字符串</param> 
        /// <returns>加密成功返回加密后的字符串，失败返回源串 </returns>
        public static string CipherEncryptDES(this string EncryptString)
        {
            try
            {
                //转换为字节
                byte[] rgbKey = Encoding.UTF8.GetBytes(sKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(EncryptString);
                //实例化数据加密标准
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                //实例化内存流
                MemoryStream mStream = new MemoryStream();
                //将数据流链接到加密转换的流
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return EncryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="DecryptString">待解密的字符串</param> 
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string CipherDecryptDES(this string DecryptString)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(sKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(DecryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return DecryptString;
            }
        }





    }
}
