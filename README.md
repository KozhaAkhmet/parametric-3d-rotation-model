# parametric-3d-rotation-model
An interactive User interface that can display 3d rotation of different symmetric gemetrical shapes by using only line segment. 
 
![ezgif-4-06035d0b69](https://user-images.githubusercontent.com/80167990/198712847-6d5245a4-56ed-4d81-9061-4c02938182f0.gif)

# Code

```C#
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

            
            lineRenderer.SetPosition(index++, currentPos);
            lineRenderer.SetPosition(index++, shiftedPos);
            

            point.transform.position = shiftedPos;

            iteration += ((360 / points.Length) * Mathf.PI) / 180;

            Debug.Log(index);
            if(index >= 24) index = 0;
            

            //You can add an delay here to improve performance.
        }

```
