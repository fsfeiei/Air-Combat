using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBullet : Bullet
{
    private void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "Enemy")
        {
            other.gameObject.GetComponent<Enemy>().hp -= 1;
        }
        Destroy(gameObject);
    }
}
