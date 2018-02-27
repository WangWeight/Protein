using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// 复杂点
    /// </summary>
    public class MultiPoint
    {
        public String type = "MultiPoint";
        public List<double[]> coordinates = null;
        public MultiPoint() { }
        public MultiPoint(List<double[]> multipoint)
        {
            // TODO Auto-generated constructor stub
            this.coordinates = multipoint;
        }
        //	public void add(List<Point> points){
        //		this.points = points;
        //	}
    }
}
