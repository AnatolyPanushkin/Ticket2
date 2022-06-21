using System;

namespace Ticket2.ErrorsSupport
{
    public static class Extantions
    {
        public static ErrorObject ToErrorObject(this Exception exception, Ticket2Context context)
        {
            return new ErrorObject(exception, context);
        }
    }
}