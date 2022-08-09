using UnityEngine;

public class PlayerController : MonoBehaviour
{
  [SerializeField] private float jumpHeight = 10f;
  private static bool isJumping = false;
  private GameObject player;
  private Rigidbody2D playerBody;
  private const string enemyTag = "enemy";
  private const string floorTag = "floor";

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
    if (collision.collider.tag == floorTag && isJumping == true)
    {
      isJumping = false;
    }
    if (collision.collider.tag == enemyTag)
    {
      GameManager.Instance.ResetScene();
      Debug.Log("The scene was reset");
    }
  }

  private void OnCollisionExit2D(Collision2D collision)
  {
    if (collision.collider.tag == floorTag && isJumping == false)
    {
      isJumping = true;
    }
  }
}
