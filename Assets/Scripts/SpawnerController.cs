using UnityEngine;

public class SpawnerController : MonoBehaviour
{
  public void SpawnEnemy(GameObject enemy)
  {
    enemy.transform.position = transform.position;
    enemy.transform.rotation = Quaternion.identity;
    enemy.SetActive(true);
  }
}
