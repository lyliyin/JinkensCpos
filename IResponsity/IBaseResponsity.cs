using System;
using System.Linq;
using System.Linq.Expressions;
using DataCommTools;

namespace IResponsity
{
    //[Log(Order = 2)]
    public interface IBaseResponsity
    {
        /// <summary>
        /// 查找信息
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        IQueryable<T> FindByWhere<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 获取单条信息
        /// </summary>
        /// <typeparam name="T">泛型</typeparam>
        /// <param name="predicate">表达式</param>
        /// <returns></returns>
        T Get<T>(Expression<Func<T, bool>> predicate) where T : class;

        /// <summary>
        /// 添加信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Add<T>(T t) where T : class;
        /// <summary>
        /// 删除信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="t"></param>
        /// <returns></returns>
        T Delete<T>(T t) where T : class;
        /// <summary>
        /// 分页查询信息
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="predicate"></param>
        /// <param name="PageIndex"></param>
        /// <param name="PageSzie"></param>
        /// <param name="Recordcount"></param>
        /// <returns></returns>
        IQueryable<T> FindByPaged<T>(Expression<Func<T, bool>> predicate, int PageIndex, int PageSzie,string OrderName,string OrderBy,out int Recordcount) where T : class;
        /// <summary>
        /// 保存信息
        /// </summary>
        void SaveChanges();
    }
}
