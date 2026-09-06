using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public enum ledState
{
    off,
    red,
    green
}
public class LEDbehave : MonoBehaviour
{
    public ledState ledState;
    // Start is called before the first frame update
    void Start()
    {
        UpdateLED(ledState.off);
    }

    // Update is called once per frame
    public void UpdateLED(ledState state)
    {
        ledState = state;
        switch (ledState)
        {
            case ledState.off:
                this.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0f,0f,0f,0.8f));
                this.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.black);
                this.GetComponent<Light>().enabled = false;
                break;
            case ledState.red:
                this.GetComponent<Light>().color = Color.red;
                this.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(1f, 0f, 0f, 0.8f));
                this.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.red);
                this.GetComponent<Light>().enabled = true;
                break; 
            case ledState.green:
                this.GetComponent<Light>().color = Color.green;
                this.GetComponent<MeshRenderer>().material.SetColor("_Color", new Color(0f, 1f, 0f, 0.8f));
                this.GetComponent<MeshRenderer>().material.SetColor("_EmissionColor", Color.green);
                this.GetComponent<Light>().enabled = true;
                break;
        }
    }
}
