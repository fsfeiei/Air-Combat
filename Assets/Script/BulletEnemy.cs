using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletEnemy : Enemy
{
    public Bullet bullet;
    public override void Start() {
        base.Start();
        InvokeRepeating("Attack", 0, 1f);
    }
    void Attack()
    {
        var sbullet = Instantiate(bullet, transform.position, transform.rotation);
        sbullet.force = 3;
    }
}
