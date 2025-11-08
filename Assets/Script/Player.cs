using UnityEngine;

public class Player : MonoBehaviour
{
    private float moveMent;
    [SerializeField] private float moveSpeed = 5f;
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        moveMent = Input.GetAxis("Horizontal");
    }
    private void FixedUpdate()
    {
        transform.position += new Vector3(moveMent, 0f, 0f) *moveSpeed* Time.deltaTime;
    }
}
