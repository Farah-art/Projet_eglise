using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform joueur;
    public Vector3 offset;

    public float vitesse;
    public bool droite = true;

    void Start()
    {
        offset = new Vector3(2, 1.4f, -8.6f);
    }

    // Update is called once per frame
    void Update()
    {
        Rotation(droite);
        Vector3 positionFutur = joueur.position + offset ;
        Vector3 positionTransit = Vector3.Lerp(transform.position, positionFutur, vitesse*Time.deltaTime) ;
        transform.position = positionTransit;
    }

    void Rotation(bool droite)
    {
        if((droite && offset.x < 0) || (!droite && offset.x > 0))
        {
            offset.x *= -1;
        }
    }
}
