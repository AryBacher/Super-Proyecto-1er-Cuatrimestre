using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovimientoPersonaje2 : MonoBehaviour
{

    bool HasJump;
    Rigidbody rb;
    float jumpForce = 5;

    // Start is called before the first frame update
    void Start()
    {
        HasJump = true;
        rb = GetComponent<Rigidbody>();
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
        if (col.gameObject.name == "DeathWall")
        {
            transform.position = new Vector3(0, 0.5f, -13.5f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (col.gameObject.name == "Fuego")
        {
            transform.position = new Vector3(4.5f, 0.5f, -13.5f);
            transform.eulerAngles = new Vector3(0, 0, 0);
        }

        if (col.gameObject.name == "Piso" || col.gameObject.name == "Agua")
        {
            HasJump = true;
        }
    }
}
