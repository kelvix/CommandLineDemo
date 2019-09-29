using System;
using System.Threading;
using Newtonsoft.Json;
using Newtonsoft.Json.Converters;

namespace TestHarness.Models
{
    /// <summary>
    /// 
    /// </summary>
    public class TestMeta
    {
        public string Id { get; set; }
        [JsonConverter(typeof(StringEnumConverter))]
        public TestStatus Status { get; set; }
        [JsonIgnore]
        public CancellationToken CancellationToken { get; set; }
    }
}