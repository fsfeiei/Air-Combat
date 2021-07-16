using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AimTurretEnemy : Enemy
{
    public Bullet bullet;
    private GameObject player;
    public override void Start() {
        player = GameObject.Find("Player");
        gameObject.layer = 7;
        gameObject.tag = "Enemy";
        InvokeRepeating("Attack", 0, 1f);
        base.HpSliderInit();
    }
    public override void Move()
    {
        if (player != null)
        {
            var angle = Mathf.Atan2((transform.position.y - player.transform.position.y), (transform.position.x - player.transform.position.x)) * Mathf.Rad2Deg + 90;
            transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
        }
        base.HpSliderUpdate();
    }
    void Attack()
    {
        var sbullet = Instantiate(bullet, transform.position, transform.rotation);
        sbullet.force = 3;
    }
}
