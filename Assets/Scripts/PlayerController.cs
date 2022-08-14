using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float jumpHeight = 10f;
    private bool isJumping = false;
    private Rigidbody2D playerRb;
    private const string enemyTag = "enemy";
    private const string floorTag = "floor";

    private void Awake()
    {
        playerRb = gameObject.GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Space) && !isJumping)
        {
            isJumping = true;
            playerRb.velocity = Vector2.up * jumpHeight;
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.tag == floorTag && isJumping)
        {
            isJumping = false;
        }
        if (collision.collider.tag == enemyTag)
        {
            GameManager.Instance.ResetScene();
            Debug.Log("The scene was reset");
        }
    }
}
