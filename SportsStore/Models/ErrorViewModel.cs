using System;

namespace SportsStore.Models
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }
        public string dummy1 { get; set;  }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}