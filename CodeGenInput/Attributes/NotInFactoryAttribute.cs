using System;

namespace CodeGenInput.Attributes
{
    public class NotInFactoryAttribute : Attribute
    {
        public NotInFactoryAttribute()
        {
        }

        public NotInFactoryAttribute(string factoryInit)
        {
            FactoryInit = factoryInit;
        }
        public string FactoryInit { get; set; }
    }
}