// Add deserialize method with generic to Judge.Model
//
// Usage:
//
//    using Judge.Model;
//
//    SubmissionResult result = Deserialize.FromJson<SubmissionResult>(jsonString);

namespace Judge.Model
{
    using Newtonsoft.Json;

    public class Deserialize
    {
        public static T FromJson<T>(string json) => JsonConvert.DeserializeObject<T>(json, Judge.Model.Converter.Settings);
    }

}
