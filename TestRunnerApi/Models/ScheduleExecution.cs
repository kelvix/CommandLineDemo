namespace TestRunnerApi.Models
{
    public class ScheduleExecutionRequest
    {
        public string TestName { get; set; }
    }

    public class ScheduleExecutionResponse
    {
        public string TestName { get; set; }
        public TestStatus Status { get; set; }
    }
}