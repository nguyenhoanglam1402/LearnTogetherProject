using UnityEngine;
using Cinemachine;

public class CameraLook : MonoBehaviour
{
  [SerializeField]
  private Player playerInput;
  [SerializeField]
  private CinemachineFreeLook cinemachine;
  [SerializeField]
  private int SpeedLook = 0;
  // Start is called before the first frame update
  void Awake()
  {
    playerInput = new Player();
    cinemachine = GetComponent<CinemachineFreeLook>();
  }

  private void OnEnable()
  {
    playerInput.Enable();
  }

  // Update is called once per frame
  void Update()
  {
    Vector2 delta = playerInput.PlayerMain.Look.ReadValue<Vector2>();
    cinemachine.m_XAxis.Value += delta.x * 200 * SpeedLook * Time.deltaTime;
    cinemachine.m_YAxis.Value -= delta.y * SpeedLook * Time.deltaTime;
  }
}
