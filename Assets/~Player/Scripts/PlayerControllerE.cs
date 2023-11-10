using System;
using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerControllerE : MonoBehaviour, PlayerActions.IMainActions
{
    [SerializeField] private float _moveSpeed;
    [SerializeField]private int _jerkSpeed;
    private Vector2 _direction;
    private PlayerActions _playerActions;
    private void Start()
    {
        _playerActions = new PlayerActions();
        _playerActions.Main.SetCallbacks(this);
        _playerActions.Main.Enable();
    }

    private void OnDisable()
    {
        _playerActions.Disable();
    }

    private void Update()
    {
        // _direction = _playerActions.Main.Move.ReadValue<Vector2>(); 
        Move(_direction);
        
    }
    
    private void Move(Vector2 directionMove)
    {
        Vector3 direction = new Vector3(directionMove.x, 0, directionMove.y);
        transform.position += direction * _moveSpeed * Time.deltaTime;
    }

    public void OnMove(InputAction.CallbackContext context)
    {
        _direction = context.ReadValue<Vector2>();
        print("111111111 " + context.ReadValue<Vector2>());
    }

    public void OnAttack(InputAction.CallbackContext context)
    {
        print("Attack");
    }

    public void OnRun(InputAction.CallbackContext context)
    {
        StartCoroutine(Jerk());
    }

    private IEnumerator Jerk()
    {
        int elapsedTime = 20;
        _direction = new Vector2(_direction.x * _jerkSpeed, _direction.y * _jerkSpeed);
        int i = 0;
        while (i < elapsedTime)
        {
            yield return new WaitForEndOfFrame();
        }

        _direction = new Vector2(_direction.x / _jerkSpeed, _direction.y / _jerkSpeed);
    }
    public void OnLook(InputAction.CallbackContext context)
    {
    }
}