using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Project.InputDemo
{
    public class InputButton : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
    {
        public event Action OnPressed;
        public event Action OnUnpressed;
        
        public void OnPointerDown(PointerEventData eventData)
        {
            OnPressed?.Invoke();
        }

        public void OnPointerUp(PointerEventData eventData)
        {
            OnUnpressed?.Invoke();
        }
    }
}