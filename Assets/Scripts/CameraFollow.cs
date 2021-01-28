using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform joueur;
    public Vector3 offset;

    public float vitesse;

    void Start()
    {
        offset = new Vector3(3.1f,0.8f,-7.6f);
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 positionFutur = joueur.position + offset ;
        Vector3 positionTransit = Vector3.Lerp(transform.position, positionFutur, vitesse*Time.deltaTime) ;
        transform.position = positionTransit;
    }
}
