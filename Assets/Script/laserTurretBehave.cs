using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class laserTurretBehave : MonoBehaviour
{
    public LineRenderer laser;
    public bool isTracking;
    AudioSource sor;
    public List<GameObject> smokeEffect;

    public List<SlotManager> slots;
    // Start is called before the first frame update
    void Start()
    {
        laser.enabled = false;
        sor = this.GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        this.transform.LookAt(MainManager.DM.transform.position);
        if (isTracking || MainManager.DM.diceValue == slotValue.five_12)
        {
            if (!laser.enabled)
            {
                laser.enabled = true;
                sor.Play();
                foreach(GameObject smoke in smokeEffect) 
                {
                    if(smoke != smokeEffect[0])
                    {
                        smoke.SetActive(true);
                    }
                    else
                    {
                        var emission = smokeEffect[0].GetComponent<ParticleSystem>().emission;
                        emission.rateOverTime = 10f;
                    }
                }
            }
            float length = (MainManager.DM.transform.position - this.transform.position).magnitude - 1f;
            laser.SetPosition(1, Vector3.forward * length);
            if(smokeEffect.Count > 0)
            {
                smokeEffect[0].transform.position = MainManager.DM.transform.position;
            }
            foreach (SlotManager slot in slots)
            {
                if(slot.slotValue != slotValue.empty)
                {
                    slot.clearSlot();
                }
            }
        }
        else if (laser.enabled)
        {
            laser.enabled = false;
            sor.Stop();
            foreach (GameObject smoke in smokeEffect)
            {
                if (smoke != smokeEffect[0])
                {
                    smoke.SetActive(false);
                }
                else
                {
                    var emission = smokeEffect[0].GetComponent<ParticleSystem>().emission;
                    emission.rateOverTime = 0f;
                }
            }
        }
    }

    public void fireLaser()
    {

    }
}
