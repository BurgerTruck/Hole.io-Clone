using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class ScoreManager : MonoBehaviour
{

    [SerializeField]
    private ScoreComponent playerScore; 
    [SerializeField]
    private TextMeshProUGUI scoreText;
    // Start is called before the first frame update
    void Start()
    {   

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void UpdateScore(int score){
        playerScore.Score+=score;
        scoreText.text = "Score: "+playerScore.Score;
    }
}
