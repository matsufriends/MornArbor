﻿using System;
using Arbor;
using UniRx;
using UniRx.Triggers;
using UnityEngine;
using UnityEngine.EventSystems;

namespace MornArbor
{
    public class WaitPointerEventState : StateBehaviour
    {
        [SerializeField] private UIBehaviour _target;
        [SerializeField] private PointerEventType _pointerEventType;
        [SerializeField] private StateLink _nextState;
        private IDisposable _disposable;
        private bool _isPressed;

        public override void OnStateBegin()
        {
            _isPressed = false;
            var observable = _pointerEventType switch
            {
                PointerEventType.PointerDown => _target.OnPointerDownAsObservable(),
                PointerEventType.PointerUp => _target.OnPointerUpAsObservable(),
                PointerEventType.PointerEnter => _target.OnPointerEnterAsObservable(),
                PointerEventType.PointerExit => _target.OnPointerExitAsObservable(),
                PointerEventType.PointerClick => _target.OnPointerClickAsObservable(),
                _ => throw new ArgumentOutOfRangeException()
            };
            _disposable = observable.Subscribe(_ => _isPressed = true);
        }

        public override void OnStateUpdate()
        {
            if (_isPressed) Transition(_nextState);
        }

        public override void OnStateEnd()
        {
            _disposable?.Dispose();
        }

        private enum PointerEventType
        {
            PointerDown,
            PointerUp,
            PointerEnter,
            PointerExit,
            PointerClick
        }
    }
}