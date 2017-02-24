using System;
using System.Collections.Concurrent;

namespace MedAssets.AMS.WinSvc.ADTMasterRouter
{

    public class LockProvider : ILockProvider
    {
        private readonly ConcurrentDictionary<string, object> _locks;
        private static readonly Lazy<LockProvider> _instance = new Lazy<LockProvider>(() => new LockProvider());

        public LockProvider()
        {
            _locks = new ConcurrentDictionary<string, object>();
        }

        public static ILockProvider Instance
        {
            get { return _instance.Value; }
        }

        public object GetLock(string key)
        {
            return _locks.GetOrAdd(key, (k) => new object());
        }
    }

    public interface ILockProvider
    {
        object GetLock(string key);
    }
}
