using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;


//Notes here for my coding convention:
//Unity functions: StartAgain()
//Our functions: startAgain()
//Variables: startAgain
//
//Everything (or almost everything) is public!

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
        

        public bool windowVisible = false;

        ApplicationLauncherButton button;

        public VGA vga;

        public Screen screen;
        public Texture2D render;

        public void Awake()
        {
            try
            {
                GameEvents.onGUIApplicationLauncherDestroyed.Add(endAppLauncher);
            }
            catch(Exception e)
            {
                Debug.LogError(e.Message);
            }
        }

        public void Start()
        {
            try
            {
                Debug.Log("[kOS-Editor] Start!");
                logo = FileUtil.loadTexture("logo.png");
                if (logo.width == 0)
                {
                    Debug.LogError("[kOS-Editor] Unable to load logo texture!");
                    return;
                }

                Debug.Log("[kOS-Editor] Adding button to AppLauncher!");

                onAppLauncher();

                Debug.Log("[kOS-Editor] Creating window!");
                RenderingManager.AddToPostDrawQueue(0, Draw);

                Debug.Log("[kOS-Editor] Creating emulator screen!");
                render = new Texture2D(760, 760);
                screen = new Screen();
                vga = new VGA();
                vga.loadFont();
                System.Random rng = new System.Random();

                for (int x = 0; x < 76; x++)
                {
                    for (int y = 0; y < 76; y++)
                    {
                        if (rng.Next() % 1000 >= 500)
                        {
                            vga.chars[x, y] = new Glyph(5, Color.BLUE, Color.CYAN);
                        }
                        else
                        {
                            vga.chars[x, y] = new Glyph(0, Color.RED, Color.BLACK);
                        }
                    }
                }

                Pixel[,] test = new Pixel[760,760];
                for(int x = 0; x <= 760 - 1; x++)
                {
                    for(int y = 0; y <= 760 - 1; y++)
                    {
                        //vga.chars[x, y] = new Glyph((byte)rng.Next(), Color.RED, Color.GREEN);
                        if (x <= 200)
                        {
                            test[x, y] = new Pixel(Color.BLUE);
                        }
                        else if(y <= 200)
                        {
                            test[x, y] = new Pixel(Color.RED);
                        }
                        else
                        {
                            test[x, y] = new Pixel(Color.GREEN);
                        }
                    }
                }
                screen.addPixelArray(vga.getPixelArray());

                int[] Acoords = VGA.getFontLocation(80);
                Debug.Log("A: X: " + Acoords[0] + " Y: " + Acoords[1]);

                //screen.addPixelArray(test);
            }
            catch(Exception e)
            {
                Debug.LogError("[kOS-Editor] " + e.Message);
            }

        }

       
        public void Update()
        {
            try
            {


                //Only rerender texture if window is open and something changed:
                if (windowVisible && screen.changed == true)
                {
                    Debug.Log("New Texture!");
                    render = screen.getTexture(1);
                    render.filterMode = FilterMode.Point;
                }
            }
            catch(Exception e)
            {
                Debug.LogError("[kOS-Editor->Update] " + e.Message);
            }
        }

        public void Draw()
        {
            if(windowVisible)
            {
                //I don't know if that ID is good or bad, but who cares (could use some 0xDEADBEEF)
                windowPosition = GUILayout.Window(1234, windowPosition, onWindow, "kOS-Editor (WIP)");
            }
        }
        
        public void onWindow(int windowID)
        {
            GUILayout.Box(render);

            //I just love Unity: :)
            GUI.DragWindow();
        }

        public void buttonDown()
        {
            windowVisible = true;
        }

        public void buttonUp()
        {
            windowVisible = false;
        }

        //Basically calls buttonUp (indirectly)
        public void closeWindow()
        {
            button.Disable(true);
        }

        public void endAppLauncher()
        {
            //Not sure if this has to be done!
            ApplicationLauncher.Instance.RemoveModApplication(button);
        }

        public void onAppLauncher()
        {
            try
            {
                Debug.Log("[kOS-Editor] AppLauncher ready, adding logo!");
                button = ApplicationLauncher.Instance.AddModApplication(buttonDown, buttonUp, null, null, null, null,
                    ApplicationLauncher.AppScenes.FLIGHT, logo);
               


            }
            catch(Exception e)
            {
                Debug.LogError("[kOS-Editor] " + e.Message);
            }
        }
    }
}
