using System;
using System.IO;
using System.Xml;
using System.Collections;
using System.Data;
using System.Collections.Generic; 
using System.Reflection;

namespace Protein.Enzyme.Repository
{
    /// <summary>
    /// XmlFiles 的摘要说明。
    /// </summary>
    public class XmlHelper : XmlDocument
    {
        #region 属性
        protected string _xmlFileName;
        public string XmlFileName
        {
            set { _xmlFileName = value; }
            get { return _xmlFileName; }
        }
        #endregion
        /// <summary>
        /// 
        /// </summary>
        /// <param name="xmlFile"></param>
        public XmlHelper(string xmlFile)
        {　
            XmlFileName = xmlFile;
            this.Load(XmlFileName); 　
        }
        /// <summary>
        /// 
        /// </summary>
        public XmlHelper()
        { }
        /// <summary>
        /// 给定一个节点的xPath表达式并返回一个节点
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public XmlNode FindNode(string xPath)
        {
            XmlNode xmlNode = this.SelectSingleNode(xPath);
            return xmlNode;
        }

        /// <summary>
        /// 从给定的列表中返回一个节点列表
        /// </summary>
        /// <param name="nodeName"></param>
        /// <param name="nodeList"></param>
        public ArrayList GetNodeListTable(string nodeName, XmlNodeList nodeList)
        {
            ArrayList al=new ArrayList();
            
            foreach (XmlNode node in nodeList)
            {
                if (node.Name == nodeName)
                {
                    //string xx = node.SelectSingleNode("./SystemName").InnerText;
                    al.Add(node);
                }
            }
            
            return al;
        }

        /// <summary>
        /// 给定一个节点的xPath表达式返回其值
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public string GetNodeValue(string xPath)
        {
             
                XmlNode xmlNode = this.SelectSingleNode(xPath);
                return xmlNode.InnerText;
            
            
        }
        /// <summary>
        /// 给定一个节点的表达式返回此节点下的孩子节点列表
        /// </summary>
        /// <param name="xPath"></param>
        /// <returns></returns>
        public XmlNodeList GetNodeList(string xPath)
        {
            XmlNodeList nodeList = null;
             
            nodeList=this.SelectSingleNode(xPath).ChildNodes;
                
            
            return nodeList;
        }

        
        public static void GetNodes(XmlNode node)
        {
            XmlAttribute showname = node.Attributes["showname"];
            XmlAttribute show = node.Attributes["show"];
            XmlAttribute value = node.Attributes["value"];
            if (showname != null || show != null || value != null)
            {
                Console.Write("tagname:{0} ", node.Name);
                if (showname != null)
                    Console.Write("showname:{0} ", showname.Value);
                if (show != null)
                    Console.Write("show:{0} ", show.Value);
                if (value != null)
                    Console.Write("value:{0} ", value.Value);
                Console.WriteLine();
            }
            foreach (XmlNode xn in node.ChildNodes)
                GetNodes(xn);
        }


        public  void EditElement(string nodeName,string nodeValue)
        {　
            XmlElement e = (XmlElement)this.SelectSingleNode("//" + nodeName);
            e.Value = nodeValue;
            this.Save(_xmlFileName);　
        }


        public void UpdateNode(string xPath, string strColName, string strColValue)
        {　
            System.Xml.XmlNodeList nodes = this.SelectNodes(xPath);
            if (nodes != null)
            {
                
                foreach (System.Xml.XmlNode xn in nodes)
                {
                    if (xn.Name == strColName)
                    {
                        xn.InnerText = strColValue;
                    }
                }
            }
            this.Save(this._xmlFileName);
           
        }


        public void UpdateNodeValue( string xPath,string strValue)
        {
            
            System.Xml.XmlNodeList nodes = this.SelectNodes(xPath);
            if (nodes != null)
            {
                foreach (System.Xml.XmlNode xn in nodes)
                {

                    xn.InnerText = strValue;
                    
                }
            }
            this.Save(this._xmlFileName);
        
        }

        public void UpdateNodeValue(string xPath, string nodeIdName, string nodeIdValue, string nodeValueName, string nodeValue)
        {
             
            System.Xml.XmlNodeList nodes = this.SelectNodes(xPath);
            if (nodes != null)
            {
                foreach (System.Xml.XmlNode xn in nodes)
                {
                    if (xn.SelectSingleNode(nodeIdName).InnerText == nodeIdValue)
                    {
                        xn.SelectSingleNode(nodeValueName).InnerText = nodeValue;
                    }
                }
            }
            this.Save(this._xmlFileName);
        
        }


        /// <summary>
        /// 删除一个节点
        /// </summary>
        /// <param name="xPath">xPath表达式</param>
        /// <param name="nodeColumn">节点的匹配字段</param>
        /// <param name="nodeValue">匹配字段是直</param>
        public void DeleteNodeValue(string xPath, string nodeColumn, string nodeValue)
        {
            
            XmlNode root = this.SelectSingleNode(xPath);
            XmlNodeList nodes = root.ChildNodes;
            if (nodes != null)
            {
                foreach (System.Xml.XmlNode xn in nodes)
                {
                    if (xn.SelectSingleNode(nodeColumn).InnerText == nodeValue)
                    {
                         
                        root.RemoveChild(xn);
                    }
                }
            }
            this.Save(this._xmlFileName);
        
        }


      
 
        public string getDataSetColumn(string tableName, string valueName)
        {
            DataSet ds = new DataSet();
            string xmlPath = this.XmlFileName; //;HttpContext.Current.Server.MapPath("config.xml"); //获取xml存储路径
            ds.ReadXml(xmlPath);
            string returnValue = ds.Tables[tableName].Rows[2][valueName].ToString();
            return returnValue;


        }

        public DataSet  getDataSet(string tableName)
        {
           
            DataSet ds = new DataSet();
            string xmlPath = this.XmlFileName; //;HttpContext.Current.Server.MapPath("config.xml"); //获取xml存储路径
             
                 
            ds.ReadXml(xmlPath);
             
            return ds;


        }
    }


 
}
