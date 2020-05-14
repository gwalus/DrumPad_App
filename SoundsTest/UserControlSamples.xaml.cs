﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Media;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using WMPLib;

namespace SoundsTest
{
    /// <summary>
    /// Logika interakcji dla klasy ButtonLayout.xaml
    /// </summary>
    public partial class UserControlSamples : UserControl
    {
        SoundPlayer soundPlayer;
        PathFiles pathFiles;
        int tag;

        double position;

        static WindowsMediaPlayer mediaPlayer = new WindowsMediaPlayer();
        IWMPMedia media;
        IWMPPlaylist playlist = mediaPlayer.playlistCollection.newPlaylist("myPlayList");

        public UserControlSamples()
        {
            InitializeComponent();

            soundPlayer = new SoundPlayer();
            pathFiles = new PathFiles();
        }        

        private void ButtonAddSampleToMedia_Click(object sender, RoutedEventArgs e)
        {
            tag = int.Parse((sender as Control).Tag.ToString());

            media = mediaPlayer.newMedia(pathFiles.allEffects[tag]);
            playlist.appendItem(media);
            mediaPlayer.currentPlaylist = playlist;
            soundPlayer.Stop();
        }

        private void Button_MouseEnter(object sender, MouseEventArgs e)
        {
            soundPlayer.Stop();
            tag = int.Parse((sender as Control).Tag.ToString());
            soundPlayer.SoundLocation = pathFiles.allEffects[tag];
            soundPlayer.Play();
        }

        private void Button_MouseLeave(object sender, MouseEventArgs e)
        {
            soundPlayer.Stop();
            mediaPlayer.controls.stop();
        }

        private void ButtonPlayMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.controls.play();
        }

        private void ButtonPauseMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.controls.pause();
            position = mediaPlayer.controls.currentPosition;
        }

        private void ButtonResumeMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            mediaPlayer.controls.currentPosition = position;
            mediaPlayer.controls.play();
        }

        private void ButtonClearMediaPlayer_Click(object sender, RoutedEventArgs e)
        {
            playlist.clear();
        }
    }    
}