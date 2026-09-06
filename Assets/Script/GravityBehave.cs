using System.Collections;
using System.Collections.Generic;
using Unity.Burst.CompilerServices;
using UnityEngine;

public class GravityBehave : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;
    float gravAmount;
    // Start is called before the first frame update
    void Start()
    {
        gravAmount = Physics.gravity.magnitude;
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("slot"))
                {
                    Vector3 dir = Vector3.down;
                    switch (MainManager.DM.diceValue)
                    {
                        case slotValue.one_12://A
                            dir = Vector3.up;
                            break;
                        case slotValue.two_12://T
                            dir = Vector3.left;
                            break;
                        case slotValue.three_12://G
                            dir = Vector3.forward;
                            break;
                        case slotValue.four_12://R
                            dir = Vector3.back;
                            break;
                        case slotValue.five_12://Y
                            dir = Vector3.right;
                            break;
                        case slotValue.six_12://I
                            dir = Vector3.down;
                            break;
                    }
                    Physics.gravity = dir * gravAmount;
                }
            }
            if (MainManager.AM.loadClicked)
            {
                Physics.gravity = Vector3.down * gravAmount;
            }
        }
    }
}
