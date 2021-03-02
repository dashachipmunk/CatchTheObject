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

    public HealthBar health;
    public BeautyPoints bP;
    public GameManager gM;

    public float xMax;
    
    private void Start()
    {
        health = FindObjectOfType<HealthBar>();
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
            bP.MinusBP();
            GirlLookChange();
            if (bP.beautyPoints % 2 == 0)
            {
                health.MinusHeart();
            }
        }
        if (collision.gameObject.CompareTag("heal"))
        {
            if (bP.beautyPoints < 6)
            {
                bP.PlusBP();
                GirlLookChange();
            }
        }
    }
    void GirlLookChange()
    {
        for (int i = bP.beautyPoints; i > 0; i--)
        {
            if (bP.beautyPoints == i)
            {
                sRender.sprite = girlLook[i - 1];
            }
        }
    }
}
