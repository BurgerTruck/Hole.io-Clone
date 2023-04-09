using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Collector : MonoBehaviour
{   

    [SerializeField]
    private HoleEat holeEat;
    [SerializeField]
    private ScoreManager scoreManager;

    [SerializeField]
    private AudioSource audioSource;    
    public  delegate void OnFall(int score);
    public  event OnFall fallEvent;


    void OnEnable(){
        fallEvent += holeEat.OnEatObject;
        fallEvent += scoreManager.UpdateScore;
        fallEvent += PlayCollectSound;
        
    }

    void OnDisable(){
        fallEvent -= holeEat.OnEatObject;
        fallEvent -= scoreManager.UpdateScore;
        fallEvent -= PlayCollectSound;
    }
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    //score paramter just to match signature of delegate
    void PlayCollectSound(int score){
        audioSource.PlayOneShot(audioSource.clip);
    }
    void OnTriggerExit(Collider other){

        if(other.CompareTag("Object")){
            Debug.Log(message: "EXITED");   
            CollectedComponent collectedComponent = other.gameObject.GetComponent<CollectedComponent>();
            if(collectedComponent.Collected)return;
            if(other.transform.position.y>transform.position.y)return;
            if(fallEvent!=null){
                collectedComponent.Collected = true;

                fallEvent(other.gameObject.GetComponent<ScoreComponent>().Score);

            }
        }
    }
}
