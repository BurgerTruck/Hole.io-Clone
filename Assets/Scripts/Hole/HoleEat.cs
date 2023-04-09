using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleEat : MonoBehaviour
{
    [SerializeField]
    private GameObject scoreEffect;
    [SerializeField]
    private ScoreComponent scoreComponent;
    private float targetScale = 1;
    
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnEatObject(int score){
        GrowHole(score);
        GenerateScoreEffect(score);
    }

    private void GrowHole(int score){
        targetScale += score/500f;
        StartCoroutine("ScaleHole"); 
    }

    private void GenerateScoreEffect(int score){
        GameObject scoreEffectClone = Instantiate(scoreEffect, GameObject.FindObjectOfType<Canvas>().transform);
        scoreEffectClone.GetComponent<AddScoreEffect>().Score = score;
    }

    private IEnumerator ScaleHole(){

        while(targetScale - transform.localScale.x > 0.001f ){
            Vector3 tempTarget = new Vector3(targetScale, transform.localScale.y, targetScale);

            transform.localScale = Vector3.Lerp(transform.localScale, tempTarget, 0.01f);
            yield return null;
            
        }
        transform.localScale = new Vector3(targetScale, transform.localScale.y, targetScale);

    }


}
