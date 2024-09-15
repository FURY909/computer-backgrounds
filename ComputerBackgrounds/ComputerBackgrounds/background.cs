using System;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
using UnityEngine.Video;

namespace Computerbackgrounds
{

    public class background : MonoBehaviour
    {
        public Material Background;
        public Material NULL;
        public GameObject gorilla;
        public static VideoPlayer VP;
        public string VideoPath;
        public bool Video;
        public bool SetBackground;
        public static List<string> Backgrounds = new List<string>();
        public void Start()
        {
            try
            {
                Background = new Material(Shader.Find("GorillaTag/UberShader"));
                NULL = new Material(Shader.Find("GorillaTag/UberShader"));
                string AppPath = Application.dataPath;
                AppPath = AppPath.Replace("/Gorilla Tag_Data", "");
                string path = AppPath + @"/BepInEx/plugins/ComputerBackground/";

                Byte[] bytes = File.ReadAllBytes(Directory.GetFiles(path, "*.png")[0]);


                Debug.Log(Directory.GetFiles(path, "*.png")[0]);
                Texture2D loadTexture = new Texture2D(1, 1);
                ImageConversion.LoadImage(loadTexture, bytes);
                loadTexture.Apply();
                byte[] debugImage = loadTexture.EncodeToPNG();
                File.WriteAllBytes(path + "/../Img1.png", debugImage);

                Background.mainTexture = loadTexture;

                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] info = dir.GetFiles("*.png");

                foreach (var image in info)
                {
                    Backgrounds.Add(image.Name + " Image\n");
                    Debug.Log(image);
                }
            }
            catch
            { }
            try
            {
                string AppPath = Application.dataPath;
                AppPath = AppPath.Replace("/Gorilla Tag_Data", "");
                string path = AppPath + @"/BepInEx/plugins/ComputerBackground/";

                VideoPath = Directory.GetFiles(path, "*.mp4")[0];
                Debug.Log(Directory.GetFiles(path, "*.mp4"));
                Debug.Log(VideoPath);

                DirectoryInfo dir = new DirectoryInfo(path);
                FileInfo[] info = dir.GetFiles("*.mp4");

                foreach (var video in info)
                {
                    Backgrounds.Add(video.Name + " Video\n");
                    Debug.Log(video);
                }
            }
            catch
            { }



        }
        public void Update()
        {
            if (!SetBackground)
            {
                SetBackground = true;
                if (VideoPath != null && !Video)
                {
                    Video = true;
                    VP = this.gameObject.AddComponent<VideoPlayer>();
                    VP.url = VideoPath;
                    VP.isLooping = true;
                    VP.EnableAudioTrack(0, false);
                    VP.SetDirectAudioMute(0, false);
                    this.gameObject.GetComponent<MeshRenderer>().material = NULL;
                    NULL.mainTexture = new Texture2D(1, 1);
                    NULL.shaderKeywords = new string[]
                    {
                    "_USE_TEXTURE",
                    };
                }
                else if (Background.mainTexture != null)
                {
                    this.gameObject.GetComponent<MeshRenderer>().material = Background;
                    Background.shaderKeywords = new string[]
                {
                "_USE_TEXTURE",
                };
                }
                else
                {
                    this.gameObject.GetComponent<MeshRenderer>().material = NULL;
                    this.gameObject.GetComponent<MeshRenderer>().material.color = Color.red;
                    Background.shaderKeywords = null;
                }
            }
        }
    }
}