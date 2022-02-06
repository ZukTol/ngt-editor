using System;

namespace NgtEditor.Common.Utils
{
    public static class StringHelper
    {
        public static bool IsNullOrEmpty(this string str)
        {
            return string.IsNullOrEmpty(str);
        }
        
        public static bool OrdinalEquals(this string leftStr, string rightStr, bool ignoreCase = true)
        {
            return string.Equals(leftStr, rightStr, ignoreCase ? StringComparison.OrdinalIgnoreCase : StringComparison.Ordinal);
        }
    }
}