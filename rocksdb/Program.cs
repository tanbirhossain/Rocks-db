using RocksDbSharp;
using System;
using System.IO;

namespace rocksdb
{
    class Program
    {
        static void Main(string[] args)
        {
            string temp = Path.GetTempPath();
            var testdir = Path.Combine(temp, "functional_test");
            var testdb = Path.Combine(testdir, "main");
            var testcp = Path.Combine(testdir, "cp");
            var path = Environment.ExpandEnvironmentVariables(testdb);
            var cppath = Environment.ExpandEnvironmentVariables(testcp);

            if (Directory.Exists(testdir))
                Directory.Delete(testdir, true);
            Directory.CreateDirectory(testdir);



            var options = new DbOptions()
       .SetCreateIfMissing(true);
            using (var db = RocksDb.Open(options, path))
            {
                // Using strings below, but can also use byte arrays for both keys and values
                // much care has been taken to minimize buffer copying
                db.Put("key", "value");
                string value = db.Get("key");
                db.Remove("key");
            }
            Console.ReadKey();
        }
    }
}
