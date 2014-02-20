using UnityEngine;
using System.Collections;

public class FollowTarget : MonoBehaviour {

    public Transform m_Target;

	// Use this for initialization
	void Start () {
	
	}
	
	// Update is called once per frame
	void Update () {
        transform.position = new UnityEngine.Vector3(m_Target.position.x, transform.position.y, transform.position.z);
	}
}
