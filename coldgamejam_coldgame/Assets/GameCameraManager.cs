using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Com.LuisPedroFonseca.ProCamera2D;

public class GameCameraManager : MonoBehaviour
{
    public ProCamera2DCinematics proCamera2DCinematics;

    public void Awake()
    {
        proCamera2DCinematics = FindObjectOfType<ProCamera2DCinematics>();
    }
    
    // Start is called before the first frame update
    void Start()
    {

        proCamera2DCinematics.Play();
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
