using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml.Linq;

namespace Channel9.Extensions
{
    internal class Throw
    {
        public static void IfIsNull(object argument, string argumentName)
        {
            if (argument == null)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void IfIsNullOrEmpty<T>(IEnumerable<T> argument, string argumentName)
        {
            IfIsNull(argument, argumentName);
            if (argument.Any() == false)
            {
                throw new ArgumentNullException(argumentName);
            }
        }

        public static void IfElementNameIsNotMatch(XElement element, XName elementName)
        {
            if (elementName != element.Name)
            {
                throw new ArgumentException($"[{element.Name}] is not [{elementName}] element.");
            }
        }
    }
}