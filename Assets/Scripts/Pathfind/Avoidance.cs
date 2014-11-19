using UnityEngine;
using System.Collections;

public class Avoidance : MonoBehaviour {
	
	public bool DebugMode;
	
	void Update () 
	{
		UpdateRay2d();
		//UpdateRay3d();
	}
	void UpdateRay2d () {

		/***if to close to a wall move away***/
		float distance = 0.5f;
		RaycastHit2D hit;
		// -X
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(-distance, 0), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(-distance, 0, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(resistPower, 0, 0));
			}
		}
		// +X
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(distance, 0), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(distance, 0, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(-resistPower, 0, 0));
			}
		}
		// +Y
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(0, distance), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(0, distance, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(0, -resistPower, 0));
			}
		}
		// -Y
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(0, -distance), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(0, -distance, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(0, resistPower, 0));
			}
		}
		// +X/+Y
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(distance, distance), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(distance, distance, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(-resistPower, -resistPower, 0));
			}
		}
		// +X/-Y
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(distance, -distance), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(distance, -distance, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(-resistPower, resistPower, 0));
			}
		}
		// -X/+Y
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(-distance, distance), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(-distance, distance, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(resistPower, -resistPower, 0));
			}
		}
		// -X/-Y
		if (PhysicsEx.Raycast2D(transform.position, new Vector2(-distance, -distance), out hit, distance))
		{
			if (hit.transform.tag != "con")
			{
				if (DebugMode)
					Debug.DrawLine(transform.position, transform.position + new Vector3(-distance, -distance, 0));
				float resistPower = 0.1f - hit.distance/(distance*10);
				MoveTo (new Vector3(resistPower, resistPower, 0));
			}
		}
	}
	
	private void MoveTo (Vector3 movement)
	{
		transform.position += movement;
	}
}
