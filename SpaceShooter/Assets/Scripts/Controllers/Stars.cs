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

    }

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

}
