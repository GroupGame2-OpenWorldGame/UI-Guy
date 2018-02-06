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

	[SerializeField]
	private GameObject[] patrolPoints;
	[SerializeField]
	private int currentPoint;
	[SerializeField]
	private bool randomPatrol;
	[SerializeField]
	private bool patroling;

	// Use this for initialization
	void Start () {
		navAgent = this.GetComponent<NavMeshAgent> ();

		if (randomPatrol && !patroling) {
			patroling = true;
		}

		if (navAgent == null) {
			Debug.LogError ("The nav mesh agent is not attatched to " + gameObject.name);
		} else if (patroling) {
			ChangePatrol ();
		} else {
			SetDestination ();
		}
	}

	void Update()
	{
		if (isMovingTarget) {
			SetDestination ();
		}

		if (currentPoint >= patrolPoints.Length) {
			currentPoint = 0;
		}
	}

	void SetDestination () {
		if (destination != null && !patroling) {
			Vector3 targetVector = destination.transform.position;
			navAgent.SetDestination (targetVector);
		} else if (destination != null && patroling) {
			navAgent.SetDestination (patrolPoints [currentPoint].transform.position);
		}
	}

//	void OnTriggerEnter (Collider other)
//	{
//		if (other.CompareTag("PatrolPoint")) {
//			ChangePatrol ();
//			other.gameObject.SetActive (false);
//		}
//		Debug.Log ("enter " + other.name);
//	}

	public void ChangePatrol()
	{
		int tempPoint;
		if (randomPatrol) {
			tempPoint = Random.Range (0, patrolPoints.Length);
			currentPoint = tempPoint;
		} else {
			tempPoint = currentPoint;
			currentPoint++;
		}
		navAgent.SetDestination (patrolPoints [tempPoint].transform.position);
	}
}
