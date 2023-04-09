using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveHole : MonoBehaviour
{
    [SerializeField]
    private Transform ground;
    [HideInInspector]
    public float speed = 1;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        float tempX = transform.position.x;
        float tempY = transform.position.y;
        float tempZ = transform.position.z;

        float groundHalfLength = ground.localScale.x * 5f;
        float groundHalfWidth =  ground.localScale.z * 5f;
        float holeRadius = transform.localScale.x/2f;

        tempX += Input.GetAxis("Horizontal") * Time.deltaTime * speed;
        tempZ += Input.GetAxis("Vertical") * Time.deltaTime * speed;

        tempX = Mathf.Clamp(tempX,
            -groundHalfLength+holeRadius, 
            +groundHalfLength-holeRadius);
        tempZ = Mathf.Clamp(tempZ,
            -groundHalfWidth+holeRadius, 
            +groundHalfWidth-holeRadius);

        transform.position = new Vector3(tempX, transform.position.y, tempZ);
        
    }

    void LateUpdate(){


    }
}
