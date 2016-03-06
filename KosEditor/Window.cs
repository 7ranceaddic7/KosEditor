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

        public void Start()
        {
            Debug.Log("[kOS-Editor] Start!");
        }
    }
}
