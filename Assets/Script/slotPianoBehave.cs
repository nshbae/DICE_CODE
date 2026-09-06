using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class slotPianoBehave : MonoBehaviour
{
    public List<SlotManager> slots;
    public starBehave starBehave;
    public float noteTime;

    public Material starOn;
    public Material starOff;

    int index;
    public AudioSource sor;
    float timer;

    // Start is called before the first frame update
    void Start()
    {
        //MainManager.DM.gameObject.GetComponent<MeshRenderer>().material = starOn;
    }

    // Update is called once per frame
    void Update()
    {

        //timer += Time.deltaTime;
        //if(timer > noteTime)
        //{
        //    timer = 0;
        //    index++;
        //    if(index >= slots.Count + 1)
        //    {
        //        index = 0;
        //    }
        //    if(index != slots.Count && slots[index].slotValue != slotValue.empty)
        //    {
        //        sor.pitch = starBehave.pitches[(int)slots[index].slotValue - 1] * 2;
        //        sor.Play();
        //        turnOnNote();
        //    }
        //}
        //if(MainManager.DM.diceValue == slotValue.empty && MainManager.DM.gameObject.GetComponent<MeshRenderer>().material != starOff)
        //{
        //    MainManager.DM.gameObject.GetComponent<MeshRenderer>().material = starOff;
        //}
        //else if (MainManager.DM.diceValue != slotValue.empty && MainManager.DM.gameObject.GetComponent<MeshRenderer>().material != starOn)
        //{
        //    MainManager.DM.gameObject.GetComponent<MeshRenderer>().material = starOn;
        //}
    }

    public void turnOnNote()
    {
        for(int i=0;i< slots.Count;i++)
        {
            if(i == index)
            {
                slots[i].nowDice.GetComponent<MeshRenderer>().material = starOn;
            }
            else
            {
                slots[i].nowDice.GetComponent<MeshRenderer>().material = starOff;
            }
        }
    }
}
