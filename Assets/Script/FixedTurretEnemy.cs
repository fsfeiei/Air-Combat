using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FixedTurretEnemy : Enemy
{
    public Bullet bullet;
    public override void Start() {
        gameObject.layer = 7;
        gameObject.tag = "Enemy";
        InvokeRepeating("Attack", 0, 1f);
    }
    public override void Move()
    {
        
    }
    void Attack()
    {
        var sbullet = Instantiate(bullet, transform.position, transform.rotation);
        sbullet.force = 3;
    }
}
