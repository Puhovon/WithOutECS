using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerE : MonoBehaviour, PlayerActions.IMainActions
{
    [SerializeField] private float _moveSpeed;
    [SerializeField]private int _jerkSpeed;
    private float _currentSpeed;
    private Vector2 _direction;
    private PlayerActions _playerActions;
    private CharacterController _characterController;
    private bool _hasJerk = false;
    [SerializeField] private float _rotateSpeed;
    
    private void Start()
    {
        _playerActions = new PlayerActions();
        _playerActions.Main.SetCallbacks(this);
        _playerActions.Main.Enable();
        _characterController = GetComponent<CharacterController>();
        _currentSpeed = _moveSpeed;
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    private void Update()
    {
        Move(_direction);
    }

    private void Move(Vector2 directionMove)
    {
        Vector3 direction = new Vector3(directionMove.x, 0, directionMove.y);
        _characterController.Move(direction * _currentSpeed * Time.deltaTime);
        RotateCharacter(_direction);
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        if (!_hasJerk)
        {
            print("Move");

            _direction = context.ReadValue<Vector2>();
        }
    }

    private void RotateCharacter(Vector2 moveDirection)
    {
        Vector3 direction = new Vector3(moveDirection.x, 0, moveDirection.y);
        if (Vector3.Angle(transform.forward, direction) > 0)
        {
            Vector3 newDirection = Vector3.RotateTowards(transform.forward, direction
                , _rotateSpeed, 0);
            transform.rotation = Quaternion.LookRotation(newDirection);
        }
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        print("Attack");
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        if(!_hasJerk)
            StartCoroutine(Jerk());
    }

    private IEnumerator Jerk()
    {
        print("Jerk");
        _hasJerk = true;
        _currentSpeed = _jerkSpeed;
        yield return new WaitForSeconds(0.2f);
        _currentSpeed = _moveSpeed;
        _hasJerk = false;
    }
}
