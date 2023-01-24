using Morpeh;
using UnityEngine;
using Zenject;
using Survival.Player;
using Survival.Bullets;

public class BulletSpawner : MonoBehaviour
{
    [SerializeField] private EntityProvider prefab;

    [Inject] private Player player;

    public void CreateBullet()
    {
        EntityProvider e = Instantiate(prefab);

        e.transform.SetParent(transform);
        e.transform.position = player.transform.position;

        e.transform.localEulerAngles = new Vector3(e.transform.localEulerAngles.x,
            player.transform.localEulerAngles.y + 90,
            e.transform.localEulerAngles.z);

        e.GetComponent<Rigidbody>().AddForce(player.transform.forward * 30f, ForceMode.Impulse);

        e.Entity.RemoveComponent<BulletSpawnComponent>();
    }
}
