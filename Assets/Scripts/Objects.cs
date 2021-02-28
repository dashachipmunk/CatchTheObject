using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Objects : MonoBehaviour
{
    public GameObject particlePrefab;
    public int score;
    [Header("Sounds")]
    public AudioClip audioObj;
    Sounds sound;
    private void Awake()
    {
        sound = FindObjectOfType<Sounds>();
    }
    void ApplyScore()
    {
        GameManager gM = FindObjectOfType<GameManager>();
        gM.AddScore(score);
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("girl"))
        {
            sound.PlaySound(audioObj);
            Instantiate(particlePrefab, transform.position, Quaternion.identity);
            ApplyScore();
            Destroy(gameObject);
        }
        if (collision.gameObject.CompareTag("wall"))
        {
            Destroy(gameObject);
        }
    }

}
