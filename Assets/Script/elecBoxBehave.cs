using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class elecBoxBehave : MonoBehaviour
{
    // Start is called before the first frame update

    public List<GameObject> disableOnBreak;
    public List<GameObject> enableOnBreak;

    public ParticleSystem sparkParticleSystem;
    public GameObject lid;

    void Start()
    {
        
    }

    // Update is called once per frame
    public void OnCollisionEnter(Collision det)
    {
        if (det.gameObject.CompareTag("dice") && lid.GetComponent<Rigidbody>().isKinematic)
        {
            lid.GetComponent<Rigidbody>().isKinematic = false;
            foreach (GameObject obj in disableOnBreak)
            {
                obj.SetActive(false);
            }
            foreach (GameObject obj in enableOnBreak)
            {
                obj.SetActive(true);
            }
            sparkParticleSystem.Emit(10);
            this.GetComponent<AudioSource>().Play();
            sparkParticleSystem.gameObject.GetComponent<AudioSource>().Play();
        }
    }
}
