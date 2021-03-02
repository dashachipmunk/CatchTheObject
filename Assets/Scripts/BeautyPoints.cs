using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BeautyPoints : MonoBehaviour
{
    public Image[] lips;
    public int beautyPoints;

    private void Start()
    {
        beautyPoints = lips.Length;
        for (int i = 0; i < lips.Length; i++)
        {
            lips[i].enabled = true;
        }
    }
    public void MinusBP()
    {
        beautyPoints--;
        for (int i = lips.Length; i >= 0; i--)
        {
            if (i > beautyPoints)
            {
                lips[i - 1].enabled = false;
            }
        }
    }
    public void PlusBP()
    {
        beautyPoints++;
        for (int i = beautyPoints; i >= 0; i--)
        {
            lips[beautyPoints - 1].enabled = true;
        }
    }
}
