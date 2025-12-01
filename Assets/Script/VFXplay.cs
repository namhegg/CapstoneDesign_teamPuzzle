using UnityEngine;
using UnityEngine.VFX;

public class VFXplay : MonoBehaviour
{
    [Header("vfx")]
    public ParticleSystem particleEffect;

    public void OnButtonClick()
    {
        particleEffect.Play();
    }
}
