using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerVFX : MonoBehaviour
{
    [SerializeField] ParticleSystem[] engineExhausts;
    [SerializeField] GameObject explosionParticle;

    #region Moving Effects
    internal void PlayExhaustParticlesWhenMoving(float input)
    {
        if (input != 0)
        {
            for (int i = 0; i < engineExhausts.Length; i++)
            {
                engineExhausts[i].Emit(1);
                engineExhausts[i].Play();
            }
        }
        else
            StopExhaustParticles();
    }

    internal void PlayExhaustParticlesWhenRotating(float input)
    {
        if (input != 0)
        {
            if (input > 0)
            {
                engineExhausts[1].Emit(1);
                engineExhausts[1].Play();
            }
            else
            {
                engineExhausts[0].Emit(1);
                engineExhausts[0].Play();
            }
        }
        else
            StopExhaustParticles();
    }

    private void StopExhaustParticles()
    {
        for (int i = 0; i < engineExhausts.Length; i++)
        {
            engineExhausts[i].Stop();
        }
    }
    #endregion

    #region Explosion Effects

    public void PlayExplodeEffect()
    {
        GameObject _explosionParticle = Instantiate(explosionParticle, gameObject.transform.position, Quaternion.identity);

        Destroy(_explosionParticle, 2f);
    }
    #endregion
}
