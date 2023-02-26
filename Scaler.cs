using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.Control;

namespace Client
{
    public class Scaler
    {
        public int xNativeResolution, yNativeResolution;
        List<Object> nativeControlCollection;
        public Scaler(int XRes, int YRes, ControlCollection NativeControls)
        {
            xNativeResolution = XRes;
            yNativeResolution = YRes;
            
            nativeControlCollection = new List<Object>();
            foreach(Control control in NativeControls)
            {
                Object temp = new Object();
                temp.Name = control.Name;
                temp.Width = control.Width;
                temp.Height = control.Height;
                temp.X = control.Location.X;
                temp.Y = control.Location.Y;
                nativeControlCollection.Add(temp);
            }
        }
        public void ScaleAllControls(ControlCollection controls, int xResolution, int yResolution)
        {
            foreach(Control control in controls)
            {
                foreach(Object nativeControl in nativeControlCollection)
                {
                    if (control.Name == nativeControl.Name)
                    {
                        control.Width = (int)((xResolution / (float)xNativeResolution) * nativeControl.Width);
                        control.Height = (int)((yResolution / (float)yNativeResolution) * nativeControl.Height);
                        Point newPos = new Point();
                        newPos.X = (int)(nativeControl.X * (xResolution / (float)xNativeResolution));
                        newPos.Y = (int)(nativeControl.Y * (yResolution / (float)yNativeResolution));
                        control.Location = newPos;
                    }
                }
            }
        }
        public class Object
        {
            public string Name;
            public int Width, Height;
            public int X, Y;
        }


        public static void HideEveryObject(ControlCollection Controls, List<Control> excludeList)
        {
            foreach (Control control in Controls)
            {
                bool ok = true;
                foreach (Control excludeControl in excludeList)
                {
                    if (control.Name == excludeControl.Name)
                    {
                        ok = false;
                    }
                }
                if (ok)
                {
                    control.Visible = false;
                }
            }
        }
        public static void HideEveryObject(ControlCollection Controls)
        {
            foreach (Control control in Controls)
            {
                control.Visible = false;
            }
        }
        public static void ShowEveryObject(ControlCollection Controls, List<Control> excludeList)
        {
            foreach (Control control in Controls)
            {
                bool ok = true;
                foreach (Control excludeControl in excludeList)
                {
                    if (control.Name == excludeControl.Name)
                    {
                        ok = false;
                    }
                }
                if (ok)
                {
                    control.Visible = true;
                }
            }
        }
        public static void ShowEveryObject(ControlCollection Controls)
        {
            foreach (Control control in Controls)
            {
                control.Visible = true;
            }
        }
    }
}
