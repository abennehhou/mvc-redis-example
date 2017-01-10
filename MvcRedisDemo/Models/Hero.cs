using System;

namespace MvcRedisDemo.Models
{
    public class Hero
    {
        public string Id { get; set; }

        public string Name { get; set; }

        public string Description { get; set; }

        public int Score { get; set; }

        public DateTime CreationDate { get; set; }

        public string Status { get; set; }
    }
}