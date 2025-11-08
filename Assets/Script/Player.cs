using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveMent;
    [SerializeField] private float moveSpeed = 5f;
    private bool facingRight = true;
    Rigidbody2D rb;
    [SerializeField] private float jumpHight = 5f;
    private bool isGround = true;
    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveMent = Input.GetAxis("Horizontal");
        if (moveMent < 0f && facingRight)
        {
            transform.eulerAngles = new Vector3(0f, -180f, 0f);
            facingRight = false;
        }
        else if (moveMent > 0f && facingRight == false)
        {
            transform.eulerAngles = new Vector3(0f, 0f, 0f);
            facingRight = true;
        }
        if (Input.GetKey(KeyCode.Space) && isGround == true) 
        {
            jump();
            isGround = false;
        }
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(moveMent, 0f, 0f) *moveSpeed* Time.deltaTime;
    }
    private void jump()
    {
        rb.AddForce(new Vector2 (0f, jumpHight), ForceMode2D.Impulse);   
    }
}
