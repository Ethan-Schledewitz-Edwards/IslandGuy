using UnityEngine;
using UnityEngine.InputSystem;

[RequireComponent (typeof(Rigidbody))]
public class PlayerController : MonoBehaviour
{
	private const float walkSpeed = 20f;

	// Components
	private Rigidbody rb;

	// System
	private Vector2 rawInputDir;

	#region Init

	private void Awake()
	{
		rb = GetComponent<Rigidbody>();

		// Freeze rb rotation & enable interpolation
		rb.freezeRotation = true;
		rb.interpolation = RigidbodyInterpolation.Interpolate;
	}

	private void Start()
	{
		SubscribeInput();
	}
	#endregion

	private void OnDestroy()
	{
		UnsubscribeInput();
	}

	#region Input

	private void SubscribeInput()
	{
		InputManager.Controls.Player.Movement.performed += OnMoveInput;
		InputManager.Controls.Player.Movement.canceled += OnMoveInput;
	}

	private void UnsubscribeInput()
	{
		InputManager.Controls.Player.Movement.performed -= OnMoveInput;
		InputManager.Controls.Player.Movement.canceled -= OnMoveInput;
	}

	private void OnMoveInput(InputAction.CallbackContext context)
	{
		rawInputDir = context.ReadValue<Vector2>();
	}
	#endregion

	private void FixedUpdate()
	{
		// Simple rb movement
		rb.AddForce(new Vector3(rawInputDir.x, 0, rawInputDir.y) * (walkSpeed));
	}
}
