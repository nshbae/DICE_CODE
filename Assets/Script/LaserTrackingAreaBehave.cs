using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserTrackingAreaBehave : MonoBehaviour
{
    public List<laserTurretBehave> laserTurretBehave;

    public void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag("dice") && !laserTurretBehave[0].isTracking)
        {
            foreach (laserTurretBehave laser in laserTurretBehave)
            {
                laser.isTracking = true;
            }
        }
    }

    public void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("dice") && laserTurretBehave[0].isTracking)
        {
            foreach (laserTurretBehave laser in laserTurretBehave)
            {
                laser.isTracking = false;
            }
        }
    }
}
