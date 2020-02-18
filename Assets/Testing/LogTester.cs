using Athanor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LogTester : MonoBehaviour
{
	[ContextMenu("Test Debug")]
	public void TestDebug()
	{
		Log.D(this, "This is a Debug message", this);
	}
	[ContextMenu("Test Error")]
	public void TestError()
	{
		Log.Error(this, "This is an Error message", this);
	}
	[ContextMenu("Test Warning")]
	public void TestWarning()
	{
		Log.Warning(this, "This is a Warning message", this);
	}
	[ContextMenu("Test Info")]
	public void TestInfo()
	{
		Log.Info(this, "This is an Info message", this);
	}
	[ContextMenu("Test Verbose")]
	public void TestVerbose()
	{
		Log.Verbose(this, "This is a Verbose message", this);
	}
	[ContextMenu("Test WTF")]
	public void TestWTF()
	{
		Log.WTF(this, "This is a WTF message", this);
	}
}
