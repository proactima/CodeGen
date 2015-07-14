using System;
using System.Linq;
using CodeGen.Helpers;
using CodeGenInput.Attributes;

namespace ConsoleApplication1
{
    internal class Program
    {
        private static void Main(string[] args)
        {

            var includeInGenType = typeof(IncludeInGeneration);
            var allToGenerate = T4Helper.FindAllClassesToInclude(includeInGenType);
            var currentType = allToGenerate.First();
            var propertiesInType = currentType.GetProperties().ToList();
            var props = T4Helper.GetProperties(includeInGenType);

            var properties = T4Helper.GenerateDataForTemplate(propertiesInType);

            Console.ReadLine();
        }
    }
}