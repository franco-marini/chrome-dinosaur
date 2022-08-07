using UnityEngine;

public class EnemySpawnerController : MonoBehaviour
{
  [SerializeField] private GameObject enemy;
  [SerializeField] private float repeatTime = 3f;

  public static EnemySpawnerController Instance { get; private set; }
  private GameObject newEnemy;
  private Vector2 spawnPoint;

  private void Awake()
  {
    // If there is an instance, and it's not me, delete myself.
    if (Instance != null && Instance != this)
    {
      Destroy(this);
    }
    else
    {
      Instance = this;
    }
  }

  private void Start()
  {
    this.spawnPoint = transform.position;
    InvokeRepeating("SpawnNewEnemy", 0f, repeatTime);
  }

  private void SpawnNewEnemy()
  {
    newEnemy = Instantiate(enemy, spawnPoint, Quaternion.identity);
  }
}
