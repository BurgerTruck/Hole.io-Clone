using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class AddScoreEffect : MonoBehaviour
{
    [SerializeField]
    private float animationDuration;
    [SerializeField]
    private float speed;
    [SerializeField]
    private float fadeDuration;

    [SerializeField]
    private TextMeshProUGUI text;
    [SerializeField]
    private RectTransform textTransform;
    [SerializeField]
    private float distanceOffset;
    private float time;
    private int score;

    public int Score{
        get{return score;}
        set{score = value;}
    }

    private float distance;


    // Start is called before the first frame update
    void Start()
    {
        text.text = "+"+score;
        // textTransform.position = Vector3.Scale(textTransform.position, new Vector3(1, 0.5f, 0.5f));
    }

    // Update is called once per frame
    void Update()
    {   
        float tempDistance = distance;
        distance = Mathf.SmoothStep(distanceOffset, speed*animationDuration + distanceOffset, time/animationDuration);
        distance = distance - tempDistance;
        textTransform.position = new Vector3(
            
            textTransform.position.x,
            textTransform.position.y+distance,
            textTransform.position.z+distance
        );
        distance = tempDistance + distance;
        
        if(animationDuration - time <=fadeDuration){
            float alpha = Mathf.SmoothStep(from: 1, 0, (time - (animationDuration-fadeDuration))/fadeDuration);
            text.alpha = alpha;
        }

        time +=Time.deltaTime;
        if(time > animationDuration)Destroy(gameObject);
    }
}
