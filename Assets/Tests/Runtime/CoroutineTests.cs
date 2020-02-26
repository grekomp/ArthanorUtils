using System.Collections;
using System.Collections.Generic;
using NUnit.Framework;
using UnityEngine;
using UnityEngine.TestTools;

namespace Tests
{
	public class CoroutineTests
	{
		GameObject coroutineRunner;

		[SetUp]
		public void SetUp()
		{
			coroutineRunner = new GameObject("Test coroutine runner");
		}

		[UnityTest]
		public IEnumerator CoroutineT_Should_ReturnResultAfterCoroutineHasFinishedRunning()
		{


			yield return new WaitForSeconds(1);
		}

		[TearDown]
		public void TearDown()
		{
			GameObject.Destroy(coroutineRunner);
		}
	}
}
