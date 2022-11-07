using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Main_Controll : MonoBehaviour
{
    public List<Camera> cameras;
    public GameObject upper_box;
    private bool _ceiling;
    // Start is called before the first frame update
    void Start()
    {
        cameras[0].enabled = true;
        _ceiling = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Toggle_ceiling() 
    {
        _ceiling =  !_ceiling;
        upper_box.SetActive(_ceiling);
    }
}
