using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour {

    private Animator anim;

    void Awake ()
    {
        anim = GetComponent<Animator>();
    }

	// Use this for initialization
	void Start () {
		
	}

    void OnCollisionEnter2D(Collision2D hit)
    {
        transform.position = new Vector3(Random.Range(960, -960), Random.Range(540, -540), 0);
        anim.SetTrigger("Click");
        // print("hit");
    }
	
	// Update is called once per frame
	void Update () {
        if (Input.GetMouseButtonDown(0))
        {
            transform.position = new Vector3(Random.Range(960, -960), Random.Range(540, -540), 0);
            anim.SetTrigger("Click");
            // print("mouse");
        }
	}
}
