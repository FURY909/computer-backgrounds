using BepInEx;
using ComputerBackgrounds;
using System;
using UnityEngine;
using UnityEngine.UIElements;
using Utilla;
using static Photon.Pun.UtilityScripts.TabViewManager;
using TMPro;

namespace Computerbackgrounds
{
    /// <summary>
    /// This is your mod's main class.
    /// </summary>

    /* This attribute tells Utilla to look for [ModdedGameJoin] and [ModdedGameLeave] */
    [ModdedGamemode]
    [BepInDependency("org.legoandmars.gorillatag.utilla", "1.5.0")]
    [BepInPlugin(info.GUID, info.Name, info.Version)]
    public class Plugin : BaseUnityPlugin
    {
        public GameObject pcmesh;
        public GameObject newtab;
        public GameObject pcmeshplane;
        public GameObject tab;
        public Material tabmat;

        void Start()
        {
            /* A lot of Gorilla Tag systems will not be set up when start is called /*
			/* Put code in OnGameInitialized to avoid null references */

            Utilla.Events.GameInitialized += OnGameInitialized;
        }

        void OnEnable()
        {
            /* Set up your mod here */
            /* Code here runs at the start and whenever your mod is enabled*/

            HarmonyPatches.ApplyHarmonyPatches();
        }

        void OnDisable()
        {
            /* Undo mod setup here */
            /* This provides support for toggling mods with ComputerInterface, please implement it :) */
            /* Code here runs whenever your mod is disabled (including if it disabled on startup)*/

            HarmonyPatches.RemoveHarmonyPatches();
        }

        void OnGameInitialized(object sender, EventArgs e)
        {
            Debug.Log("is initialized");
            setup();
        }
        public void setup()
        {
            pcmeshplane = GameObject.CreatePrimitive(PrimitiveType.Plane);
            pcmeshplane.transform.position = new Vector3(-65.4623f, 11.999f, - 80.0045f);
            pcmeshplane.transform.rotation = Quaternion.Euler(84.7581f, 200.596f, 0.2129f);
            pcmeshplane.transform.localScale = new Vector3(0.069f, 0.206f, 0.046f);
            newtab = GameObject.CreatePrimitive(PrimitiveType.Plane);
            newtab.transform.position = new Vector3(-65.4623f, 11.999f, - 80.0145f);
            newtab.transform.rotation = Quaternion.Euler(84.7581f, 200.596f, 0.2129f);
            newtab.transform.localScale = new Vector3(0.069f, 0.206f, 0.046f);
            tab = GameObject.CreatePrimitive(PrimitiveType.Cube);
            tabmat = new Material(Shader.Find("GorillaTag/UberShader"));
            tab.layer = 18;
            tab.GetComponent<Renderer>().material = tabmat;
            tab.GetComponent<BoxCollider>().isTrigger = true;
            var textuiclone = new GameObject("textui", typeof(TextMeshPro));
            textuiclone.transform.parent = newtab.transform;
            textuiclone.transform.localPosition = new Vector3(2.1494f, 0.0082f, - 3.0561f);
            textuiclone.transform.localRotation = Quaternion.Euler(90f, 180.0719f, 0f);
            textuiclone.transform.localScale = new Vector3(0.2f, 0.3f, 0.3f);
            textuiclone.GetComponentInChildren<TextMeshPro>().text = "                title\r\n------------------------------\r\nhi im striker";
            textuiclone.GetComponentInChildren<TextMeshPro>().enableWordWrapping = false;
            tab.transform.position = new Vector3(-65.5004f, 11.7811f, - 80.1518f);
            tab.transform.rotation = Quaternion.Euler(89.4475f, 305.3931f, 180.0407f);
            tab.transform.localScale = new Vector3(-0.03f, 0.06f, 0.04f);
            pcmeshplane.AddComponent<background>();
            newtab.AddComponent<background>();
            tab.AddComponent<tabmaker>().tab = newtab; 

        }



    }
}