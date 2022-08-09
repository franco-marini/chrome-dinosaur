using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] private int spawnersAmount = 2;
  [SerializeField] private GameObject spawner;
  [SerializeField] float initialSpawnTime = 1f;
  [SerializeField] float intervalSpawnTime = 3f;
  private GameObject[] enemySpawners;
  private Vector2 managerPosition;
  private RectTransform managerTransform;
  public static SpawnManager Instance { get; private set; }

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
    CreateSpawners();
    InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
  }

  private void OrderSpawn()
  {
    int randomIndex = Random.Range(0, enemySpawners.Length);
    EnemySpawnerController enemySpawner = enemySpawners[randomIndex].GetComponent<EnemySpawnerController>();
    enemySpawner.SpawnEnemy();
  }

  private void CreateSpawners()
  {
    enemySpawners = new GameObject[spawnersAmount];
    managerPosition = transform.position;
    Vector2 managerScale = transform.localScale;
    // Review the formula
    float positionTopY = managerScale.y - (managerScale.y + managerPosition.y) - managerPosition.y;
    float spawnPositionY = managerPosition.y / spawnersAmount;
    float spawnScaleY = managerScale.y / spawnersAmount;
    for (int i = 0; i < spawnersAmount; i++)
    {
      Vector2 spawnPosition = managerPosition;
      float spawnerScaleY = spawner.transform.localScale.y;
      float spawnerPivotY = spawnerScaleY / 2;
      //   Debug.Log("position top: " + positionTopY);
      //   Debug.Log("spawner position Y: " + (spawnerPivotY + spawnerScaleY * i * 2));
      spawnPosition.y = positionTopY - (spawnerPivotY + spawnerScaleY * i * 2);
      //   Debug.Log("spawner position Y: ");
      enemySpawners[i] = Instantiate(spawner, spawnPosition, Quaternion.identity, transform);
    }
  }
}
