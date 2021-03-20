using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiShotCannon : MonoBehaviour
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
			FireAllProjectile();
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

		FireAllProjectile();
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

	void FireAllProjectile()
	{
		float fullAngle = 90;

		float angleDelta = fullAngle / (projectilePrefab.Length + 1);

		Quaternion startRotation = firePosition.rotation * Quaternion.Euler(0, -fullAngle / 2, 0);
		Quaternion rotation = startRotation;

		foreach(GameObject prefab in projectilePrefab)
		{
			rotation *= Quaternion.Euler(0, angleDelta, 0);
			FireProjectile(prefab, rotation);
		}
	}

	void FireProjectile(GameObject prefab, Quaternion rotation)
	{
		GameObject o = Instantiate(prefab, firePosition.transform.position, Quaternion.identity);

		o.transform.rotation = rotation;
	}
}
