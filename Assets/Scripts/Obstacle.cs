using UnityEngine;
using System.Collections;

public class Obstacle : MonoBehaviour {

	public Transform m_upper;
	public SpriteRenderer m_upperSprite;
	public Transform m_lower;
	public SpriteRenderer m_lowerSprite;
	public float m_hole;
	public float m_holePosition;

	public GameObject[] m_upperBalkar;
	public GameObject[] m_lowerBalkar;

	// Use this for initialization
	void Start () {

	
	}
	
	// Update is called once per frame
	void Update () {


	
	}

	void OnCreated()
	{
		m_holePosition =  Random.Range(-6.5f, 6.5f);

		m_upper.localPosition = new Vector3(0,m_holePosition + m_upperSprite.bounds.extents.y + m_hole, 0);
		m_lower.localPosition = new Vector3(0,m_holePosition - m_upperSprite.bounds.extents.y - m_hole, 0);

		int randBalk = Random.Range(0, m_upperBalkar.Length);
		for (int i = 0; i < m_upperBalkar.Length; i++)
		{
			if (i == randBalk)
				m_upperBalkar[i].SetActive(true);
			else
				m_upperBalkar[i].SetActive(false);
		}

		randBalk = Random.Range(0, m_lowerBalkar.Length);
		for (int i = 0; i < m_lowerBalkar.Length; i++)
		{
			if (i == randBalk)
				m_lowerBalkar[i].SetActive(true);
			else
				m_lowerBalkar[i].SetActive(false);
		}
	}
}
