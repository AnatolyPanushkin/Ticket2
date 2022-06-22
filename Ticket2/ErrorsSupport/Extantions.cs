using System;

namespace Ticket2.ErrorsSupport
{
    public static class Extantions
    {
        public static ErrorObject ToErrorObject(this Exception exception)
        {
            return new ErrorObject(exception);
        }
    }
}