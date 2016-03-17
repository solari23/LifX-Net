using System;

namespace LifXNet
{
    /// <summary>
    /// Defines various internally used helpers.
    /// </summary>
    internal static class Helpers
    {
        public static void NullCheck(object parameter, string parameterName)
        {
            if (parameter == null)
            {
                throw new ArgumentNullException(parameterName);
            }
        }
    }
}
