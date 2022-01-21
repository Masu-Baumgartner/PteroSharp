using System;
using System.Collections.Generic;

namespace PteroSharp.Utils
{
    public class PteroApiKeyPool
    {
        private Dictionary<string, DateTime> Pool { get; set; }

        public int Timeout { get; set; } = 60;

        public PteroApiKeyPool()
        {
            Pool = new Dictionary<string, DateTime>();
        }

        public void AddKey(string key)
        {
            lock(Pool)
            {
                Pool.Add(key, DateTime.Now);
            }
        }

        public string Get()
        {
            string key = null;

            foreach(var k in Pool.Keys)
            {
                if((DateTime.Now - Pool[key]).TotalSeconds > Timeout)
                {
                    key = k;
                    break;
                }
            }

            return key;
        }

        public void SetTimeout(string key)
        {
            if(Pool.ContainsKey(key))
                Pool[key] = DateTime.Now;
        }
    }
}