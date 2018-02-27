using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// BoundingBox边框
    /// </summary>
    public class BoundingBox {
	
	    public double minx = 0;
	    public double miny = 0;
	    public double maxx = 0;
	    public double maxy = 0;
        /// <summary>
        /// 
        /// </summary>
	    public BoundingBox(){}
        /// <summary>
        /// 
        /// </summary>
        /// <param name="minx"></param>
        /// <param name="miny"></param>
        /// <param name="maxx"></param>
        /// <param name="maxy"></param>
	    public BoundingBox(Double minx, Double miny, Double maxx, Double maxy){
		    this.minx = minx;
		    this.miny = miny;
		    this.maxx = maxx;
		    this.maxy = maxy;
	    }
    }
}
