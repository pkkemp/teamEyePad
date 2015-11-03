using System;
using System.IO;
using System.Reflection;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Text;
using System.Windows.Forms;

namespace ALSProject
{
    static class ALS_App
    {
        //main loop
        static void Main(String[] args)
        {
            CVInterface tobiiInt = new CVInterface();
            //we should confer on appropriate design structure here for the various subapps
            
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new UI());
        }
    }
}
