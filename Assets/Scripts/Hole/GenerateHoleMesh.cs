using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenerateHoleMesh : MonoBehaviour
{   

    [SerializeField]
    private int nVertices;

    // Start is called before the first frame update
    public PolygonCollider2D hole2DCollider;
    public PolygonCollider2D ground2DCollider;
    public MeshCollider GeneratedMeshCollider;
    Mesh GeneratedMesh; 
    
    void Awake(){
            float initRadius = 0.5f;
            Vector2[] vertices = new Vector2[nVertices];
            Vector2 center = new Vector2(0,0);
            float angleStep = 360f/nVertices * Mathf.Deg2Rad;
            float angle = 90f * Mathf.Deg2Rad;
            for(int i = 0; i < nVertices;i++, angle+=angleStep){
                float x = initRadius * Mathf.Cos(angle);
                float y = initRadius * Mathf.Sin(angle);
                Vector2 point = new Vector2(x,y);
                vertices[i] = point;
            }
            hole2DCollider.SetPath(0, vertices);
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
         if(transform.hasChanged){
            transform.hasChanged = false;

            Generate2DHole();
            Generate3DMeshCollider();
        }
    }
    private void FixedUpdate(){

    }

    private void Generate2DHole(){
        hole2DCollider.transform.position = new Vector2(transform.position.x, transform.position.z);
        Vector2[] PointPositions =  hole2DCollider.GetPath(0);
        Vector2 scaleTemp = new Vector2(transform.localScale.x, transform.localScale.z);
        for(int i = 0; i < PointPositions.Length; i++){ 
            PointPositions[i] *= scaleTemp;
            PointPositions[i]+=(Vector2)hole2DCollider.transform.position;

        }
        ground2DCollider.pathCount = 2;
        ground2DCollider.SetPath(1, PointPositions);
    }

    private void Generate3DMeshCollider(){
        if(GeneratedMesh) Destroy(GeneratedMesh);

        GeneratedMesh = ground2DCollider.CreateMesh(true,true);
        GeneratedMeshCollider.sharedMesh = GeneratedMesh;

    }
}
