using Athanor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTester : MonoBehaviour
{
	[ContextMenu("Test")]
	public void TestLog()
	{
		Log.D(this, "This is a message", this);
	}
}
