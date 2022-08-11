using UnityEngine;

public class SpawnerController : MonoBehaviour
{
  public void SpawnEnemy(GameObject enemy)
  {
    Rigidbody2D enemyRb = enemy.GetComponent<Rigidbody2D>();
    enemyRb.transform.position = transform.position;
    enemyRb.transform.rotation = Quaternion.identity;
    enemy.gameObject.SetActive(true);
  }
}
