using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BattleshipEnemy : Enemy
{
    public override void Start() {
        force = 0.01f;
        mass = 1000;
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.mass = mass;
        enemyRb.drag = 0;
        enemyRb.gravityScale = 0;
        gameObject.layer = 11;
        gameObject.tag = "Enemy";
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass, ForceMode2D.Impulse);
    }
    public override void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.name == "DestroyWall")Destroy(gameObject);
        Invoke("CheckDestroy",.1f);
    }
    private void CheckDestroy()
    {
        Debug.Log(gameObject.GetComponentsInChildren<Enemy>().Length);
        if(gameObject.GetComponentsInChildren<Enemy>().Length == 1)Destroy(gameObject);
    }
}
