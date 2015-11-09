using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Tobii.EyeX.Client;
using Tobii.EyeX.Framework;
using EyeXFramework;
using System.Drawing;
using System.Windows.Forms;

namespace ALSProject
{

    //this translates the Tobii SDK to calls for our system

    //Tobii SDK: http://developer.tobii.com/documentation/
    class CVInterface
    {
        public CVInterface()
        {

        }

        public void StartEyeTracking()
        {
            using (var eyeXHost = new EyeXHost())
            {
                // Create a data stream: lightly filtered gaze point data.
                // Other choices of data streams include EyePositionDataStream and FixationDataStream.
                using (var fixationGazeDataStream = eyeXHost.CreateFixationDataStream(FixationDataMode.Slow))
                {
                    // Start the EyeX host.
                    eyeXHost.Start();
                    double smoothX = 0;
                    double smoothY = 0;
                    double box = 40;

                    // Write the data to the console.
                    fixationGazeDataStream.Next += (s, e) =>
                    {
                        if (e.X > smoothX + box || e.X < smoothX - box || e.Y > smoothY + box || e.Y < smoothY - box)
                        {
                            Cursor.Position = new Point(Convert.ToInt32(e.X), Convert.ToInt32(e.Y));
                            smoothX = e.X;
                            smoothY = e.Y;
                        }
                        else
                        {
                            Cursor.Position = new Point(Convert.ToInt32(smoothX), Convert.ToInt32(smoothY));
                        }

                    };
                }
            }
        }
    }
}
