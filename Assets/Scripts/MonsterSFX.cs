using UnityEngine;
using System.Collections;
using Random = UnityEngine.Random;

public class MonsterSFX : MonoBehaviour {

	[SerializeField] private AudioClip[] monsterSounds;    // an array of footstep sounds that will be randomly selected from.
	private AudioSource m_AudioSource;

	// Use this for initialization
	void Start () {
		m_AudioSource = GetComponent<AudioSource>();

		StartCoroutine(PlaySounds());
	}

	IEnumerator PlaySounds() {
		while(5 < 6)
		{
		int n = Random.Range(1, monsterSounds.Length);
		m_AudioSource.clip = monsterSounds[n];
		m_AudioSource.PlayOneShot(m_AudioSource.clip);
		//// move picked sound to index 0 so it's not picked next time
		monsterSounds[n] = monsterSounds[0];
		monsterSounds[0] = m_AudioSource.clip;

		yield return new WaitForSeconds(8);
		}
	}
}