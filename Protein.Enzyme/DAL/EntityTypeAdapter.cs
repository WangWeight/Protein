using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Protein.Enzyme.DAL
{
    /// <summary>
    /// 实体对象类型适配器
    /// </summary>
    public abstract class EntityTypeAdapter
    {
        /// <summary>
        /// 
        /// </summary>
        protected  EntityTypeAdapter nextEntityType{get;set;}

        /// <summary>
        /// 设置下一个字段处理方式
        /// </summary>
        /// <param name="EntityType"></param>
        public virtual void SetNextEntityType(EntityTypeAdapter EntityType)
        { 
            if (this.nextEntityType == null)
            {
                this.nextEntityType = EntityType;
            }
            else
            {
                if (this.nextEntityType == EntityType)
                {
                    return;
                }
                this.nextEntityType.SetNextEntityType(EntityType);
            }
        }

        /// <summary>
        /// 定义实体类对象
        /// </summary>
        /// <returns></returns>
        public virtual T Definition<T>(Type EntityType, params object[] Parameters)
        {
            T result = default(T);
            if (IsType(EntityType))
            {
                result = CreateInstance<T>(Parameters);
            }
            else if (this.nextEntityType != null)
            {
                result = this.nextEntityType.Definition<T>(EntityType, Parameters);
            }
            return result;
        }

        /// <summary>
        /// 创建实例
        /// </summary>
        /// <typeparam name="T"></typeparam>
        protected T CreateInstance<T>( params object[] Parameters)
        {
            T ins = (T)Activator.CreateInstance(TargetType, Parameters);
            return ins;
        }
         
        /// <summary>
        /// 判断处理类型
        /// </summary>
        /// <param name="EntityType"></param>
        /// <returns></returns>
        protected abstract bool IsType(Type EntityType);
        /// <summary>
        /// 
        /// </summary>
        protected  Type TargetType { get; set; }
        
    }
}
