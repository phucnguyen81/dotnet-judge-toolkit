using System;
using System.IO;
using System.Reflection;

namespace Judge.Test.Resource
{
    public class TestResource
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
    }
}
