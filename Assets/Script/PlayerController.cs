using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerBullet bullet;
    private float force = 10;
    private Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Attack", 0, 0.1f);
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }
    void Move()
    {
        playerRb.AddForce(Vector2.right * Input.GetAxis("Mouse X") * force);
        playerRb.AddForce(Vector2.up * Input.GetAxis("Mouse Y") * force);
    }
    void Attack()
    {
        Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + 0.6f), bullet.transform.rotation);
    }
    private void OnCollisionEnter2D(Collision2D other) {

    }
}
