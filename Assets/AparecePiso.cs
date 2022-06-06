using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AparecePiso : MonoBehaviour
{

    public GameObject ObjectToClone;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void Instantiateobject()
    {
        Instantiate(ObjectToClone);
    }
}
