using System;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Hole.Runtime.Features.UI
{
    public class Joystick : MonoBehaviour, IDragHandler, IEndDragHandler
    {
        [SerializeField] private RectTransform handle;

        [SerializeField] private float moveRadius;

        private Vector3 startPosition;
        private Vector3 inputPosition;
        private bool isDrag;
        
        public Action<Vector3> Dragged;

        private void Awake() =>
            startPosition = handle.transform.position;

        private void FixedUpdate()
        {
            if (isDrag)
                Dragging();
        }

        public void OnDrag(PointerEventData eventData)
        {
            inputPosition = eventData.position;
            isDrag = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (Input.GetMouseButtonDown(0))
                return;

            isDrag = false;
            handle.transform.position = startPosition;
        }

        private void Dragging()
        {
            var newPosition = Vector3.ClampMagnitude(inputPosition - startPosition, moveRadius);

            handle.transform.position = startPosition + newPosition;

            var deltaDragging = handle.transform.position - startPosition;
            
            Dragged?.Invoke(deltaDragging);
        }
    }
}