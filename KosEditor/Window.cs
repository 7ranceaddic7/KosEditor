using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace KosEditor
{

    // This class handles display of the 
    // generated bitmap and the overlay
    // "retro-style" image
    // Relies on Unity UI
    //-------------------------------------
    // Interface between other classes and Unity

    [KSPAddon(KSPAddon.Startup.Flight, false)]
    public class Window : MonoBehaviour
    {
        //Holds the position of our window
        private Rect windowPosition = new Rect();
        public Texture2D logo;
        public bool running = true;

        ApplicationLauncherButton button;

        public void Start()
        {
            try
            {
                Debug.Log("[kOS-Editor] Start!");
                logo = FileUtil.loadTexture("logo.png");
                if (logo.width == 0)
                {
                    Debug.LogError("[kOS-Editor] Unable to load logo texture! Not starting!");
                    running = false;
                    return;
                }

                Debug.Log("[kOS-Editor] Waiting for AppLauncher event");

                onAppLauncher();
            }
            catch(Exception e)
            {
                Debug.LogError("[kOS-Editor] " + e.Message);
            }

        }

        public void onAppLauncher()
        {
            try
            {

                if (running == true)
                {
                    Debug.Log("[kOS-Editor] AppLauncher ready, adding logo!");
                    button = ApplicationLauncher.Instance.AddModApplication(null, null, null, null, null, null,
                        ApplicationLauncher.AppScenes.FLIGHT, logo);
                }
            }
            catch(Exception e)
            {
                Debug.LogError("[kOS-Editor] " + e.Message);
            }
        }
    }
}
