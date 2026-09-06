using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum dir
{
    up,
    down, 
    left, 
    right
}

[System.Serializable]
public class wireConnect
{
    //public int sign;
    //public wireBehave wb;
    public GameObject thisSlot;
    //public GameObject mother;
    public dir wireDir;
    public List<GameObject> connectedWire;
}

public class wireSlotBehave : MonoBehaviour
{
    public wireManager wireManager;
    public int sign;
    //public Material wireLight;
    //public Material wireDark;
    public List<wireConnect> wireConnects;
    SlotManager SM;
    slotValue nowSlot;
    // Start is called before the first frame update
    void Start()
    {
        SM = this.gameObject.GetComponent<SlotManager>();
        nowSlot = SM.slotValue;
        for(int i=0;i<wireConnects.Count;i++)
        {
            if (wireConnects[i].connectedWire.Count > 0)
            {
                //wireConnects[i].wb = wireConnects[i].connectedWire[0].GetComponent<wireBehave>();
                wireConnects[i].thisSlot = this.gameObject;
                
            }
        }
    }

    // Update is called once per frame
    void Update()
    {
        if(nowSlot != SM.slotValue)
        {
            nowSlot = SM.slotValue;
            changeWireSlot(nowSlot);
        }
    }

    public void clearSlotConnection()
    {
        //changeWireSlot(nowSlot);
        foreach (wireConnect wc in wireConnects)
        {
            foreach (GameObject go in wc.connectedWire)
            {
                //go.GetComponent<MeshRenderer>().material = wireDark;
                /*if(Mathf.Abs(wc.maxSign) < Mathf.Abs(go.GetComponent<wireBehave>().sign))
                {
                    wc.maxSign = go.GetComponent<wireBehave>().sign;
                }*/
            }
        }
    }

    public void connectWire(dir dir1, dir dir2)
    {
        if(dir1 == dir2)
        {
            return;
        }
        bool dir1exist = false;
        bool dir2exist = false;
        wireConnect wc1 = wireConnects[0];
        wireConnect wc2 = wireConnects[0];
        foreach (wireConnect wc in wireConnects)
        {
            if(wc.wireDir == dir1)
            {
                dir1exist = true;
                wc1 = wc;
            }
            if (wc.wireDir == dir2)
            {
                dir2exist = true;
                wc2 = wc;
            }
        }
        if(!dir1exist || !dir2exist)
        {
            return;
        }

        c12(wc1, wc2);
        c12(wc2, wc1);
    }

    void c12(wireConnect wc1, wireConnect wc2)
    {
        int sign1 = wc1.connectedWire[0].GetComponent<wireBehave>().sign;
        int sign2 = wc2.connectedWire[0].GetComponent<wireBehave>().sign;
        if (sign1 > 0)
        {
            if (sign2 > 0)
            {
                if (sign1 - 1 > sign2)
                {
                    //wc2.wb.sign = wc1.wb.sign - 1;
                    //wc1.thisSlot.GetComponent<wireSlotBehave>().sign = sign1;
                    foreach(GameObject wire in wc2.connectedWire)
                    {
                        wire.GetComponent<wireBehave>().sign = sign1 - 1;
                        //wire.GetComponent<wireBehave>().connectPlus(wc1);
                    }
                }
                else if (sign1 < sign2 - 1)
                {
                    //wc1.wb.sign = wc2.wb.sign - 1;
                    //wc1.thisSlot.GetComponent<wireSlotBehave>().sign = sign2;
                    foreach (GameObject wire in wc1.connectedWire)
                    {
                        wire.GetComponent<wireBehave>().sign = sign2 - 1;
                        //wire.GetComponent<wireBehave>().connectPlus(wc2);
                    }
                }
            }
            else if(sign2 == 0)
            {
                foreach (GameObject wire in wc2.connectedWire)
                {
                    wire.GetComponent<wireBehave>().sign = sign1 - 1;
                    //wire.GetComponent<wireBehave>().connectPlus(wc1);
                }
            }
            else if (sign2 < 0)
            {
                //Lightup(wc1, wc2);
            }
        }
        else if (sign1 < 0)
        {
            if (sign2 > 0)
            {
                //Lightup(wc1, wc2);
            }
            else if (sign2 == 0)
            {
                foreach (GameObject wire in wc2.connectedWire)
                {
                    wire.GetComponent<wireBehave>().sign = sign1 + 1;
                    //wire.GetComponent<wireBehave>().connectPlus(wc1);
                }
            }
            else if (sign2 < 0)
            {
                if (sign1 + 1 < sign2)
                {
                    //wc2.wb.sign = wc1.wb.sign + 1;
                    //wc1.thisSlot.GetComponent<wireSlotBehave>().sign = sign1;
                    foreach (GameObject wire in wc2.connectedWire)
                    {
                        wire.GetComponent<wireBehave>().sign = sign1 + 1;
                        //wire.GetComponent<wireBehave>().connectPlus(wc1);
                    }
                }
                else if (sign1 > sign2 + 1)
                {
                    //wc1.wb.sign = wc2.wb.sign + 1;
                    //wc1.thisSlot.GetComponent<wireSlotBehave>().sign = sign2;
                    foreach (GameObject wire in wc1.connectedWire)
                    {
                        wire.GetComponent<wireBehave>().sign = sign2 + 1;
                        //wire.GetComponent<wireBehave>().connectPlus(wc2);
                    }
                }
            }
        }

        /*
        if (Mathf.Sign(wc1.sign) == Mathf.Sign(wc2.sign))
        {
            if (Mathf.Abs(wc1.sign) > Mathf.Abs(wc2.sign) + 1)
            {
                if (wc1.sign > 0)
                {
                    wc2.sign = wc1.sign - 1;
                }
                else
                {
                    wc2.sign = wc1.sign + 1;
                }
            }
        }
        else
        {
            foreach (GameObject wire in wc1.connectedWire)
            {
                wire.GetComponent<MeshRenderer>().material = wireLight;
            }
            foreach (GameObject wire in wc2.connectedWire)
            {
                wire.GetComponent<MeshRenderer>().material = wireLight;
            }
        }*/

        //Debug.Log("connected" + wc1.wireDir.ToString() + ", " + wc2.wireDir.ToString());
    }

    public GameObject findWireBetween(wireConnect wc1, wireConnect wc2)
    {
        foreach (GameObject wire in wc1.connectedWire)
        {
            foreach (GameObject wire2 in wc2.connectedWire)
            {
                if (wire == wire2)
                {
                    return wire;
                }
            }
        }

        return null;
    }
    /*
    public void Lightup(wireConnect wc1, wireConnect wc2)
    {

        Debug.Log("lighting " + wc1.thisSlot.name + ", " + wc2.thisSlot.name);
        foreach (GameObject wire in wc1.connectedWire)
        {
            if(wire.GetComponent<wireBehave>().sign == wc1.maxSign)
                wire.GetComponent<MeshRenderer>().material = wireLight;
        }
        foreach (GameObject wire in wc2.connectedWire)
        {
            if (wire.GetComponent<wireBehave>().sign == wc2.maxSign)
                wire.GetComponent<MeshRenderer>().material = wireLight;
        }

        
        GameObject between = findWireBetween(wc1, wc2);
        if (between != null)
        {
            between.GetComponent<MeshRenderer>().material = wireLight;
        }*/
    /*
    wireConnect temp = wc1;
    wireConnect temp2 = wc1;
    for (int i = 0; i < 100; i++)
    {
        between = findWireBetween(wc1, wc2);
        if (between.GetComponent<wireBehave>().mother == null)
        {
            break;
        }
        else
        {
            temp2 = temp.mother.GetComponent<wireConnect>();
            Lightup(temp, temp2);
            temp = temp2;
            temp2 = temp2.mother.GetComponent<wireConnect>();
        }
    }
    temp = wc2;
    temp2 = wc2;
    for (int i = 0; i < 100; i++)
    {
        if (temp2 == null)
        {
            break;
        }
        else
        {
            temp2 = temp.mother.GetComponent<wireConnect>();
            Lightup(temp, temp2);
            temp = temp2;
            temp2 = temp2.mother.GetComponent<wireConnect>();
        }
    }
}
    */
    public void changeWireSlot(slotValue slot)
    {
        //clearSlotConnection();
        switch (slot)
        {
            case slotValue.one_12:
            case slotValue.one_3:
            case slotValue.one_6:
            case slotValue.one_9:
                connectWire(dir.up, dir.left);
                connectWire(dir.up, dir.right);
                connectWire(dir.up, dir.down);
                connectWire(dir.left, dir.right);
                connectWire(dir.left, dir.down);
                connectWire(dir.right, dir.down);
                break;
            case slotValue.two_12:
                connectWire(dir.left, dir.right);
                break;
            case slotValue.two_3:
                connectWire(dir.up, dir.down);
                break;
            case slotValue.two_6:
                connectWire(dir.left, dir.right);
                break;
            case slotValue.two_9:
                connectWire(dir.up, dir.down);
                break;
            case slotValue.three_12:
                connectWire(dir.up, dir.left);
                connectWire(dir.up, dir.right);
                connectWire(dir.left, dir.right);
                break;
            case slotValue.three_3:
                connectWire(dir.up, dir.down);
                connectWire(dir.up, dir.right);
                connectWire(dir.down, dir.right);
                break;
            case slotValue.three_6:
                connectWire(dir.down, dir.left);
                connectWire(dir.down, dir.right);
                connectWire(dir.left, dir.right);
                break;
            case slotValue.three_9:
                connectWire(dir.up, dir.down);
                connectWire(dir.up, dir.left);
                connectWire(dir.down, dir.left);
                break;
            case slotValue.four_12:
            case slotValue.four_3:
            case slotValue.four_6:
            case slotValue.four_9:
                connectWire(dir.up, dir.down);
                connectWire(dir.right, dir.left);
                break;
            case slotValue.five_12:
                connectWire(dir.up, dir.right);
                connectWire(dir.left, dir.down);
                break;
            case slotValue.five_3:
                connectWire(dir.up, dir.left);
                connectWire(dir.right, dir.down);
                break;
            case slotValue.five_6:
                connectWire(dir.up, dir.right);
                connectWire(dir.left, dir.down);
                break;
            case slotValue.five_9:
                connectWire(dir.up, dir.left);
                connectWire(dir.right, dir.down);
                break;
            case slotValue.six_12:
                connectWire(dir.up, dir.left);
                break;
            case slotValue.six_3:
                connectWire(dir.up, dir.right);
                break;
            case slotValue.six_6:
                connectWire(dir.down, dir.right);
                break;
            case slotValue.six_9:
                connectWire(dir.down, dir.left);
                break;
        }
        wireManager.checkWiresOn();
    }
}
