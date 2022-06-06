using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Threading.Tasks;

public class MovimientoPersonaje : MonoBehaviour
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
        //Debug.Log(Input.GetAxis("Vertical"));

        //transform.Translate(0, 0, 0.1f * Input.GetAxis("Vertical"));

        if (Input.GetKey(KeyCode.UpArrow))
        {
            transform.Translate(0, 0, 0.1f);
        }

        if (Input.GetKey(KeyCode.DownArrow))
        {
            transform.Translate(0, 0, -0.1f);
        }

        if (Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(0, 3, 0);
        }

        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(0, -3, 0);
        }

        if (Input.GetKeyDown(KeyCode.Space) && HasJump)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            HasJump = false;
        }

    }

    void OnCollisionEnter(Collision col)
    {
       if (col.gameObject.name == "DeathWall")
       {
            transform.position = new Vector3(4.5f, 0.5f, -13.5f);
            transform.eulerAngles = new Vector3(0,0,0);
       }

       if (col.gameObject.name == "Agua")
       {
            transform.position = new Vector3(4.5f, 0.5f, -13.5f);
            transform.eulerAngles = new Vector3(0, 0, 0);
       }

        if (col.gameObject.name == "Piso" || col.gameObject.name == "Fuego")
        {
                HasJump = true;
        }
    }
}
