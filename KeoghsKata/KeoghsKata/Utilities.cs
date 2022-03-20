using System.Runtime.CompilerServices;

namespace KeoghsKata
{
    public static class Utilities
    {
        /// <summary>
        /// Used for retrieving an asynchronous method's name
        /// </summary>
        /// <returns></returns>
        public static string GetCurrentMethodName([CallerMemberName] string callerName = "")
        {
            return callerName;
        }
    }
}
