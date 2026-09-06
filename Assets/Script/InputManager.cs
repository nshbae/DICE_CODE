using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputManager : MonoBehaviour
{
    Ray ray;
    RaycastHit hit;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("dice"))
                {
                    if (!MainManager.AM.isCorrect)
                    {
                        MainManager.DM.OnDiceClickDown();
                    }
                    else
                    {
                        MainManager.AM.readyLoad();
                    }
                }
                else if (hit.collider.CompareTag("slot"))
                {
                    SlotManager SM = hit.collider.GetComponent<SlotManager>();
                    SM.OnSlotClickDown();
                }
            }
        }
        else if (Input.GetMouseButtonUp(0))
        {
            if (MainManager.DM.diceState == diceState.aiming)
            {
                MainManager.DM.OnDiceClickUp();
            }
        }else if (Input.GetMouseButtonDown(1))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("slot"))
                {
                    SlotManager SM = hit.collider.GetComponent<SlotManager>();
                    SM.clearSlot();
                }
            }
        }


        if (Input.GetMouseButton(0))
        {
            if (MainManager.DM.diceState == diceState.aiming)
            {
                MainManager.DM.OnDiceClick();
            }
        }
    }
}
