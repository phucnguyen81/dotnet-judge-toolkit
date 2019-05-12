using System;

using Microsoft.VisualStudio.TestTools.UnitTesting;

using Newtonsoft.Json;

using Judge.Model;
using TestUtil = Judge.Test.Util.TestUtil;

namespace Judge.Test
{
    [TestClass]
    public class JudgeModelTests
    {
        [TestMethod]
        public void TestLanguageItemsConversion()
        {
            string jsonExpected = TestUtil.Read("language_items.json");
            LanguageItem[] items = JsonConvert.DeserializeObject<LanguageItem[]>(jsonExpected);
            string jsonActual = JsonConvert.SerializeObject(items);
            TestUtil.AssertJsonEqual(jsonExpected, jsonActual);
        }

        [TestMethod]
        public void TestSubmissionsRequestConversion()
        {
            string jsonExpected = TestUtil.Read("submission_request.json");
            Submission submission = JsonConvert.DeserializeObject<Submission>(jsonExpected);
            string jsonActual = JsonConvert.SerializeObject(submission);
            TestUtil.AssertJsonEqual(jsonExpected, jsonActual);
        }

        [TestMethod]
        public void TestSubmissionsResponseConversion()
        {
            string jsonExpected = TestUtil.Read("submission_response.json");
            SubmissionResult model = JsonConvert.DeserializeObject<SubmissionResult>(jsonExpected);
            string jsonActual = JsonConvert.SerializeObject(model);
            TestUtil.AssertJsonEqual(jsonExpected, jsonActual);
        }

    }

}
