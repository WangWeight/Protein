using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// 多边形
    /// </summary>
    public class Polygon
    {
        /// <summary>
        /// 
        /// </summary>
        public string type = "Polygon";
        public List<List<double[]>> coordinates = null;
        public Polygon() { }
        public Polygon(List<List<double[]>> coordinates)
        {
            this.coordinates = coordinates;
        }

        /**创建面
         * @param points 一个环的点集合
         */
        public Polygon(List<Point> points){
		List<double[]> polygonArr = new List<double[]>();
		foreach (Point point in points) {
			double[] tmpoint = point.coordinates;
			polygonArr.Add(tmpoint);
		}
		polygonArr.Add(points[0].coordinates); 
		this.coordinates  = new List<List<double[]>>();
		this.coordinates.Add(polygonArr);
	}
        /**
         *  添加点集合
         * @param pointArray
         * @param index
         */
        public void add(List<double[]> pointArray, int index)
        {
            for (int i = 0; i < pointArray.Count; i++)
            {
                this.coordinates[index].Add(pointArray[i]);
            }
        }
        /**
         * 添加点
         * @param point
         * @param index
         */
        public void add(double[] point, int index)
        {
            this.coordinates[index].Add(point);
        }
        /**
         * 添加多边形数组，闭合的数组
         * @param pointArray
         */
        public void add(List<double[]> pointArray)
        {
            this.coordinates.Add(pointArray);
        }
        private void isClosed(List<List<double[]>> lineStrings)
        {

        }

        public List<List<double[]>> getCoordinates()
        {
            return this.coordinates;
        }
    }

}
