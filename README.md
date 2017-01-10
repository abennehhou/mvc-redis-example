MVC Redis Example
====================================

This example is an **MVC** project using [**StackExchange.Redis**](https://github.com/StackExchange/StackExchange.Redis) to connect to a **Redis** server and perform basic operations.

# Setup

* Run Redis service
* Change *RedisDatabase* in Web.config file to use your server, specify port if it is not the default one.

# Run

* Run the application
* Open a redis client *redis-cli.exe* and type `monitor` to track all the operations in redis database.
