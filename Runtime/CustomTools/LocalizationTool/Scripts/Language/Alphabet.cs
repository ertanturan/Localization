using System.IO;
using System.Threading;
using System.Threading.Tasks;
using UnityEditor;
using UnityEngine;

public enum ReadOrder
{
	RTL,
	LTR
}

[CreateAssetMenu(
	                fileName = "New Alphabet",
	                menuName = "Localization/Alphabet")]
public class Alphabet : ScriptableObject
{
	public ReadOrder ReadOrder;

	private void Awake()
	{
	#if UNITY_EDITOR
		WaitAndMove();
	#endif
	}


	private async void WaitAndMove()
	{
		await Task.Run(delegate
		               {
			               Thread.Sleep(100);
		               });
		string oldPath = AssetDatabase.GetAssetPath(this);
		string dir = Path.Combine(Directory.GetCurrentDirectory(), "Assets/Resources/Data/Localization/Alphabets");

		if (!Directory.Exists(dir))
		{
			Directory.CreateDirectory(dir);
		}

		AssetDatabase.Refresh();

		string targetPath = $"Assets/Resources/Data/Localization/Alphabets/{name}.asset";
		AssetDatabase.MoveAsset(oldPath, targetPath);
		EditorUtility.FocusProjectWindow();
	}
}