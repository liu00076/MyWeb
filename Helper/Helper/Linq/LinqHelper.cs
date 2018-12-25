using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Linq.Expressions;

namespace Helper.Helper.Linq
{
    /// <summary>
    /// Linq 的帮助类
    /// </summary>
    public static class LinqHelper
    {
        /// <summary>
        /// 使用 System.Linq.Dynamic 将字符串转换成Expression表达式
        /// </summary>
        /// <typeparam name="T">返回的Expression表达式</typeparam>
        /// <param name="type">Expression表达式中的数据源类型</param>
        /// <param name="lambdaString">对数据源进行操作的字符串表达形式</param>
        /// <returns></returns>
        public static T GetEval<T>(this Type type, string lambdaString)
        {
            LambdaExpression func = System.Linq.Dynamic.DynamicExpression.ParseLambda(type, null, lambdaString);
            ParameterExpression objParameter = Expression.Parameter(typeof(object), "obj");
            UnaryExpression objConvert = Expression.Convert(objParameter, type);
            InvocationExpression objInvoke = Expression.Invoke(func, objConvert);
            Expression<T> resultExpression = Expression.Lambda<T>(objInvoke, objParameter);
            return resultExpression.Compile();
        }
    }
}
