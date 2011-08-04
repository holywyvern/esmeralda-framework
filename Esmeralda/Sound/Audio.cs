using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Microsoft.Xna.Framework.Audio;

namespace Esmeralda.Sound
{
    public static class Audio
    {
        #region Constants
        private static string defaultBgmFolder = @"Audio\BGM";
        private static string defaultBgsFolder = @"Audio\BGS";
        private static string defaultMeFolder  = @"Audio\ME";
        private static string defaultSeFolder  = @"Audio\SE";

        /// <summary>
        /// Gets the defaullt directory where you load Background Music.
        /// </summary>
        public static string DefaultBgmFolder
        {
            get { return Audio.defaultBgmFolder; }
        }

        /// <summary>
        /// Gets the defaullt directory where you load Background Sound.
        /// </summary>
        public static string DefaultBgsFolder
        {
            get { return Audio.defaultBgsFolder; }
        }

        /// <summary>
        /// Gets the defaullt directory where you load Musical Effects.
        /// </summary>
        public static string DefaultMeFolder
        {
            get { return Audio.defaultMeFolder; }
        }

        /// <summary>
        /// gets the defaullt directory where you load Sound Effects.
        /// </summary>
        public static string DefaultSeFolder
        {
            get { return Audio.defaultSeFolder; }
        }

        #endregion

        #region Variable Declaration
        private static int MAX_EFFECTS = 31;
        private static AudioConfig config;
        private static SoundEffect bgmEffect, bgsEffect;
        private static SoundEffectInstance bgmInstance, bgsInstance;
        private static SoundEffect[] seEffects = new SoundEffect[MAX_EFFECTS];
        private static SoundEffect[] meEffects = new SoundEffect[MAX_EFFECTS];
        private static SoundEffectInstance[] meInstances = new SoundEffectInstance[MAX_EFFECTS];
        private static SoundEffectInstance[] seInstances = new SoundEffectInstance[MAX_EFFECTS];
        private static int seIndex = 0;
        private static int meIndex = 0;
        private static string bgmName, bgsName = "";
        #endregion

        #region Bgm Control
        /// <summary>
        /// Plays a Background Music.
        /// If the Audio Name is the same than the last audio played, the music will change
        /// its volume, pitch or pan if needed.
        /// </summary>
        /// <param name="file">The AudioFile to play</param>
        /// <returns></returns>
        public static void BgmPlay(AudioFile file)
        {
            if (Audio.bgmName == file.Name)
            {
                Audio.bgmInstance.Pause();
                Audio.bgmInstance.Pitch = ((file.Pitch - 50) / 50.0f) - 1;
                Audio.bgmInstance.Volume = file.Volume / 100.0f;
                Audio.bgmInstance.Pan = file.Pan / 100.0f;
                Audio.bgmInstance.Play();
            }
            else
            {
                if (Audio.bgmEffect != null)
                {
                    Audio.bgmInstance.Stop();
                    Audio.bgmInstance.Dispose();
                    Audio.bgmEffect.Dispose();
                };
                Audio.bgmEffect = config.ContentManager.Load<SoundEffect>(String.Format(@"{0}\{1}", Audio.config.Paths["BGM"], file.Name));
                Audio.bgmInstance = Audio.bgmEffect.CreateInstance();
                Audio.bgmInstance.IsLooped = true;
                Audio.bgmInstance.Pitch = ((file.Pitch - 50) / 50.0f) - 1;
                Audio.bgmInstance.Volume = file.Volume / 100.0f;
                Audio.bgmInstance.Pan = file.Pan / 100.0f;
                Audio.bgmInstance.Play();
            }
        }

        /// <summary>
        /// Stops the curren Background Music.
        /// </summary>
        public static void BgmStop()
        {
            bgmName = "";
            bgmInstance.Stop();
        }

        /// <summary>
        /// Pauses the current Background Music.
        /// </summary>
        public static void BgmPause()
        {
            bgmInstance.Pause();
        }

        /// <summary>
        /// Resumes the current Background Music.
        /// </summary>
        public static void BgmResume()
        {
            bgmInstance.Play();
        }

        #endregion

        #region Bgs Control
        /// <summary>
        /// Plays a Background Sound
        /// If the Audio Name is the same than the last audio played, the music will change
        /// its volume, pitch or pan if needed.
        /// </summary>
        /// <param name="file">The AudioFile to play</param>
        /// <returns></returns>
        public static void BgsPlay(AudioFile file)
        {
            if (Audio.bgsName == file.Name)
            {
                Audio.bgsInstance.Pause();
                Audio.bgsInstance.Pitch = ((file.Pitch - 50) / 50.0f) - 1;
                Audio.bgsInstance.Volume = file.Volume / 100.0f;
                Audio.bgsInstance.Pan = file.Pan / 100.0f;
                Audio.bgsInstance.Play();
            }
            else
            {
                if (Audio.bgsEffect != null)
                {
                    Audio.bgsInstance.Stop();
                    Audio.bgsInstance.Dispose();
                    Audio.bgsEffect.Dispose();
                };
                Audio.bgsEffect = config.ContentManager.Load<SoundEffect>(String.Format(@"{0}\{1}", Audio.config.Paths["BGS"], file.Name));
                Audio.bgsInstance = Audio.bgsEffect.CreateInstance();
                Audio.bgsInstance.IsLooped = true;
                Audio.bgsInstance.Pitch = ((file.Pitch - 50) / 50.0f) - 1;
                Audio.bgsInstance.Volume = file.Volume / 100.0f;
                Audio.bgsInstance.Pan = file.Pan / 100.0f;
                Audio.bgsInstance.Play();
            }
        }

        /// <summary>
        /// Stops the current Background Sound.
        /// </summary>
        public static void BgsStop()
        {
            bgsInstance.Stop();
            bgsName = "";
        }

        /// <summary>
        /// Pauses the current Background Sound.
        /// </summary>
        public static void BgsPause()
        {
            bgsInstance.Pause();
        }

        /// <summary>
        /// Resumes the current Background Sound.
        /// </summary>
        public static void BgsResume()
        {
            bgsInstance.Play();
        }
        #endregion

        #region Me Control
        /// <summary>
        /// Plays a Musical Effect.
        /// You can Play up to 31 at the same time, if you try to play more, the oldest will be stopped.
        /// </summary>
        /// <param name="file">The AudioFile to play</param>
        /// <returns></returns>
        public static void MePlay(AudioFile file)
        {
            if (meInstances[meIndex] != null)
            {
                meInstances[meIndex].Stop();
                meInstances[meIndex].Dispose();
                meEffects[meIndex].Dispose();
            }
            meEffects[meIndex] = config.ContentManager.Load<SoundEffect>(String.Format(@"{0}\{1}", Audio.config.Paths["ME"], file.Name));
            meInstances[meIndex] = meEffects[meIndex].CreateInstance();
            meInstances[meIndex].IsLooped = false;
            meInstances[meIndex].Pitch = ((file.Pitch - 50) / 50.0f) - 1;
            meInstances[meIndex].Volume = file.Volume / 100.0f;
            meInstances[meIndex].Pan = file.Pan / 100.0f;
            meIndex = (meIndex + 1) % MAX_EFFECTS;
        }

        /// <summary>
        /// Stops all the Musical Effects.
        /// </summary>
        public static void MeStop()
        {
            for (int i = 0; i < MAX_EFFECTS; i++)
            {
                if (meInstances[i] != null) meInstances[i].Stop();
            }
        }
        /// <summary>
        /// Pauses all the Musical Effects.
        /// </summary>
        public static void MePause()
        {
            for (int i = 0; i < MAX_EFFECTS; i++)
            {
                if (meInstances[i] != null) meInstances[i].Pause();
            }
        }

        /// <summary>
        /// Resumes all the Musical Effects.
        /// </summary>
        public static void MeResume()
        {
            for (int i = 0; i < MAX_EFFECTS; i++)
            {
                if (meInstances[i] != null) meInstances[i].Play();
            }
        }

        #endregion

        #region Se Control
        /// <summary>
        /// Plays a Sound Effect.
        /// You can Play up to 31 at the same time, if you try to play more, the oldest will be stopped.
        /// </summary>
        /// <param name="file">The AudioFile to play</param>
        /// <returns></returns>
        public static void SePlay(AudioFile file)
        {
            if (seInstances[seIndex] != null)
            {
                seInstances[seIndex].Stop();
                seInstances[seIndex].Dispose();
                seEffects[seIndex].Dispose();
            }
            seEffects[seIndex] = config.ContentManager.Load<SoundEffect>(String.Format(@"{0}\{1}", Audio.config.Paths["SE"], file.Name));
            seInstances[seIndex] = seEffects[meIndex].CreateInstance();
            seInstances[seIndex].IsLooped = false;
            seInstances[seIndex].Pitch = ((file.Pitch - 50) / 50.0f) - 1;
            seInstances[seIndex].Volume = file.Volume / 100.0f;
            seInstances[seIndex].Pan = file.Pan / 100.0f;
            seIndex = (meIndex + 1) % MAX_EFFECTS;
        }

        /// <summary>
        /// Stops all the Sound Effects.
        /// </summary>
        public static void SeStop()
        {
            for (int i = 0; i < MAX_EFFECTS; i++)
            {
                if (seInstances[i] != null) seInstances[i].Stop();
            }
        }

        /// <summary>
        /// Pauses all the Sound Effects.
        /// </summary>
        public static void SePause()
        {
            for (int i = 0; i < MAX_EFFECTS; i++)
            {
                if (seInstances[i] != null) seInstances[i].Pause();
            }
        }

        /// <summary>
        /// Resumes all the Sound Effects.
        /// </summary>
        public static void SeResume()
        {
            for (int i = 0; i < MAX_EFFECTS; i++)
            {
                if (seInstances[i] != null) seInstances[i].Play();
            }
        }

        #endregion

        #region Set/Get Audio Configurations
        /// <summary>
        /// This are the audio configurations to be used.
        /// </summary>
        public static AudioConfig Config
        {
            get { return Audio.config; }
            set { Audio.SetConfig(value); }
        }
        /// <summary>
        /// Sets a new AudioConfiguration.
        /// </summary>
        public static void SetConfig(AudioConfig config)
        {
            Audio.config = config;
        }
        #endregion

    }
}
