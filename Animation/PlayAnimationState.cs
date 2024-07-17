﻿using Arbor;
using UnityEngine;

namespace MornArbor.Animation
{
    public class PlayAnimationState : StateBehaviour
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationClip;
        [SerializeField] private float _fadeDuration;
        [SerializeField] private StateLink _nextState;
        private float _startTime;

        public override void OnStateBegin()
        {
            _animator.CrossFadeInFixedTime(_animationClip.name, _fadeDuration);
            _startTime = Time.time;
        }

        public override void OnStateUpdate()
        {
            if (Time.time - _startTime > _animationClip.length / _animator.speed) Transition(_nextState);
        }
    }
}