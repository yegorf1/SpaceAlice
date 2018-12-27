using System.Collections;

namespace SpaceAlice.DataAccess.Entities {
    public class User {
        private static readonly Hashtable Locks = new Hashtable();
        private object _lockCache;
        
        public string Id { get; set; }

        /// <summary>
        /// Gets lock object for user. Locks are cached and stored for all application lifetime.
        /// </summary>
        /// <returns>Lock object</returns>
        public object GetLock() {
            if (_lockCache is null) {
                CacheLock();
            }

            return _lockCache;
        }

        private void CacheLock() {
            lock (Locks.SyncRoot) {
                if (Locks.ContainsKey(Id)) {
                    _lockCache = Locks[Id];
                } else {
                    _lockCache = Locks[Id] = new object();                    
                }
            }
        }
    }
}