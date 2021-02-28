using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LostObject : MonoBehaviour
{
    public HealthBar health;
    int count;
    [Header("Sounds")]
    public AudioClip audioObj;
    Sounds sound;
    private void Awake()
    {
        sound = FindObjectOfType<Sounds>();
    }
    private void Start()
    {
        health = FindObjectOfType<HealthBar>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("condom"))
        {
            sound.PlaySound(audioObj);
            count++;
            print(count);
            if (count % 3 == 0)
            {
                health.MinusHeart();
            }
        }
    }
}
