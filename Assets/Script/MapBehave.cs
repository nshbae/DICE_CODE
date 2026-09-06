using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapBehave : MonoBehaviour
{
    public List<GameObject> activeOnPlay;
    public List<GameObject> releaseIsKinematic;
    public void MapLoadDone()
    {
        MainManager.AM.SetLed();

        foreach (GameObject obj in releaseIsKinematic)
        {
            obj.GetComponent<Rigidbody>().isKinematic = false;
        }

        foreach (GameObject obj in activeOnPlay)
        {
            obj.SetActive(true);
        }
    }
}
