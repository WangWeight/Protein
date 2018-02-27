using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Configuration;
namespace Protein.Enzyme.Layout.Configuration
{
    /// <summary>
    /// 项目通用配置对象
    /// </summary>
    public  class ProteinCustomSection : ConfigurationSection
    {


        #region 作废 fileName="default.txt" maxUsers="1000" maxIdleTime="10:15:00"
        ///// <summary>
        ///// 
        ///// </summary>
        //[ConfigurationProperty("fileName", DefaultValue = "", IsRequired = false)]
        //public string RemoteOnly
        //{
        //    get
        //    {
        //        return (string)this["fileName"];
        //    }
        //    set
        //    {
        //        this["fileName"] = value;
        //    }
        //}


        //[ConfigurationProperty("maxUsers", DefaultValue = "0", IsRequired = true)]
        //[StringValidator(InvalidCharacters = "~!@#$%^&*()[]{}/;'\"|\\GHIJKLMNOPQRSTUVWXYZ", MinLength = 0, MaxLength = 6)]
        //public string MaxUsers
        //{
        //    get
        //    {
        //        return (string)this["maxUsers"];
        //    }
        //    set
        //    {
        //        this["maxUsers"] = value;
        //    }
        //}

        //[ConfigurationProperty("maxIdleTime", DefaultValue = "0:0:01", IsRequired = true)]
        //[TimeSpanValidator(MinValueString = "0:0:00", MaxValueString = "24:00:0",  ExcludeRange = false)]
        //public TimeSpan MaxIdleTime
        //{
        //    get
        //    {
        //        return (TimeSpan)this["maxIdleTime"];
        //    }
        //    set
        //    {
        //        this["maxIdleTime"] = value;
        //    }
        //}

        #endregion

        /// <summary>
        /// 实体对象实体配置
        /// </summary>
        [ConfigurationProperty("DAlEntity")]
        public DAlEntity DAlEntity
        {
            get
            {
                return (DAlEntity)this["DAlEntity"];
            }
            set
            { this["DAlEntity"] = value; }
        }

        /// <summary>
        /// 数据库对象实体配置
        /// </summary>
        [ConfigurationProperty("DataBase")]
        public DataBase DataBase
        {
            get
            {
                return (DataBase)this["DataBase"];
            }
            set
            { this["DataBase"] = value; }
        }

        /// <summary>
        /// 消息对象实体配置
        /// </summary>
        [ConfigurationProperty("MessageOrgan")]
        public Msg Msg
        {
            get
            {
                return (Msg)this["MessageOrgan"];
            }
            set
            { this["MessageOrgan"] = value; }
        }
       
        /// <summary>
        /// 消息对象实体配置
        /// </summary>
        [ConfigurationProperty("LogOrgan")]
        public LogOrgan LogOrgan
        {
            get
            {
                return (LogOrgan)this["LogOrgan"];
            }
            set
            { this["LogOrgan"] = value; }
        }


        /// <summary>
        /// 扩展配置集合
        /// </summary>
        [ConfigurationProperty("ExConfigs",
              IsDefaultCollection = false)]
        public ExConfigCollection ExConfigCollection
        {
            get
            {
                ExConfigCollection exconfigCollection =
                (ExConfigCollection)base["ExConfigs"];
                return exconfigCollection;
            }
        }

    }
  

}
