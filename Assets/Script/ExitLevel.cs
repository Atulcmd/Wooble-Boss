using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using DG.Tweening;

public class ExitLevel : MonoBehaviour
{
    public GameObject left;
    public GameObject Right;
    public GameObject ConfettiBlast;

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
                left.GetComponent<DOTweenAnimation>().DOPlay();
                Right.GetComponent<DOTweenAnimation>().DOPlay();
                ConfettiBlast.SetActive(true);
                gameObject.transform.parent.transform.GetComponent<DOTweenAnimation>().DOPlay();
                GameManager2.instance.StartGameWin();
               // gameObject.SetActive(false);
                Debug.Log("Open the door!");
            }


        }
    }
}
