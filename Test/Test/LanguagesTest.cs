using System;
using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;
using Newtonsoft.Json;

using Judge.Model;
using TestResource = Judge.Test.Resource.TestResource;

namespace Judge.Test
{
    [TestClass]
    public class LanguagesTest
    {
        [TestMethod]
        public void TestConversionWorks()
        {
            string jsonExpected = TestResource.Read("language_items.json");
            LanguageItem[] items = JsonConvert.DeserializeObject<LanguageItem[]>(jsonExpected);
            string jsonActual = JsonConvert.SerializeObject(items);
            Assert.AreEqual(jsonExpected, jsonActual);
        }
    }
}
