using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float jumpHeight = 7f;
  private static bool isJumping = false;
  private GameObject player;
  private Rigidbody2D playerBody;

  private void Awake()
  {
    player = GameObject.FindGameObjectWithTag("player");
    if (player != null)
    {
      playerBody = player.GetComponent<Rigidbody2D>();
    }
  }

  void Update()
  {
    if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
    {
      playerBody.velocity = Vector2.up * jumpHeight;
    }
  }

  private void OnCollisionEnter2D(Collision2D collision)
  {
    if (collision.collider.tag == "Floor" && isJumping == true)
    {
      isJumping = false;
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.collider.tag == "Floor" && isJumping == false)
    {
      isJumping = true;
    }
  }
}
