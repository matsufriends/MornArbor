﻿using Arbor;
using Cysharp.Threading.Tasks;
using UnityEngine;
using VContainer;

namespace MornScreenFade
{
    public class FadeClearState : StateBehaviour
    {
        [SerializeField] private StateLink _next;
        private UniTask _fadeTask;
        [Inject] private IMornScreenFade _transition;

        public override void OnStateBegin()
        {
            _fadeTask = _transition.FadeClearAsync(CancellationTokenOnEnd);
        }

        public override void OnStateUpdate()
        {
            if (_fadeTask.Status != UniTaskStatus.Pending) Transition(_next);
        }
    }
}