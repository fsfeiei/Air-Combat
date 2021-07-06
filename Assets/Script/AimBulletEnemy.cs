using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimBulletEnemy : Enemy
{
    public Bullet bullet;
    private GameObject player;
    private Rigidbody2D playerRb;
    public override void Start() {
        base.Start();
        player = GameObject.Find("Player");
        playerRb = player.GetComponent<Rigidbody2D>();
        InvokeRepeating("Attack", 0, 0.3f);
    }
    float lastDistance = 0;
    float distance = 0;
    public override void Move()
    {
        if (player != null)
        {
            // var toRotation = Mathf.Atan2((enemyRb.position.y - player.transform.position.y), (enemyRb.position.x - player.transform.position.x)) * 180 / Mathf.PI + 90;
            var toRotation = Mathf.Atan2((enemyRb.position.y - player.transform.position.y), (enemyRb.position.x - player.transform.position.x)) * Mathf.Rad2Deg + 90;
            enemyRb.rotation = toRotation;
            distance = (enemyRb.position - playerRb.position).magnitude;
        }
        if (distance > 5)
        {
            if(distance - lastDistance > 0)
            {
                if (enemyRb.velocity.magnitude > 5)
                {
                    enemyRb.drag = 2;
                }
            }
            else
            {
                enemyRb.drag = 0;
            }
            enemyRb.AddRelativeForce(Vector2.up * force * distance * 10);
        }
        if (distance < 5)
        {
            enemyRb.AddRelativeForce(Vector2.down * force * (5 - distance) * 10);
        }
        if (distance < 3)
        {
            if(distance - lastDistance < 0)
            {
                if (enemyRb.velocity.magnitude > 1)
                {
                    enemyRb.drag = (3 - distance);
                }
            }
            else
            {
                enemyRb.drag = 0;
            }
        }
        lastDistance = distance;
    }
    void Attack()
    {
        var sbullet = Instantiate(bullet, transform.position, transform.rotation);
        sbullet.force = 10;
    }
}
