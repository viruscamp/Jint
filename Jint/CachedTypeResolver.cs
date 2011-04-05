using System;
using System.Collections.Generic;
using System.Text;
using System.Reflection;
using System.Threading;

namespace Jint {
    public class CachedTypeResolver : ITypeResolver {
        Dictionary<string, Type> m_cache = new Dictionary<string, Type>();
        ReaderWriterLock m_lock = new ReaderWriterLock();
        static CachedTypeResolver m_default;

        public static CachedTypeResolver Default {
            get {
                lock (typeof(CachedTypeResolver)) {
                    if (m_default == null)
                        m_default = new CachedTypeResolver();
                    return m_default;
                }
            }
        }

        public Type ResolveType(string fullname) {
            m_lock.AcquireReaderLock(Timeout.Infinite);

            try {
                if (m_cache.ContainsKey(fullname)) {
                    return m_cache[fullname];
                }
            }
            finally {
                m_lock.ReleaseReaderLock();
            }

            Type type = null;
            foreach (Assembly a in AppDomain.CurrentDomain.GetAssemblies()) {
                type = a.GetType(fullname, false, false);

                if (type != null) {
                    break;
                }
            }

            m_lock.AcquireWriterLock(Timeout.Infinite);

            try {
                m_cache.Add(fullname, type);
                return type;
            }
            finally {
                m_lock.ReleaseWriterLock();
            }
        }
    }
}
