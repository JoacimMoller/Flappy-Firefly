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

	bool m_dead = false;

	public Light m_light;

	public GUIText m_gameOverText;

	// Use this for initialization
	void Start () {
        rigidbody2D.isKinematic = true;
	
	}
	
	// Update is called once per frame
	void Update () {
		if (m_dead)
			return;

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
		if (m_dead)
			return;

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

	IEnumerator OnCollisionEnter2D(Collision2D collision)
	{
		if (!m_dead)
		{

			m_dead = true;

			m_gameOverText.gameObject.SetActive(true);


			yield return new WaitForSeconds(0.1f);

			while(!Input.anyKeyDown)
				yield return null;



			Application.LoadLevel(0);
		}

	}

	IEnumerator OnPassingObstacle()
	{
		 //light.intensity = 
		float default_intens = 5.5f;
		//float default_range = 12f;

		m_light.intensity = default_intens + 9f;
		//m_light.range = default_range + 4f;

		while (m_light.intensity > default_intens)
		{
			m_light.intensity = m_light.intensity - Time.deltaTime * 4f;
			//m_light.range = m_light.range - Time.deltaTime * 4f;
			yield return null;
		}

		m_light.intensity = default_intens;
		//m_light.range = default_range;

		yield return null;
	}
}
