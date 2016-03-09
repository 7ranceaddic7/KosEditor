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
                    pixels[x, y] = new Pixel(Color.BLACK);
                }
            }
        }

        public void fillRandom()
        {
            Random rng = new Random();
            for (int x = 0; x <= 760 - 1; x++)
            {
                for (int y = 0; y <= 760 - 1; y++)
                {
                    Color rand = Color.BLACK;
                    //This works!
                    rand = (Color)(rng.Next() % 15);
                    pixels[x, y].color = rand;
                }

            }
        }

        public void fillPerlin(Color down, Color up)
        {
            for (int x = 0; x <= 760 - 1; x++)
            {
                for (int y = 0; y <= 760 - 1; y++)
                {
                    if(UnityEngine.Mathf.PerlinNoise((float)(x / 20), (float)(y/20)) >= 0.4f)
                    {
                        pixels[x, y].color = up;
                    }
                    else
                    {
                        pixels[x, y].color = down;
                    }
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
            for (int x = 0; x <= 760 - 1; x++)
            {
                for (int y = 0; y <= 760 - 1; y++)
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

                scale = 1;

                UnityEngine.Texture2D tex =
                    new UnityEngine.Texture2D(760, 760);

                for (int x = 0; x <= 760 - 1; x++)
                {
                    for (int y = 0; y <= 760 - 1; y++)
                    {
                        tex.SetPixel(x, y, pixels[x, y].getColor());
                    }

                }
                tex.filterMode = UnityEngine.FilterMode.Point;
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
