using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackExchange.Redis;


namespace DataAccess_RedisCache_RepositoryAccess
{
    public class redisConnectionHelper
    {
        private static Lazy<ConnectionMultiplexer> lazyConnection = CreateConnection();

        private static Lazy<ConnectionMultiplexer> CreateConnection()
        {
            return new Lazy<ConnectionMultiplexer>( () =>
            {
                string cacheConnection = "172.17.0.2:15634";
                return ConnectionMultiplexer.Connect(cacheConnection);
            });
        }



        public static ConnectionMultiplexer connection
        {
            get
            {
                return lazyConnection.Value;
            }
            set
            {

            }

        }


    }
}
