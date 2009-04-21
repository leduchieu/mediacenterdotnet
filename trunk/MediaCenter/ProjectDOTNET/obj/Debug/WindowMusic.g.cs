﻿#pragma checksum "..\..\WindowMusic.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "C90B0AC5060408990540D09337FA142C"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:2.0.50727.3053
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Ink;
using System.Windows.Input;
using System.Windows.Markup;
using System.Windows.Media;
using System.Windows.Media.Animation;
using System.Windows.Media.Effects;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using System.Windows.Media.TextFormatting;
using System.Windows.Navigation;
using System.Windows.Shapes;


namespace ProjectDOTNET {
    
    
    /// <summary>
    /// WindowMusic
    /// </summary>
    public partial class WindowMusic : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\WindowMusic.xaml"
        internal ProjectDOTNET.WindowMusic Window;
        
        #line default
        #line hidden
        
        
        #line 60 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 62 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.MediaElement MusicPlayer;
        
        #line default
        #line hidden
        
        
        #line 63 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.ListBox listBoxSongs;
        
        #line default
        #line hidden
        
        
        #line 65 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.TextBlock textPos;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Image StopMusic;
        
        #line default
        #line hidden
        
        
        #line 67 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Image BackMusic;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Image PlayMusic;
        
        #line default
        #line hidden
        
        
        #line 69 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Image NextMusic;
        
        #line default
        #line hidden
        
        
        #line 70 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Image CancelMusic;
        
        #line default
        #line hidden
        
        
        #line 72 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.TextBlock textVolume;
        
        #line default
        #line hidden
        
        
        #line 73 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Slider sliderVol;
        
        #line default
        #line hidden
        
        
        #line 80 "..\..\WindowMusic.xaml"
        internal System.Windows.Controls.Slider sliderPos;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/ProjectDOTNET;component/windowmusic.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowMusic.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Window = ((ProjectDOTNET.WindowMusic)(target));
            
            #line 7 "..\..\WindowMusic.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.windowLoad);
            
            #line default
            #line hidden
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.MusicPlayer = ((System.Windows.Controls.MediaElement)(target));
            
            #line 62 "..\..\WindowMusic.xaml"
            this.MusicPlayer.MediaEnded += new System.Windows.RoutedEventHandler(this.nextSongEnd);
            
            #line default
            #line hidden
            
            #line 62 "..\..\WindowMusic.xaml"
            this.MusicPlayer.MediaOpened += new System.Windows.RoutedEventHandler(this.MusicPlayer_MediaOpened);
            
            #line default
            #line hidden
            return;
            case 4:
            this.listBoxSongs = ((System.Windows.Controls.ListBox)(target));
            
            #line 63 "..\..\WindowMusic.xaml"
            this.listBoxSongs.MouseDoubleClick += new System.Windows.Input.MouseButtonEventHandler(this.listBoxSongs_MouseDoubleClick);
            
            #line default
            #line hidden
            return;
            case 5:
            this.textPos = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 6:
            this.StopMusic = ((System.Windows.Controls.Image)(target));
            
            #line 66 "..\..\WindowMusic.xaml"
            this.StopMusic.MouseEnter += new System.Windows.Input.MouseEventHandler(this.stopEnter);
            
            #line default
            #line hidden
            
            #line 66 "..\..\WindowMusic.xaml"
            this.StopMusic.MouseLeave += new System.Windows.Input.MouseEventHandler(this.stopLeave);
            
            #line default
            #line hidden
            
            #line 66 "..\..\WindowMusic.xaml"
            this.StopMusic.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.stopSong);
            
            #line default
            #line hidden
            return;
            case 7:
            this.BackMusic = ((System.Windows.Controls.Image)(target));
            
            #line 67 "..\..\WindowMusic.xaml"
            this.BackMusic.MouseEnter += new System.Windows.Input.MouseEventHandler(this.backEnter);
            
            #line default
            #line hidden
            
            #line 67 "..\..\WindowMusic.xaml"
            this.BackMusic.MouseLeave += new System.Windows.Input.MouseEventHandler(this.backLeave);
            
            #line default
            #line hidden
            
            #line 67 "..\..\WindowMusic.xaml"
            this.BackMusic.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.backSong);
            
            #line default
            #line hidden
            return;
            case 8:
            this.PlayMusic = ((System.Windows.Controls.Image)(target));
            
            #line 68 "..\..\WindowMusic.xaml"
            this.PlayMusic.MouseEnter += new System.Windows.Input.MouseEventHandler(this.playEnter);
            
            #line default
            #line hidden
            
            #line 68 "..\..\WindowMusic.xaml"
            this.PlayMusic.MouseLeave += new System.Windows.Input.MouseEventHandler(this.playLeave);
            
            #line default
            #line hidden
            
            #line 68 "..\..\WindowMusic.xaml"
            this.PlayMusic.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.playSong);
            
            #line default
            #line hidden
            return;
            case 9:
            this.NextMusic = ((System.Windows.Controls.Image)(target));
            
            #line 69 "..\..\WindowMusic.xaml"
            this.NextMusic.MouseEnter += new System.Windows.Input.MouseEventHandler(this.nextEnter);
            
            #line default
            #line hidden
            
            #line 69 "..\..\WindowMusic.xaml"
            this.NextMusic.MouseLeave += new System.Windows.Input.MouseEventHandler(this.nextLeave);
            
            #line default
            #line hidden
            
            #line 69 "..\..\WindowMusic.xaml"
            this.NextMusic.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.nextSong);
            
            #line default
            #line hidden
            return;
            case 10:
            this.CancelMusic = ((System.Windows.Controls.Image)(target));
            
            #line 70 "..\..\WindowMusic.xaml"
            this.CancelMusic.MouseEnter += new System.Windows.Input.MouseEventHandler(this.cancelEnter);
            
            #line default
            #line hidden
            
            #line 70 "..\..\WindowMusic.xaml"
            this.CancelMusic.MouseLeave += new System.Windows.Input.MouseEventHandler(this.cancelLeave);
            
            #line default
            #line hidden
            
            #line 70 "..\..\WindowMusic.xaml"
            this.CancelMusic.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.closeWindow);
            
            #line default
            #line hidden
            return;
            case 11:
            this.textVolume = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.sliderVol = ((System.Windows.Controls.Slider)(target));
            
            #line 73 "..\..\WindowMusic.xaml"
            this.sliderVol.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.changeVolume);
            
            #line default
            #line hidden
            return;
            case 13:
            this.sliderPos = ((System.Windows.Controls.Slider)(target));
            
            #line 80 "..\..\WindowMusic.xaml"
            this.sliderPos.ValueChanged += new System.Windows.RoutedPropertyChangedEventHandler<double>(this.changePosition);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}
