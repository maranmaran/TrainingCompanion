using System;
using System.Collections.Generic;
using System.Text;

namespace Backend.Service.Chat.NgChatModels
{
    public class ErrorViewModel
    {
        public string RequestId { get; set; }

        public bool ShowRequestId => !string.IsNullOrEmpty(RequestId);
    }
}
