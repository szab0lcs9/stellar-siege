using UnityEngine;

namespace Assets.Scripts.Enemy
{
    public abstract class EnemyFactory
    {
        public abstract IEnemy SpawnEnemy(GameObject prefab, Vector3 position);
    }
}
