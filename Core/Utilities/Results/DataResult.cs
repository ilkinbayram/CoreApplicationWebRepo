namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        private T _data;
        public DataResult(T data,bool success, bool isProcessBroken, string message) : base(success, isProcessBroken, message)
        {
            _data = data;
        }

        public DataResult(T data, bool success, bool isProcessBroken):base(success, isProcessBroken)
        {
            _data = data;
        }

        public T Data => _data;

        public void SetData(T data)
        {
            _data = data;
        }
    }
}
