using UnityEngine.Audio;
using UnityEngine;

[System.Serializable]
public class Sound {
	public string name;

	public AudioClip clip;

	public string dialogue;

	[Range(0f,1f)]
	public float volume;

	[Range(.1f,3f)]
	public float pitch;

	public bool loop;
	public bool PlayOnAwake;

	[Range(0f,1f)]
	public float spatial_blend;

	public float spatial_min=1;
	public float spatial_max=20;

	public bool is3D;

	[HideInInspector]
	public AudioSource source;

	public AudioMixerGroup output;
}
