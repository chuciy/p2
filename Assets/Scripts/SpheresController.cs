using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;


public class SpheresController : MonoBehaviour
{
    // Start is called before the first frame update
    public GameObject center;
    public float range;
    public float period;
    public float startPhase;
    public float height;

    private float _x;
    private float _y;
    private float _z;



    void Start()
    {
        _x = center.transform.position.x;
        _y = center.transform.position.y;
        _z = center.transform.position.z;
        period /= 2;
    }

    // Update is called once per frame
    void Update()
    {
        float d = Time.time;
        float x = range * MathF.Cos(d * MathF.PI / period + startPhase);
        float z = range * MathF.Sin(d * MathF.PI / period + startPhase);
        transform.position = new Vector3(x + _x, 
                                         height + _y, 
                                         z + _z);

    }
}
