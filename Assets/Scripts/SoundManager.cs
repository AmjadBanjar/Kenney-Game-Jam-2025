using System.Collections.Generic;
using UnityEngine;
using System.Collections;

public class SoundManager : MonoBehaviour
{
	public static SoundManager Instance = null;
	[SerializeField] private AudioSource SfxPrefab = null;
	private List<AudioSource> UsedSFXAudioSources = new();

	private void Awake()
	{
		if (Instance != null && Instance != this)
		{
			Destroy(gameObject);
		}

		Instance = this;
	}

	/// <summary>
	/// Plays the audio clip
	/// </summary>
	/// <param name="clip">the clip to play</param>
	/// <param name="volume">the volume of the clip</param>
	/// <param name="pitch">the pitch of the clip</param>
	public AudioSource PlaySFX(AudioClip clip, float volume = 1f, float pitch = 1f)
	{
		AudioSource source = null;
		// Check for Used audio source pool
		if (UsedSFXAudioSources.Count > 0)
		{
			foreach (AudioSource usedSource in UsedSFXAudioSources)
			{
				if (!usedSource.isActiveAndEnabled)
				{
					// Found an unused audio source
					usedSource.gameObject.SetActive(true);
					source = usedSource;
					break;
				}
			}
		}

		if (source == null)
		{
			source = Instantiate(SfxPrefab, transform.position, Quaternion.identity, transform);
		}

		source.clip = clip;
		source.volume = volume;
		source.pitch = pitch;

		source.Play();

		StartCoroutine(DisableAudioSource(source, source.clip.length));
		return source;
	}
	public AudioSource PlaySFX(AudioClip[] clip, float volume = 1f, float pitch = 1f)
	{
		AudioSource source = null;
		// Check for Used audio source pool
		if (UsedSFXAudioSources.Count > 0)
		{
			foreach (AudioSource usedSource in UsedSFXAudioSources)
			{
				if (!usedSource.isActiveAndEnabled)
				{
					// Found an unused audio source
					usedSource.gameObject.SetActive(true);
					source = usedSource;
					break;
				}
			}
		}

		if (source == null)
		{
			source = Instantiate(SfxPrefab, transform.position, Quaternion.identity, transform);
		}

		int randomIndex = UnityEngine.Random.Range(0, clip.Length);
		source.clip = clip[randomIndex];
		source.volume = volume;
		source.pitch = pitch;

		source.Play();

		StartCoroutine(DisableAudioSource(source, source.clip.length));
		return source;
	}
	private IEnumerator DisableAudioSource(AudioSource source, float timeToDisable)
	{
		if (source == null || !source.gameObject.activeInHierarchy)
		{
			yield break;
		}
		yield return new WaitForSeconds(timeToDisable);
		UsedSFXAudioSources.Add(source);
		source.gameObject.SetActive(false);
	}


}