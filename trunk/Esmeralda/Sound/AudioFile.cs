using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Esmeralda.Sound
{
    public class AudioFile
    {
        #region Variable Declaration
        private int volume;
        private int pitch;
        private int pan;
        private string name;
        #endregion

        #region Volume
        /// <summary>
        /// Sets or Gets the volume of the audio from 
        /// 0 meaning mute to 100 meaning max volume
        /// </summary>
        public int Volume
        {
            get { return this.volume; }
            set { this.volume = (value > 100) ? 100 : ((value < 0) ? 0 : value); }
        }
        #endregion

        #region Pitch
        /// <summary>
        /// Sets the pitch of the File from the lowest 50 to the highest 150. 100 means normal.
        /// </summary>
        public int Pitch
        {
            get { return this.pitch; }
            set { this.pitch = (value > 150) ? 100 : ((value < 50) ? 50 : value); }
        }
        #endregion

        #region Pan
        /// <summary>
        /// Sets the balance of the speakers. from -100 meaning left balance to 100 meaning right balance.
        /// 0 means center.
        /// </summary>
        public int Pan
        {
            get { return this.pan; }
            set { this.pan = (value < -100) ? -100 : ( (value > 100) ? 100 : value);}
        }
        #endregion

        #region Name
        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
        #endregion

        #region Constructors
        /// <summary>
        /// Creates a new Audio file to play
        /// </summary>
        /// <param name="name">the name of the file</param>
        public AudioFile(string name)
        {
            this.Name = name;
            this.Volume = 100;
            this.Pitch = 100; 
        }

        /// <summary>
        /// Creates a new Audio file to play. 
        /// </summary>
        /// <param name="name">the name of the file</param>
        /// <param name="volume">the volume of the file in the range of 0 to 100</param>
        public AudioFile(string name, int volume)
        {
            this.Name = name;
            this.Volume = volume;
            this.Pitch = 100;
            this.Pan = 0;
        }

        /// <summary>
        /// Creates a new Audio file to play
        /// </summary>
        /// <param name="name">the name of the file</param>
        /// <param name="volume">the volume of the file in the range of 0 to 100</param>
        /// <param name="pitch">the pitch of the file in the range of 50 to 150</param>
        public AudioFile(string name, int volume, int pitch)
        {
            this.Name = name;
            this.Volume = volume;
            this.Pitch = pitch;
            this.Pan = 0;
        }

        /// <summary>
        /// Creates a new Audio file to play
        /// </summary>
        /// <param name="name">the name of the file</param>
        /// <param name="volume">the volume of the file in the range of 0 to 100</param>
        /// <param name="pitch">the pitch of the file in the range of 50 to 150</param>
        /// <param name="pan">the pan of the file in the range of -100 to 100</param>
        public AudioFile(string name, int volume, int pitch, int pan)
        {
            this.Name = name;
            this.Volume = volume;
            this.Pitch = pitch;
            this.Pan = pan;
        }
        #endregion
    }
}
