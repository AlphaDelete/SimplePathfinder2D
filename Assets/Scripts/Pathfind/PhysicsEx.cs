using UnityEngine;

// Class to make Physics2D act like Physics
public static class PhysicsEx
{
	// Bit shift the index of the layer (8) to get a bit mask
	// This would cast rays only against colliders in layer 8.
	// But instead we want to collide against everything except layer 8. The ~ operator does this, it inverts a bitmask.
	private static int layerMask = 1 << 8;

	public static bool Raycast2D(Vector2 rPosition, Vector2 rTarget, out RaycastHit2D rHit, float rDistance)
	{    
		rHit = Physics2D.Raycast(rPosition, rTarget, rDistance, ~layerMask);
		return (rHit) ? true : false;
	}

	public static bool Raycast2D(Vector3 rPosition, Vector3 rTarget, float rDistance)
	{    
		return (Physics2D.Raycast(rPosition, rTarget, rDistance, ~layerMask)) ? true : false;
	}
}
