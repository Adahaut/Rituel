using System;
using Enum;
using UnityEngine;
using UnityEngine.EventSystems;

namespace Enigmas.Key
{
    public class TurnableKey : MonoBehaviour, IBeginDragHandler, IDragHandler, IEndDragHandler
    {
        private new Transform transform;
        [SerializeField] private float sensibility = 1f;
        [SerializeField] private float loopThreshold = 180f;
        private const float fullLoop = 360f;
        private float currentAngle = 0;

        private bool mustReleaseToDrag;
        
        public Action<KeyTurnSide> OnKeyFullLoopEvent;
        
        private Vector3 rotationVector;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            rotationVector = Vector3.zero;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            
        }

        public void OnDrag(PointerEventData eventData)
        {
            if (mustReleaseToDrag)
            {
                return;
            }
            
            float deltaX = eventData.delta.x;
            currentAngle += -deltaX * sensibility;
            
            CheckReachedFullLoop();
            
            rotationVector.Set(0, 0, currentAngle);
            transform.eulerAngles = rotationVector;
        }

        private void CheckReachedFullLoop()
        {
            if (Math.Abs(currentAngle) <= fullLoop)
            {
                return;
            }

            OnFullLoop();
        }

        private void OnFullLoop()
        {
            float sign = Mathf.Sign(currentAngle);
            Debug.Log(sign > 0 ? KeyTurnSide.Left.ToString() : KeyTurnSide.Right.ToString());
            OnKeyFullLoopEvent?.Invoke(sign > 0 ? KeyTurnSide.Left : KeyTurnSide.Right);
            currentAngle = 0;
            mustReleaseToDrag = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            mustReleaseToDrag = false;
        }
    }
}