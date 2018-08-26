using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class Live1 : MonoBehaviour {

   
    public float HP = 100f;
    public UnityEngine.UI.Text text;

   // private Animator animator = null; 
	// Use this for initialization
	void Start () {//animator = GetComponent<Animator>();
        GetComponent<Animator>().Play("walk");
    }
    // Update is called once per frame
    public void Update()
    {
        text.text = HP.ToString();
    }

      
    public void LifeDown(float l)
    {
          HP = HP > l ? HP - l:0;
        if (HP <= 0 && tag!="master")
        {
            GetComponent<Animator>().Play("fallingback");
        }
        if (HP <= 0 && tag == "master")
        { GetComponent<Animator>().Play("Unarmed-Death1"); }
            if (HP>0)
        { GetComponent<Animator>().Play("walk"); }
    }
}
