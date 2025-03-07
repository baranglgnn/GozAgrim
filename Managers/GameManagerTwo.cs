using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManagerTwo : MonoBehaviour
{
    
   public static GameManagerTwo Instance;

    public int sceneIndex;
    private void Awake()
    {
        Instance = this;
    }
}
