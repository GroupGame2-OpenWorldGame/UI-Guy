using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NPCMove : MonoBehaviour {

	[SerializeField]
	private Transform destination;

	private NavMeshAgent navAgent;

	[SerializeField]
	private bool isMovingTarget;

	// Use this for initialization
	void Start () {
		navAgent = this.GetComponent<NavMeshAgent> ();

		if (navAgent == null) {
			Debug.LogError ("The nav mesh agent is not attatched to " + gameObject.name);
		} else {
			SetDestination ();
		}
	}

	void Update()
	{
		if (isMovingTarget) {
			SetDestination ();
		}
	}

	void SetDestination () {
		if (destination != null) {
			Vector3 targetVector = destination.transform.position;
			navAgent.SetDestination (targetVector);
		}
	}
}
