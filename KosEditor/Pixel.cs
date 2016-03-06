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
        public static UnityEngine.Color get(Color c)
        {
            if (c == Color.BLACK)
            {
                return new UnityEngine.Color(35, 35, 39);
            }
            else if (c == Color.GRAY)
            {
                return new UnityEngine.Color(86, 87, 94);
            }
            else if (c == Color.BLUE)
            {
                return new UnityEngine.Color(55, 64, 128);
            }
            else if (c == Color.LBLUE)
            {
                return new UnityEngine.Color(80, 94, 198);
            }
            else if (c == Color.GREEN)
            {
                return new UnityEngine.Color(67, 142, 59);
            }
            else if (c == Color.LGREEN)
            {
                return new UnityEngine.Color(97, 196, 87);
            }
            else if (c == Color.CYAN)
            {
                return new UnityEngine.Color(70, 152, 151);
            }
            else if (c == Color.LCYAN)
            {
                return new UnityEngine.Color(83, 205, 204);
            }
            else if (c == Color.RED)
            {
                return new UnityEngine.Color(152, 70, 70);
            }
            else if (c == Color.LRED)
            {
                return new UnityEngine.Color(207, 88, 88);
            }
            else if (c == Color.PINK)
            {
                return new UnityEngine.Color(134, 70, 152);
            }
            else if (c == Color.LPINK)
            {
                return new UnityEngine.Color(173, 80, 200);
            }
            else if (c == Color.YELLOW)
            {
                return new UnityEngine.Color(152, 145, 70);
            }
            else if (c == Color.LYELLOW)
            {
                return new UnityEngine.Color(201, 192, 94);
            }
            else if (c == Color.LGRAY)
            {
                return new UnityEngine.Color(156, 158, 172);
            }
            else if (c == Color.WHITE)
            {
                return new UnityEngine.Color(202, 204, 219);
            }
            else
            {
                return UnityEngine.Color.black;
            }
        }
    }

    //A basic, pallete pixel
    public class Pixel
    {

        public Color color = Color.BLACK;
        
        //Forms a Unity color from the color (using pallete)
        public UnityEngine.Color getColor()
        {
            return Pallete.get(color);
        }


    }

}
