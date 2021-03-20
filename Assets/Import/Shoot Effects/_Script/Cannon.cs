using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour
{
	public Transform firePosition;
	public GameObject[] projectilePrefab;
	public bool autoFire = false;
	[Range(0.1f, 10f)] public float fireInterval = 1.0f;       // number of fire per


	private float m_fireCooldown = 0;

	public int selectedIndex = 0;

	private void Awake()
	{
	
	}

	// Start is called before the first frame update
	void Start()
    {
	}

    // Update is called once per frame
    void Update()
    {
		if (Input.GetMouseButtonDown(0) || Input.GetKeyDown(KeyCode.Space)) 
		{
			FireProjectile();
		}

		if(Input.GetKeyDown(KeyCode.O))
		{
			SelectLastProjectile();
		}

		if (Input.GetKeyDown(KeyCode.P))
		{
			SelectNextProjectile();
		}

		HandleAutoFire();
	}

	void HandleAutoFire()
	{
		if(autoFire == false)
		{
			return;
		}

		if(m_fireCooldown > 0)
		{
			m_fireCooldown -= Time.deltaTime;
			return;
		}

		FireProjectile();
		m_fireCooldown = fireInterval;
	}

	void SelectNextProjectile()
	{
		int newIndex = selectedIndex + 1;
		if(newIndex >= projectilePrefab.Length)
		{
			newIndex = 0;
		}
		selectedIndex = newIndex;
	}

	void SelectLastProjectile()
	{
		int newIndex = selectedIndex - 1;
		if (newIndex < 0)
		{
			newIndex = projectilePrefab.Length - 1;
		}
		selectedIndex = newIndex;
	}

	GameObject GetSelectedPrefab()
	{
		return projectilePrefab[selectedIndex];
	}

	void FireProjectile()
	{
		GameObject o = Instantiate(GetSelectedPrefab(), firePosition.transform.position, Quaternion.identity);

		o.transform.rotation = firePosition.rotation;
	}
}
