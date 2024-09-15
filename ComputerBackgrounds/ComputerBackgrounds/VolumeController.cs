using Computerbackgrounds;
using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;

namespace ComputerBackgrounds
{
    public class VolumeController : MonoBehaviour
    {
        int volume = 1;
        private void OnTriggerEnter(Collider other)
        {
            if (other.name == "LeftHandTriggerCollider")
            {
                if (name == "volup")
                {
                    if(volume < 1)
                    {
                        volume++;
                    }
                   
                   
                }
                if (name == "voldown")
                {
                    if (volume > -1)
                    {
                        volume--;
                    }
                  

                }
                background.VP.SetDirectAudioVolume(0, volume);
            }
        }
    }
}
