using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FaceManager : MonoBehaviour
{
    public float timer;
    public bool grounded;

    public slotValue faceValue;
    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            grounded = true;
        }
    }
    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("wall"))
        {
            grounded = false;
        }
    }

    public void Update()
    {
        if ((this.transform.position - Physics.gravity.normalized * 0.5f - this.transform.parent.transform.position).magnitude < 0.2f)
        {
            if (grounded)
            {
                if(timer < 0.3f)
                {
                    timer += Time.deltaTime;
                }
                else if (MainManager.DM.diceValue != faceValue)
                {
                    MainManager.DM.diceValue = faceValue;
                }
            }
            else if (timer > 0)
            {
                timer = 0;
                if (MainManager.DM.diceValue == faceValue)
                {
                    MainManager.DM.diceValue = slotValue.empty;
                }
            }
        }
    }
}
