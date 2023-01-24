using UnityEngine;

[CreateAssetMenu(fileName = "EnemiesConfig", menuName = "Enemy/EnemiesConfig", order = 0)]
public sealed class EnemiesConfig : ScriptableObject 
{
    public GameObject[] enemies;
}