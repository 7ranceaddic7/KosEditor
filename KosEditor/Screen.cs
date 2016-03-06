using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;


namespace KosEditor
{
    //This holds the 760 * 760 screen
    //wich renders to a texture

    public class Screen
    {

        public bool changed = true;

        public Pixel[,] pixels = new Pixel[760,760]; //Not dynamic
        
        public Screen()
        {
            changed = true;
            pixels = new Pixel[760, 760];
            for (int x = 0; x <= 760 - 1; x++)
            {
                for (int y = 0; y <= 760 - 1; y++)
                {
                    pixels[x, y] = new Pixel(Color.RED);
                }
            }
        }

        public void setPixel(int x, int y, Pixel p)
        {
            if (x < 0 || x >= 760 || y < 0 || y >= 760)
            {
                UnityEngine.Debug.LogError("[kOS-Editor->Screen] Pixel out of range!");
                return;
            }
            changed = true;
            pixels[x,y] = p;
        }

        public Pixel getPixel(int x, int y)
        {
            if (x < 0 || x >= 760 || y < 0 || y >= 760)
            {
                UnityEngine.Debug.LogError("[kOS-Editor->Screen] Pixel out of range!");
                return new Pixel();
            }
            return pixels[x, y];
        }

        //pixel array requires to be 760x760
        public void addPixelArray(Pixel[,] np)
        {
            for (int x = 0; x < 760; x++)
            {
                for (int y = 0; y < 760; y++)
                {
                    pixels[x, y] = np[x, y];
                }
            }
            changed = true;
        }

        public UnityEngine.Texture2D getTexture(int scale)
        {
            try
            {


                changed = false;
                if (scale <= 0)
                {
                    scale = 1;
                }
                UnityEngine.Texture2D tex =
                    new UnityEngine.Texture2D(760, 760);

                UnityEngine.Debug.Log("!111!!!11!!!");

                for (int x = 0; x <= 760 - 1; x++)
                {
                    for (int y = 0; y <= 760 - 1; y++)
                    {
                        tex.SetPixel(x, y, pixels[x, y].getColor());
                            /*
                            if (scale > 1)
                            {
                                for (int oX = 0; oX < scale; oX++)
                                {
                                    for (int oY = 0; oY < scale; oY++)
                                    {
                                        tex.SetPixel((x + oX) * scale, (y + oY) * scale, pixels[x + y * 760].getColor());
                                        UnityEngine.Debug.Log("SCALE: Set pixel (x: " + x + " y: " + y + ") color: " +
                                    pixels[x + y * 760].getColor());
                                    }
                                }
                            }
                            else
                            {
                                tex.SetPixel(x, y, pixels[x + y * 760].getColor());
                                UnityEngine.Debug.Log("Set pixel (x: " + x + " y: " + y + ") color: " +
                                    pixels[x + y * 760].getColor());
                            }*/
                        }
                    }
                tex.Apply();
                return tex;
            }
            catch(Exception e)
            {
                UnityEngine.Debug.LogError("[kOS-Editor->Screen->getTexture] " + e.Message);
                return new UnityEngine.Texture2D(760, 760);
            }
        }

    }
}
