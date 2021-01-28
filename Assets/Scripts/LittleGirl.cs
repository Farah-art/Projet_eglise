using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LittleGirl : Character
{
    public float hauteurSaut;

    //Récupération des variables du parent
    public LittleGirl(CharacterController c, float s, float g, Vector3 v, Transform solC, float solD,LayerMask solM, bool auS)
    {
        controller = c;
        speed = s;
        gravity = g;
        velocity = v;
        solCheck = solC;
        solDistance = solD;
        solMask = solM;
        auSol = auS;
    }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
