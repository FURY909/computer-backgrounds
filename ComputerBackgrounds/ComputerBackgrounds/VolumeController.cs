using Computerbackgrounds;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.UIElements;

namespace ComputerBackgrounds
{
    public class VolumeController : MonoBehaviour
    {
        private float touchTime = 0f;
        private const float debounceTime = 0.25f;
        private void OnTriggerEnter(Collider other)
        {


            if (other.name == "LeftHandTriggerCollider" || other.name == "RightHandTriggerCollider")
            {
                if (touchTime + debounceTime >= Time.time)
                {
                    if (name == "volup")
                    {
                        if (background.volume <= 1)
                        {
                            background.volume += 0.1f;
                        }


                    }
                    if (name == "voldown")
                    {
                        if (background.volume >= 0)
                        {
                            background.volume -= 0.1f;
                        }


                    }
                }


                background.VP.SetDirectAudioVolume(0, background.volume);
            }
            touchTime = Time.time;

        }
    }
}
