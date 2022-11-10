using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Controll : MonoBehaviour
{
    public List<Camera> cameras;

    public GameObject upper_box;
    public GameObject trees;
    public GameObject outter_particle;
    private bool _ceiling;

    public GameObject dir_light;
    public float daylight_time;
    private float timer;
    // Start is called before the first frame update
    void Start()
    {
        cameras[0].enabled = true;
        _ceiling = true;
        timer = 0.0f;
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer >= daylight_time) 
        {
            timer -= daylight_time;
        }
        //dir_light.transform.Rotate(Vector3.right * 360 * Time.deltaTime / daylight_time);
        dir_light.transform.eulerAngles = Vector3.right * 360 * timer / daylight_time;

    }

    public void Toggle_ceiling() 
    {
        _ceiling =  !_ceiling;
        upper_box.SetActive(_ceiling); 
        trees.SetActive(!_ceiling);
        outter_particle.SetActive(!_ceiling);
    }
}
