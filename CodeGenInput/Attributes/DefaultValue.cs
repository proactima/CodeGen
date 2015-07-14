using System;

namespace CodeGenInput.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DefaultValue : Attribute
    {
        public DefaultValue()
        {
        }

        public DefaultValue(string factoryInit)
        {
            FactoryInit = factoryInit;
        }

        public string FactoryInit { get; set; }
    }
}