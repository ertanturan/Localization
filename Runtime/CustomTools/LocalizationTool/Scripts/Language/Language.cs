using System.IO;
using System.Threading;
using TMPro;
using UnityEditor;
using UnityEngine;

[CreateAssetMenu(
	                fileName = "New Language",
	                menuName = "Localization/Language")]
public class Language : ScriptableObject
{
	public Alphabet Alphabet;

	public string Name;

	public Sprite Icon;

	public SystemLanguage systemLanguageType;

	public TMP_FontAsset LanguageFontAsset;

	private void Awake()
	{
	#if UNITY_EDITOR
		WaitAndMove();
	#endif
	}


	private void WaitAndMove()
	{
		Thread.Sleep(10);
		string oldPath = AssetDatabase.GetAssetPath(this);
		string dir = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Resources/Data/Localization/Languages");

		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}

		AssetDatabase.Refresh();

		string targetPath = $"Assets/Resources/Data/Localization/Languages/{name}.asset";
		AssetDatabase.MoveAsset(oldPath, targetPath);
	}
}