using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class NVC : MonoBehaviour
{
  [SerializeField]
  private NavMeshAgent character;
  [SerializeField]
  private GameObject[] destinations;
  public int randomPosition = 0;
  public float stopDistance = 5;
  // Start is called before the first frame update
  void Start()
  {
    character = GetComponent<NavMeshAgent>();
    character.updateRotation = true;
    character.stoppingDistance = stopDistance;
    destinations = GameObject.FindGameObjectsWithTag("destination");
    randomPosition = Random.Range(0, destinations.Length - 1);
    character.ResetPath();
  }

  // Update is called once per frame
  void Update()
  {
    if (((int)character.remainingDistance) > ((int)character.stoppingDistance))
    {
      Debug.Log(character.remainingDistance);
      character.SetDestination(destinations[randomPosition].transform.position);
    }
    else
    {
      Debug.Log(character.remainingDistance);
    }

  }


}
