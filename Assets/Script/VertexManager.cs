using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class VertexManager : MonoBehaviour
{
    public bool isMonoPitched;
    AudioSource sor;
    Rigidbody diceRB;
    public float volumeThreshold;

    // Start is called before the first frame update
    void Start()
    {
        sor = this.GetComponent<AudioSource>();
        diceRB = this.GetComponentInParent<Rigidbody>();
    }

    // Update is called once per frame
    public void OnTriggerEnter(Collider det)
    {
        if (!det.isTrigger)
        {
            //Debug.Log(diceRB.velocity.magnitude);
            sor.volume = diceRB.velocity.magnitude > volumeThreshold ? 1f : diceRB.velocity.magnitude / volumeThreshold;
            if (!isMonoPitched)
            {
                sor.pitch = sor.volume / 2f + 0.5f;
            }
            sor.Play();
        }
    }
}
