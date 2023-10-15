using System;
using Unity.VisualScripting;
using UnityEngine;

namespace Project.InputDemo
{
    public class InputManager : MonoBehaviour
    {
        public static InputManager Instance { get; private set; }

        [SerializeField] private InputButton _leftButton;
        [SerializeField] private InputButton _rightButton;
        [SerializeField] private InputButton _jumpButton;

        public int DirectionMove { get; private set; }
        //0 - stop
        //-1 - left
        //1 - right

        public event Action OnJump;

        private void Awake()
        {
            Instance = this;

            _leftButton.OnPressed += OnLeftButtonPressed;
            _leftButton.OnUnpressed += OnLeftButtonUnpressed;
            
            _rightButton.OnPressed += OnRightButtonPressed;
            _rightButton.OnUnpressed += OnRightButtonUnpressed;
            
            _jumpButton.OnPressed += OnJumpButtonPressed;
        }

        private void OnJumpButtonPressed()
        {
            OnJump?.Invoke();
        }

        private void OnRightButtonUnpressed()
        {
            DirectionMove = 0;
        }

        private void OnRightButtonPressed()
        {
            DirectionMove = 1;
        }

        private void OnLeftButtonUnpressed()
        {
            DirectionMove = 0;
        }

        private void OnLeftButtonPressed()
        {
            DirectionMove = -1;
        }
    }
}