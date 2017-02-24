using System;
using System.Threading;
using MedAssets.AMS.WinSvc.ADTMasterRouter;

namespace Demo.Locking
{
    public class Worker
    {
        private readonly string _name;
        private readonly TimeSpan _workTime;
        public static readonly object SyncLock = new object();

        public Worker(string name, TimeSpan workTime)
        {
            _name = name;
            _workTime = workTime;
        }

        public void DoWork(string lockKey = null)
        {
            var syncLock = LockProvider.Instance.GetLock(lockKey);

            lock (syncLock)
            {
                Thread.Sleep(_workTime);
                Console.WriteLine($"Worker:  {_name}, Status:  Complete");
            }
        }
    }
}