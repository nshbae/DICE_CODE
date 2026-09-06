using System.Collections;
using System.Collections.Generic;
using Unity.IO.LowLevel.Unsafe;
using UnityEngine;
using UnityEngine.UIElements;

[System.Serializable]
public enum slotValue
{
    empty,
    one_12,
    one_3,
    one_6,
    one_9,
    two_12,
    two_3,
    two_6,
    two_9,
    three_12,
    three_3,
    three_6,
    three_9,
    four_12,
    four_3,
    four_6,
    four_9,
    five_12,
    five_3,
    five_6,
    five_9,
    six_12,
    six_3,
    six_6,
    six_9,
}

public class SlotManager : MonoBehaviour
{
    public bool isNotRotatable;
    public GameObject virtualDicePrefab;
    public GameObject nowDice;
    public GameObject diceContainer;
    public slotValue slotValue;

    AudioSource sor;

    // Start is called before the first frame update
    void Start()
    {
        nowDice = Instantiate(virtualDicePrefab, this.transform.position, Quaternion.identity, diceContainer.transform);
        nowDice.GetComponent<MeshRenderer>().material = MainManager.DM.gameObject.GetComponent<MeshRenderer>().material;
        sor = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    public void OnSlotClickDown()
    {
        if(MainManager.DM.diceValue != slotValue.empty)
        {
            if (isNotRotatable)
            {
                slotValue = (slotValue)((int)MainManager.DM.diceValue);
                if (MainManager.AM.gameObject.GetComponent<starBehave>())
                {
                    starBehave temp = MainManager.AM.gameObject.GetComponent<starBehave>();
                    sor.pitch = temp.vertexs[0].pitch;
                }
                if (MainManager.AM.gameObject.GetComponent<ColorDiceManager>())
                {
                    nowDice.GetComponent<MeshRenderer>().material = MainManager.AM.gameObject.GetComponent<ColorDiceManager>().colorMat[(int)slotValue];
                    Debug.Log(MainManager.AM.gameObject.GetComponent<ColorDiceManager>().colorMat[(int)slotValue].name);
                }
            }
            else if (slotValue - MainManager.DM.diceValue >= 4 || slotValue - MainManager.DM.diceValue < 0) //슬롯과 주사위가 다른 면인 상태
            {
                slotValue = (slotValue)((int)MainManager.DM.diceValue + Random.Range(0, 4));
            }
            else //슬롯과 주사위가 같은면이면 90도 회전
            {
                if ((int)(slotValue - 1) / 4 == (int)(slotValue) / 4)
                {
                    slotValue = (slotValue)((int)slotValue + 1);
                }
                else
                {
                    slotValue = (slotValue)((int)slotValue - 3);
                }
            }
            sor.Play();

            if (MainManager.AM)
            {
                MainManager.AM.OnSlotValueChange();
            }
        }
        switch (slotValue)
        {
            case slotValue.empty:
                //slotValue = slotValue.empty;
                break;
            case slotValue.one_12:
                nowDice.transform.localRotation = Quaternion.Euler(0, 90, 90);
                break;
            case slotValue.one_3:
                nowDice.transform.localRotation = Quaternion.Euler(0, 180, 90);
                break;
            case slotValue.one_6:
                nowDice.transform.localRotation = Quaternion.Euler(0, 270, 90);
                break;
            case slotValue.one_9:
                nowDice.transform.localRotation = Quaternion.Euler(0, 0, 90);
                break;
            case slotValue.two_12:
                nowDice.transform.localRotation = Quaternion.Euler(90, 0, 90);
                break;
            case slotValue.two_3:
                nowDice.transform.localRotation = Quaternion.Euler(90, 0, 0);
                break;
            case slotValue.two_6:
                nowDice.transform.localRotation = Quaternion.Euler(90, 0, -90);
                break;
            case slotValue.two_9:
                nowDice.transform.localRotation = Quaternion.Euler(90, 0, -180);
                break;
            case slotValue.three_12:
                nowDice.transform.localRotation = Quaternion.Euler(180, -90, 0);
                break;
            case slotValue.three_3:
                nowDice.transform.localRotation = Quaternion.Euler(180, 0, 0);
                break;
            case slotValue.three_6:
                nowDice.transform.localRotation = Quaternion.Euler(180, 90, 0);
                break;
            case slotValue.three_9:
                nowDice.transform.localRotation = Quaternion.Euler(180, 180, 0);
                break;
            case slotValue.four_12:
                nowDice.transform.localRotation = Quaternion.Euler(0, -90, 0);
                break;
            case slotValue.four_3:
                nowDice.transform.localRotation = Quaternion.Euler(0, 0, 0);
                break;
            case slotValue.four_6:
                nowDice.transform.localRotation = Quaternion.Euler(0, 90, 0);
                break;
            case slotValue.four_9:
                nowDice.transform.localRotation = Quaternion.Euler(0, 180, 0);
                break;
            case slotValue.five_12:
                nowDice.transform.localRotation = Quaternion.Euler(-90, -180, 90);
                break;
            case slotValue.five_3:
                nowDice.transform.localRotation = Quaternion.Euler(-90, -180, 180);
                break;
            case slotValue.five_6:
                nowDice.transform.localRotation = Quaternion.Euler(-90, -180, 270);
                break;
            case slotValue.five_9:
                nowDice.transform.localRotation = Quaternion.Euler(-90, -180, 0);
                break;
            case slotValue.six_12:
                nowDice.transform.localRotation = Quaternion.Euler(0, -90, -90);
                break;
            case slotValue.six_3:
                nowDice.transform.localRotation = Quaternion.Euler(0, 0, -90);
                break;
            case slotValue.six_6:
                nowDice.transform.localRotation = Quaternion.Euler(0, 90, -90);
                break;
            case slotValue.six_9:
                nowDice.transform.localRotation = Quaternion.Euler(0, 180, -90);
                break;

        }
        if (slotValue != slotValue.empty)
        {
            nowDice.SetActive(true);
        }
        else
        {
            nowDice.SetActive(false);
        }
    }

    public void clearSlot()
    {
        slotValue = slotValue.empty;
        nowDice.SetActive(false);
        if (MainManager.AM)
        {
            MainManager.AM.OnSlotValueChange();
        }
    }


    public void clearSlot(bool isCall)
    {
        slotValue = slotValue.empty;
        nowDice.SetActive(false);
        if (MainManager.AM && isCall)
        {
            MainManager.AM.OnSlotValueChange();
        }
    }
}
