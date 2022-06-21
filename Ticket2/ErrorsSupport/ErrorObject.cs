using System;

namespace Ticket2.ErrorsSupport
{
    public class ErrorObject
    {
        public string ErrorMessage { get; private set; }
        public string? ErrorData { get; private set; }
        public string ErrorCode { get; private set; }
        public string ErrorCodeDb { get; private set; }
        
        public ErrorObject(Exception e, Ticket2Context context)
        {
            ErrorMessage = e.Message;
            ErrorData = e.StackTrace;
            BindViaDbAndMapError(context);
        }

        private void BindViaDbAndMapError(Ticket2Context context)
        {
            var externalErrorCode = context;
        }
    }
}