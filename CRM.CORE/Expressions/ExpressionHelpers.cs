using System;
using System.Linq.Expressions;
using System.Reflection;

namespace CRM.CORE
{
    /// <summary>
    /// A helper for expressions
    /// </summary>
    public static class ExpressionHelpers
    {
        /// <summary>
        /// Compiles an expression and gets the function return value
        /// </summary>
        /// <typeparam name="T">The type of the return value</typeparam>
        /// <param name="lambda">The exprassion to compile</param>
        /// <returns></returns>
        public static T GetPropertyValue<T>(this Expression<Func<T>> lambda) =>
            lambda.Compile().Invoke();

        /// <summary>
        /// Sets the underlying properties value to the given value,
        /// from an exprassion that contains the property
        /// </summary>
        /// <typeparam name="T">The type of value to set</typeparam>
        /// <param name="lambda">The exprassion</param>
        public static void SetPropertyValue<T>(this Expression<Func<T>> lambda,T value)
        {
            var exprassion = (lambda as LambdaExpression).Body as MemberExpression;

            var propertyInfo = (PropertyInfo)exprassion.Member;

            var target = Expression.Lambda(exprassion.Expression).Compile().DynamicInvoke();

            propertyInfo.SetValue(target, value);
        }

    }
}
