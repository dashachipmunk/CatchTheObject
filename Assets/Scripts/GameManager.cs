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
    public float timeRepeat;

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
    private void Awake()
    {
        sound = FindObjectOfType<Sounds>();
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
        InvokeRepeating("Condoms", condT, timeRepeat);
        InvokeRepeating("Diseases", disT, timeRepeat);
        InvokeRepeating("Meds", medsT, timeRepeat);
        InvokeRepeating("Faster", 50f, 50f);
    }
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (isPaused)
            {
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
    void Faster()
    {
        if (timeRepeat >= 0.2f)
        {
            timeRepeat -= 0.2f;
        }
        foreach (var rB in rBs)
        {
            rB.gravityScale += 0.2f;
        }
    }
    public void AddScore(int addScore)
    {
        score += addScore;
        scoreText.text = "Score: " + score.ToString();
        PlayerPrefs.SetInt("TotalScore", score);
    }
    
    public void Condoms()
    {
        int randomCondom = Random.Range(0, 5);
        for (int i = 0; i < condoms.Length; i++)
        {
            if (randomCondom == i)
            {
                Instantiate(condoms[i], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
            }
        }
    }
    void Diseases()
    {
        int randomDisease = Random.Range(0, 25);
        for (int j = 0; j < diseases.Length; j++)
        {
            if (randomDisease == j)
            {
                Instantiate(diseases[j], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
            }
        }
    }
    void Meds()
    {
        int randomMed = Random.Range(0, 41);
        for (int k = 0; k < meds.Length; k++)
        {
            if (randomMed == k)
            {
                Instantiate(meds[k], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
            }
        }
    }

    #region Commented Code
    //IEnumerator ObjectsFall(float condTime, float disTime)
    //{
    //    while (true)
    //    {
    //        int randomCondom = Random.Range(0, 5);
    //        int randomDisease = Random.Range(0, 19);
    //        int randomMed = Random.Range(0, 41);
    //        print("Cond " + randomCondom + ". Dis " + randomDisease + ". Med " + randomMed);
    //        for (int i = 0; i < condoms.Length; i++)
    //        {
    //            yield return new WaitForSeconds(condTime);
    //            if (randomCondom == i)
    //            {
    //                Instantiate(condoms[i], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
    //            }
    //        }
    //        for (int j = 0; j < diseases.Length; j++)
    //        {
    //            yield return new WaitForSeconds(disTime);
    //            if (randomDisease == j)
    //            {
    //                Instantiate(diseases[j], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
    //            }
    //        }
    //        for (int k = 0; k < meds.Length; k++)
    //        {
    //            if (randomMed == k)
    //            {
    //                Instantiate(meds[k], new Vector2(Random.Range(-8f, 8f), 6f), Quaternion.identity);
    //            }
    //        }
    //    }
    //}
    #endregion 
}
