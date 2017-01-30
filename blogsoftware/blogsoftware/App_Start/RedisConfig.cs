using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using StackExchange.Redis;

namespace blogsoftware.App_Start
{
    public class RedisConfig
    {
        private static readonly Lazy<ConnectionMultiplexer> LazyRedis;

        static RedisConfig()
        {
            var configOptions = new ConfigurationOptions
            {
                EndPoints = {"localhost"}
            };

            LazyRedis = new Lazy<ConnectionMultiplexer>(() => ConnectionMultiplexer.Connect(configOptions));
        }

        public static ConnectionMultiplexer Connection => LazyRedis.Value;
        public static IDatabase RedisCache => Connection.GetDatabase();


    }
}