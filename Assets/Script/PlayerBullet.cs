using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : MonoBehaviour
{
    private float force = 10;
    private Rigidbody2D bulletRb;
    // Start is called before the first frame update
    void Start()
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
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().hp -= 1;
        }
        Destroy(gameObject);
    }
}
