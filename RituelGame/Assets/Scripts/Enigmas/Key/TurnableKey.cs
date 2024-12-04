using System;
using DG.Tweening;
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
        private bool isReturningToZero;
        
        public Action<KeyTurnSide> OnKeyFullLoopEvent;
        
        private Vector3 rotationVector;

        private void Awake()
        {
            transform = GetComponent<Transform>();
            rotationVector = Vector3.zero;
        }

        private void Update()
        {
            if (!isReturningToZero)
            {
                return;
            }
            
            if (currentAngle == 0)
            {
                isReturningToZero = false;
            }
            
            SetRotation();
        }
        
        private void SetRotation()
        {
            rotationVector.Set(0, 0, currentAngle);
            transform.eulerAngles = rotationVector;
        }

        public void OnBeginDrag(PointerEventData eventData)
        {
            if (!isReturningToZero)
            {
                return;
            }
            DOTween.Kill(this, false);
            isReturningToZero = false;
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
            
            SetRotation();
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
            OnKeyFullLoopEvent?.Invoke(sign > 0 ? KeyTurnSide.Left : KeyTurnSide.Right);
            currentAngle = 0;
            mustReleaseToDrag = true;
        }

        public void OnEndDrag(PointerEventData eventData)
        {
            if (mustReleaseToDrag)
            {
                mustReleaseToDrag = false;
                return;
            }
            
            isReturningToZero = true;

            if (Mathf.Abs(currentAngle) > loopThreshold)
            {
                DOTween.To(() => currentAngle, x => currentAngle = x, (fullLoop + 1) * Mathf.Sign(currentAngle), 0.15f)
                    .onComplete += () =>
                {
                    OnFullLoop();
                    mustReleaseToDrag = false;
                };
            }
            else
            {
                DOTween.To(() => currentAngle, x => currentAngle = x, 0, 0.15f);
            }
        }
    }
}