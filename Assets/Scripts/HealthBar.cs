using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Image[] hearts;
    public int health;

    [Header("Game Over")]
    public GameObject gameOverPanel;
    public GameManager score;
    public Text totalScore;
    public bool isDead;

    [Header("Sounds")]
    public AudioClip audioObj;
    Sounds sound;

    [Header("Animation")]
    Animator animator;
    private void Awake()
    {
        sound = FindObjectOfType<Sounds>();
        animator = GetComponent<Animator>();
    }
    private void Start()
    {
        isDead = false;
        for (int i = 0; i < hearts.Length; i++)
        {
            hearts[i].enabled = true;
        }
    }
    //private void Update()
    //{
    //    if (gameOverPanel.activeSelf)
    //    {
    //        animator.Play("Button");
    //        animator.Play("PauseText");
    //    }
    //}
    public void MinusHeart()
    {
        health--;
        for (int i = hearts.Length; i >= 0; i--)
        {
            if (i > health)
            {
                hearts[i - 1].enabled = false;
            }
        }
        GameOver();
    }
    public void GameOver()
    {
        if (health <= 0)
        {
            sound.PlaySound(audioObj);
            isDead = true;
            gameOverPanel.SetActive(true);
            Time.timeScale = 0f;
            totalScore.text = "Total score: " + PlayerPrefs.GetInt("TotalScore", score.score).ToString();
            animator.Play("Button");
        }
    }
}
