using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] public Transform _enemyLimitPosX;
    [SerializeField] public Transform _enemyLimitPosNegX;
    private Vector2 velocity;
    private Vector2 speedLeft;
    private Vector2 speedRight;
    private Rigidbody2D rb;
    // Update is called once per frame
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        speedRight = new Vector2(2, 0);
        speedLeft = new Vector2(-2, 0);
        velocity = speedRight;
    }
    void Update()
    {
        OnMove();
    }
    private void OnMove()
    {
        if (rb.position.x >= _enemyLimitPosX.position.x && velocity == speedRight)
        {
            velocity = speedLeft;
            rb.position = rb.position + new Vector2(0, -1);
        }
        else if(rb.position.x <= _enemyLimitPosNegX.position.x && velocity == speedLeft)
        {
            velocity = speedRight;
            rb.position = rb.position + new Vector2(0, -1);
        }
        rb.linearVelocity = (velocity);
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.layer == 6)
        {

        }
        if (collision.gameObject.layer == 7)
        {
            GameOver();
        }
    }
    public void GameOver()
    {

    }
}
