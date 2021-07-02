using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float force = 10;
    public Rigidbody2D bulletRb;
    // Start is called before the first frame update
    public virtual void Start()
    {
        bulletRb = GetComponent<Rigidbody2D>();
        bulletRb.AddRelativeForce(Vector2.up * force,ForceMode2D.Impulse);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {

    }
    private void OnCollisionEnter2D(Collision2D other) {
        Destroy(gameObject);
    }
}
