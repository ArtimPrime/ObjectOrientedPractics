using System;
using System.Collections.Generic;
using System.Text;

namespace ObjectOrientedPractics.Services
{
    public static class ValueValidator
    {
        public static void AssertStringOnLength(string value, int maxLength, string propertyName)
        {
            if (value.Length > maxLength)
            {
                throw new ArgumentException($"{propertyName} must be less than {maxLength} chars");
            }
        }
    }
}
