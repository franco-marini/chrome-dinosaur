using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] int spawnersAmount = 2;
  [SerializeField] int enemiesAmount = 10;
  [SerializeField] float initialSpawnTime = 1f;
  [SerializeField] float intervalSpawnTime = 3f;
  private SpawnerController[] spawners;
  private Queue<GameObject> enemiesQueue;
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
    // TO-DO: Check if could show a develop warning
    ValidateInitialValues();
    CreateEnemies();
    CreateSpawners();
    InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
  }

  private void OrderSpawn()
  {
    int randomIndex = Random.Range(0, spawners.Length);
    GameObject firstEnemy = enemiesQueue.Dequeue();
    spawners[randomIndex].SpawnEnemy(firstEnemy);
  }

  private void CreateSpawners()
  {
    GameObject spawnerPrefab = Utils.GetPrefabResource("Spawner");
    Vector2 managerPosition = transform.position;
    Vector2 managerScale = transform.localScale;
    float managerPivot = Utils.GetFloatWith2Decimal(managerScale.y / 2);
    float positionTopY = Utils.GetFloatWith2Decimal(managerScale.y - ((managerPivot) - (managerPosition.y)));
    int spacesInsideManager = spawnersAmount * 2 - 1;
    float spawnerHeight = Utils.GetFloatWith1Decimal(managerScale.y / spacesInsideManager);
    float spawnerPivot = Utils.GetFloatWith2Decimal(spawnerHeight / 2);
    for (int i = 0; i < spacesInsideManager; i++)
    {
      if (i % 2 == 0)
      {
        float spawnPositionY = Utils.GetFloatWith2Decimal(positionTopY - spawnerPivot - spawnerHeight * i);
        Vector2 spawnPosition = new Vector2(managerPosition.x, spawnPositionY);
        Instantiate(spawnerPrefab, spawnPosition, Quaternion.identity, transform);
      }
    }
    spawners = GetComponentsInChildren<SpawnerController>();
  }

  private void CreateEnemies()
  {
    GameObject enemyPrefab = Utils.GetPrefabResource("Enemy");
    enemiesQueue = new Queue<GameObject>();
    for (int i = 0; i < enemiesAmount; i++)
    {
      GameObject newEnemy = Instantiate(enemyPrefab, transform.position, Quaternion.identity);
      enemiesQueue.Enqueue(newEnemy);
    }
  }

  private void ValidateInitialValues()
  {
    if (spawnersAmount <= 0)
    {
      spawnersAmount = 1;
    }
    if (enemiesAmount <= 2)
    {
      enemiesAmount = 3;
    }
    if (initialSpawnTime <= 0)
    {
      initialSpawnTime = 1f;
    }
    if (intervalSpawnTime <= 0)
    {
      intervalSpawnTime = 3f;
    }
  }

  public void AddEnemyToList(GameObject enemyGo)
  {
    enemiesQueue.Enqueue(enemyGo);
  }
}
