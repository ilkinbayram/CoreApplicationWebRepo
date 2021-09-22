namespace Core.Utilities.Results
{
    public class DataResult<T> : Result, IDataResult<T>
    {
        private T _data;
        public DataResult(T data,bool success, string message) : base(success, message)
        {
            _data = data;
        }

        public DataResult(T data, bool success):base(success)
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
