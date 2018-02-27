using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// 空间点
    /// </summary>
    public class Point
    {
         
        public String type = "Point";
        public double[] coordinates = null;

        /// <summary>
        /// 
        /// </summary>
        public Point()
        {

        }

        public Point(double x, double y)
        {
            this.coordinates = new double[] { x, y };
        }
        public double[] getCoordinates()
        {
            return this.coordinates;
        }
        public Point(double[] coordinates)
        {
            this.coordinates = coordinates;
        }
    }
}
