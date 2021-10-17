using DG.Tweening;
using Main.ScriptablesObjects;
using Main.Scripts.Core;
using UnityEngine;
using UnityEngine.InputSystem;

namespace Main.Scripts.Actors.Player
{
    public class ShooterPlayerController : MonoBehaviour
    {
        [SerializeField] private ShooterSO playerData;
        [SerializeField] private Rigidbody2D rb2d;
        [SerializeField] private Transform gunPoint;

        private Vector2 _moveInputs;
        private Vector2 _lookInputs;
        private Timer _fireTimer;
        private bool _isFirePressed;
    
        [SerializeField] private PlayerInput controls;
        [SerializeField] private Transform graphics;

        private void Start()
        {
            _fireTimer = gameObject.AddComponent<Timer>();
            _fireTimer.TimeInSeconds = playerData.shootPaceTime;
        
            controls = GetComponent<PlayerInput>();
        }

        private void Update()
        {
            if (_isFirePressed)
                Fire();
        }

        void FixedUpdate()
        {
            rb2d.velocity = Vector2.Lerp(rb2d.velocity, _moveInputs, 1f) * playerData.movementSpeed;
        
            var angle = Mathf.Atan2(_lookInputs.y, _lookInputs.x) * Mathf.Rad2Deg;
            graphics.DORotateQuaternion(
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

        public void FireState(InputAction.CallbackContext context)
        {
            if (context.performed)
                return;
        
            if (context.started)
                _isFirePressed = true;
            if (context.canceled)
                _isFirePressed = false;
        }
    
        private void Fire()
        {
            if (_fireTimer.isTurnedOn)
                return;
        
            Instantiate(playerData.bullet, gunPoint.position, gunPoint.rotation);
            _fireTimer.StartTimer();
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
            rb2d.AddForceAtPosition(dir * 6f, other.GetContact(0).point);
        }
    }
}
