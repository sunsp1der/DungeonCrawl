using UnityEngine;
using System.Collections;

public class lerppractise : MonoBehaviour {

	public Vector3 StartPosition;
	public Vector3 EndPosition;
	//public float Amount;
	public Vector3 EndSize;
	Vector3 StartSize;
	float StartTime;
	public MethodButton _DoMove;
	bool Moving = false;
float HalfElapsed;
	// Use this for initialization
	void Start () {
	
	StartSize = gameObject.transform.localScale;
	

	
	}
	
	// Update is called once per frame
	void Update () {
		if (Moving) {
			float elapsed = (Time.time - StartTime) / 5.0f;
			HalfElapsed = (Time.time - StartTime) / 2.5f;
			gameObject.transform.localScale = Vector3.Lerp (StartSize, EndSize, HalfElapsed);
			gameObject.transform.position = Vector3.Lerp (StartPosition, EndPosition, elapsed);
			if (elapsed >= 1){
				Moving = false;
			}
		}
	}
	
	void DoMove () {
		Moving = true;
		StartTime = Time.time;
		StartPosition = gameObject.transform.position;
		EndPosition = StartPosition + new Vector3 (5, 0, 0); 
		Invoke("Shrink", 2.5f);
	}
	void Shrink () {
	gameObject.transform.localScale = Vector3.Lerp (EndSize, StartSize, HalfElapsed);
	}
}
