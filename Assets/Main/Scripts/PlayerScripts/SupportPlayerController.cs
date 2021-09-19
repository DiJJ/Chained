using DG.Tweening;
using UnityEngine;
using UnityEngine.InputSystem;

public class SupportPlayerController : MonoBehaviour
{
    [SerializeField] private PlayerSObj playerData;

    private Vector2 _moveInputs;
    private Vector2 _lookInputs;
    
    [SerializeField] private PlayerInput controls;
    [SerializeField] private Rigidbody2D rb2d;
    private HealthManager _healthManager;

    private void Start()
    {
        _healthManager = FindObjectOfType<HealthManager>();
    }

    void FixedUpdate()
    {
        rb2d.velocity = Vector2.Lerp(rb2d.velocity, _moveInputs, 1f) * playerData.movementSpeed;
        
        var angle = Mathf.Atan2(_lookInputs.y, _lookInputs.x) * Mathf.Rad2Deg;
        transform.DORotateQuaternion(
            Quaternion.AngleAxis(angle, Vector3.forward),
            controls.currentControlScheme == controls.defaultControlScheme ? .08f : Time.fixedDeltaTime);
    }

    public void Move(InputAction.CallbackContext context)
    {
        _moveInputs = context.ReadValue<Vector2>();
    }
    
    public void Look(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        
        _lookInputs = context.ReadValue<Vector2>();
    }

    public void Switch(InputAction.CallbackContext context)
    {
        if(!context.performed)
            return;
        _healthManager.SwitchReceiver();
    }
    
    public void ControlsChanged(PlayerInput input)
    {
        controls = input;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        transform.DOKill();
        var position = other.transform.position;
        var dir = transform.position - position;
        GetComponent<Rigidbody2D>().AddForceAtPosition(dir * 10f, other.GetContact(0).point, ForceMode2D.Impulse);
    }
}
