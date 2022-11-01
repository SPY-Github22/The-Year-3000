using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Win : MonoBehaviour
{
    public GameObject WinScreen;
    public bool won;
    // Start is called before the first frame update
    void Start()
    {
        won = false;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D col) {
        if (col.gameObject.tag == "Finish") {
            WinScreen.SetActive(true);
            won = true;
        }
    }
}
