using UnityEngine;

public class ButtonAudioPlayer : MonoBehaviour
{
    public float AudioVolume = 0.3f;
    public AudioClip ClickAudio = null;

    public void PlayClick()
    {
        SoundManager.Instance.PlaySFX(ClickAudio, AudioVolume, 1f);
    }
}
