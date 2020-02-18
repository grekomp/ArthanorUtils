using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Athanor
{
	[Flags]
	public enum LogLevel
	{
		Debug = (1 << 0),      // Temporary development-only logs
		Error = (1 << 1),      // Logs about bad and impossible to ignore situations
		Warning = (1 << 2),    // Logs about potentially unwanted situations, that were handled by the system
		Info = (1 << 3),       // Informational logs about general / important events and states of the system
		Verbose = (1 << 4),    // Detailed informational logs that might be helpful to inspect the inner workings of a system
		WTF = (1 << 5)         // What a Terrible Failure = Critical situations that should never happen
	}

	public static class Log
	{
		public readonly static string quickDebugLogTag = "QuickDebug";

		public static void PrintLog(LogLevel logLevel, object tag, object message, UnityEngine.Object context = null)
		{
			if (LogConfig.Instance.ShouldLogMessage(tag.ToString(), logLevel) == false) return;


			string logString = $"[{logLevel.ToString().Substring(0, 3)}] {tag}: {message}";

			if (context == null)
			{
				switch (logLevel)
				{
					case LogLevel.Debug:
					case LogLevel.Info:
					case LogLevel.Verbose:
						Debug.Log(logString);
						break;
					case LogLevel.Error:
					case LogLevel.WTF:
						Debug.LogError(logString);
						break;
					case LogLevel.Warning:
						Debug.LogWarning(logString);
						break;
				}
			}
			else
			{
				switch (logLevel)
				{
					case LogLevel.Debug:
					case LogLevel.Info:
					case LogLevel.Verbose:
						Debug.Log(logString, context);
						break;
					case LogLevel.Error:
					case LogLevel.WTF:
						Debug.LogError(logString, context);
						break;
					case LogLevel.Warning:
						Debug.LogWarning(logString, context);
						break;
				}
			}
		}

		public static void D(object message)
		{
			PrintLog(LogLevel.Debug, quickDebugLogTag, message);
		}
		public static void D(object tag, object message, UnityEngine.Object context = null)
		{
			PrintLog(LogLevel.Debug, tag, message, context);
		}
		public static void Error(object tag, object message, UnityEngine.Object context = null)
		{
			PrintLog(LogLevel.Error, tag, message, context);
		}
		public static void Warning(object tag, object message, UnityEngine.Object context = null)
		{
			PrintLog(LogLevel.Warning, tag, message, context);
		}
		public static void Info(object tag, object message, UnityEngine.Object context = null)
		{
			PrintLog(LogLevel.Info, tag, message, context);
		}
		public static void Verbose(object tag, object message, UnityEngine.Object context = null)
		{
			PrintLog(LogLevel.Verbose, tag, message, context);
		}
		public static void WTF(object tag, object message, UnityEngine.Object context = null)
		{
			PrintLog(LogLevel.WTF, tag, message, context);
		}
	}
}
