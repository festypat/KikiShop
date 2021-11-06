using System;

namespace KikiShop.Helper.Exceptions
{
    public class ApplicationDataException : Exception
    {
        public ApplicationDataException(string message) : base(message) { }
    }
}
