namespace Core.Utilities.Helpers.Abstracts
{
    public interface ISessionStorageHelper
    {
        void Set(string key, string value, int expirationMinute = 15);
        void Remove(string key, string value);
        string GetValue(string key);

        void SetSessionLangIfNotExist();
    }
}
