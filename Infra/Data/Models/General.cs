using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infra.Data.Models
{
    public class ResultValue<T>
    {
        public int ErrorCode { get; set; }
        public bool ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
        public T Value { get; set; }

    }
    public class Abstract
    {
    }
    public class PostData<T>
    {
        public Origins Origins { get; set; }
        public T Value { get; set; }
    }
    public class Origins
    {
        public string Source { get; set; } 
        public string Version { get; set; } 
    }

    public class JwtToken
    {
        public string token { get; set; }
        public string expirationDate { get; set; }
    }

    public class Result
    {
        public int ErrorCode { get; set; }
        public bool ErrorStatus { get; set; }
        public string ErrorMessage { get; set; }
    }
    public class ResultError
    {
        public Result result(int messageCode, bool messageStatus, string messageString)
        {
            Result result = new Result();
            result.ErrorCode = messageCode;
            result.ErrorStatus = messageStatus;
            result.ErrorMessage = messageString;
            return result;
        }
    }

}
