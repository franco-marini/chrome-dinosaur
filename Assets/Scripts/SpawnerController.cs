using UnityEngine;

public class SpawnerController : MonoBehaviour
{
  [SerializeField] private GameObject enemy;

  public void SpawnEnemy()
  {
    Instantiate(enemy, transform.position, Quaternion.identity);
  }
}
