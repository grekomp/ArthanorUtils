using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEngine;

namespace Athanor
{
	[CreateAssetMenu(menuName = "Config/Log Config")]
	public class LogConfig : ScriptableObjectSingleton<LogConfig>
	{
		[Serializable]
		public class LogConfigLine
		{
			public string LogTag;
			public LogLevel LogLevelsEditor = (LogLevel)int.MaxValue;
			public LogLevel LogLevelsBuild = (LogLevel)int.MaxValue;
		}

		[Header("Log Settings")]
		public bool overrideLogAll = false;
		[SerializeField] protected List<LogConfigLine> Filters = new List<LogConfigLine>();


		#region Public methods
		public bool ShouldLogMessage(string logTag, LogLevel logLevel)
		{
			if (overrideLogAll) return true;

			LogConfigLine line = Filters.Find(l => l.LogTag == logTag);

			if (line == null)
			{
				line = new LogConfigLine() { LogTag = logTag };
				Filters.Add(line);
			}

			if (Application.isEditor)
			{
				return (line.LogLevelsEditor & logLevel) > 0;
			}
			else
			{
				return (line.LogLevelsBuild & logLevel) > 0;
			}
		}
		#endregion
	}
}
