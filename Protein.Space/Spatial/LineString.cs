using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// 线对象
    /// </summary>
    public class LineString
    {
        //	{ type: "LineString", coordinates: [ [ 40, 5 ], [ 41, 6 ] ] }
        public String type = "LineString";
        public List<double[]> coordinates = null;

        /// <summary>
        /// 
        /// </summary>
        public LineString() { }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="coordinates"></param>
        public LineString(List<double[]> coordinates)
        {
            this.coordinates = coordinates;
        }
        /// <summary>
        /// 
        /// </summary>
        /// <returns></returns>
        public List<double[]> getCoordinates()
        {
            return this.coordinates;
        }
        
        /// <summary>
        /// 增加点数组
        /// </summary>
        /// <param name="points"></param>
        public void add(List<double[]> points)
        {
            for (int i = 0; i < points.Count; i++)
            {
                this.coordinates.Add(points[i]);
            }
        }
         
        /// <summary>
        /// 增加点
        /// </summary>
        /// <param name="points"></param>
        public void add(double[] points)
        {
            this.coordinates.Add(points);
        }
    }
}
