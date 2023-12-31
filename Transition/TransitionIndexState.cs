﻿using Arbor;
using UnityEngine;

namespace MornArbor
{
    public sealed class TransitionIndexState : StateBehaviour
    {
        [SerializeField] private FlexibleField<int> _index;
        [SerializeField] private StateLink[] _next;

        public override void OnStateBegin()
        {
            var index = Mathf.Clamp(_index.value, 0, _next.Length);
            Transition(_next[index]);
        }
    }
}