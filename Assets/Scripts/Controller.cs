using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    GameObject[] points;
    [Range(0.1f, 20f)] public float speed;
    [SerializeField] public float radiusX;
    [SerializeField] public float radiusY;
    [SerializeField] public float transposeX;
    [SerializeField] public float transposeY;
    [SerializeField] public float height;


    private float iteration = 0;
    Vector2 currentPos;
    Vector2 temp = Vector3.zero;
    Vector2 tempShift = Vector3.zero;
    Vector2 shiftedPos;
    LineRenderer lineRenderer;
    int index = 0;  

    private void Start()
    {
        lineRenderer = GetComponent<LineRenderer>();

        lineRenderer.startColor = Color.red;
        lineRenderer.endColor = Color.red;

        lineRenderer.startWidth = 0.08f;
        lineRenderer.endWidth = 0.08f;
        

        points = GameObject.FindGameObjectsWithTag("Point");
    }

    private void Update()
    {
        Gizmos.color = Color.red;
        points = GameObject.FindGameObjectsWithTag("Point");
        lineRenderer.positionCount = points.Length * 6;
        foreach (var point in points)
        {

            currentPos = new Vector2(radiusX * Mathf.Cos((float)(Time.timeSinceLevelLoad * speed + iteration)) + transposeX,
                                                   radiusY * Mathf.Sin((float)(Time.timeSinceLevelLoad * speed + iteration)) + transposeY
                                                   );

            lineRenderer.SetPosition(index++, temp);
            lineRenderer.SetPosition(index++, currentPos);

            temp = currentPos;

            shiftedPos = currentPos + new Vector2(0, height);

            lineRenderer.SetPosition(index++, tempShift);
            lineRenderer.SetPosition(index++, shiftedPos);


            tempShift = shiftedPos;
            point.transform.position = currentPos;

            //if (!(index % 4 == 0))
            //{
                lineRenderer.SetPosition(index++, currentPos);
                lineRenderer.SetPosition(index++, shiftedPos);
            //}

            point.transform.position = shiftedPos;

            iteration += ((360 / points.Length) * Mathf.PI) / 180;

            Debug.Log(index);
            if(index >= lineRenderer.positionCount) index = 0;
            

            //You can add an delay here to improve performance.
        }
    }


}
