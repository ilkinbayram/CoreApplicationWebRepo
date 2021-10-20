using System.Collections.Generic;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T>:DataResult<T>
    {
        public ErrorDataResult(T data, bool isProcessBroken, string message) : base(data, false, isProcessBroken, message)
        {
        }

        public ErrorDataResult(T data, bool isProcessBroken) : base(data, false, isProcessBroken)
        {
        }

        public ErrorDataResult(bool isProcessBroken, string message) : base(default, false, isProcessBroken, message)
        {

        }

        public ErrorDataResult(bool isProcessBroken, List<string> messages) : base(default, false, isProcessBroken, messages)
        {

        }

        public ErrorDataResult(string message) : base(default, false, false, message)
        {

        }

        public ErrorDataResult() : base(default, false, false)
        {

        }
    }
}
