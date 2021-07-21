using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    int hp = 5;
    GameObject hpSliderObject;
    Slider hpSlider;
    Image[] hpSliderImage;
    public PlayerBullet bullet;
    private float force = 20;
    public Rigidbody2D playerRb;
    // Start is called before the first frame update
    void Start()
    {
        playerRb = GetComponent<Rigidbody2D>();
        InvokeRepeating("Attack", 0, 0.1f);
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
    void Update()
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
                item.color = new Color(item.color.r, item.color.g, item.color.b, item.color.a - 0.001f);
            }
        }
        hpSliderObject.transform.position = transform.position;
        hpSliderObject.transform.Translate(Vector3.up * .5f);
        hpSlider.value = hp;
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
        if(other.gameObject.name == "LimitPlayers")return;
        if(other.gameObject.tag == "Enemy")
        {
            hp--;
            foreach (var item in hpSliderImage)
            {
                item.color = new Color(item.color.r, item.color.g, item.color.b, 1);
            }
            if(hp < 1)
            {
                Destroy(gameObject);
                Destroy(hpSliderObject);
            }
        }
    }
}
