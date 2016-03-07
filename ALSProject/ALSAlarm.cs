using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;

namespace ALSProject
{
    public class ALSAlarm : ALSButton
    {
        private static Boolean alarmOn;
        private const int APPCOMMAND_VOLUME_UP = 0xA0000;
        private const int WM_APPCOMMAND = 0x319;

        private static List<ALSAlarm> alarms = new List<ALSAlarm>();
        SoundPlayer player;

        public ALSAlarm()
        {
            this.player = new SoundPlayer(Properties.Resources.buzz);
            alarmOn = false;
            this.Text = "";
            Click += new System.EventHandler(this.ALSAlarm_Click);
            this.BackgroundImage = Properties.Resources.speaker_icon;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Zoom;
            alarms.Add(this);
            this.Disposed += ALSAlarm_Disposed;
        }

        private void ALSAlarm_Disposed(object sender, EventArgs e)
        {
            alarms.Remove(this);
        }

        public Boolean isAlarmOn()
        {
            return alarmOn;
        }

        public void ALSAlarm_Click(object sender, EventArgs e)
        {

            if (alarmOn)
            {
                //this.timeDivision = ALSButton.defaultTimeDivision;
                this.BackgroundImage = Properties.Resources.speaker_icon;
                player.Stop();
                alarmOn = false;
            }
            else
            {
                this.dwellTimeInterval = 50;
                this.BackgroundImage = Properties.Resources.AlarmOff;
                //Maximize volume
                for (int i = 0; i < 64; i++)
                {
                    //my ears... they bleed. Disable the following line for authentic testing environment
                    //VolUp();
                    //throw new NotImplementedException();
                }
                try
                {
                    player.PlayLooping();
                }
                catch (Exception) { }

                alarmOn = true;
            }
            if (Visible)
            {
                foreach (var alarm in alarms)
                    if (alarmOn)
                    {
                        alarm.BackgroundImage = Properties.Resources.AlarmOff;
                    }
                    else
                    {
                        alarm.BackgroundImage = Properties.Resources.speaker_icon;
                    }
            }
        }

        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ALSAlarm
            // 
            this.FlatAppearance.BorderSize = 0;
            this.ResumeLayout(false);

        }
    }
}
