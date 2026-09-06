using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamManager : MonoBehaviour
{
    public Animator cam_controller;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            cam_controller.SetInteger("viewpoint", 0);
        }
        else if (Input.GetKeyDown(KeyCode.W))
        {
            cam_controller.SetInteger("viewpoint", 1);
        }else if (Input.GetKeyDown(KeyCode.S))
        {
            cam_controller.SetInteger("viewpoint", 4);
        }
        else if(Input.GetKeyDown(KeyCode.A))
        {
            cam_controller.SetInteger("viewpoint", 3);
        }
        else if(Input.GetKeyDown(KeyCode.D))
        {
            cam_controller.SetInteger("viewpoint", 2);
        }
    }
}
