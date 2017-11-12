using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace SoulCaptcha {
    public class BulletLender : SingletonMonoBehaviour<BulletLender> {
        public int bulletPreloadCount = 30;
        public List<GameObject> bullets;

        Dictionary<GameObject, BulletPool> pools = new Dictionary<GameObject, BulletPool>();

        // Use this for initialization
        protected override void Init () {
            CreatePools(bullets, bulletPreloadCount);
        }

        void CreatePools(List<GameObject> prefabs, int preloadCount) {
            foreach (GameObject prefab in prefabs) {
                BulletPool pool = new BulletPool(prefab);
                pool.PreloadAsync(preloadCount, 10).Subscribe();
                pools.Add(prefab, pool);
            }
        }

        public GameObject Rent(GameObject prefab) {
            Bullet bo = pools[prefab].Rent();
            bo.prefab = prefab;
            return bo.gameObject;
        }

        public void Return(GameObject go) {
            Bullet instance = go.GetComponent<Bullet>();
            pools[instance.prefab].Return(instance);
        }

        public void Return(Bullet instance) {
            pools[instance.prefab].Return(instance);
        }
    }
}
