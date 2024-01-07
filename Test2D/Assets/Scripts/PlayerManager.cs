using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerManager : MonoBehaviour
{
    public static int score;
    public static int lives;

    [SerializeField] TextMeshProUGUI scoreText;
    [SerializeField] TextMeshProUGUI livesText;
    public GameObject panel;
    // Start is called before the first frame update
    void Start()
    {
        score = 0;
        lives = 3;
    }

    // Update is called once per frame
    void Update()
    {
        scoreText.text = score.ToString();
        livesText.text = lives.ToString();
        if (lives <= 0)
        {
            panel.SetActive(true);
        }
        
    }

  

  
}

