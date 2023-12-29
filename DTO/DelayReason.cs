using System;

namespace DTO
{
    public class DelayReason
    {
        public int id { get; set; }
        public string name { get; set; }
        public TimeSpan delay { get; set; }
    }
}
