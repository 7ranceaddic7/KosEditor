using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KosEditor
{
    //This holds the 768 * 768 screen
    //wich renders to a texture
    public class Screen
    {
        Pixel[] pixels = new Pixel[768 * 768]; //Not dynamic

        UnityEngine.Texture2D getTexture(int scale)
        {

            if(scale <= 0)
            {
                scale = 1;
            }
            UnityEngine.Texture2D tex = 
                new UnityEngine.Texture2D(768 * scale, 768 * scale);

            for(int x = 0; x < 768; x++)
            {
                for (int y = 0; y < 768; y++)
                {
                    if (scale > 1)
                    {
                        for (int oX = 0; oX < scale; oX++)
                        {
                            for (int oY = 0; oY < scale; oY++)
                            {
                                tex.SetPixel(x + oX, y + oY, pixels[x + y * 768].getColor());
                            }
                        }
                    }
                    else
                    {
                        tex.SetPixel(x, y, pixels[x + y * 768].getColor());
                    }
                }
            }
            return tex;
        }

    }
}
