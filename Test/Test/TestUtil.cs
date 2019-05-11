using System;
using System.IO;
using System.Reflection;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json.Linq;

namespace Judge.Test.Util
{
    public class TestUtil
    {
        // Read embedded resources in the directory of this class to string
        // path = e.g. names.json, where names.json is a file in the directory of this class
        public static string Read(string path)
        {
            Assembly assem = Assembly.GetExecutingAssembly();
            string assemName = assem.GetName().Name;
            string resourceName = assemName + ".Resource." + path;
            using (Stream stream = assem.GetManifestResourceStream(resourceName))
            {
                if (stream == null)
                {
                    throw new IOException("Failed to get resource: " + resourceName);
                }
                using (var reader = new StreamReader(stream))
                {
                    return reader.ReadToEnd();
                }
            }
        }

        public static void AssertJsonEqual(string expectedJson, string actualJson)
        {
            expectedJson = JToken.Parse(expectedJson).ToString().Trim();
            actualJson = JToken.Parse(actualJson).ToString().Trim();
            Assert.AreEqual(expectedJson, actualJson);
        }
    }
}
