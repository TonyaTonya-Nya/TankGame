using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class ProjectileMove : MonoBehaviour
{
	public float speed = 14;

	[SerializeField] protected GameObject m_hitPrefab;
	[SerializeField] protected GameObject m_muzzlePrefab;
	[SerializeField] protected AudioClip m_shotSFX;

	protected bool m_collided = false;
	protected Rigidbody m_rigidbody;

	void Awake()
	{
		gameObject.tag = "Bullet";  // ken: Make sure the Tag is added,
									// the tag is used to prevent collision

		m_rigidbody = GetComponent<Rigidbody>();
	}



	// Start is called before the first frame update
	void Start()
	{
		CreatewMuzzleVFX();
		PlayShotSound();
	}

	// Update is called once per frame
	void Update()
	{
		MoveProjectile();
	}

	void MoveProjectile()
	{
		if(speed <= 0 || m_rigidbody == null)
		{
			return;
		}

		//m_rigidbody.MovePosition(transform.forward * speed )
		m_rigidbody.position += transform.forward * (speed * Time.deltaTime);
	}

	void CreatewMuzzleVFX()
	{
		if(m_muzzlePrefab == null)
		{
			return;
		}

		var muzzleVFX = Instantiate(m_muzzlePrefab, transform.position, Quaternion.identity);
		muzzleVFX.transform.forward = gameObject.transform.forward;

		DestroyParticle(muzzleVFX);
	}

    void CreateHitVFX(ContactPoint contact)
	{
		if(m_hitPrefab == null)
		{
			return;
		}

		Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
		Vector3 pos = contact.point;
		//Debug.Log("hitPrefab=" + hitPrefab);
		var hitVFX = Instantiate(m_hitPrefab, pos, rot) as GameObject;

		DestroyParticle(hitVFX);
	}

	void DestroyParticle(GameObject obj)
	{
		var ps = obj.GetComponent<ParticleSystem>();
		if (ps == null)
		{
			ps = obj.transform.GetComponentInChildren<ParticleSystem>();
		}

		if (ps != null)
		{
			Destroy(obj, ps.main.duration);
		}
	}

	void PlayShotSound()
	{
		AudioSource source = GetComponent<AudioSource>();
		if (source == null)
		{
			return;
		}
		if (m_shotSFX == null)
		{
			return;
		}

		source.PlayOneShot(m_shotSFX);
	}

	void OnCollisionEnter(Collision co)
	{
		//Debug.Log("OnCollisionEnter: co=" + co);
		if (co.gameObject.tag == "Bullet")
		{
			return;     // Bullet not collide with other bullet
		}

        if(m_collided)
		{
			return;
		}

		HandleCollision(co);

		ClearProjectile();
	}

   
    void HandleCollision(Collision co)
	{
		m_collided = true;

		if (co.contactCount > 0)
		{
			ContactPoint cp = co.GetContact(0);

			CreateHitVFX(cp);
		}

		
	}

    void DisablePhysics()
	{
		m_rigidbody.isKinematic = true; //not collide any more
		speed = 0;
	}

	void ClearProjectile()
	{
		Destroy(gameObject);
	}

}
