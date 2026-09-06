using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class wireBehave : MonoBehaviour
{
    public Material offWire;
    public Material onWire;
    public int sign;
    public WireSlot ws1;
    public WireSlot ws2;

    public void turnOn(bool isOn)
    {
        if (isOn)
        {
            this.GetComponent<MeshRenderer>().material = onWire;
        }
        else
        {
            this.GetComponent<MeshRenderer>().material = offWire;
        }
    }
    /*
    public GameObject plusMother;
    public GameObject minusMother;
    //public List<wireSlotBehave> ConnectedSlots;

    public void connectPlus(GameObject pm)
    {
        this.plusMother = pm;
        checkWireOn();
    }
    public void connectPlus(wireConnect wc)
    {
        this.plusMother = wc.connectedWire[0].GetComponent<wireBehave>().plusMother;
        checkWireOn();
    }
    public void connectMinus(GameObject mm)
    {
        this.minusMother = mm;
        checkWireOn();
    }
    public void connectMinus(wireConnect wc)
    {
        this.minusMother = wc.connectedWire[0].GetComponent<wireBehave>().minusMother;
        checkWireOn();
    }

    public void checkWireOn()
    {
        if (plusMother != null && minusMother != null)
        {
            if (plusMother.GetComponent<wireSlotBehave>() != null && minusMother.GetComponent<wireSlotBehave>() != null)
            {
                if (plusMother.GetComponent<wireSlotBehave>().sign == 999 && minusMother.GetComponent<wireSlotBehave>().sign == -999)
                {
                    this.GetComponent<MeshRenderer>().material = onWire;
                    return;
                }
            }
        }
        this.GetComponent<MeshRenderer>().material = offWire; ;
    }
    */
}
