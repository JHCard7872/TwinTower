using System.Collections;
using System.Collections.Generic;
using System.Linq;
using TwinTower;
using UnityEngine;

public class SoundManager : Manager<SoundManager> {
    private AudioSource bgmSource;
    private List<AudioSource> effectSources;

    protected override void Awake() {
        base.Awake();

        bgmSource = GetComponent<AudioSource>();
        if (bgmSource == null) bgmSource = gameObject.AddComponent<AudioSource>();
        effectSources = GetComponents<AudioSource>().ToList();
        if (effectSources.Count == 0) effectSources.Add(gameObject.AddComponent<AudioSource>());
        
        effectSources.Remove(bgmSource);
        bgmSource.loop = true;
    }

    public void SetBGM(AudioClip bgm, float volume = 1) {
        bgmSource.volume = volume;
        if (bgm == bgmSource.clip) return;
        bgmSource.clip = bgm;
        if(!bgmSource.isPlaying) bgmSource.Play();
    }

    public void PlayEffect(AudioClip effect) {
        foreach (AudioSource source in effectSources) {
            if (!source.isPlaying) {
                source.clip = effect;
                source.Play();
                return;
            }
        }
        
        AudioSource newSource = gameObject.AddComponent<AudioSource>();
        newSource.clip = effect;
        newSource.Play();
        effectSources.Add(newSource);
    }
}
