using UnityEngine;

public class Car : MonoBehaviour
{
  [SerializeField]
  private GameObject[] cars;

  [SerializeField]
  private GameObject[] characters;

  [SerializeField]
  private float speed = 20f;
  [SerializeField]
  private float distanceStop = 10f;
  // Start is called before the first frame update
  void Start()
  {
    characters = GameObject.FindGameObjectsWithTag("people");
    cars = GameObject.FindGameObjectsWithTag("car");
  }

  // Update is called once per frame
  void Update()
  {
    float characterDistance = Vector3.Distance(characters[0].transform.position, transform.position);
    Debug.Log(characterDistance);
    if (characterDistance > distanceStop)
    {
      transform.Translate(Vector3.up * Time.deltaTime * speed);
    }
    else
    {
      transform.Translate(Vector3.zero);
    }
  }
}
