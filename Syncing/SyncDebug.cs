using System;
using System.Collections.Concurrent;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace DeveloperSample.Syncing
{
    public class SyncDebug
    {
        public List<string> InitializeList(IEnumerable<string> items)
        {
            var bag = new ConcurrentBag<string>();
            Parallel.ForEach(items,  i =>
            {
                bag.Add(i);
            });
            var list = bag.ToList();
            return list;
        }

        public Dictionary<int, string> InitializeDictionary(Func<int, string> getItem)
        {
            // Ok the original code has a problem with the closure we are using the same instance of
            // itemsToInitialize and iterate over them which could cause race conditions. So replace the commented
            // out code with Parallel Linq. NOte the original used 3 threads so lets keep it at 3:

            var itemsToInitialize = Enumerable.Range(0, 100).ToList();
            var concurrentDictionary = new ConcurrentDictionary<int, string>();
            var options = new ParallelOptions { MaxDegreeOfParallelism = 3 };
            Parallel.ForEach (itemsToInitialize, options, item => concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s));

            //var threads = Enumerable.Range(0, 3)
            //    .Select(i => new Thread(() => {
            //        foreach (var item in itemsToInitialize)
            //        {
            //            concurrentDictionary.AddOrUpdate(item, getItem, (_, s) => s);
            //        }
            //    }))
            //    .ToList();

            //foreach (var thread in threads)
            //{
            //    thread.Start();
            //}
            //foreach (var thread in threads)
            //{
            //    thread.Join();
            //}

            return concurrentDictionary.ToDictionary(kv => kv.Key, kv => kv.Value);
        }
    }
}