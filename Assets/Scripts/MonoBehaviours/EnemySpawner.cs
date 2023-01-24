using UnityEngine;

namespace Survival.Enemy
{
    public class EnemySpawner : MonoBehaviour
    {
        [SerializeField] private EnemiesConfig config;

        [SerializeField] private int maxCapacity = 100;

        private int enemiesCounter = 0;

        //private Vector3 leftBottom;
        //private Vector3 rightTop;

        private void Awake()
        {
            //leftBottom = Camera.main.ScreenToWorldPoint(new Vector3(0f, 0f, 7));
            //rightTop = Camera.main.ScreenToWorldPoint(new Vector3(Camera.main.pixelWidth, Camera.main.pixelHeight, 7));
        }

        public void Spawn()
        {
            if (enemiesCounter < maxCapacity)
            {
                var rand = Random.Range(0, config.enemies.Length);

                var enemy = Instantiate(config.enemies[rand]);

                enemy.transform.SetParent(transform);

                SetSide(enemy);

                enemiesCounter++;
            }
        }

        public void DecreaseCount() => enemiesCounter--;

        private void SetSide(GameObject enemy)
        {
            var side = Random.Range(0, 4);

            switch (side)
            {
                case 0:
                    enemy.transform.position = new Vector3(Random.Range(-15, -10), 0, Random.Range(-9, 9));
                    break;
                case 1:
                    enemy.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(7, 9));
                    break;
                case 2:
                    enemy.transform.position = new Vector3(Random.Range(10, 15), 0, Random.Range(-9, 9));
                    break;
                case 3:
                    enemy.transform.position = new Vector3(Random.Range(-10, 10), 0, Random.Range(-9, -7));
                    break;
                default:
                    break;
            }
        }
    }
}
