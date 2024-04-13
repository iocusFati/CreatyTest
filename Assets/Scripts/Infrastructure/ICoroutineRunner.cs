using System;
using System.Collections;
using UnityEngine;

namespace Infrastructure
{
    public  interface ICoroutineRunner
    {
        public Coroutine StartCoroutine(IEnumerator coroutine);
        public void DoAfter(Func<bool> condition, Action action);
    }
}