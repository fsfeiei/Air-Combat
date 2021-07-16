using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Enemy : MonoBehaviour
{
    protected int hp = 10;
    protected GameObject hpSliderObject;
    protected Slider hpSlider;
    protected Image[] hpSliderImage;
    protected float force = 1f;
    protected float mass = 20;
    protected Rigidbody2D enemyRb;
    // Start is called before the first frame update
    public virtual void Start()
    {
        enemyRb = GetComponent<Rigidbody2D>();
        enemyRb.mass = mass;
        enemyRb.drag = 0;
        enemyRb.gravityScale = 0;
        gameObject.layer = 7;
        gameObject.tag = "Enemy";
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass, ForceMode2D.Impulse);
        HpSliderInit();
    }

    public void HpSliderInit()
    {
        hpSliderObject = GameObject.Find("HpSlider");
        hpSliderObject = Instantiate(hpSliderObject, transform.position, hpSliderObject.transform.rotation);
        hpSlider = hpSliderObject.GetComponentInChildren<Slider>();
        hpSlider.maxValue = hp;
        hpSlider.value = hp;
        hpSliderImage = hpSliderObject.GetComponentsInChildren<Image>();
        foreach (var item in hpSliderImage)
        {
            item.color = new Color(item.color.r, item.color.g, item.color.b , 0);
        }
    }

    // Update is called once per frame
    public virtual void FixedUpdate()
    {
        Move();
        HpSliderUpdate();
    }

    public void HpSliderUpdate()
    {
        if(hpSliderImage[0].color.a >= 0)
        {
            foreach (var item in hpSliderImage)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, item.color.a - 0.01f);
            }
        }
        hpSliderObject.transform.position = transform.position;
        hpSliderObject.transform.Translate(Vector3.up * .5f);
        hpSlider.value = hp;
    }

    public virtual void Move()
    {
        enemyRb.AddRelativeForce(Vector2.up * force * enemyRb.mass);
    }
    public virtual void OnCollisionEnter2D(Collision2D other) {
        if(other.gameObject.tag == "PlayerBullet")
        {
            hp--;
            foreach (var item in hpSliderImage)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, 1);
            }
        }
        if(other.gameObject.name == "DestroyWall" || hp < 1)
        {
            Destroy(gameObject);
            Destroy(hpSliderObject);
        }
    }
}
