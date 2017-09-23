using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class poloController : MonoBehaviour {

    private gameController gc;

    private void Start()
    {
        gc = GameObject.Find("GameController").GetComponent<gameController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        print("trigger!");
        gc.FoundPolo();
        Destroy(this.gameObject);
    }
}
