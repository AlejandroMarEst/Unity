using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour, InputSystem_Actions.IPlayerActions
{
    [SerializeField] private GameObject bullet;
    [SerializeField] public Transform _boundsLimitBullet;
    private InputSystem_Actions inputAction;
    private Rigidbody2D _rb;
    [SerializeField] private Transform _shootPoint;
    private Quaternion rotation;
    private float Cooldown;
    private float TimeSinceLastShot;
    public Stack<GameObject> stack = new Stack<GameObject>();
    private void Awake()
    {
        _rb = GetComponent<Rigidbody2D>();
        inputAction = new InputSystem_Actions();
        inputAction.Player.SetCallbacks(this);
        rotation = Quaternion.identity;
        Cooldown = 0.2f;
    }
    public void OnAttack(InputAction.CallbackContext context)
    {
        if (context.performed && Time.time >= TimeSinceLastShot + Cooldown )
        {
            if (stack.Count == 0)
            {
                InstantiateBullet();
            } 
            else
            {
                GameObject bull = stack.Pop();
                bull.SetActive(true);
                bull.transform.position = _shootPoint.position;
            }
                TimeSinceLastShot = Time.time;
        }
    }

    public void InstantiateBullet()
    {
        GameObject bull = Instantiate(bullet, _shootPoint.position, rotation);
        bull.GetComponent<Bullet>()._boundsLimit = _boundsLimitBullet;
    }
    public void OnMove(InputAction.CallbackContext context)
    {
        _rb.linearVelocity = context.ReadValue<Vector2>() * 5;
    }
    private void OnEnable()
    {
        inputAction.Enable();
    }
    private void OnDisable()
    {
        inputAction.Disable();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
