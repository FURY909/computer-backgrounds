using System;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using GorillaNetworking;
using static OVRPlugin;
using UnityEngine.UI;
using UnityEngine.UIElements;
using Computerbackgrounds;
using TMPro;

namespace ComputerBackgrounds
{
    public class tabmaker : MonoBehaviour
    {
        public GameObject tab;
        public Material tabmat;
        public GameObject pcmesh;
        public GameObject canvas;
        public bool OnNewTab;
        public float cooldown = .1f;
        public float nextcliked;
        public bool Key1;
        public bool Key2;
        public bool Key3;
        public bool Key4;
        public bool Key5;
        public bool Key6;
        public bool Key7;
        public bool Key8;
        public bool Key9;
        public bool enterkey;
        public bool up;
        public bool down;
        public bool left;
        public bool right;
        public Material textcolor;
        public void Start()
        {
           
            OnNewTab = false;
            Debug.Log("broke at mat");
          
            clicked(OnNewTab);
        }
        private void OnTriggerEnter(Collider collider)
        {
            if (Time.time > nextcliked)
            {
                if (collider.name == "LeftHandTriggerCollider" || collider.name == "RightHandTriggerCollider")
                {
                    clicked(OnNewTab);
                    nextcliked = Time.time + cooldown;
                }
                
            }




        }
        public void clicked(bool customtab)
        {
            if (customtab)
            {
                
                OnNewTab = false;
                tab.SetActive(false);
            }
            else
            {
                OnNewTab = true;
                tab.SetActive(true);
                tab.GetComponentInChildren<TextMeshPro>().text = "THIS IS A TEST \n \n TANKS FOR INSTALLING OUR MOD ( :\n" + string.Join(",", background.Backgrounds);
            }
        }

    }
}
