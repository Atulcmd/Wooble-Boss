using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CashCheck : MonoBehaviour
{
    public GameObject CoinBlast;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    public void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Selector"))
        {
            Debug.Log("Haha");
            CoinBlast.SetActive(true);
            GameManager2.instance.AddScore();
            gameObject.SetActive(false);

        }
    }

   
}
