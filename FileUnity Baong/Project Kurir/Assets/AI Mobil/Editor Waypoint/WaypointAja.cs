using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointAja : MonoBehaviour
{
    public WaypointAja previousWaypoint;

    public WaypointAja nextWaypoint;

    public List<WaypointAja> perempatan = new List<WaypointAja>();

    [Range(0f,5f)]
    public float width = 1f;
    // Start is called before the first frame update

    public Vector3 GetPosition(){
        Vector3 minBound = transform.position + transform.right * width / 2f;
        Vector3 maxBound = transform.position - transform.right * width / 2f;

        return Vector3.Lerp(minBound, maxBound, Random.Range(0f,1f));
    }
}
