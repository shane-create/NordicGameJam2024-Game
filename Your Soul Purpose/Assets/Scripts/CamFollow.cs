using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{



	public Transform target;
	public float smoothTime = 0.2f;
	private Vector3 _velocity = Vector3.zero;
	public float offset = 2;

	void Start()
	{


	}
	void Update()
	{

		Vector3 Targetposition = new Vector3(target.transform.position.x, target.transform.position.y + offset, this.transform.position.z);
		transform.position = Vector3.SmoothDamp(transform.position, Targetposition, ref _velocity, smoothTime);

	}
}
