using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    [SerializeField]
    private Transform hole;
    // Start is called before the first frame update
    void Start()
    {

    }


    void LateUpdate()
    {
        float angle = transform.eulerAngles.x;
        float holeScale = hole.localScale.x;  
        float distance = 2.5f * holeScale;

        transform.position = new Vector3(hole.position.x,
         Mathf.Sin(angle * Mathf.Deg2Rad) * distance,
         hole.position.z-Mathf.Cos(angle* Mathf.Deg2Rad)*distance-holeScale/2.5f);
    }
}
