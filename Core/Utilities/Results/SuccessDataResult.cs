namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        public SuccessDataResult(T data, string message) : base(data, true, false, message)
        {
        }

        public SuccessDataResult(T data) : base(data, true, false)
        {
        }

        public SuccessDataResult(string message) : base(default, true, false, message)
        {

        }

        public SuccessDataResult() : base(default, true, false)
        {

        }
    }
}
