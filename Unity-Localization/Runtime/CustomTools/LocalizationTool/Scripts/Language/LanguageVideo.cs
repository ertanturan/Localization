using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Video;
using UnityEngine.UI;

[RequireComponent(typeof(VideoPlayer))]
public class LanguageVideo : MonoBehaviour
{

    [SerializeField] private LanguageDependentVideo _LanguageDependentVideo;

    private VideoPlayer _player;

    void Start()
    {
        _player = GetComponent<VideoPlayer>();

        LanguageManager.OnLanguageChange += (language) => ChangeLanguageVideo();
        ChangeLanguageVideo();
    }

    private void ChangeLanguageVideo()
    {
        _player.clip = _LanguageDependentVideo.GetVideoClip(LanguageManager.SelectedLanguage);
    }
}
