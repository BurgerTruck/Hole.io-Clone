using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class Timer : MonoBehaviour
{   
    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private GameObject gameOverSreen;
    [SerializeField]
    private float duration;

    [SerializeField]
    private Collector  collector;

    [SerializeField]
    private MoveHole moveHole;

    [SerializeField]
    private ScoreComponent playerScore;
    [SerializeField]
    private TextMeshProUGUI gameOverScore;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {   
        if(duration<=0){
            duration = 0;
            collector.enabled = false;
            moveHole.enabled = false;
            gameOverScore.text = "Score: "+playerScore.Score;
            gameOverSreen.SetActive(true);

        }else{
            int minutes = Mathf.FloorToInt(duration / 60);
            int seconds = Mathf.FloorToInt(duration); 
            text.text = minutes + " : " + (seconds>9?seconds: "0"+seconds);
            duration -= Time.deltaTime;
        }



    }

    
    
}
