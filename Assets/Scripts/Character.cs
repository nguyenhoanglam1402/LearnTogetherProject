using UnityEngine;

public class Character : MonoBehaviour
{
  private float speed = 10.0f;
  private Joystick joystick;
  // Start is called before the first frame update
  void Start()
  {
    joystick = FindObjectOfType<Joystick>();
  }

  // Update is called once per frame
  void Update()
  {
    var rigidbody = GetComponent<Rigidbody>();
    if (joystick.Horizontal > 0 || joystick.Horizontal < 0 ||
    joystick.Vertical > 0 || joystick.Vertical < 0)
    {
      transform.Translate(Vector3.right * joystick.Horizontal * Time.deltaTime * speed);
      transform.Translate(Vector3.forward * joystick.Vertical * Time.deltaTime * speed);
    }
  }
}
