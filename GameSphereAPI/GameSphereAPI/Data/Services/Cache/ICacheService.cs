namespace GameSphereAPI.Data.Services.Cache
{
    public interface ICacheService
    {
        T GetData<T>(String key);

        bool SetData<T>(String key, T value, DateTimeOffset expirationTime);

        object RemoveData(String key);
    }
}