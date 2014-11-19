using UnityEngine;
using System.Collections;

public class CameraControl : MonoBehaviour {
	
	RaycastHit hit;
	bool leftClickFlag = true;
	
	public GameObject actor;
	public string floorTag;

	Actor actorScript;
	
	void Start()
	{
		if (actor != null)
		{
			actorScript = (Actor)actor.GetComponent(typeof(Actor));
		}
	}
	
	void Update () 
	{
		/***Left Click****/
		if (Input.GetKey(KeyCode.Mouse0) && leftClickFlag)
			leftClickFlag = false;
		
		if (!Input.GetKey(KeyCode.Mouse0) && !leftClickFlag)
		{
			leftClickFlag = true;

			float X = camera.ScreenToWorldPoint(Input.mousePosition).x;
			float Y = camera.ScreenToWorldPoint(Input.mousePosition).y;
			
			Vector3 target = new Vector3(X, Y, actor.transform.position.z);
			
			actorScript.MoveOrder(target);
		}
	}
}
