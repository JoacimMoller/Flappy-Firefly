using UnityEngine;
using System.Collections;

public class ObstacleManager : MonoBehaviour {

	public GameObject m_obstaclePrefab;
	private Queue m_obstacles;  
	public Transform m_Zid;

	public float m_distance;
	public float m_initial_distance;
	private float lastX = 0;
	private int lastPlaced = 0;

	public GUIText m_ScoreText;
	public int score;

	public AudioSource m_bloop;

	// Use this for initialization
	void Start () {

		m_ScoreText.text = "" + 0;
		score = 0;

		m_obstacles = new Queue();        
		
		for (int i = -5; i < 5; i++)
		{
			if (i > -4 && i < 1)
				continue;

			GameObject g = Instantiate(m_obstaclePrefab, new Vector3(m_initial_distance + m_distance * i, 0f), Quaternion.identity) as GameObject;
			g.transform.parent = transform;
			g.SendMessage("OnCreated");
			m_obstacles.Enqueue(g);
			lastPlaced = i;

		}
	}
	
	// Update is called once per frame
	void Update () {


		if ((m_Zid.position.x - m_initial_distance) + - lastX > m_distance)
		{
			score++;
			m_ScoreText.text = "" +  score;
			m_bloop.Play();
			m_Zid.gameObject.SendMessage("OnPassingObstacle");

			GameObject g = (m_obstacles.Dequeue() as GameObject);
			lastPlaced++;
			g.transform.position = new Vector3(m_initial_distance + m_distance * lastPlaced, 0f);
			g.SendMessage("OnCreated");
			lastX += m_distance;
			m_obstacles.Enqueue(g);
		}
	}
}
