using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

namespace Athanor
{
	public class ScriptableObjectSingleton<T> : ScriptableObject where T : ScriptableObject
	{
		#region Singleton
		protected static T _instance;
		public static T Instance {
			get {
				Initialize();

				return _instance;
			}
		}

		//#if UNITY_EDITOR
		//		[InitializeOnLoadMethod]
		//#else
		//	[RuntimeInitializeOnLoadMethod]
		//#endif
		protected static void Initialize()
		{
			if (_instance == null)
			{
				var found = Resources.LoadAll<T>("");
				_instance = found.FirstOrDefault();

				if (_instance == null)
				{
					_instance = CreateNewInstance();
					Log.Warning($"ScriptableObjectSingleton<{typeof(T)}>", $"Cannot find instance of ScriptableObjectSingleton<{typeof(T)}>, creating a new config file: Assets/Resources/{typeof(T).Name}.asset", _instance);
				}
			}
		}

		private static T CreateNewInstance()
		{
			ScriptableObject newObject = CreateInstance<T>();
#if UNITY_EDITOR
			if (AssetDatabase.IsValidFolder("Assets/Resources") == false)
			{
				AssetDatabase.CreateFolder("Assets", "Resources");
			}

			AssetDatabase.CreateAsset(newObject, $"Assets/Resources/{typeof(T).Name}.asset");
			AssetDatabase.SaveAssets();
#endif
			return newObject as T;
		}
		#endregion
	}
}
