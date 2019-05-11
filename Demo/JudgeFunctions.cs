using Judge.Model;

namespace Judge
{
    public static class Functions
    {
        public static Response<string> Authenticate(
                string token, string tokenName = "X-Auth-Token")
        {
            string url = JudgeUrl.Authentication(tokenName, token);
            Rest.Request request = new Rest.Request(url, "POST");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<string>(response);
        }

        public static Response<string> Authorize(
                string token, string tokenName = "X-Auth-Token")
        {
            string url = JudgeUrl.Authorization(tokenName, token);
            Rest.Request request = new Rest.Request(url, "POST");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<string>(response);
        }

        public static Response<SubmissionResult> Submit(Submission submission)
        {
            return Submit(submission, new SubmissionParameters());
        }

        public static Response<SubmissionResult> Submit(
                Submission submission, SubmissionParameters parameters)
        {
            string url = JudgeUrl.Submission(parameters);
            string contentJson = Serialize.ToJson(submission);
            Rest.Request request = new Rest.Request(url, "POST", contentJson);
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<SubmissionResult>(response);
        }

        public static Response<SubmissionResult> GetSubmission(GetSubmissionParms parms)
        {
            string url = JudgeUrl.GettingSubmission(parms);
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<SubmissionResult>(response);
        }

        public static Response<SubmissionsPage> GetAllSubmissions(
                GetAllSubmissionsParms parms)
        {
            string url = JudgeUrl.GettingAllSubmissions(parms);
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<SubmissionsPage>(response);
        }

        public static Response<LanguageItem[]> GetLanguages()
        {
            string url = JudgeUrl.Languages();
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<LanguageItem[]>(response);
        }

        public static Response<SubmissionStatus[]> GetStatuses()
        {
            string url = JudgeUrl.Statuses();
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<SubmissionStatus[]>(response);
        }

        public static Response<SystemInfo> GetSystemInfo()
        {
            string url = JudgeUrl.SystemInfo();
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<SystemInfo>(response);
        }

        public static Response<ConfigInfo> GetConfigInfo()
        {
            string url = JudgeUrl.ConfigInfo();
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<ConfigInfo>(response);
        }

        public static Response<Worker[]> GetWorkers()
        {
            string url = JudgeUrl.Workers();
            Rest.Request request = new Rest.Request(url, "GET");
            Rest.Response response = Rest.Send(request);
            return JudgeResponse<Worker[]>(response);
        }

        static Response<T> JudgeResponse<T>(Rest.Response response)
        {
            T model = Deserialize.FromJson<T>(response.Json);
            return new Response<T>() {
                IsSuccess = response.IsSuccessStatusCode,
                StatusCode = response.StatusCode,
                StatusMessage = response.StatusMessage,
                Model = model
            };
        }
    }
}

