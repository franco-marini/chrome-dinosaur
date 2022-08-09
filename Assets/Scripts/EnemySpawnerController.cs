using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
  [SerializeField] private GameObject enemy;

  public void SpawnEnemy()
  {
    Instantiate(enemy, transform.position, Quaternion.identity);
  }
}
