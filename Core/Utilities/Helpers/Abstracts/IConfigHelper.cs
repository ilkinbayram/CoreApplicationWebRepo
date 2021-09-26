namespace Core.Utilities.Helpers.Abstracts
{
    public interface IConfigHelper
    {
        T GetSettingsData<T>(string parentKey, string childKey);
    }
}
