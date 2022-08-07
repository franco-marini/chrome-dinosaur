using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float jumpHeight = 5f;
  private static bool isJumping = false;
  private Rigidbody2D rigidbody2d;

  // Start is called before the first frame update
  void Start()
  {

  }

  private void Awake()
  {
    rigidbody2d = transform.GetComponent<Rigidbody2D>();
  }

  // Update is called once per frame
  void Update()
  {
    Debug.Log("isJumping" + isJumping.ToString());
    if (Input.GetKeyDown(KeyCode.Space) && isJumping == false)
    {
      rigidbody2d.velocity = Vector2.up * jumpHeight;
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
