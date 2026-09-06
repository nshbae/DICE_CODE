using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class starBehave : MonoBehaviour
{
    public float timeInterval;
    public List<GameObject> stars;
    public List<float> pitches;

    public Material starOn;
    public Material starOff;

    public List<AudioSource> vertexs;
    public List<FaceManager> faces;

    float timer;
    public int currentPitch;

    Ray ray;
    RaycastHit hit;
    bool aiming;

    // Start is called before the first frame update
    void Start()
    {
        pitches = new List<float>() {1f, 1.122f, 1.26f, 1.335f, 1.498f, 1.682f, 1.888f};
        currentPitch = 0;
        turnOn(currentPitch);
        /*
        C1
        1.059
        D1.122
        1.189
        E1.26
        F1.335
        1.414
        G1.498
        1.587
        A1.682
        1.782
        B1.888
        */
        foreach (FaceManager face in faces)
        {
            face.faceValue = slotValue.empty;
        }
    }

    // Update is called once per frame
    void Update()
    {
        timer += Time.deltaTime;
        if (timer > timeInterval)
        {
            timer = 0;
            currentPitch++;
            if(currentPitch >= pitches.Count)
            {
                currentPitch = 0;
            }
            turnOn(currentPitch);
        }
        if (Input.GetMouseButtonDown(0))
        {
            ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.collider.CompareTag("dice"))
                {
                    if (!MainManager.AM.isCorrect)
                    {
                        aiming = true;
                    }
                }
            }
        }

        if (Input.GetMouseButtonUp(0))
        {
            if (aiming)
            {
                aiming = false;
                //Debug.Log("!");
                foreach (FaceManager face in faces)
                {
                    face.faceValue = (slotValue) (currentPitch + 1);
                }
                setPitch();
            }
        }
    }

    public void turnOn(int i)
    {
        for(int j = 0; j < stars.Count; j++)
        {
            if (j == i)
            {
                stars[j].GetComponentInChildren<Light>().enabled = true;
                stars[j].GetComponentInChildren<MeshRenderer>().material = starOn;
            }
            else
            {
                stars[j].GetComponentInChildren<Light>().enabled = false;
                stars[j].GetComponentInChildren<MeshRenderer>().material = starOff;
            }
        }
    }

    public void setPitch()
    {
        for(int i = 0; i<vertexs.Count; i++)
        {
            vertexs[i].pitch = pitches[currentPitch] * 0.5f;
        }
    }
}
