using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public class wireManager : MonoBehaviour
{
    public List<wireBehave> wireList;
    public void checkConnect(wireBehave wb)
    {
        Debug.Log(FindBiggestConnectedPlus(wb).sign + ", "+ FindSmallestConnectedMinus(wb).sign);
        if (FindBiggestConnectedPlus(wb).sign == 999 && FindSmallestConnectedMinus(wb).sign == -999)
        {
            wb.turnOn(true);
        }
        else
        {
            wb.turnOn(false);
        }
    }

    public wireBehave FindBiggestConnectedPlus(wireBehave wb)
    {
        wireBehave temp = new wireBehave();
        if (wb.ws1 != null)
        {
            foreach (wireBehave connected in wb.ws1.link)
            {
                if (connected != null)
                {
                    if (connected.sign > wb.sign)
                    {
                        temp = FindBiggestConnectedPlus(connected);
                    }
                    else
                    {
                        temp = wb;
                    }
                }
            }
        }

        wireBehave temp2 = new wireBehave();
        if (wb.ws2 != null)
        {
            foreach (wireBehave connected in wb.ws2.link)
            {
                if (connected != null)
                {
                    if (connected.sign > wb.sign)
                    {
                        temp2 = FindBiggestConnectedPlus(connected);
                    }
                    else
                    {
                        temp2 = wb;
                    }
                }
            }
        }

        if (temp.sign > temp2.sign)
        {
            return temp;
        }
        else
        {
            return temp2;
        }
    }
    public wireBehave FindSmallestConnectedMinus(wireBehave wb)
    {
        wireBehave temp = new wireBehave();
        if (wb.ws1 != null)
        {
            foreach (wireBehave connected in wb.ws1.link)
            {
                if (connected != null)
                {
                    if (connected.sign < wb.sign)
                    {
                        temp = FindSmallestConnectedMinus(connected);
                    }
                    else
                    {
                        temp = wb;
                    }
                }
            }
        }

        wireBehave temp2 = new wireBehave();
        if (wb.ws2 != null)
        {
            foreach (wireBehave connected in wb.ws2.link)
            {
                if (connected != null)
                {
                    if (connected.sign < wb.sign)
                    {
                        temp2 = FindSmallestConnectedMinus(connected);
                    }
                    else
                    {
                        temp2 = wb;
                    }
                }
            }
        }

        if (temp.sign < temp2.sign)
        {
            return temp;
        }
        else
        {
            return temp2;
        }
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void checkWiresOn()
    {
        foreach(wireBehave wb in wireList)
        {
            checkConnect(wb);
        }
    }
}
