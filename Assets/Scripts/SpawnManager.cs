using UnityEngine;

public class SpawnManager : MonoBehaviour
{
  [SerializeField] private int spawnersAmount = 2;
  [SerializeField] private GameObject spawner;
  [SerializeField] float initialSpawnTime = 1f;
  [SerializeField] float intervalSpawnTime = 3f;
  private SpawnerController[] spawners;
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
    spawners = GetComponentsInChildren<SpawnerController>();
    InvokeRepeating("OrderSpawn", initialSpawnTime, intervalSpawnTime);
  }

  private void OrderSpawn()
  {
    int randomIndex = Random.Range(0, spawners.Length);
    spawners[randomIndex].SpawnEnemy();
  }

  private void CreateSpawners()
  {
    managerPosition = transform.position;
    Vector2 managerScale = transform.localScale;
    float managerPivot = managerScale.y / 2;
    float positionTopY = managerScale.y - ((managerPivot) - (managerPosition.y));
    int spacesInsideManager = spawnersAmount * 2 - 1;
    float spawnerHeight = managerScale.y / spacesInsideManager;
    float spawnerPivot = spawnerHeight / 2;
    for (int i = 0; i < spacesInsideManager; i++)
    {
      if (i % 2 == 0)
      {
        float spawnPositionY = positionTopY - spawnerPivot - spawnerHeight * i;
        Vector2 spawnPosition = new Vector2(managerPosition.x, spawnPositionY);
        Instantiate(spawner, spawnPosition, Quaternion.identity, transform);
      }
    }
  }
}
