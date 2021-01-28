using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour
{
    protected CharacterController controller;

    //Variables liés au déplacement
    public float speed;
    public float gravity;
    protected Vector3 velocity;

    //Variable pour détection du sol
    public Transform solCheck;
    public float solDistance = 0.2f;
    public LayerMask solMask;
    public bool auSol;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Gravity(gravity);
        Deplacement(speed);
        //Jump(hauteurSaut);    

        /*if (Input.GetButtonDown("Transformation"))
        {
            Debug.Log("Touche transformation");
            Transformation();
        }*/
    }

    void Deplacement(float speed)
    {
        float x = Input.GetAxis("Horizontal");
        Vector3 deplacement = transform.right * x * speed;
        controller.Move(deplacement * Time.deltaTime);
    }

    void Gravity(float gravity)
    {
        auSol = Physics.CheckSphere(solCheck.position, solDistance, solMask); //Vérifie si le joueur est au sol à partir de layers

        if (auSol && velocity.y < 0)
        {
            velocity.y = -4f;
        }

        velocity.y += gravity * Time.deltaTime;

        controller.Move(velocity * Time.deltaTime);
    }

    void Jump(float hauteurSaut)
    {
        float y = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump") && auSol)
        {
            velocity.y = Mathf.Sqrt(hauteurSaut * -2f * gravity);
        }
    }

    /*void Transformation()
    {
        if(!monster)
        {
            speed += speedMonstre;
            hauteurSaut += hauteurSautMonstre;
            transform.localScale *= scaleMonstre;
            monster = true;
        }
        else
        {
            speed -= speedMonstre;
            hauteurSaut -= hauteurSautMonstre;
            transform.localScale /= scaleMonstre;
            monster = false;
        }
    }*/
}


