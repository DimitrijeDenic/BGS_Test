using UnityEngine;
using UnityEngine.Pool;
using Object = UnityEngine.Object;

namespace BGS.Util
{
    public class Pooler<T> where T : MonoBehaviour
    {
        private ObjectPool<T> _pool;

        protected void Init(int defaultCapacity, int maxSize, T prefab)
        {
            _pool = new ObjectPool<T>(() => OnSpawn(prefab),
                OnGet,
                OnRelease,
                OnDestroy,
                true, defaultCapacity, maxSize);
        }

        protected ObjectPool<T> GetPool()
        {
            return _pool;
        }
        protected virtual T OnSpawn(T prefab,Vector3 pos = default,Quaternion rot = default,Transform parent = null)
        {
            return _pool == null ? null : Object.Instantiate(prefab,pos,rot,parent);
        }
        protected virtual void OnGet(T obj)
        {
            obj.gameObject.SetActive(true);
        }
        protected virtual void OnRelease(T obj)
        {
            obj.gameObject.SetActive(false);
        }

        private static void OnDestroy(T obj)
        {
            Object.Destroy(obj.gameObject);
        }

        protected T Get()
        {
            return _pool.Get();
        }

        protected void Release(T toRelease)
        {
            _pool.Release(toRelease);
        }
    }
}