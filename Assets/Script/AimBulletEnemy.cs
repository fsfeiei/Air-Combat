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
        InvokeRepeating("Attack", 0, 1f);
    }
    public override void Move()
    {
        var toRotation = Mathf.Atan2((enemyRb.position.y - player.transform.position.y), (enemyRb.position.x - player.transform.position.x)) * 180 / Mathf.PI + 90;
        enemyRb.rotation = toRotation;
        base.Move();
    }
    void Attack()
    {
        // var bulletRotation = Mathf.Atan2((enemyRb.position.y - player.transform.position.y), (enemyRb.position.x - player.transform.position.x)) * 180 / Mathf.PI + 90;
        var sbullet = Instantiate(bullet, transform.position, transform.rotation);
        sbullet.force = 5;
    }
}
