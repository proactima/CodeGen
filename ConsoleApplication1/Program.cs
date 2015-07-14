using System;
using System.Collections.Immutable;
using System.Linq;
using CodeGen;
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

            var mail = MailAttachmentFromBlob.Create("", "", "");
            var a = InternalMailRequest.Create("", "", "", "", "");
            var b = a
                .WithMailContent("")
                .WithCompany("")
                .WithMailAttachementFromBlobs(ImmutableArray<MailAttachmentFromBlob>.Empty);

            Console.ReadLine();
        }
    }
}