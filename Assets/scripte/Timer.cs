using UnityEngine;
using System.Collections;

public class Timer : MonoBehaviour {
	public int timer = 0;
	public int newtimer = 0;
	public GameObject Getimter;
	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void FixedUpdate () {
		timer -= 1;
		if(timer <= 0){
			if(Getimter.activeSelf == true){
				Getimter.SetActive(false);
			} else {
				Getimter.SetActive(true);
			}
			timer = newtimer;
		}
	}
}
