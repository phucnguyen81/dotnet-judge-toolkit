using System.Linq;

using Judge.Model;

namespace Judge {
    static class JudgeUrl {
        private const string BASE_URL = "https://api.judge0.com";

        internal static string Authentication(string tokenName, string token)
        {
            return Make("authenticate/", tokenName + "=" + token);
        }

        internal static string Authorization(string tokenName, string token)
        {
            return Make("authorize/", tokenName + "=" + token);
        }

        internal static string Submission(SubmissionParameters parameters)
        {
            return Make("submissions/",
                    GetBase64EncodedQuery(parameters.Base64Encoded),
                    GetWaitQuery(parameters.Wait));
        }

        internal static string GettingSubmission(GetSubmissionParms parms)
        {
            return Make("submissions/" + parms.Token,
                    GetBase64EncodedQuery(parms.Base64Encoded),
                    GetFieldsQuery(parms.Fields));
        }

        internal static string GettingAllSubmissions(GetAllSubmissionsParms parms)
        {
            return Make("submissions/",
                    GetBase64EncodedQuery(parms.Base64Encoded),
                    GetFieldsQuery(parms.Fields),
                    GetPageQuery(parms.Page),
                    GetPerPageQuery(parms.PerPage));
        }

        internal static string Languages()
        {
            return Make("languages/");
        }

        internal static string Statuses()
        {
            return Make("statuses/");
        }

        internal static string SystemInfo()
        {
            return Make("system_info/");
        }

        internal static string ConfigInfo()
        {
            return Make("config_info/");
        }

        internal static string Workers()
        {
            return Make("workers/");
        }

        private static string GetBase64EncodedQuery(bool? base64Encoded)
        {
            if (base64Encoded.HasValue)
            {
                if (base64Encoded.Value)
                {
                    return "base64_encoded=true";
                }
                else
                {
                    return "base64_encoded=false";
                }
            }
            else
            {
                return "";
            }
        }

        private static string GetWaitQuery(bool? wait)
        {
            if (wait.HasValue)
            {
                if (wait.Value)
                {
                    return "wait=true";
                }
                else
                {
                    return "wait=false";
                }
            }
            else
            {
                return "";
            }
        }

        private static string GetPageQuery(long? page)
        {
            if (page.HasValue)
            {
                return "page=" + page.Value;
            }
            else
            {
                return "";
            }
        }

        private static string GetPerPageQuery(long? perPage)
        {
            if (perPage.HasValue)
            {
                return "per_page=" + perPage.Value;
            }
            else
            {
                return "";
            }
        }

        private static string GetFieldsQuery(SubmissionField[] fields)
        {
            if (fields == null || fields.Length == 0)
            {
                return "";
            }

            return string.Join(",", fields.Select(field => ToStringValue(field)));
        }

        private static string ToStringValue(SubmissionField field)
        {
            string fieldJson = Serialize.ToJson(field);
            return fieldJson.Substring(1, fieldJson.Length - 2);
        }

        private static string Make(string function, params string[] queries)
        {
            string query = string.Join("&", queries);
            if (string.IsNullOrWhiteSpace(query)) {
                return string.Format("{0}/{1}",
                        BASE_URL, function);
            }
            else {
                return string.Format("{0}/{1}?{2}",
                        BASE_URL, function, query);
            }
        }

    }
}
