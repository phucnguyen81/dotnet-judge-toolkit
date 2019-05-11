using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using Judge.Model;
using TestUtil = Judge.Test.Util.TestUtil;

namespace Judge.Test
{
    [TestClass]
    public class LanguagesTest
    {
        [TestMethod]
        public void TestConversionIsReversible()
        {
            string jsonExpected = TestUtil.Read("language_items.json");
            LanguageItem[] items = JsonConvert.DeserializeObject<LanguageItem[]>(jsonExpected);
            string jsonActual = JsonConvert.SerializeObject(items);
            TestUtil.AssertJsonEqual(jsonExpected, jsonActual);
        }
    }
}
