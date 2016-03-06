using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace KosEditor
{


    public enum Color
    {
        BLACK,
        GRAY,
        BLUE,
        LBLUE,
        GREEN,
        LGREEN,
        CYAN,
        LCYAN,
        RED,
        LRED,
        PINK,
        LPINK,
        YELLOW,
        LYELLOW,
        LGRAY,
        WHITE
    }

    //Simple handler class to return 
    //colors from a COLOR object
    public static class Pallete
    {
        //Boring "look-up table" :P
        public static UnityEngine.Color32 get(Color c)
        {
            if (c == Color.BLACK)
            {
                return new UnityEngine.Color32(35, 35, 39, 255);
            }
            else if (c == Color.GRAY)
            {
                return new UnityEngine.Color32(86, 87, 94, 255);
            }
            else if (c == Color.BLUE)
            {
                return new UnityEngine.Color32(55, 64, 128, 255);
            }
            else if (c == Color.LBLUE)
            {
                return new UnityEngine.Color32(80, 94, 198, 255);
            }
            else if (c == Color.GREEN)
            {
                return new UnityEngine.Color32(67, 142, 59, 255);
            }
            else if (c == Color.LGREEN)
            {
                return new UnityEngine.Color32(97, 196, 87, 255);
            }
            else if (c == Color.CYAN)
            {
                return new UnityEngine.Color32(70, 152, 151, 255);
            }
            else if (c == Color.LCYAN)
            {
                return new UnityEngine.Color32(83, 205, 204, 255);
            }
            else if (c == Color.RED)
            {
                return new UnityEngine.Color32(152, 70, 70, 255);
            }
            else if (c == Color.LRED)
            {
                return new UnityEngine.Color32(207, 88, 88, 255);
            }
            else if (c == Color.PINK)
            {
                return new UnityEngine.Color32(134, 70, 152, 255);
            }
            else if (c == Color.LPINK)
            {
                return new UnityEngine.Color32(173, 80, 200, 255);
            }
            else if (c == Color.YELLOW)
            {
                return new UnityEngine.Color32(152, 145, 70, 255);
            }
            else if (c == Color.LYELLOW)
            {
                return new UnityEngine.Color32(201, 192, 94, 255);
            }
            else if (c == Color.LGRAY)
            {
                return new UnityEngine.Color32(156, 158, 172, 255);
            }
            else if (c == Color.WHITE)
            {
                return new UnityEngine.Color32(202, 204, 219, 255);
            }
            else
            {
                return new UnityEngine.Color32(0, 0, 0, 255);
            }
        }
    }

    //A basic, pallete pixel
    public class Pixel
    {

        public Color color = Color.BLACK;
        
        //Forms a Unity color from the color (using pallete)
        public UnityEngine.Color32 getColor()
        {
            return Pallete.get(color);
        }

        public Pixel(Color c)
        {
            color = c;
        }

        public Pixel()
        {
            color = Color.BLACK;
        }



    }

}
