using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipEnemy : Enemy
{
    public override void Start() {
        hp = 100;
        force = 0.01f;
        mass = 1000;
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.mass = mass;
        enemyRb.drag = 0;
        enemyRb.gravityScale = 0;
        gameObject.layer = 11;
        gameObject.tag = "Enemy";
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass, ForceMode2D.Impulse);
        base.HpSliderInit();
    }
    public override void OnCollisionEnter2D(Collision2D other) {
        base.OnCollisionEnter2D(other);
        StartCoroutine(CheckChildren());
    }
    IEnumerator CheckChildren()
    {
        yield return null;
        if(gameObject.GetComponentsInChildren<Enemy>().Length == 1)gameObject.layer = 7;
    }
}
