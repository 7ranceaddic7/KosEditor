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

        public Glyph(byte index, Color color, Color bColor)
        {
            this.index = index;
            this.color = color;
            this.bColor = bColor;
        }

    }


    //Handles converting glyphs
    //to pixels, any not set pixels
    //are transparent to later blend with the 
    //Screen pixel array
    public class VGA
    {


        public Pixel[,] pixels = new Pixel[760, 760];
        //256 characters as in the codepage
        public Glyph[,] chars = new Glyph[76, 76];

        public UnityEngine.Texture2D font;
        

        public VGA()
        {
            chars = new Glyph[76, 76];
            for(int x = 0; x <= 76 - 1; x++)
            {
                for(int y = 0; y <= 76 - 1; y++)
                {
                    chars[x, y] = new Glyph(0, Color.BLACK, Color.BLACK);
                }
            }
            pixels = new Pixel[760, 760];
            for (int x = 0; x <= 760 - 1; x++)
            {
                for (int y = 0; y <= 760 - 1; y++)
                {
                    pixels[x, y] = new Pixel(Color.BLACK);
                }
            }
        }

        public void loadFont()
        {
            UnityEngine.Texture2D fLoad = FileUtil.loadTexture("font.png");
            if (fLoad.width == 160 && fLoad.height == 160)
            {
                font = fLoad;
                font.filterMode = UnityEngine.FilterMode.Point;
            }
            else
            {
                font = new UnityEngine.Texture2D(160, 160);
                UnityEngine.Debug.LogError("[kOS-Editor] Unable to load font!");
            }
        }


        public static int[] getFontLocation(byte index)
        {
            int[] coords = new int[2];
            coords[0] = index % 76;
            coords[1] = (index - coords[0]) / 76;
            return coords;
        }

        public Pixel[,] getPixelArray()
        {
            //We will work on the "pixels" array
            if(font == null)
            {
                UnityEngine.Debug.LogError("[kOS-Editor->VGA->getPixelArray()] Font is null!");
                return pixels;
            }
            //We will go through every character:
            for(int x = 0; x <= 76 - 1; x++)
            {
                for(int y = 0; y <= 76 - 1; y++)
                {

                    Glyph c = chars[x, y];
                    //Indexes in the font texture:
                    int fontIndexX = 0;
                    int fontIndexY = 0;

                    //Get these:
                    fontIndexX = c.index % 76;
                    fontIndexY = (c.index - fontIndexX) / 76;

                    //Now we will draw every single pixel
                    //of the character, setting color depending
                    //on the color of the font

                    for(int oX = 0; oX < 10; oX++)
                    {
                        for(int oY = 0; oY < 10; oY++)
                        {
                            //Sample from font: (OMG I'm dumb GetPixel returns floats T_T)
                            if(font.GetPixel(fontIndexX + oX, fontIndexY + oY).r >= 0.3)
                            {
                                //White pixel:
                                pixels[(x * 10) + oX, (y * 10) + oY] = new Pixel(chars[x, y].color);
                            }
                            else
                            {
                                //Black pixel:
                                pixels[(x * 10) + oX, (y * 10) + oY] = new Pixel(chars[x, y].bColor);
                            }
                        }
                    }
                }
            }

            return pixels;
        }

        public void log(string a)
        {
            UnityEngine.Debug.Log(a);
        }

    }


   

}
