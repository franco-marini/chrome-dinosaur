using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [SerializeField] public float moveForce = 2f;
  private Rigidbody2D enemyBody;
  private const string destroyZoneTag = "destroyZone";

  private void Start()
  {
    enemyBody = GetComponent<Rigidbody2D>();
    gameObject.SetActive(false);
  }

  private void Update()
  {
    MoveToLeft();
  }

  private void MoveToLeft()
  {
    enemyBody.velocity = Vector2.left * moveForce;
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.tag == destroyZoneTag)
    {
      SpawnManager.Instance.AddEnemyToList(this.gameObject);
      gameObject.SetActive(false);
    }
  }
}
