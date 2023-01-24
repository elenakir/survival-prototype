using UnityEngine;

namespace Survival.Effects
{
    public class ExplosionSpawner : MonoBehaviour
    {
        [SerializeField] private GameObject explosionPrefab;

        public void CreateExplosion(Vector3 location)
        {
            var exp = Instantiate(explosionPrefab);
            exp.transform.SetParent(transform);
            exp.transform.position = location;

            Destroy(exp, 5);
        }
    }
}
