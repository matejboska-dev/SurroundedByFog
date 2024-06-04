using UnityEngine;

public class PlayerMovementScript : MonoBehaviour
{
    public float baseMoveSpeed = 5.0f;
    public float sneakMoveSpeed = 2.5f;
    public float sprintingSpeed = 7.5f;
    public float jumpSpeed = 4.0f;
    public float gravity = 9.8f;
    public float terminalVelocity = 100f;
    public float sprintDuration = 5.0f;
    public float sprintCooldown = 30.0f;

    private CharacterController _charCont;
    private Vector3 _moveDirection = Vector3.zero;
    private float _sprintTimeRemaining;
    private float _cooldownTimeRemaining;
    private bool _canSprint = true;

    void Start()
    {
        _charCont = GetComponent<CharacterController>();
        _sprintTimeRemaining = sprintDuration;
        _cooldownTimeRemaining = 0f;
    }

    void Update()
    {
        if (true)
        {
            HandlePlayerMove();
        }
        else if (false)
        {
            HandlePlayerInactiveMove();
        }

        HandleSprintCooldown();
    }

    private void HandlePlayerMove()
    {
        float deltaX = Input.GetAxis("Horizontal");
        float deltaZ = Input.GetAxis("Vertical");

        bool isSneaking = Input.GetKey(KeyCode.LeftControl) || Input.GetKey(KeyCode.RightControl);
        bool isSprinting = Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift);

        float currentMoveSpeed = baseMoveSpeed;

        if (isSneaking)
        {
            currentMoveSpeed = sneakMoveSpeed;
        }
        else if (isSprinting && _canSprint)
        {
            currentMoveSpeed = sprintingSpeed;
            _sprintTimeRemaining -= Time.deltaTime;

            if (_sprintTimeRemaining <= 0)
            {
                _canSprint = false;
                _cooldownTimeRemaining = sprintCooldown;
            }
        }

        _moveDirection = new Vector3(deltaX * currentMoveSpeed, _moveDirection.y, deltaZ * currentMoveSpeed);

        if (_charCont.isGrounded)
        {
            if (Input.GetButton("Jump"))
            {
                _moveDirection.y = jumpSpeed;
            }
            else
            {
                _moveDirection.y = 0f;
            }

            if (deltaX != 0 || deltaZ != 0)
            {
                // Handle footsteps SFX here
            }
        }
        else
        {
            // Handle movement stop processes, such as footsteps SFX
        }

        ApplyMovement();
    }

    private void HandlePlayerInactiveMove()
    {
        _moveDirection = Vector3.zero;
        ApplyMovement();
    }

    private void ApplyMovement()
    {
        _moveDirection = transform.TransformDirection(_moveDirection);
        _moveDirection.y -= this.gravity * Time.deltaTime;
        _charCont.Move(_moveDirection * Time.deltaTime);
    }

    private void HandleSprintCooldown()
    {
        if (!_canSprint)
        {
            _cooldownTimeRemaining -= Time.deltaTime;

            if (_cooldownTimeRemaining <= 0)
            {
                _canSprint = true;
                _sprintTimeRemaining = sprintDuration;
            }
        }
    }
}
