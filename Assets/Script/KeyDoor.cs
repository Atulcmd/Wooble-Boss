using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;
public class KeyDoor : MonoBehaviour
{
    public GameObject door;

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
        if (other.gameObject.CompareTag("Player"))
        {

            if (closed)
            {
                closed = false;
                //door.SetBool("Close", true);
                door.GetComponent<DOTweenAnimation>().DOPlayForward();
                gameObject.SetActive(false);
                Debug.Log("Open the door!");
            }
          

        }
    }
}
