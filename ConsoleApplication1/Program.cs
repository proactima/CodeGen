﻿using System;
using System.Collections.Generic;
using System.Data.HashFunction;
using System.Linq;
using System.Reflection;
using System.Threading.Tasks;
using Ninject;

namespace ConsoleApplication1
{
    public class T4Info
    {
        public string PropertyName { get; set; }
        public string PropertyType { get; set; }
        public string GenericType { get; set; }
        public string CustomFactory { get; set; }
        public bool NotInFactory { get; set; }
    }
    internal class Program
    {
        private static void Main(string[] args)
        {
            var kernel = new StandardKernel();
            kernel.Bind<IHashShit>().To<Hasher>();
            kernel.Bind<IHashFunction>()
                .To<MurmurHash3>()
                .WithConstructorArgument("hashSize", 32)
                .WithConstructorArgument("seed", 1U);

            //HashTest(kernel).Wait();

            var includeAttr = typeof(IncludeInGenAttribute);
            var a = typeof(InternalMailRequest).GetProperties();
            var b = (from propertyInfo in a
                     from customAttributeData in propertyInfo.CustomAttributes
                     where customAttributeData.AttributeType == includeAttr
                     select propertyInfo)
                     .ToList();

            var fixPropNames = new Func<string, string>(x =>
            {
                var withoutStuff = x.Contains('`') ? x.Split('`').First() : x;

                switch (withoutStuff.ToLower())
                {
                    case "string":
                    case "int":
                        return withoutStuff.ToLower();
                    default:
                        return withoutStuff;
                }
            });

            var getCustomFactory = new Func<IEnumerable<CustomAttributeData>, string>(x =>
            {
                var customFactoryAttribute = typeof (NotInFactoryAttribute);
                foreach (var customAttributeData in x)
                {
                    if (customAttributeData.AttributeType == customFactoryAttribute)
                    {
                        if (customAttributeData.ConstructorArguments.Any())
                            return customAttributeData.ConstructorArguments.First().Value as string;
                    }
                }
                return string.Empty;
            });

            var properties = b.Select(x =>
            {
                var customFactoryCode = getCustomFactory(x.CustomAttributes);

                return new T4Info
                {
                    PropertyName = x.Name,
                    PropertyType = fixPropNames(x.PropertyType.Name),
                    GenericType =
                        (x.PropertyType.GenericTypeArguments.Any())
                            ? x.PropertyType.GenericTypeArguments.First().Name
                            : String.Empty,
                    CustomFactory = customFactoryCode,
                    NotInFactory = (!string.IsNullOrEmpty(customFactoryCode))
                };
            }).ToList();

            var constructs = properties
                .Select(x =>
                {
                    if(string.IsNullOrEmpty(x.GenericType))
                        return x.PropertyType + " " + x.PropertyName.ToLower();

                    return x.PropertyType + "<" + x.GenericType + ">" + " " + x.PropertyName.ToLower();
                })
                .ToList()
                .Aggregate((current, next) => current + ",\r\n" + next );

            var factoryParams = properties
                .Where(x => !x.NotInFactory)
                .Select(x => x.PropertyType + " " + x.PropertyName.ToLower())
                .ToList()
                .Aggregate((current, next) => current + ",\r\n" + next);

            var factory = properties
                .Select(x => x.NotInFactory ? x.CustomFactory : x.PropertyName.ToLower())
                .ToList()
                .Aggregate((current, next) => current + ",\r\n" + next);

            Console.ReadLine();
        }


        public static async Task HashTest(IKernel kernel)
        {
            var hasher = kernel.Get<IHashShit>();

            var sizes = new List<int>();
            for (var i = 0; i < 10000; i++)
            {
                var testString = Guid.NewGuid().ToString();
                var hash = hasher.Hash(testString);

                sizes.Add(hash);
            }

            var high = sizes.Max();
            var low = sizes.Min();

            Console.WriteLine($"High:{high} - Low:{low}");
        }
    }

    public interface IHashShit
    {
        int Hash(string input);
    }

    public class Hasher : IHashShit
    {
        private readonly IHashFunction _hasher;

        public Hasher(IHashFunction hasher)
        {
            _hasher = hasher;
        }

        public int Hash(string input)
        {
            var hashBytes = _hasher.ComputeHash(input);

            var hash = BitConverter.ToUInt32(hashBytes, 0);
            var hashMod = hash % 128;

            return Convert.ToInt32(hashMod);
        }
    }
}