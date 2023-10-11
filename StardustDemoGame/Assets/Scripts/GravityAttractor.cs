using System.Collections;
using System.Collections.Generic;
using UnityEngine;

	public class GravityAttractor : MonoBehaviour
	{

		public float gravity = -9.8f;
		public Rigidbody body;
	    public Transform player;
		public Transform planet;

    private void FixedUpdate()
    {
		//Vector3 downwardForce = (player.transform.position - transform.position).normalized;
	

    }
}

