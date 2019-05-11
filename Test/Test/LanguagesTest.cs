using System;
using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Judge.Model;

namespace Judge.Test
{
    [TestClass]
    public class LanguagesTest
    {
        [TestMethod]
        public void TestSerialization()
        {
            LanguageItem[] langs = new LanguageItem[]
            {
                new LanguageItem()
            };
        }

        [TestMethod]
        public void GetFromResources()
        {
            Assembly assem = this.GetType().Assembly;
            var resources = assem.GetManifestResourceNames();
            Console.WriteLine(resources);
            /* string resourceName = "Resource.language_items.json"; */
            /* using (Stream stream = assem.GetManifestResourceStream(resourceName)) */
            /* { */
            /*     using (var reader = new StreamReader(stream)) */
            /*     { */
            /*         reader.ReadToEnd(); */
            /*     } */
            /* } */
        }
    }
}
