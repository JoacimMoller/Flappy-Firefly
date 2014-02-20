using UnityEngine;
using System.Collections;

public class Background : MonoBehaviour {

    public GameObject m_Background_Strip;
    public Transform m_Zid;

    private Queue m_backgrounds;    
    private float lastX = 0;
    private int lastPlaced = 0;

	// Use this for initialization
	void Start () {
        m_backgrounds = new Queue();        

        for (int i = -5; i < 10; i++)
        {
            GameObject g = Instantiate(m_Background_Strip, new Vector3(10.18576f * i, 0f), Quaternion.identity) as GameObject;
            g.transform.parent = transform;
            m_backgrounds.Enqueue(g);
            lastPlaced = i;
        }
	}

    // Update is called once per frame
    void Update()
    {
        if (m_Zid.position.x - lastX > 10.18576f)
        {
            GameObject g = (m_backgrounds.Dequeue() as GameObject);
            lastPlaced++;
            g.transform.position = new Vector3(10.18576f * lastPlaced, 0f);
            lastX += 10.18576f;
            m_backgrounds.Enqueue(g);
        }
	
	}
}
