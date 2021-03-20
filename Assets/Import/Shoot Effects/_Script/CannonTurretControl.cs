using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonTurretControl : MonoBehaviour
{
	protected Quaternion m_originRotation;  // Local Rotation
	protected Vector3 m_originEuler;        // Local Rotation (using Euler)
	protected Vector2 deltaDegree;

	[SerializeField] float xRange = 90;
	[SerializeField] float yRange = 90;
	[SerializeField] float delta = 1;

	void Awake()
	{
		m_originRotation = transform.localRotation;
		m_originEuler = m_originRotation.eulerAngles;
	}

	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		UpdateDeltaDegree();
	}

	protected void UpdateDeltaDegree()
	{
		if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.A))
		{
			float newAngle = deltaDegree.y - delta;
			deltaDegree.y = Mathf.Max(newAngle, -xRange);
		}

		if (Input.GetKey(KeyCode.RightArrow) || Input.GetKey(KeyCode.D))
		{
			float newAngle = deltaDegree.y + delta;
			deltaDegree.y = Mathf.Min(newAngle, xRange);
		}

		if (Input.GetKey(KeyCode.UpArrow) || Input.GetKey(KeyCode.W))
		{
			float newAngle = deltaDegree.x - delta;
			deltaDegree.x = Mathf.Max(newAngle, -yRange);
		}

		if (Input.GetKey(KeyCode.DownArrow) || Input.GetKey(KeyCode.S))
		{
			float newAngle = deltaDegree.x + delta;
			deltaDegree.x = Mathf.Min(newAngle, yRange);
		}

		SetRotation(deltaDegree.x, deltaDegree.y);
	}


    public void SetRotation(float xRotation, float yRotation)
	{
		Quaternion change = Quaternion.Euler(xRotation, yRotation, 0);

		transform.localRotation = m_originRotation * change;
	}
}
