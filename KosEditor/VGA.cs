using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KosEditor
{

    
    //I know glyph is not the proper term for this
    public class Glyph
    {
        public byte index = 0;
        public Color color = Color.WHITE;
        public Color bColor = Color.BLACK;
    }


    //Handles converting glyphs
    //to pixels, any not set pixels
    //are transparent to later blend with the 
    //Screen pixel array
    public class VGA
    {
        public Pixel[] pixels = new Pixel[760 * 760];
        //256 characters as in the codepage
        public Glyph[] chars = new Glyph[76 * 76];

        public UnityEngine.Texture2D font;

        public void loadFont(string path)
        {
            UnityEngine.Texture2D fLoad = UnityEngine.Resources.Load<UnityEngine.Texture2D>(path);
            if(fLoad.width == 160 && fLoad.height == 160)
            {
                font = fLoad;
            }
            else
            {
                font = new UnityEngine.Texture2D(160, 160);
                UnityEngine.Debug.LogError("[kOS-Editor] Unable to load font!");
            }
        }

        public Pixel[] getPixelArray()
        {
            Pixel[] pixels = new Pixel[760 * 760];
            for(int x = 0; x < 76; x++)
            {
                for(int y = 0; y < 76; y++)
                {
                    //This is simple, the byte stored
                    //in the byte array is an index in our
                    //font file

                    int oX = 0;
                    int oY = 0;
                    for(int i = 0; i < chars[x + y * 76].index; i++)
                    {
                        //We travel to the starting index of the character,
                        //as every characters is 10x10 and x is limited to
                        //10, we do this:
                        if(oX >= 10)
                        {
                            oY++;
                            oX = 0;
                        }
                    }

                    //Now we have the location of the glyph at oX and oY,
                    //simply get the 100 pixels of it!

                    for(int pX = 0; pX < 10; pX++)
                    {
                        for(int pY = 0; pY < 10; pY++)
                        {
                            //Check if it's not a black pixel
                            if (font.GetPixel(oX + pX, oY + pY).r != 0)
                            {
                                pixels[(x + pX) + (y + pY) * 760].color = chars[x + y * 76].color;
                            }
                            else
                            {
                                pixels[(x + pX) + (y + pY) * 760].color = chars[x + y * 76].bColor;
                            }
                        }
                    }
                }
            }
            return pixels;
        }

    }
}
