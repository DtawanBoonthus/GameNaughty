using System;
using Manager;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.InputSystem;

[Serializable]
public class MoveInputEvent : UnityEvent<float, float>
{
}

namespace Players
{
    public class PlayerController : MonoBehaviour
    {
        [SerializeField] private MoveInputEvent moveInputEvent;
        [SerializeField] private float rotationSpeed;

        private CharacterInputActions inputActions;
        private float horizontal;
        private float vertical;

        private void Awake()
        {
            InitInput();
        }

        private void Update()
        {
            Move();
        }

        private void InitInput()
        {
            inputActions = new CharacterInputActions();

            inputActions.Player.Move.performed += OnMovePerformed;
            inputActions.Player.Move.performed += OpenWalkSound;
            inputActions.Player.Move.canceled += OnMovePerformed;
            inputActions.Player.Move.canceled += CloseWalkSound;
            inputActions.Player.Hurl.performed += OnHurled;
            inputActions.Player.OpenStore.performed += OnOpenStored;
        }

        private void Move()
        {
            Vector3 moveDirection = Vector3.forward * vertical + Vector3.right * horizontal;

            Vector3 projectedCameraForward = Vector3.ProjectOnPlane(Camera.main.transform.forward, Vector3.up);
            Quaternion rotationToCamera = Quaternion.LookRotation(projectedCameraForward, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToCamera,
                rotationSpeed * Time.deltaTime);

            moveDirection = rotationToCamera * moveDirection;
            Quaternion rotationToMoveDirection = Quaternion.LookRotation(moveDirection, Vector3.up);

            transform.rotation = Quaternion.RotateTowards(transform.rotation, rotationToMoveDirection,
                rotationSpeed * Time.deltaTime);

            transform.position += moveDirection * CharacterManager.Instance.PlayerSpawn.Speed * Time.deltaTime;
        }

        private void OnOpenStored(InputAction.CallbackContext context)
        {
            CharacterManager.Instance.PlayerSpawn.OpenStore();
        }

        private void OnHurled(InputAction.CallbackContext context)
        {
            CharacterManager.Instance.PlayerSpawn.Hurl();
        }

        private void OpenWalkSound(InputAction.CallbackContext context)
        {
            SoundManager.Instance.Play(SoundManager.Sound.Walk);
        }

        private void CloseWalkSound(InputAction.CallbackContext context)
        {
            SoundManager.Instance.Stop(SoundManager.Sound.Walk);
        }

        private void OnMovePerformed(InputAction.CallbackContext context)
        {
            var moveInput = context.ReadValue<Vector2>();
            moveInputEvent.Invoke(moveInput.x, moveInput.y);
        }

        private void OnEnable()
        {
            inputActions.Player.Enable();
            inputActions.Player.Move.performed += OnMovePerformed;
            inputActions.Player.Move.canceled += OnMovePerformed;
        }

        public void OnMoveInput(float horizontal, float vertical)
        {
            this.vertical = vertical;
            this.horizontal = horizontal;
        }
    }
}