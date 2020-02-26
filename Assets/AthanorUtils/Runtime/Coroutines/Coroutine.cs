using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Athanor
{
	namespace Athanor
	{
		public class Coroutine<T>
		{
			private IEnumerator _target;
			public T result;
			public Coroutine coroutine { get; private set; }

			public Coroutine(MonoBehaviour owner_, IEnumerator target_)
			{
				_target = target_;
				coroutine = owner_.StartCoroutine(Run());
			}

			private IEnumerator Run()
			{
				while (_target.MoveNext())
				{
					result = (T)_target.Current;
					yield return result;
				}
			}
		}
	}
}
