using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GirlPad : MonoBehaviour
{
    [Header("Girl's parameters")]
    public GameObject girl;
    public Sprite[] girlLook;
    public SpriteRenderer sRender;
    int girlHealth;

    public HealthBar health;
    public GameManager gM;
    
    public float xMax;
    
    private void Start()
    {
        health = FindObjectOfType<HealthBar>();
        girlHealth = health.health * 2;
    }
    private void Update()
    {
        if (gM.isPaused)//пад не двигается во время паузы
        {
            return;
        }
        if (health.isDead)//пад не двигается во время Гейм Овер
        {
            return;
        }

        Vector2 mousePixelPoint = Input.mousePosition;
        Vector2 mouseWorldPosition = Camera.main.ScreenToWorldPoint(mousePixelPoint);
        Vector2 padNewPosition = new Vector2(mouseWorldPosition.x, transform.position.y);
        padNewPosition.x = Mathf.Clamp(padNewPosition.x, -xMax, xMax);
        transform.position = padNewPosition;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("disease"))
        {
            girlHealth--;
            GirlLookChange();
            if (girlHealth % 2 == 0)
            {
                health.MinusHeart();
            }
        }
        if (collision.gameObject.CompareTag("heal"))
        {
            if (girlHealth < 6)
            {
                girlHealth++;
                GirlLookChange();
            }
        }
    }
    void GirlLookChange()
    {
        for (int i = girlHealth; i > 0; i--)
        {
            if (girlHealth == i)
            {
                sRender.sprite = girlLook[i - 1];
            }
        }
    }

}
