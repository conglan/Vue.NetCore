using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq.Expressions;
using VOL.Core.CacheManager;
using VOL.Core.Utilities;
using VOL.Entity;
using VOL.Entity.DomainModels;

namespace VOL.Core.BaseProvider
{
    public interface IService<T> where T : KeyEntity
    {
        ICacheService CacheContext { get; }
        Microsoft.AspNetCore.Http.HttpContext Context { get; }

        /// <summary>
        /// 查询
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        PageGridData<T> GetPageData(PageDataOptions pageData);

        object GetDetailPage(PageDataOptions pageData);

        WebResponseContent Upload(List<IFormFile> files);

        WebResponseContent DownLoadTemplate();

        WebResponseContent Import(List<IFormFile> files);

        /// <summary>
        /// 导出
        /// </summary>
        /// <param name="pageData"></param>
        /// <returns></returns>
        WebResponseContent Export(PageDataOptions pageData);

        /// <summary>
        /// 新增
        /// </summary>
        /// <param name="saveDataModel">主表与子表的数据</param>
        /// <returns></returns>
        WebResponseContent Add(SaveModel saveDataModel);

        /// <summary>
        ///
        /// </summary>
        /// <param name="entity">保存的实体</param>
        /// <param name="validationEntity">是否对实体进行校验</param>
        /// <returns></returns>
        WebResponseContent AddEntity(T entity, bool validationEntity = true);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TDetail"></typeparam>
        /// <param name="entity">保存的实体</param>
        /// <param name="list">保存的明细</param>
        /// <param name="validationEntity">是否对实体进行校验</param>
        /// <returns></returns>
        WebResponseContent Add<TDetail>(T entity, List<TDetail> list = null, bool validationEntity = true) where TDetail : class;

        /// <summary>
        /// 编辑
        /// </summary>
        /// <param name="saveDataModel">主表与子表的数据</param>
        /// <returns></returns>
        WebResponseContent Update(SaveModel saveDataModel);

        /// <summary>
        /// 删除数据
        /// </summary>
        /// <param name="keys">删除的主键</param>
        /// <param name="delList">是否删除对应明细(默认会删除明细)</param>
        /// <returns></returns>
        WebResponseContent Del(object[] keys, bool delList = true);

        WebResponseContent Audit(object[] id, int? auditStatus, string auditReason);

        (string, T, bool) ApiValidate(string bizContent, Expression<Func<T, object>> expression = null);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="bizContent"></param>
        /// <param name="expression">对指属性验证格式如：x=>new { x.UserName,x.Value }</param>
        /// <returns>(string,TInput, bool) string:返回验证消息,TInput：bizContent序列化后的对象,bool:验证是否通过</returns>
        (string, TInput, bool) ApiValidateInput<TInput>(string bizContent, Expression<Func<TInput, object>> expression);

        /// <summary>
        ///
        /// </summary>
        /// <typeparam name="TInput"></typeparam>
        /// <param name="bizContent"></param>
        /// <param name="expression">对指属性验证格式如：x=>new { x.UserName,x.Value }</param>
        /// <param name="validateExpression">对指定的字段只做合法性判断比如长度是是否超长</param>
        /// <returns>(string,TInput, bool) string:返回验证消息,TInput：bizContent序列化后的对象,bool:验证是否通过</returns>
        (string, TInput, bool) ApiValidateInput<TInput>(string bizContent, Expression<Func<TInput, object>> expression, Expression<Func<TInput, object>> validateExpression);

        /// <summary>
        /// 将数据源映射到新的数据中,List<TSource>映射到List<TResult>或TSource映射到TResult
        /// 目前只支持Dictionary或实体类型
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="resultExpression">只映射返回对象的指定字段</param>
        /// <param name="sourceExpression">只映射数据源对象的指定字段</param>
        TResult MapToEntity<TSource, TResult>(TSource source, Expression<Func<TResult, object>> resultExpression,
           Expression<Func<TSource, object>> sourceExpression = null) where TResult : class;

        /// <summary>
        /// 将一个实体的赋到另一个实体上,应用场景：
        /// 两个实体，a a1= new a();b b1= new b();  a1.P=b1.P; a1.Name=b1.Name;
        /// </summary>
        /// <typeparam name="TSource"></typeparam>
        /// <typeparam name="TResult"></typeparam>
        /// <param name="source"></param>
        /// <param name="result"></param>
        /// <param name="expression">指定对需要的字段赋值,格式x=>new {x.Name,x.P},返回的结果只会对Name与P赋值</param>
        void MapValueToEntity<TSource, TResult>(TSource source, TResult result, Expression<Func<TResult, object>> expression = null) where TResult : class;
    }
}