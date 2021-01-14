using System;
using System.Threading.Tasks;


namespace CopaFilmes.Core.Extension
{
    public static class TaskExtensions
    {
        public static async Task<TReturn> SelectMany<T, TMap, TReturn>(
            this Task<T> @this,
            Func<T, Task<TMap>> bind,
            Func<T, TMap, TReturn> project
        )
        {
            var value = await @this;
            var mapped = await bind(value);
            return project(value, mapped);
        }

        public static Task<TReturn> SelectMany<T, TReturn>(
           this Task<T> @this,
           Func<T, Task<TReturn>> bind
       ) => @this.SelectMany<T, TReturn, TReturn>(bind, (_, value) => value);

        public static async Task<TReturn> Select<T, TReturn>(
            this Task<T> @this,
            Func<T, TReturn> map
        ) => map(await @this);

    }
}
