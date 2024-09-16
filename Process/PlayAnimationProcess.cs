using UnityEngine;

namespace MornArbor.Process
{
    public class PlayAnimationProcess : ProcessBase
    {
        [SerializeField] private Animator _animator;
        [SerializeField] private AnimationClip _animationClip;
        [SerializeField] private float _transitionDuration;
        private float _startTime;
        public override float Progress => _animationClip ? Mathf.Clamp01((Time.time - _startTime) / _animationClip.length * _animator.speed) : 1f;

        public override void OnStateBegin()
        {
            _animator.CrossFadeInFixedTime(_animationClip.name, _transitionDuration);
            _startTime = Time.time;
        }
    }
}