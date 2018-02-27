using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Data.Spatial
{
    /// <summary>
    /// 复杂多边形
    /// </summary>
    public class MultiPolygon
    {
        public String type = "MultiPolygon";
        public List<List<List<double[]>>> coordinates = new List<List<List<double[]>>>();
        public MultiPolygon() { }
        public MultiPolygon(List<List<List<double[]>>> coordinates)
        {
            this.coordinates = coordinates;
        }
        /**
         * 添加多边形
         * @param polygon
         */
        public void add(List<List<double[]>> polygon)
        {
            this.coordinates.Add(polygon);
        }
        /**
         * 向某一多边形添加点
         * @param point
         * @param index1 多边形所在的复杂多边形的索引，默认为0
         * @param index2 多边形中某一闭合数组的索引，默认为0
         */
        public void add(double[] point, int index1, int index2)
        {
            this.coordinates[index1][index2].Add(point);
        }
        /**
         * 向某一多边形添加多个点
         * @param points
         * @param index1 多边形所在的复杂多边形的索引，默认为0
         * @param index2 多边形中某一闭合数组的索引，默认为0
         */
        public void add(List<double[]> points, int index1, int index2)
        {
            for (int i = 0; i < points.Count; i++)
            {
                this.coordinates[index1][index2].Add(points[i]);
            }
        }
        /**
         * 获取当前复杂多边形
         * @return
         */
        public List<List<List<double[]>>> getCoordinates()
        {
            return this.coordinates;
        }
    }
}
