using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stars : MonoBehaviour
{
    public List<Transform> starTransforms;
    public float drawingTime;

    public int starListSize = 0;
    public float lineOpacity = 1;

    private void Start()
    {
        starListSize = starTransforms.Count;
    }

    // Update is called once per frame
    void Update()
    {

        DrawConstellation();
        //DrawLine();

    }

    // IN-CLASS - ENABLED
    private void DrawConstellation()
    {
        Color lineColor = Color.white;
        lineColor.a = lineOpacity;

        for (int i = 0; i < starListSize - 1; i++)
        {
            Debug.DrawLine(starTransforms[i].position, starTransforms[i + 1].position, lineColor);

        }

        lineOpacity -= 0.0005f;

    }

    // JOURNAL 3 - DISABLED
    private void DrawLine()
    {


        Color lineColor = Color.white;
        lineColor.a = lineOpacity;

        for (int i = 0; i < starListSize - 1; i++)
        {
            float currentLineLength = 0f;
            float distance = Vector3.Distance(starTransforms[i + 1].position, starTransforms[i].position);

            while (currentLineLength <= distance)
            {
                Vector3 direction = new Vector3(starTransforms[i + 1].position.x - starTransforms[i].position.x, starTransforms[i + 1].position.y - starTransforms[i].position.y);
                Vector3 normalizedDirection = NormalizeVector(direction);
                Vector3 newPoint = new Vector3(starTransforms[i].position.x + (normalizedDirection.x * currentLineLength), starTransforms[i].position.y + (normalizedDirection.y * currentLineLength));

                Debug.DrawLine(transform.position, newPoint, Color.white);
                currentLineLength += 0.00001f;
            }
        }
    }

    Vector3 NormalizeVector(Vector3 v)
    {
        Vector3 normalized = new Vector3(v.x / GetMagnitude(v), v.y / GetMagnitude(v));
        return normalized;

    }

    float GetMagnitude(Vector3 v)
    {

        float magnitude = Mathf.Sqrt(v.x * v.x + v.y * v.y);
        return magnitude;

    }


}
