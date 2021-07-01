using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public int hp = 10;
    private float force = 2f;
    private Rigidbody2D enemyRb;
    // Start is called before the first frame update
    void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass, ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    void Move()
    {
        enemyRb.AddRelativeForce(Vector2.up * force);
    }
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "DestroyWall")Destroy(gameObject);
        if(hp < 1)Destroy(gameObject);
    }
}
