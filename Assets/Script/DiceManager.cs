using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum diceState
{
    idle,
    aiming,
    rolling
}

public class DiceManager : MonoBehaviour
{
    public slotValue diceValue;
    //public Animator dice_controller;
    public Rigidbody dice;
    public diceState diceState;

    public DragUIBehave dragUI;

    public Vector3 touchPoint;

    public float maxTorque;
    public float maxVelocity;

    // Start is called before the first frame update
    void Start()
    {
        diceState = diceState.idle;
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnDiceClickDown()
    {
        if (diceState == diceState.idle)
        {
            maxVelocity = PlayerPrefs.GetFloat("MaxVelocity");
            touchPoint = Input.mousePosition;
            diceState = diceState.aiming;
        }
    }

    public void OnDiceClickUp()
    {
        if (diceState == diceState.aiming)
        {
            Vector3 temp = touchPoint - Input.mousePosition;
            float angle = Mathf.Atan2(temp.y, temp.x) - 90f * Mathf.Deg2Rad;
            Vector3 forceDir = Vector3.zero;
            Vector3 torqueDir = Vector3.zero;


            if (Physics.gravity.normalized == Vector3.down)
            {
                forceDir = new Vector3(temp.x, temp.magnitude, temp.y);
                torqueDir = new Vector3(Mathf.Cos(angle), 0, Mathf.Sin(angle));
                /*
                dice.AddForce(new Vector3(temp.x, temp.magnitude, temp.y) * maxVelocity, ForceMode.Impulse);
                torqueDir = new Vector3(temp.magnitude * Mathf.Cos(angle), 0, temp.magnitude * Mathf.Sin(angle));
                dice.AddTorque(torqueDir * maxTorque, ForceMode.Impulse);*/
            }
            else if (Physics.gravity.normalized == Vector3.up)
            {
                forceDir = new Vector3(temp.x, -temp.magnitude, temp.y);
                torqueDir = new Vector3(-Mathf.Cos(angle), 0, -Mathf.Sin(angle));
            }
            else if (Physics.gravity.normalized == Vector3.right)
            {
                forceDir = new Vector3(-temp.magnitude, temp.y, -temp.x);
                torqueDir = new Vector3(0, Mathf.Sin(angle), -Mathf.Cos(angle));
            }
            else if (Physics.gravity.normalized == Vector3.left)
            {
                forceDir = new Vector3(temp.magnitude, temp.y, temp.x);
                torqueDir = new Vector3(0, Mathf.Sin(angle), Mathf.Cos(angle));
            }
            else if (Physics.gravity.normalized == Vector3.forward)
            {
                forceDir = new Vector3(temp.x, temp.y, -temp.magnitude);
                torqueDir = new Vector3(Mathf.Cos(angle), Mathf.Sin(angle), 0);
            }
            else if (Physics.gravity.normalized == Vector3.back)
            {
                forceDir = new Vector3(temp.x, temp.y, temp.magnitude);
                torqueDir = new Vector3(Mathf.Cos(angle), -Mathf.Sin(angle), 0);
            }

            dice.AddForce(forceDir * maxVelocity, ForceMode.Impulse);
            dice.AddTorque(torqueDir * temp.magnitude * maxTorque, ForceMode.Impulse);

            diceState = diceState.idle;
            dragUI.setDragUI(Vector3.zero);
        }
    }

    public void OnDiceClick()
    {
        if (diceState == diceState.aiming)
        {
            dragUI.setDragUI(touchPoint - Input.mousePosition);
        }
    }
}
