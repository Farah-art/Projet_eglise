using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    private bool monstreEtat = false;
    public Vector3 mouvement;

    private float speed;
    private float saut;
    private float masse;
    private float gravity;
    private Transform tete;
    public LayerMask plafondMask;
    private bool hitTete;

    public float speedF;
    public float sautF;
    public float masseF;
    public float gravityF;
    public Transform teteF;

    public float speedM;
    public float sautM;
    public float masseM;
    public float gravityM;
    public Transform teteM;

    private GameObject character;
    private CharacterController controller;
    public CameraFollow cam;

    public GameObject gbF;
    public GameObject gbM;
    
    private float[] fille;
    private float[] monstre;
    
    /////////////////////////////////////////////////////////////////////////////////////////////

    // Start is called before the first frame update
    void Start()
    {
        fille = new float[4] { speedF, sautF, masseF, gravityF};
        monstre = new float[4] { speedM, sautM, masseM, gravityM };
        ChangeGB(gbF, 0, fille);
    }

    // Update is called once per frame
    void Update()
    {
        float x = Input.GetAxis("Horizontal");
        mouvement.x = x * speed;

        if(controller.isGrounded && mouvement.y < 0)
        {
            mouvement.y = masse;
        }

        if(Input.GetButtonDown("Transformation") && !monstreEtat)
        {
            ChangeGB(gbM, 1.3f, monstre);
            monstreEtat = true;
        }
        else if(Input.GetButtonDown("Transformation") && monstreEtat)
        {
            ChangeGB(gbF, -0.6f, fille);
            monstreEtat = false;
        }        

        Rotate();
        Jump();
        //hitTete = Physics.CheckSphere(tete, 0.4f, plafondMask);
        //Debug.Log("teteF.position : " + (character.transform.position + teteF.TransformPoint(0,0,0)));

        //Debug.DrawLine(tete, new Vector3(0, 0.4f, 0), Color.red, 2.5f);


        if (hitTete)
        {
            Debug.Log("Detection objet");
        }
        
        mouvement.y += gravity * Time.deltaTime;        
        controller.Move(mouvement * Time.deltaTime);
    }

    /////////////////////////////////////////////////////////////////////////////////////////////


    void ChangeGB(GameObject gb, float decalage, float[] stats)
    {
        Vector3 spawn;
        //Debug.Log("Transformation");

        if (!character)
        {
            spawn = transform.position + new Vector3(0, decalage, 0);
        }
        else
        {
            spawn = character.transform.position + new Vector3(0, decalage, 0);
        }

        Destroy(character);
        character = Instantiate(gb, spawn, Quaternion.identity, transform);
        controller = character.GetComponent<CharacterController>();
        cam.joueur = character.transform;
        speed = stats[0];
        saut = stats[1];
        masse = stats[2];
        gravity = stats[3];
    }

    void Jump()
    {
        if (Input.GetButtonDown("Jump") && controller.isGrounded)
        {
            mouvement.y = Mathf.Sqrt(saut * -2 * gravity);
        }
    }

    void Rotate()
    {
        if (cam.droite && mouvement.x < 0)
        {
            cam.droite = false;
            character.transform.Rotate(0, 180, 0);
        }
        else if (!cam.droite && mouvement.x > 0)
        {
            cam.droite = true;
            character.transform.Rotate(0, -180, 0);
        }
    }
    

    void DetectionTete()
    {
        
    }
}
