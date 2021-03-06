using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading.Tasks;
using System;

public class MovimientoPersonaje2 : MonoBehaviour
{

    bool HasJump;
    Rigidbody rb;
    float jumpForce = 5;
    public GameObject objeto;
    public GameObject victoria;

    public GameObject ObjectToClone;
    System.Random guido = new System.Random();
    int ary;

    System.Random guido2 = new System.Random();
    int ary2;

    // Start is called before the first frame update
    void Start()
    {
        HasJump = true;
        rb = GetComponent<Rigidbody>();

        ary = guido.Next(1, 6);
        ary2 = guido2.Next(-13, 13);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.W))
        {
            transform.Translate(0, 0, 0.1f);
        }

        if (Input.GetKey(KeyCode.S))
        {
            transform.Translate(0, 0, -0.1f);
        }

        if (Input.GetKey(KeyCode.D))
        {
            transform.Rotate(0, 3, 0);
        }

        if (Input.GetKey(KeyCode.A))
        {
            transform.Rotate(0, -3, 0);
        }

        if (Input.GetKeyDown(KeyCode.LeftShift) && HasJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            HasJump = false;
        }
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.name == "DeathWall" || col.gameObject.name == "Fuego" || col.gameObject.name == "FuegoGanar" || col.gameObject.name == "EsferaKiller")
        {
            transform.position = new Vector3(0, 0.5f, -13.5f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (col.gameObject.name == "Piso" || col.gameObject.name == "Agua" || col.gameObject.name == "InvisibleAgua" || col.gameObject.name == "InvisibleFuego" || col.gameObject.name == "Boton" || col.gameObject.name == "Piso2" || col.gameObject.name == "Piso3")
        {
            HasJump = true;
        }

        if (col.gameObject.name == "Boton")
        {
            objeto.SetActive(true);
        }

        if (col.gameObject.name == "AguaGanar")
        {
            victoria.SetActive(true);
            Task.Delay(5000);
            victoria.SetActive(false);
        }

        if (col.gameObject.name == "Piso2" || col.gameObject.name == "Piso3")
        {
            rb.constraints = RigidbodyConstraints.FreezePositionX;
            rb.constraints = RigidbodyConstraints.FreezePositionY;
            rb.constraints = RigidbodyConstraints.FreezePositionZ;
        }

        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;
            /*rb.constraints = RigidbodyConstraints.FreezeRotationX;
            rb.constraints = RigidbodyConstraints.FreezeRotationY;
            rb.constraints = RigidbodyConstraints.FreezeRotationZ;*/
        }

        if (col.gameObject.name == "Piso3")
        {
            Task.Delay(1500);
            for (int i = 0; i <= ary; i++)
            {
                ObjectToClone.transform.position = new Vector3(ary2, 84, 235);
                Instantiate(ObjectToClone);
            }

            ary = guido.Next(1, 6);
            ary2 = guido2.Next(-13, 13);
        }
    }
}
