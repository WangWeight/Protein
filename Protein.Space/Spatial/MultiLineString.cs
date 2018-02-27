using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// 复杂线
    /// </summary>
    public class MultiLineString
    {
        public String type = "MultiLineString";
        public List<List<double[]>> coordinates = new List<List<double[]>>();
        public MultiLineString() { }
        public MultiLineString(List<List<double[]>> multiLineString)
        {
            this.coordinates = multiLineString;
        }

        public void add(List<List<double[]>> multiLineString)
        {
            for (int i = 0; i < multiLineString.Count; i++)
            {
                coordinates.Add(multiLineString[i]);
            }
        }
    }
}
