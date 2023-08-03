using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public interface IFadeAudio
{
    void fadeAudioIn( );
    void fadeAudioOut( );
    void destroyAudio( );
}