using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameOverUI : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI scoreFinal;
    [SerializeField] private TextMeshProUGUI highScoreFinal;

    private void Start()
    {
        scoreFinal.text = PlayerPrefs.GetInt("CurrentScore", 0).ToString();
        highScoreFinal.text = PlayerPrefs.GetInt("HighScore", 0).ToString();
    }
}
