using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using Protein.Enzyme.Layout.Configuration;
using Protein.Enzyme.Layout.Mechanisms;
using System.Configuration;
using Test.LHTDZS;
using Protein.Enzyme.DAL;
using Test.LHTDZS.TypeAdapter;
using Protein.Enzyme.Repository;
using System.IO;
using System.Xml.Serialization;
using System.Xml;
using System.Web.Configuration;
using System.Security.Cryptography;
using System.IO.Compression;
using Protein.Enzyme.IO;
using System.Diagnostics;
namespace Test
{
    public partial class Form1 : Form
    {
        private IEntityFactory entityfactory = null;
        public Form1()
        {
            InitializeComponent();
        }

        protected  virtual void button1_Click(object sender,    EventArgs e)
        {
            //ProteinCustomSection config
            //    = (ProteinCustomSection)System.Configuration.ConfigurationManager.GetSection("Protein");
            //ProteinConfig pconfig = ProteinConfig.GetInstance();
            throw new Exception("测试");

            ///
            ILHTDZS_ManagerUser user = this.entityfactory.CreateEntityInstance<ILHTDZS_ManagerUser>();
            IDvTable dvt = this.entityfactory.CreateDriveTable(user);
            DataSet ds = dvt.Select();
            //List<LHTDZS_ManagerUser> list = this.dh.Convert<LHTDZS_ManagerUser>(user.GetType(), ds);
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            Protein.Enzyme.Repository.ProteinHandler ph=new Protein.Enzyme.Repository.ProteinHandler(); 
            //this.entityfactory.TypeAdapter.SetNextEntityType(new UserAdapter());
            ph.SetEntityTypeAdapter<ILHTDZS_ManagerUser, LHTDZS_ManagerUser>();
            this.entityfactory = MachineEntityHandler.GetEntityFactory();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //ProteinHandler ph = new ProteinHandler();
            //Itesta aa = ph.ExtendConfig<Itesta>();

            //$$$$$$$$$$
            //string filename = System.Windows.Forms.Application.StartupPath+"\\testa.xml";
            //string filename1 = System.Windows.Forms.Application.StartupPath + "\\testa2.xml";
            //XmlSerializer xs = new XmlSerializer(typeof(testa));
            //Itesta aa = (Itesta)xs.Deserialize(File.OpenRead(filename));
            //Itesta bb = new testa();
            //bb.aaad = new rsfc();
            //bb.aaad.ti = DateTime.Now;
            //bb.a1="rsfc";
            //bb.a3=123;
            //bb.a4 = "aaa";
            ////XmlWriter xw=new 
            //xs.Serialize(File.Create(filename1),  bb);
            //CustomErrorsSection customerrors = systemWeb.CustomErrors;

            string aa = EncryptDES("张某某", "SuperMap");
            string bb = DecryptDES(aa, "SuperMap");
            string cc = Compress("张某某");
            string ggg = "211481218212张某某";
            int a=ggg.GetHashCode();

            Protein.Enzyme.Repository.ProteinHandler ph = new Protein.Enzyme.Repository.ProteinHandler();
            ph.SetEntityTypeAdapter<ILHTDZS_XZQH, LHTDZS_XZQH>();
            ph.SetEntityTypeAdapter<ILHTDZS_ManagerUser, LHTDZS_ManagerUser>();
            ph.SetEntityTypeAdapter<ILHTDZS_SZDBCJL, LHTDZS_SZDBCJL>(); 


            DalHandler dl = new DalHandler();
            ILHTDZS_SZDBCJL enty = dl.DalCreateEntityInstance<ILHTDZS_SZDBCJL>();
            enty.BuChangBianHao = @"21148121821200001";
            int i= dl.RemoveEntityData(enty, "BuChangBianHao", Protein.Enzyme.DAL.Operator.Deng, Protein.Enzyme.DAL.LinkOperator.nul);
        }

        //单纯为了字符串压缩：
        public string Compress(string strSource)
        {
            if (strSource == null || strSource.Length > 8 * 1024)
                throw new System.ArgumentException("字符串为空或长度太大！");

            System.Text.Encoding encoding = System.Text.Encoding.Unicode;
            byte[] buffer = encoding.GetBytes(strSource);
            //byte[] buffer = Convert.FromBase64String(strSource); //传入的字符串不一定是Base64String类型，这样写不行

            System.IO.MemoryStream ms = new System.IO.MemoryStream();
            System.IO.Compression.DeflateStream stream = new System.IO.Compression.DeflateStream(ms, System.IO.Compression.CompressionMode.Compress, true);
            stream.Write(buffer, 0, buffer.Length);
            stream.Close();

            buffer = ms.ToArray();
            ms.Close();

            return Convert.ToBase64String(buffer); //将压缩后的byte[]转换为Base64String
        }


        private static byte[] Keys = { 0x12, 0x34, 0x56, 0x78, 0x90, 0xAB, 0xCD, 0xEF };
        /// <summary>
        /// DES加密字符串
        /// </summary>
        /// <param name="encryptString">待加密的字符串</param>
        /// <param name="encryptKey">加密密钥,要求为8位</param>
        /// <returns>加密成功返回加密后的字符串，失败返回源串</returns>
        public static string EncryptDES(string encryptString, string encryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(encryptKey.Substring(0, 8));
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Encoding.UTF8.GetBytes(encryptString);
                DESCryptoServiceProvider dCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, dCSP.CreateEncryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Convert.ToBase64String(mStream.ToArray());
            }
            catch
            {
                return encryptString;
            }
        }

        /// <summary>
        /// DES解密字符串
        /// </summary>
        /// <param name="decryptString">待解密的字符串</param>
        /// <param name="decryptKey">解密密钥,要求为8位,和加密密钥相同</param>
        /// <returns>解密成功返回解密后的字符串，失败返源串</returns>
        public static string DecryptDES(string decryptString, string decryptKey)
        {
            try
            {
                byte[] rgbKey = Encoding.UTF8.GetBytes(decryptKey);
                byte[] rgbIV = Keys;
                byte[] inputByteArray = Convert.FromBase64String(decryptString);
                DESCryptoServiceProvider DCSP = new DESCryptoServiceProvider();
                MemoryStream mStream = new MemoryStream();
                CryptoStream cStream = new CryptoStream(mStream, DCSP.CreateDecryptor(rgbKey, rgbIV), CryptoStreamMode.Write);
                cStream.Write(inputByteArray, 0, inputByteArray.Length);
                cStream.FlushFinalBlock();
                return Encoding.UTF8.GetString(mStream.ToArray());
            }
            catch
            {
                return decryptString;
            }
        }


        public static string CompressStringToString(string toCompress)
        {
             
                byte[] inBuffer = Encoding.UTF8.GetBytes(toCompress);
                using (MemoryStream compressedStream = new MemoryStream())
                {
                    using (GZipStream gzip = new GZipStream(compressedStream, CompressionMode.Compress, true))
                    {
                        gzip.Write(inBuffer, 0, inBuffer.Length);
                    }

                    compressedStream.Position = 0;

                    // store the length of the uncompressed array (inBuffer) at the first 4 bytes in outBuffer
                    byte[] outBuffer = new byte[compressedStream.Length + 4];
                    System.Buffer.BlockCopy(compressedStream.ToArray(), 0, outBuffer, 4, Convert.ToInt32(compressedStream.Length));
                    System.Buffer.BlockCopy(BitConverter.GetBytes(inBuffer.Length), 0, outBuffer, 0, 4);

                    return Convert.ToBase64String(outBuffer);
                }
            

        }

        public static string CompressString(string str)
        {

            const int iMaxCount = 9;//常量，表示多少进制，如十进制的 a9 表示9个a， 十六进制的af表示15个a。这里用十进制。

            StringBuilder stringBuilder = new StringBuilder();

            int countChar = 1;//计数器

            str = str.Trim() + " ";//为了防止在下面的循环中溢出，我在原来的字符串末尾加上了一个空格。

            for (int i = 0; i < str.Length - 1; i++)
            {

                if (str[i + 1] == str[i])//如果连续的字符相等
                {

                    countChar++;//计数器加一

                    if (countChar > iMaxCount)//如果计数器大于9，压入stringBuilder，比如，连续十个a，应该表示为：a9a1，而不是a10
                    {

                        stringBuilder.Append(str[i]);

                        stringBuilder.Append(iMaxCount.ToString());

                        countChar = 1;

                    }

                    continue;

                }

                else//如果不等，就将当前的字符和计数压入stringBuilder。
                {

                    stringBuilder.Append(str[i]);

                    stringBuilder.Append(countChar.ToString());

                    countChar = 1;

                }

            }

            return stringBuilder.ToString();

        }

        private void button3_Click(object sender, EventArgs e)
        {
            //testa s = new testa();
            //s.aaad = new List<rsfc>();
            //s.aaad.Add(new rsfc() { ti = DateTime.Now });
            //s.aaad.Add(new rsfc() { ti = DateTime.Now });
            //s.aaad.Add(new rsfc() { ti = DateTime.Now });
            //s.aaad.Add(new rsfc() { ti = DateTime.Now });
            //s.aaad.Add(new rsfc() { ti = DateTime.Now });
            //NormalIO.XmlSerialize<testa>(@"F:\SourceCode\Application\Exgis\SSMTool\CSFv0.2\asdf.xml", Encoding.UTF8, s);
            string aa = ProteinHandler.GetExtendConfig<testa>().a1;
        }
        KeyHook kh = null;
        KeyHook khd1 = null;

        private void button5_Click(object sender, EventArgs e)
        {
            kh = KeyHook.GetHook();
            kh.InstallHook(keyf1);
            //ProcessKeyHandle pkh = new ProcessKeyHandle(keyf1);
            //kh.InstallHook(pkh);


            khd1 = KeyHook.GetHook();
            khd1.InstallHook(keyD1);
            //ProcessKeyHandle pkhd1 = new ProcessKeyHandle(keyD1);
            //khd1.InstallHook(pkhd1);
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="handle"></param>
        public void keyf1(HookStruct param, out bool handle)
        {
            handle = false; 
            if (param.vkCode == (int)System.Windows.Forms.Keys.F1)
            {
                Debug.WriteLine("F1");
                param.vkCode = (int)System.Windows.Forms.Keys.None; //设键为0
                handle = true;
                //MessageBox.Show("F1");
            } 
        
        }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="param"></param>
        /// <param name="handle"></param>
        public void keyD1(HookStruct param, out bool handle)
        {
            handle = false; 
            if (param.vkCode == (int)System.Windows.Forms.Keys.D1)
            {
                Debug.WriteLine("D1");
                param.vkCode = (int)System.Windows.Forms.Keys.None; //设键为0
                handle = true;
                //MessageBox.Show("D1");
            }


        }

        private void button6_Click(object sender, EventArgs e)
        {
            this.kh.UninstallHook(keyf1);
        }

        private void button7_Click(object sender, EventArgs e)
        {
            this.khd1.UninstallHook(keyD1);
        }

        private void button4_Click(object sender, EventArgs e)
        {

        }
    }
}
