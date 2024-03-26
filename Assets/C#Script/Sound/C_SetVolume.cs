using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using UnityEngine.Audio;
using UnityEngine.UI;

public class C_SetVolume : MonoBehaviour
{
    [SerializeField]AudioMixer masterMixer;
    [SerializeField]Slider MasterSlider;
    [SerializeField]Slider BGMSlider;
    [SerializeField]Slider SFXSlider;
    

    public void MasterControl()
    {
        float mas = MasterSlider.value;
        if(mas == -40f) masterMixer.SetFloat("Master", -80);
        else masterMixer.SetFloat("Master", mas);
    }
    public void BGMControl()
    {
        float bgm = BGMSlider.value;
        if(bgm == -40f) masterMixer.SetFloat("BGM", -80);
        else masterMixer.SetFloat("BGM", bgm);
    }
    public void SFXControl()
    {
        float sfx = SFXSlider.value;
        if(sfx == -40f) masterMixer.SetFloat("SFX", -80);
        else masterMixer.SetFloat("SFX", sfx);
    }
}
