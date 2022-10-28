using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Controller : MonoBehaviour
{
    public Transform[] points;
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

    void Update()
    {
        foreach (var point in points)
        {

            currentPos = new Vector2(radiusX * Mathf.Cos((float)(Time.timeSinceLevelLoad * speed + iteration)) + transposeX,
                                                   radiusY * Mathf.Sin((float)(Time.timeSinceLevelLoad * speed + iteration)) + transposeY
                                                   );
            
            Debug.DrawLine(temp, currentPos, Color.red);
            temp = currentPos;

            shiftedPos = currentPos + new Vector2(0, height);

            Debug.DrawLine(tempShift, shiftedPos, Color.red);

            tempShift = shiftedPos;
            point.transform.position = currentPos;

            Debug.DrawLine(currentPos, shiftedPos, Color.red);

            point.transform.position = shiftedPos;

            iteration += ((360 / points.Length) * Mathf.PI) / 180;

            //You can add an delay here to improve performance.
        }
    }


}
