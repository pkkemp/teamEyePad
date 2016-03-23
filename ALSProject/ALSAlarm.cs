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
        protected static Boolean alarmOn;
        protected const int APPCOMMAND_VOLUME_UP = 0xA0000;
        protected const int WM_APPCOMMAND = 0x319;

        protected static List<ALSAlarm> alarms = new List<ALSAlarm>();
        protected SoundPlayer player;

        #region Contructors
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
        #endregion

        #region Public Methods
        public Boolean isAlarmOn()
        {
            return alarmOn;
        }
        #endregion

        #region Events
        private void ALSAlarm_Disposed(object sender, EventArgs e)
        {
            alarms.Remove(this);
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
        #endregion


        #region Private Methods
        private void InitializeComponent()
        {
            this.SuspendLayout();
            // 
            // ALSAlarm
            // 
            this.FlatAppearance.BorderSize = 0;
            this.ResumeLayout(false);
        }
        #endregion


    }
}
