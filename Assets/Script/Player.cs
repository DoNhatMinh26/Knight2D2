using Unity.Mathematics;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    public int maxHealth = 3;
    public Text health;
    Rigidbody2D rb;
    private Animator animator;
    private float moveMent;
    [SerializeField] private float moveSpeed = 10f;
    private bool facingRight = true;
    [SerializeField] private float jumpHight = 10f;
    private bool isGround = true;
    private void Awake()
    {
        animator = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();

    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (maxHealth <= 0)
        {
            
        }

        health.text = maxHealth.ToString();

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
            animator.SetBool("Jump", true);
        }
        if (math.abs(moveMent ) > 0.1f)
        {
            animator.SetFloat("Run", 1f);
        }else if(moveMent < 0.1)
        {
            animator.SetFloat("Run", 0f);
        }
        if (Input.GetMouseButtonDown(0)) 
        {
            animator.SetTrigger("Attack1");
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
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGround = true;
            animator.SetBool("Jump", false);
        }
    }
}
