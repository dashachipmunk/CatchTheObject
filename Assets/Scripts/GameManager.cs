using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class GameManager : MonoBehaviour
{
    [Header("Pickup Objects")]
    public GameObject[] condoms;
    public GameObject[] diseases;
    public GameObject[] meds;

    public Rigidbody2D[] rBs;

    [Header("Time Parameters")]
    public float condT;
    public float disT;
    public float medsT;
    public float timer;

    [Header("Score etc.")]
    public int score;
    public Text scoreText;
    public Text startText;

    [Header("Pause")]
    public bool isPaused;
    public GameObject pausePanel;

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
    void Start()
    {
        isPaused = false;
        Time.timeScale = 1f;
        score = 0;
        foreach (var rB in rBs)
        {
            rB.gravityScale = 1f;
        }
        StartCoroutine(Condoms(condT));
        StartCoroutine(Diseases(disT));
        StartCoroutine(Meds(medsT));
        StartCoroutine(Faster(timer));
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
                animator.Play("Button");
                BackToGame();
            }
            else
            {
                pausePanel.SetActive(true);
                Time.timeScale = 0f;
                sound.PlaySound(audioObj);
                isPaused = true;
            }
        }
    }
    public void BackToGame()
    {
        pausePanel.SetActive(false);
        Time.timeScale = 1f;
        isPaused = false;
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("TotalScore", score);
    }
    #region Invokes
    //public void Condoms()
    //{
    //    int randomCondom = Random.Range(0, 5);
    //    for (int i = 0; i < condoms.Length; i++)
    //    {
    //        if (randomCondom == i)
    //        {
    //            Instantiate(condoms[i], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
    //        }
    //    }
    //}
    //void Diseases()
    //{
    //    int randomDisease = Random.Range(0, 25);
    //    for (int j = 0; j < diseases.Length; j++)
    //    {
    //        if (randomDisease == j)
    //        {
    //            Instantiate(diseases[j], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
    //        }
    //    }
    //}
    //void Meds()
    //{
    //    int randomMed = Random.Range(0, 41);
    //    for (int k = 0; k < meds.Length; k++)
    //    {
    //        if (randomMed == k)
    //        {
    //            Instantiate(meds[k], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
    //        }
    //    }
    //}
    #endregion

    #region IEnumerators
    IEnumerator Condoms(float condTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(condTime);
            int randomCondom = Random.Range(0, 5);
            for (int i = 0; i < condoms.Length; i++)
            {
                if (randomCondom == i)
                {
                    Instantiate(condoms[i], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
                }
            }
        }
    }
    IEnumerator Diseases(float disTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(disTime);
            int randomDisease = Random.Range(0, 19);
            for (int j = 0; j < diseases.Length; j++)
            {
                if (randomDisease == j)
                {
                    Instantiate(diseases[j], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
                }
            }
        }
    }
    IEnumerator Meds(float medsTime)
    {
        while (true)
        {
            yield return new WaitForSeconds(medsTime);
            int randomMed = Random.Range(0, 41);
            for (int k = 0; k < meds.Length; k++)
            {
                if (randomMed == k)
                {
                    Instantiate(meds[k], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
                }
            }
        }
    }
    IEnumerator Faster(float timer)
    {
        while (true)
        {
            yield return new WaitForSeconds(timer);
            if (condT >= 0.1f && disT >= 0.1f)
            {
                condT -= 0.1f;
                disT -= 0.1f;
            }
            foreach (var rB in rBs)
            {
                rB.gravityScale += 0.2f;
            }
        }
    }
    #endregion
}
