using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainManager : MonoBehaviour
{
    public static CamManager CM;
    public static DiceManager DM;
    public static AnswerManager AM;


    public CamManager CamManager;
    public DiceManager DiceManager;
    public AnswerManager AnswerManager;

    private void Awake()
    {
        CM = CamManager; 
        DM = DiceManager;
        AM = AnswerManager;
    }
}
