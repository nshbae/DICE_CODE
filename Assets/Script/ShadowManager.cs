using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShadowManager : MonoBehaviour
{
    public List<GameObject> LightPos;
    public GameObject Light;
    public int nowPos;//empty = -1

    // Start is called before the first frame update
    void Start()
    {
        Light.SetActive(false);
        nowPos = 0;
    }

    // Update is called once per frame
    void Update()
    {
        if((int)MainManager.DM.diceValue != nowPos)
        {
            nowPos = (int)MainManager.DM.diceValue;
            if(MainManager.DM.diceValue == slotValue.empty && Light.activeSelf)
            {
                Light.SetActive(false);
            }
            else if (MainManager.DM.diceValue != slotValue.empty && !Light.activeSelf)
            {
                Light.SetActive(true);
                Light.transform.position = LightPos[nowPos].transform.position;
            }

        }
    }
}
