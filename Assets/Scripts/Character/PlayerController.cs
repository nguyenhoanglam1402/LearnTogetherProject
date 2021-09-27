using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
  private CharacterController controller;
  private Vector3 playerVelocity;
  private bool groundedPlayer;
  [SerializeField]
  private float playerSpeed = 5.0f;
  private float jumpHeight = 1.0f;
  private float gravityValue = -9.81f;
  [SerializeField]
  private Joystick joystick;

  [SerializeField]
  private Transform cameraMain;
  [SerializeField]
  private Animator animator;

  private void Start()
  {
    controller = gameObject.GetComponent<CharacterController>();
    joystick = GameObject.FindObjectOfType<Joystick>();
    animator = gameObject.GetComponent<Animator>();
    cameraMain = Camera.main.transform;
  }

  void Update()
  {
    groundedPlayer = controller.isGrounded;
    if (groundedPlayer && playerVelocity.y < 0)
    {
      playerVelocity.y = 0f;
    }

    Vector3 move = (cameraMain.forward * joystick.Vertical + cameraMain.right * joystick.Horizontal);
    move.y = 0f;
    controller.Move(move * Time.deltaTime * playerSpeed);

    if (move != Vector3.zero)
    {
      gameObject.transform.forward = move;
      animator.SetBool("move", true);
    }
    else
    {
      animator.SetBool("move", false);
    }

    // Changes the height position of the player.

    playerVelocity.y += gravityValue * Time.deltaTime;
    controller.Move(playerVelocity * Time.deltaTime);
  }
}
