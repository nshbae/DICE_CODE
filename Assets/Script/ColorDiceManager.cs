using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColorDiceManager : MonoBehaviour
{

    public List<Material> colorMat;
    public List<GameObject> slotDices;

    public slotValue nowCol;
    public Light light;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(MainManager.DM.diceValue != nowCol)
        {
            nowCol = MainManager.DM.diceValue;
            MainManager.DM.gameObject.GetComponent<MeshRenderer>().material = colorMat[(int)nowCol];
            switch (nowCol)
            {
                case slotValue.empty:
                    light.color = Color.white;
                    break;
                case slotValue.one_12:
                    light.color = Color.cyan;
                    break;
                case slotValue.one_3:
                    light.color = Color.magenta;
                    break;
                case slotValue.one_6:
                    light.color = Color.yellow;
                    break;
                case slotValue.one_9:
                    light.color = Color.red;
                    break;
                case slotValue.two_12:
                    light.color = Color.green;
                    break;
                case slotValue.two_3:
                    light.color = Color.blue;
                    break;
            }
        }
    }
}
