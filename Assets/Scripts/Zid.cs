using UnityEngine;
using System.Collections;

public class Zid : MonoBehaviour {

    public Transform m_Sprite;
    public float m_upImpulse = 20f;
    public float m_startImpulse = 10f;
    public float m_forwardForce = 5f;

    private bool m_doImpulse = false;
    private bool m_doStartImpulse = true;
    private bool m_started = false;

	// Use this for initialization
	void Start () {
        rigidbody2D.isKinematic = true;
	
	}
	
	// Update is called once per frame
	void Update () {
        

        if (Input.anyKeyDown)
        {
            
            m_doImpulse = true;

            m_started = true;
            rigidbody2D.isKinematic = false;
        } 


        Vector3 vel = new Vector3(rigidbody2D.velocity.x, rigidbody2D.velocity.y);
        m_Sprite.right = (vel).normalized;
    }

    void FixedUpdate()
    {
        if (!m_started)
            return;

        rigidbody2D.AddForce(new Vector2(m_forwardForce, 0));


        if (m_doImpulse)
        {
            rigidbody2D.AddForce(new Vector2(0, m_upImpulse / Time.deltaTime));
            m_doImpulse = false;
        }

        if (m_doStartImpulse)
        {
            rigidbody2D.AddForce(new Vector2(m_startImpulse / Time.deltaTime, 0));
            m_doStartImpulse = false;
        }
    }
}
