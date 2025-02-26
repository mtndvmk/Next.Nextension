﻿using Unity.Mathematics;
using UnityEngine;

namespace Nextension.Tween
{
    [DisallowMultipleComponent]
    public class AutoAlternateScale : AbsAutoAlternate<float3>
    {
        [SerializeField] private bool _isUniformScale;
        private void Reset()
        {
            _fromValue = _toValue = transform.localScale;
        }
        protected override float3 getCurrentValue()
        {
            return transform.localScale;
        }
        protected override void setValue(float3 value)
        {
            transform.localScale = value;
        }
        protected override NRunnableTweener onFromTo()
        {
            return NTween.scaleTo(transform, _toValue, _timePerHalfCycle);
        }
        protected override NRunnableTweener onToFrom()
        {
            return NTween.scaleTo(transform, _fromValue, _timePerHalfCycle);
        }
    }
}
