using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using TMPro;

public class PanelManager : MonoBehaviour
{
    public TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {
        scoreText.text = PlayerManager.score.ToString();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void PlayAgainClicked()
    {
        PlayerManager.lives = 3;
        PlayerManager.score = 0;
        SceneManager.LoadScene(0);
    }

    public void ExitClicked()
    {
        Application.Quit();
    }

    
}
