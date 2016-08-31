using UnityEngine;
using System.Collections;
using System;

[ExecuteInEditMode]
public class fon_position : MonoBehaviour
{

    public SpriteRenderer sr;
    public int dx = 40;
    public int dy = 40;
    // Use this for initialization
    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }
    bool IsInt(object obj)
    {
        return Convert.ToInt32(obj) == Convert.ToDouble(obj);
    }
    // Update is called once per frame
    void Update()
    {
        sr.sortingOrder = 1000 - (int)((transform.position.y) * 100.0f);
        int x_d = Convert.ToInt32(sr.transform.position.x * 100 / dx);
        float x = dx * (float)x_d / 100;


        int y_d = Convert.ToInt32(sr.transform.position.y * 100 / dy);
        float y = dy * (float)y_d / 100;

        if (IsInt(y_d / 2))
        {
            x += dx / 200;
        }

        sr.transform.position = new Vector3(x, y, sr.transform.position.z);
    }
}
