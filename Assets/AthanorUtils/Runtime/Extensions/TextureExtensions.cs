using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Athanor
{
	public static class TextureExtensions
	{
		public static Texture2D Copy(this Texture2D source)
		{
			Texture2D copy = new Texture2D(source.width, source.height);
			copy.SetPixels(source.GetPixels());
			copy.Apply();
			return copy;
		}

		public static Texture2D Copy32(this Texture2D source)
		{
			Texture2D copy = new Texture2D(source.width, source.height);
			copy.SetPixels32(source.GetPixels32());
			copy.Apply();
			return copy;
		}

		public static Texture2D ToTexture2D(this RenderTexture source, TextureFormat textureFormat = TextureFormat.ARGB32, bool createMipMaps = false, bool linear = true)
		{
			RenderTexture lastActiveRenderTexture = RenderTexture.active;

			RenderTexture.active = source;

			Texture2D convertedTexture = new Texture2D(source.width, source.height, textureFormat, createMipMaps, linear);
			convertedTexture.ReadPixels(new Rect(0, 0, convertedTexture.width, convertedTexture.height), 0, 0);
			convertedTexture.Apply();

			RenderTexture.active = lastActiveRenderTexture;

			return convertedTexture;
		}

		public static string SaveToPNG(this Texture2D source, string path)
		{
			byte[] bytes = source.EncodeToPNG();
			System.IO.File.WriteAllBytes(path, bytes);

			return path;
		}

		public static string SaveToEXR(this Texture2D source, string path)
		{
			byte[] bytes = source.EncodeToEXR();
			System.IO.File.WriteAllBytes(path, bytes);

			return path;
		}
		public static Texture2D LoadFromPng(this Texture2D target, string path)
		{
			byte[] b = File.ReadAllBytes(path);
			target.LoadImage(b);

			return target;
		}
	}
}
