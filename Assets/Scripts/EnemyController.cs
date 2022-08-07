using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
  [SerializeField] private float moveForce = 2f;
  private GameObject enemy;
  private Rigidbody2D enemyBody;

  private void Awake()
  {
    enemy = GameObject.FindWithTag("enemy");
    if (enemy != null)
    {
      enemyBody = enemy.GetComponent<Rigidbody2D>();
    }
  }

  void Update()
  {
    enemyBody.velocity = Vector2.left * moveForce;
  }
}
