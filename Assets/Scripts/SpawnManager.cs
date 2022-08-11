using UnityEngine;
using System.Collections.Generic;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] int spawnersAmount = 2;
  [SerializeField] int enemiesAmount = 10;
  [SerializeField] GameObject spawner;
  [SerializeField] GameObject enemy;
  [SerializeField] float initialSpawnTime = 1f;
  [SerializeField] float intervalSpawnTime = 3f;
  private SpawnerController[] spawners;
  private List<GameObject> enemiesQueue;
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
    CreateEnemies();
    CreateSpawners();
    spawners = GetComponentsInChildren<SpawnerController>();
    InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
  }

  private void OrderSpawn()
  {
    int randomIndex = Random.Range(0, spawners.Length);
    GameObject firstEnemy = enemiesQueue[0];
    enemiesQueue.RemoveAt(0);
    spawners[randomIndex].SpawnEnemy(firstEnemy);
  }

  private float GetFloatWith1Decimal(float value)
  {
    return Mathf.Round(value * 10.0f) * 0.1f;
  }

  private float GetFloatWith2Decimal(float value)
  {
    return Mathf.Round(value * 100f) / 100f;
  }


  private void CreateSpawners()
  {
    managerPosition = transform.position;
    Vector2 managerScale = transform.localScale;
    float managerPivot = GetFloatWith2Decimal(managerScale.y / 2);
    float positionTopY = GetFloatWith2Decimal(managerScale.y - ((managerPivot) - (managerPosition.y)));
    int spacesInsideManager = spawnersAmount * 2 - 1;
    float spawnerHeight = GetFloatWith1Decimal(managerScale.y / spacesInsideManager);
    float spawnerPivot = GetFloatWith2Decimal(spawnerHeight / 2);
    for (int i = 0; i < spacesInsideManager; i++)
    {
      if (i % 2 == 0)
      {
        float spawnPositionY = GetFloatWith2Decimal(positionTopY - spawnerPivot - spawnerHeight * i);
        Vector2 spawnPosition = new Vector2(managerPosition.x, spawnPositionY);
        Instantiate(spawner, spawnPosition, Quaternion.identity, transform);
      }
    }
  }

  private void CreateEnemies()
  {
    enemiesQueue = new List<GameObject>();
    for (int i = 0; i < enemiesAmount; i++)
    {
      GameObject newEnemy = Instantiate(enemy, transform.position, Quaternion.identity);
      enemiesQueue.Add(newEnemy);
    }
  }

  public void AddEnemyToList(GameObject enemyGo)
  {
    enemiesQueue.Add(enemyGo);
  }
}
