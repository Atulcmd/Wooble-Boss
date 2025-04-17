using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SlideDoor : MonoBehaviour
{
    public Animator door;
    bool closed;
    // Start is called before the first frame update
    void Start()
    {
        closed = true;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player")) {

            if (closed)
            {
                closed = false;
                door.SetBool("Close", true);
                Debug.Log("Open the door!");
            }
            else {
                door.SetBool("Close", false);

                closed = true;
                Debug.Log("Closing");
            }

        }
    }
}
