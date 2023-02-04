using StackExchange.Redis;

namespace Bookstore.Api.Helper
{
    public static class RedisHelper
    {
        public static bool IsCheckNullOrEmpty(this RedisValue redisValue)
        {
            if (!redisValue.IsNull)
            {
                return false; 
            }
            return true;
        }
    }
}