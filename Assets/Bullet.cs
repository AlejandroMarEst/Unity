using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    [SerializeField] public Transform _boundsLimit;
    private Vector2 velocity;
    private Rigidbody2D rb;
    private GameObject bullet;
    public Player player;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        velocity = new Vector2(0, 15);
        rb = GetComponent<Rigidbody2D>();
        bullet = GetComponent<GameObject>();
    }

    // Update is called once per frame
    void Update()
    {
        rb.AddForce(velocity);
        if (rb.position.y >= _boundsLimit.position.y)
        {
            player.stack.Push(bullet);
        }
    }
}
