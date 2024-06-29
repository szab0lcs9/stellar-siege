using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.PlayerLoop;

public class EnvironmentalBehavior : MonoBehaviour
{
    readonly float G = 6.674f * Mathf.Pow(10f, -8f);
    GameObject[] celestialBodies;

    void Start()
    {
        celestialBodies = GameObject.FindGameObjectsWithTag("CelestialBody");

        OrbitalVelocity();

        AudioManager.Instance.PlaySFX("SpaceBackgroundSound", looping: true);
    }

    void FixedUpdate()
    {
        Gravity();
    }

    void Gravity()
    {
        foreach (GameObject cb1 in celestialBodies)
        {
            foreach (GameObject cb2 in celestialBodies)
            {
                if (!cb1.Equals(cb2))
                {
                    float m1 = cb1.GetComponent<Rigidbody>().mass;
                    float m2 = cb2.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(cb1.transform.position, cb2.transform.position);

                    cb1.GetComponent<Rigidbody>().AddForce((cb2.transform.position - cb1.transform.position).normalized * (G * (m1 * m2) / (r * r)));
                }
            }
        }
    }

    void OrbitalVelocity()
    {
        foreach (GameObject cb1 in celestialBodies)
        {
            foreach (GameObject cb2 in celestialBodies)
            {
                if (!cb1.Equals(cb2))
                {
                    float m2 = cb2.GetComponent<Rigidbody>().mass;
                    float r = Vector3.Distance(cb1.transform.position, cb2.transform.position);

                    cb1.transform.LookAt(cb2.transform);

                    cb1.GetComponent<Rigidbody>().velocity += cb1.transform.right * Mathf.Sqrt((G * m2) / r);
                }
            }
        }
    }
}