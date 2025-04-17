using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharSelect : MonoBehaviour
{
    int index;
    public GameObject[] chars;
    // Start is called before the first frame update
    void Start()
    {
       index =  PlayerPrefs.GetInt("CURRENT_CHARACTER", 0);
        chars[index].SetActive(true);
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
