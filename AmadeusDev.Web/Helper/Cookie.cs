using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using System;
using System.Linq.Expressions;

namespace Jasarsoft.AmadeusDev.WEB.Helper
{
    public static class Cookie
    {
        public static void Set<T>(this IResponseCookies cookies,string key, T value, CookieOptions cookieOptions) where T : class
        {
            if (value == null) throw new ArgumentException("Value is set to null");
            cookies.Append(key, JsonConvert.SerializeObject(value), cookieOptions);
        }

        public static void Set<T>(this IResponseCookies cookies, string key, T value, Expression<Func<CookieOptions, CookieOptions>> expression) where T : class
        {
            if (value == null) throw new ArgumentException("Value is set to null");
            cookies.Append(key, JsonConvert.SerializeObject(value), expression.Compile().Invoke(new CookieOptions()));
        }

        public static T Get<T>(this IRequestCookieCollection cookies, string key) where T : class
        {
            string value = cookies[key];
            if (value != null) return JsonConvert.DeserializeObject<T>(value);
            return null;
        }


    }
}
