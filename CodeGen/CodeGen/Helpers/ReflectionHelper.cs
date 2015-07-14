using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using CodeGenInput;
using CodeGenInput.Attributes;

namespace CodeGen.Helpers
{
    public static class ReflectionHelper
    {
        public static List<Type> FindAllClassesToInclude(Type typeToFind)
        {
            var sourceAssembly = Assembly.GetAssembly(typeToFind);

            var typesToProcess = (from obj in sourceAssembly.GetExportedTypes()
                let customAttributes = obj.CustomAttributes
                from attribute in customAttributes
                where attribute.AttributeType == typeToFind
                select obj
                ).ToList();

            return typesToProcess;
        }

        public static List<PropertyInfo> GetProperties(Type currentType)
        {
            var propertiesInType = currentType.GetProperties();
            var props = (from propertyInfo in propertiesInType
                from customAttributeData in propertyInfo.CustomAttributes
                select propertyInfo)
                .ToList();

            return props;
        }

        public static List<T4Info> GenerateDataForTemplate(List<PropertyInfo> properties)
        {
            var result = (from property in properties
                let customFactoryCode = GetCustomFactory(property.CustomAttributes)
                select new T4Info
                {
                    PropertyName = property.Name,
                    PropertyType = FixPropertyName(property.PropertyType.Name),
                    GenericType =
                        (property.PropertyType.GenericTypeArguments.Any())
                            ? GetClassName(property.PropertyType.GenericTypeArguments.First().Name)
                            : string.Empty,
                    CustomFactory = customFactoryCode,
                    NotInFactory = (!string.IsNullOrEmpty(customFactoryCode)),
                    IncludeInWith = IncludeInWith(property.CustomAttributes),
                    UseOptionWrapper = ShouldWrapInOptions(property.CustomAttributes)
                }).ToList();

            return result;
        }

        public static string FixPropertyName(string input)
        {
            var withoutStuff = input.Contains('`') ? input.Split('`')[0] : input;

            switch (withoutStuff.ToLower())
            {
                case "string":
                case "int":
                    return withoutStuff.ToLower();
                default:
                    return withoutStuff;
            }
        }

        public static string GetCustomFactory(IEnumerable<CustomAttributeData> attributeData)
        {
            var customFactoryAttribute = typeof (NotInFactoryAttribute);

            foreach (var customAttributeData in attributeData
                .Where(x => x.AttributeType == customFactoryAttribute)
                .Where(x => x.ConstructorArguments.Any()))
            {
                return customAttributeData.ConstructorArguments.First().Value as string;
            }

            return string.Empty;
        }

        public static bool IncludeInWith(IEnumerable<CustomAttributeData> attributeData)
        {
            var excludeFromWithAttr = typeof (ExcludeFromWithAttribute);
            return attributeData.All(x => x.AttributeType != excludeFromWithAttr);
        }

        public static bool ShouldWrapInOptions(IEnumerable<CustomAttributeData> attributeData)
        {
            var excludeFromWithAttr = typeof (ExcludeFromWithAttribute);
            return attributeData.Any(x => x.AttributeType == excludeFromWithAttr);
        }

        public static string GetClassName(string input)
        {
            return input.Split('_')[0];
        }

        public static string ToCamelCase(string input)
        {
            var first = input[0].ToString().ToLowerInvariant();
            return first + input.Substring(1);
        }

        public static string Indent(int levels)
        {
            return new string(' ', 4 * levels);
        }

        public static string GetPrivateConstructorArgs(List<T4Info> properties)
        {
            var result = properties
                .Select(x =>
                {
                    if (string.IsNullOrEmpty(x.GenericType))
                        return x.PropertyType + " " + ToCamelCase(x.PropertyName);

                    return x.PropertyType + "<" + x.GenericType + ">" + " " + ToCamelCase(x.PropertyName);
                })
                .ToList()
                .Aggregate((current, next) => current + ",\r\n" + Indent(3) + next);

            return result;
        }
    }
}