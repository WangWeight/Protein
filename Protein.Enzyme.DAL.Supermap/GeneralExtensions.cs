using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using SuperMap.Data;
using SuperMap.Mapping; 
using System.Linq.Expressions;  

namespace Protein.Enzyme.DAL.Supermap
{
    /// <summary>
    /// 通用功能方法
    /// </summary>
    public static class GeneralExtensions
    {
        ///// <summary>
        ///// 获取指定名称的实数据集
        ///// </summary>
        ///// <param name="SourceName"></param>
        ///// <param name="Datasetname"></param>
        ///// <returns></returns>
        //public static DatasetVector GetDatasetVector(this SuperMap.Desktop.Application App, string SourceName, string Datasetname)
        //{
        //    Workspace ws = App.Workspace;
        //    DatasetVector dvSet = ws.Datasources[SourceName].Datasets[Datasetname] as DatasetVector;
        //    return dvSet;
        //}

        /// <summary>
        /// 通过图层的Caption获得名称
        /// </summary>
        /// <param name="map"></param>
        /// <param name="caption"></param>
        /// <returns></returns> 
        public static string GetLayerNamebyCaption(this Map map, string caption)
        {
            for (int i = 0; i < map.Layers.Count; i++)
            {
                if (map.Layers[i].Caption == caption)
                {
                    return map.Layers[i].Name;
                }
            }
            return null;
        }

        /// <summary>
        /// 将几何对象投影到目标投影类型
        /// </summary>
        /// <returns></returns>
        public static bool ConvertGeoPrj(this Geometry SourceGeo, PrjCoordSysType coordSysType)
        {
            CoordSysTransParameter cstp = new CoordSysTransParameter();
            return CoordSysTranslator.Convert(SourceGeo
                , new PrjCoordSys(PrjCoordSysType.EarthLongitudeLatitude)
               , new PrjCoordSys(coordSysType)
                , new CoordSysTransParameter()
                , CoordSysTransMethod.GeocentricTranslation);
        }


        /// <summary>
        /// 将几何对象从投影转换到84
        /// </summary>
        /// <returns></returns>
        public static bool ConvertGeoPrjToEarth(this Geometry SourceGeo, PrjCoordSysType coordSysType)
        {
            CoordSysTransParameter cstp = new CoordSysTransParameter();
            return CoordSysTranslator.Convert(SourceGeo
                , new PrjCoordSys(coordSysType)
               , new PrjCoordSys(PrjCoordSysType.EarthLongitudeLatitude)
                , new CoordSysTransParameter()
                , CoordSysTransMethod.GeocentricTranslation);
        }

        /// <summary>
        /// 按距离求线段延长线上的点
        /// </summary>
        /// <param name="p1"></param>
        /// <param name="p2"></param>
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Point2D findPointOnExtensionLinesByDistance(Point2D p1, Point2D p2, double distance)
        {
            double x1 = p1.X, x2 = p2.X;
            double y1 = p1.Y, y2 = p2.Y;
            Point2D objPoint = new Point2D();
            if ((x1 == x2) && (y1 == y2))
                objPoint = new Point2D(0, 0);
            if (x1 == x2)
            {
                if (y2 > y1)
                    objPoint = new Point2D(x1, y2 + distance);
                else
                    objPoint = new Point2D(x1, y2 - distance);
            }
            else if (y1 == y2)
            {
                if (x2 > x1)
                    objPoint = new Point2D(x2 + distance, y1);
                else
                    objPoint = new Point2D(x2 - distance, y1);
            }
            else
            {
                double k = (y2 - y1) / (x2 - x1);
                double t = (x2 * y1 - x1 * y2) / (x2 - x1);
                double a = 1 + k * k;
                double b = 2 * k * t - 2 * y2 * k - 2 * x2;
                double c = x2 * x2 + t * t + y2 * y2 - distance * distance - 2 * y2 * t;
                double tx1 = (-b + (Math.Sqrt(b * b - 4 * a * c))) / (2 * a);
                double ty1 = k * tx1 + t;
                double tx2 = (-b - (Math.Sqrt(b * b - 4 * a * c))) / (2 * a);
                double ty2 = k * tx2 + t;
                double d1 = (ty1 - y1) * (ty1 - y1) + (tx1 - x1) * (tx1 - x1);
                double d2 = (ty2 - y1) * (ty2 - y1) + (tx2 - x1) * (tx2 - x1);
                if (d1 >= d2)
                    objPoint = new Point2D(tx1, ty1);
                else
                    objPoint = new Point2D(tx2, ty2);
            }
            return objPoint;
        }
        /// <summary>
        /// 按距离求线段及延长线上的点
        /// </summary> 
        /// <param name="distance"></param>
        /// <returns></returns>
        public static Point2D findPointOnWholeLinesByDistance(this GeoLine refLine, double distance)
        {
            Point2D resultPoint = new Point2D();
            //GeoLine refLine = new GeoLine(new Point2Ds(p1, p2));
            double dl = refLine.Length;
            if (distance <= dl)
                resultPoint = refLine.FindPointOnLineByDistance(distance);
            else
                resultPoint = findPointOnExtensionLinesByDistance(refLine[0][0], refLine[0][1], distance - dl);
            return resultPoint;
        }


        /// <summary>
        /// 获取属性名称
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="Obj"></param>
        /// <param name="expr"></param>
        /// <returns></returns>
        public static string GetPropertyName<T>(this Type Type, Expression<Func<T, object>> expr)
        {
            var rtn = "";
            if (expr.Body is UnaryExpression)
            {
                rtn = ((MemberExpression)((UnaryExpression)expr.Body).Operand).Member.Name;
            }
            else if (expr.Body is MemberExpression)
            {
                rtn = ((MemberExpression)expr.Body).Member.Name;
            }
            else if (expr.Body is ParameterExpression)
            {
                rtn = ((ParameterExpression)expr.Body).Type.Name;
            }
            return rtn;
        }

        ///// <summary>
        ///// 从实体的超图单位对象获取几何对象
        ///// </summary>
        ///// <param name="Unit"></param>
        ///// <returns></returns>
        //public static T GetGeometryObject<T>(this SMUnit Unit)
        //    where T : new()
        //{
        //    T tObj = new T();
        //    Geometry geo = tObj as Geometry;
        //    if (Unit != null)
        //    {
        //        if (Unit.GeoObject != null)
        //        {
        //            geo = Unit.GeoObject;
        //        }
        //        else if (geo != null)
        //        {
        //            geo.FromXML(Unit.GeometrySerialize);
        //        }

        //    }
        //    return (T)((object)geo);
        //}



        #region 查询几何对象

        /// <summary>
        /// 查询几何对象
        /// </summary>
        /// <param name="MapObj">地图对象</param>
        /// <param name="LayerName">图层名称</param>
        /// <param name="SMID">编号</param>
        /// <returns></returns>
        public static Geometry QueryGeometry(this Map MapObj, string LayerName, int SMID)
        {
            Geometry result = null;
            Layer tagLayer = MapObj.Layers[LayerName];
            tagLayer.Selection.Clear();
            DatasetVector dv = (DatasetVector)tagLayer.Dataset;
            QueryParameter qp = new QueryParameter();
            qp.AttributeFilter = "SMID='" + SMID.ToString() + "'";
            qp.CursorType = CursorType.Static;
            qp.HasGeometry = true;
            Recordset rcd = dv.Query(qp);
            if (rcd != null)
            {
                result = rcd.GetGeometry();
            }
            rcd.Close();
            rcd.Dispose();
            return result;
        }

        #endregion

        /// <summary>
        /// 高亮线对象
        /// </summary>
        public static void HighLightLine(this Map MapObj, string LayerName, int SMID, GeoStyle Style)
        {
            Selection selection = new Selection();
            selection.Add(SMID);
            selection.Style = Style;
            Layer tagLayer = MapObj.Layers[LayerName];
            selection.Dataset = (DatasetVector)tagLayer.Dataset;
            tagLayer.Selection = selection;
        }

        /// <summary>
        /// 高亮对象
        /// </summary>
        public static void HighLightGeometry(this Map MapObj, string LayerName, int SMID, GeoStyle Style)
        {
            Layer tagLayer = MapObj.Layers[LayerName];
            //selection.Dataset = (DatasetVector)tagLayer.Dataset;
            //tagLayer.Selection = selection; 
            tagLayer.Selection.Add(SMID);
            tagLayer.Selection.Style = Style;
        }

        #region 定位

        /// <summary>
        /// 定位
        /// </summary>
        /// <param name="TargetGeometry"></param>
        /// <param name="MapObj"></param>
        /// <param name="IsPrj">是否投影</param>
        public static void Positioning(this Map MapObj, Geometry TargetGeometry, bool IsPrj)
        {
            Geometry geo = TargetGeometry.Clone();
            //if (IsPrj)
            //{
            //    geo.ConvertGeoPrj();
            //}
            MapObj.Center = geo.Bounds.Center;
            geo.Dispose();
            geo = null;
        }

        /// <summary>
        /// 定位
        /// </summary>
        /// <param name="SMID"></param>
        public static void Positioning(this Map MapObj, string LayerName, int SMID, bool IsPrj, GeoStyle Style)
        {
            Geometry geo = MapObj.QueryGeometry(LayerName, SMID);
            MapObj.Positioning(geo, IsPrj);
            MapObj.HighLightLine(LayerName, SMID, Style);
            MapObj.Refresh();

        }

        #endregion

        #region 查询记录集

        /// <summary>
        /// 从图层名称根据属性条件查询记录集
        /// </summary>
        /// <param name="MapObj">地图控件</param>
        /// <param name="LayerName">图层名称</param>
        /// <param name="Attribute">查询属性</param>
        /// <param name="HasGeometry">是否包含几何对象</param>
        /// <param name="Cursor">游标模式</param>
        /// <returns></returns>
        public static Recordset GetRecordset(this Map MapObj, string LayerName, string Attribute, bool HasGeometry, CursorType Cursor)
        {
            DatasetVector dvSet = (DatasetVector)MapObj.Layers[LayerName].Dataset;
            QueryParameter queryParameter = new SuperMap.Data.QueryParameter();
            queryParameter.AttributeFilter = Attribute;
            queryParameter.CursorType = Cursor;
            queryParameter.HasGeometry = HasGeometry;
            Recordset rcd = dvSet.Query(queryParameter);
            return rcd;
        }

        /// <summary>
        /// 从图层名称根据属性条件查询记录集
        /// </summary>
        /// <param name="MapObj">地图控件</param>
        /// <param name="LayerName">图层名称</param>
        /// <param name="Attribute">查询属性</param>
        /// <param name="HasGeometry">是否包含几何对象</param>
        /// <param name="Cursor">游标模式</param>
        /// <returns></returns>
        public static Recordset GetRecordset(this Map MapObj, string LayerName, string Attribute, string[] GroupBy, bool HasGeometry, CursorType Cursor)
        {
            DatasetVector dvSet = (DatasetVector)MapObj.Layers[LayerName].Dataset;
            QueryParameter queryParameter = new SuperMap.Data.QueryParameter();
            queryParameter.AttributeFilter = Attribute;
            queryParameter.CursorType = Cursor;
            queryParameter.HasGeometry = HasGeometry;
            queryParameter.GroupBy = GroupBy;
            Recordset rcd = dvSet.Query(queryParameter);
            return rcd;
        }

        /// <summary>
        /// 从图层名称根据属性条件查询记录集
        /// </summary>
        /// <param name="MapObj">地图控件</param>
        /// <param name="LayerName">图层名称</param>
        /// <param name="Attribute">查询属性</param>
        /// <param name="HasGeometry">是否包含几何对象</param>
        /// <param name="Cursor">游标模式</param>
        /// <returns></returns>
        public static Recordset GetRecordsetByIntersect(this Map MapObj, string LayerName, Geometry Geo, string Attribute, bool HasGeometry, CursorType Cursor)
        {
            Geometry query = Geo.Clone();

            DatasetVector dvSet = (DatasetVector)MapObj.Layers[LayerName].Dataset;
            QueryParameter queryParameter = new SuperMap.Data.QueryParameter();
            queryParameter.AttributeFilter = Attribute;
            queryParameter.CursorType = Cursor;
            queryParameter.HasGeometry = HasGeometry;
            queryParameter.SpatialQueryMode = SpatialQueryMode.Intersect;
            queryParameter.SpatialQueryObject = query;
            Recordset rcd = dvSet.Query(queryParameter);
            return rcd;
        }

        /// <summary>
        /// 从图层名称根据属性条件查询记录集
        /// </summary>
        /// <param name="MapObj">地图控件</param>
        /// <param name="LayerName">图层名称</param>
        /// <param name="Attribute">查询属性</param>
        /// <param name="HasGeometry">是否包含几何对象</param>
        /// <param name="Cursor">游标模式</param>
        /// <returns></returns>
        public static Recordset GetRecordsetByDatasource(this DatasetVector DvSet, string Attribute, bool HasGeometry, CursorType Cursor)
        {
            QueryParameter queryParameter = new SuperMap.Data.QueryParameter();
            queryParameter.AttributeFilter = Attribute;
            queryParameter.CursorType = Cursor;
            queryParameter.HasGeometry = HasGeometry;
            Recordset rcd = DvSet.Query(queryParameter);
            return rcd;
        }
         

        #endregion

    }
}
