﻿using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Experimental.Rendering.HDPipeline;

[ExecuteInEditMode]
public class MotionBlurQuality : MonoBehaviour {

    [Range(4, 32)]
    public int normalSamples = 5;
    [Range(4, 32)]
    public int highSamples = 12;
    [Range(4, 32)]
    public int ultraSamples = 24;

    // Use this for initialization
    void OnEnable ()
    {
        var volume = GetComponent<Volume>();
        if (volume == null)
            return;
        MotionBlur m_motionBlur;

        var profile = Application.isPlaying
                ? volume.profile
                : volume.sharedProfile;

        profile.TryGet<MotionBlur>(out m_motionBlur);

        switch(QualitySettings.GetQualityLevel())
        {
            case 0:
                m_motionBlur.sampleCount.value = normalSamples;
                break;
            case 1:
                m_motionBlur.sampleCount.value = highSamples;
                break;
            case 2:
                m_motionBlur.sampleCount.value = ultraSamples;
                break;
        }
    }
	
}
