using System;

using Judge.Model;

namespace Judge {
    class MainClass
    {
        static void Main(string[] args)
        {
            TestAuthenticate();
            TestAuthorize();
            string token = TestSubmit();
            TestGetSubmission(token);
            TestGetAllSubmissions();
            TestGetLanguages();
            TestGetStatuses();
            TestGetSystemInfo();
            TestGetConfigInfo();
            TestGetWorkers();
        }

        static void TestAuthenticate()
        {
            string token = "f6583e60-b13b-4228-b554-2eb332ca64e7";
            Response<string> authResponse = Functions.Authenticate(token);
            Console.WriteLine("Authentication response: " + authResponse);
        }

        static void TestAuthorize()
        {
            string token = "f6583e60-b13b-4228-b554-2eb332ca64e7";
            Response<string> authResponse = Functions.Authorize(token);
            Console.WriteLine("Authorization response: " + authResponse);
        }

        static string TestSubmit()
        {
            Response<SubmissionResult> response = DoSubmit();
            SubmissionResult result = response.Model;

            Console.WriteLine("Output: " + result.Stdout);
            if (!String.IsNullOrWhiteSpace(result.Stderr))
            {
                Console.WriteLine("Error: " + result.Stderr);
            }
            if (!String.IsNullOrWhiteSpace(result.Message))
            {
                Console.WriteLine("Message: " + result.Message);
            }
            if (result.Status != null)
            {
                Console.WriteLine("Status: " + result.Status.Description);
            }

            return response.Model.Token;
        }

        static void TestGetSubmission(string token)
        {
            Console.WriteLine("Submission token: " + token);
            GetSubmissionParms parms = new GetSubmissionParms() {
                Token = token,
                      Fields = new SubmissionField[] {
                          SubmissionField.Token,
                          SubmissionField.Stdout
                      }
            };
            Response<SubmissionResult> submission;
            submission = Functions.GetSubmission(parms);
            Console.WriteLine("Get submission: " + submission);
        }

        // TODO Response shows the request is Forbidden
        static void TestGetAllSubmissions()
        {
            GetAllSubmissionsParms parms;
            parms = new GetAllSubmissionsParms() {
                Fields = new SubmissionField[] {
                    SubmissionField.Status,
                    SubmissionField.Language,
                    SubmissionField.Time
                },
                PerPage = 3
            };
            Response<SubmissionsPage> submissions;
            submissions = Functions.GetAllSubmissions(parms);
            Console.WriteLine("Get submissions: " + submissions);
        }

        static void TestGetLanguages()
        {
            Response<LanguageItem[]> languages = Functions.GetLanguages();
            foreach (LanguageItem lang in languages.Model)
            {
                Console.WriteLine("Language: id=" + lang.Id + ", name=" + lang.Name);
            }
        }

        static void TestGetStatuses()
        {
            Response<SubmissionStatus[]> statuses = Functions.GetStatuses();
            foreach (SubmissionStatus lang in statuses.Model)
            {
                Console.WriteLine("Status: id=" + lang.Id + ", description=" + lang.Description);
            }
        }

        static void TestGetSystemInfo()
        {
            Response<SystemInfo> systemInfo = Functions.GetSystemInfo();
            Console.WriteLine("System info: " + systemInfo);
            Console.WriteLine("CPU(s): " + systemInfo.Model.CpuS);
        }

        static void TestGetConfigInfo()
        {
            Response<ConfigInfo> configInfo = Functions.GetConfigInfo();
            Console.WriteLine("Config info: " + configInfo);
            Console.WriteLine("Number of runs: " + configInfo.Model.NumberOfRuns);
        }

        static void TestGetWorkers()
        {
            Response<Worker[]> workersResponse = Functions.GetWorkers();
            Worker[] workers = workersResponse.Model;
            Console.WriteLine("No of workers: " + workers.Length);
            foreach (Worker worker in workers)
            {
                Console.WriteLine("Worker: queue=" + worker.Queue);
            }
        }

        static Response<SubmissionResult> DoSubmit()
        {
            SubmissionParameters parameters = new SubmissionParameters()
            {
                Wait = true
            };

            Submission submission = new Submission()
            {
                SourceCode = "print('Hello World')",
                           ExpectedOutput = null,
                           Stdin = "",
                           NumberOfRuns = 1,
                           LanguageId = 34
            };

            return Functions.Submit(submission, parameters);
        }
    }
}
