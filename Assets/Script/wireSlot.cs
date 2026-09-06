using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class WireSlot : MonoBehaviour
{
    public wireBehave[] link;

    public WireSlot(wireBehave[] link)
    {
        this.link = link;
    }
    public WireSlot()
    {
        this.link = new wireBehave[4];
    }
    public WireSlot connectedWireSlot(wireBehave wb)
    {
        if (wb.ws1 == this)
        {
            return wb.ws2;
        }
        else
        {
            return wb.ws1;
        }
    }

}