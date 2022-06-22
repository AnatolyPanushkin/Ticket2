using System;
using System.Diagnostics;
using Microsoft.Data.SqlClient;
using Npgsql;

namespace Ticket2.ErrorsSupport
{
    public class ErrorObject
    {
        public string ErrorMessage { get; private set; }
        public string? ErrorData { get; private set; }
        public string ErrorCode { get; private set; }
        public string ErrorCodeDb { get; private set; }
        
        public ErrorObject(Exception e)
        {
            ErrorData = e.StackTrace;
            BindAndMapError(e);
        }

        private void BindAndMapError(Exception e)
        {
            if (e.InnerException is PostgresException npgex && npgex.SqlState == PostgresErrorCodes.UniqueViolation)
            {
                ErrorCode = "409";
                ErrorCodeDb = "2627";
                ErrorMessage = "ticket already is payed!";
            }
            else
            {
                ErrorMessage = e.Message;
            }
            /*if (e.InnerException.InnerException is SqlException sqlException)
            {
                switch (sqlException.Number)
                {
                    case 2627:
                    {
                        ErrorCode = "409";
                        ErrorCodeDb = "2627";
                        ErrorMessage = "ticket already is payed!";
                        break;
                    }
                }
            }*/
            
        }
        
    }
}