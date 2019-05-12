using System;

using Judge.Model;

namespace Judge.Demo {
    /**
     * An example of running source code using the took kit
     */
    class JudgeDemo
    {
        static void Main(string[] args)
        {
            SubmitCodeToRun();
        }

        static void SubmitCodeToRun()
        {
            Response<SubmissionResult> response = DoSubmitCode();
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
        }

        static Response<SubmissionResult> DoSubmitCode()
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

            Console.WriteLine("Source code: " + submission.SourceCode);

            return Functions.Submit(submission, parameters);
        }
    }
}
