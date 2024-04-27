using BGS.Util;
using UnityEngine;

namespace BGS.Gameplay
{
    public class UiItemPooler : Pooler<UiItem>
    {
        private Transform _parent;
        public void InitPooler(UiItem prefab,Transform parent)
        {
            _parent = parent;
            Init(1000,1000,prefab);
        }

        protected override UiItem OnSpawn(UiItem prefab, Vector3 pos = default, Quaternion rot = default, Transform parent = null)
        {
            var ui  = base.OnSpawn(prefab, pos, rot, _parent);
            return ui;
        }

        public UiItem GetItem()
        {
            return Get();
        }

        public void ReleaseItem(UiItem item)
        {
            Release(item);
        }   
    }
}