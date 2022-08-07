using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [SerializeField] private float moveForce = 2f;
  private Rigidbody2D enemyBody;

  private void Start()
  {
    enemyBody = GetComponent<Rigidbody2D>();
  }

  private void Update()
  {
    MoveToLeft();
  }

  private void MoveToLeft()
  {
    enemyBody.velocity = Vector2.left * moveForce;
  }

  private void Destroy()
  {
    Object.Destroy(enemyBody);
  }
}
