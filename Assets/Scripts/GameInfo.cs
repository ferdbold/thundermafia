using UnityEngine;
using System.Collections;

public class GameInfo : MonoBehaviour
{
	
	/// <summary>
	/// Gets the player location.
	/// </summary>
	/// <returns>
	/// The player location.
	/// </returns>
	public static Vector3 GetPlayerLocation ()
	{
		GameObject[] go = GameObject.FindGameObjectsWithTag ("Player");
		
		foreach (GameObject player in go) {
			return player.transform.position;
		}
		
		throw new System.Exception("No player detected!");
	}
	
	/// <summary>
	/// Gets the player distance from point.
	/// </summary>
	/// <returns>
	/// The player distance from a point.
	/// </returns>
	/// <param name='point'>
	/// Point.
	/// </param>
	public static float GetPlayerDistanceFromPoint (Vector3 point)
	{
		Vector3 vec1, vec2;
		vec1 = GetPlayerLocation ();
		vec1.y = 0;
		vec2 = point;
		vec2.y = 0;
		return Vector3.Distance (vec2, vec1);
	}
	
	/// <summary>
	/// Gets the angle between player and a point.
	/// </summary>
	/// <returns>
	/// The angle between player and point.
	/// </returns>
	/// <param name='point'>
	/// Point.
	/// </param>
	public static float GetAngleBetweenPlayerAndPoint(Vector3 point)
	{
		return Vector3.Angle (point, GetPlayerLocation ());
	}
}
