﻿#pragma checksum "..\..\Window2.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "AC8B8AA76DC18A338F026F5935F39E35"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.3053
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
// </auto-generated>
//------------------------------------------------------------------------------

using ProjectDOTNET;
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
    /// Window2
    /// </summary>
    public partial class Window2 : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 7 "..\..\Window2.xaml"
        internal ProjectDOTNET.Window2 Window;
        
        #line default
        #line hidden
        
        
        #line 431 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard closeEnter_BeginStoryboard;
        
        #line default
        #line hidden
        
        
        #line 434 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard closeEnter_BeginStoryboard1;
        
        #line default
        #line hidden
        
        
        #line 437 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard windowLoad_BeginStoryboard1;
        
        #line default
        #line hidden
        
        
        #line 440 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard upEnter_BeginStoryboard1;
        
        #line default
        #line hidden
        
        
        #line 443 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard upLeave_BeginStoryboard1;
        
        #line default
        #line hidden
        
        
        #line 446 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard downEnter_BeginStoryboard1;
        
        #line default
        #line hidden
        
        
        #line 449 "..\..\Window2.xaml"
        internal System.Windows.Media.Animation.BeginStoryboard downLeave_BeginStoryboard1;
        
        #line default
        #line hidden
        
        
        #line 453 "..\..\Window2.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 459 "..\..\Window2.xaml"
        internal System.Windows.Controls.TextBlock textTime;
        
        #line default
        #line hidden
        
        
        #line 460 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image close;
        
        #line default
        #line hidden
        
        
        #line 461 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imagePics;
        
        #line default
        #line hidden
        
        
        #line 466 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imageMusic;
        
        #line default
        #line hidden
        
        
        #line 467 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imageVideo;
        
        #line default
        #line hidden
        
        
        #line 468 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imageRSS;
        
        #line default
        #line hidden
        
        
        #line 469 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imagePhone;
        
        #line default
        #line hidden
        
        
        #line 470 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imageUp;
        
        #line default
        #line hidden
        
        
        #line 471 "..\..\Window2.xaml"
        internal System.Windows.Controls.Image imageDown;
        
        #line default
        #line hidden
        
        
        #line 472 "..\..\Window2.xaml"
        internal System.Windows.Controls.TextBlock textoSelec;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectDOTNET;component/window2.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\Window2.xaml"
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
            this.Window = ((ProjectDOTNET.Window2)(target));
            
            #line 9 "..\..\Window2.xaml"
            this.Window.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 9 "..\..\Window2.xaml"
            this.Window.Activated += new System.EventHandler(this.ResumeTimer);
            
            #line default
            #line hidden
            return;
            case 2:
            this.closeEnter_BeginStoryboard = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 3:
            this.closeEnter_BeginStoryboard1 = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 4:
            this.windowLoad_BeginStoryboard1 = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 5:
            this.upEnter_BeginStoryboard1 = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 6:
            this.upLeave_BeginStoryboard1 = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 7:
            this.downEnter_BeginStoryboard1 = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 8:
            this.downLeave_BeginStoryboard1 = ((System.Windows.Media.Animation.BeginStoryboard)(target));
            return;
            case 9:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 10:
            this.textTime = ((System.Windows.Controls.TextBlock)(target));
            
            #line 459 "..\..\Window2.xaml"
            this.textTime.Loaded += new System.Windows.RoutedEventHandler(this.StartTimer);
            
            #line default
            #line hidden
            return;
            case 11:
            this.close = ((System.Windows.Controls.Image)(target));
            
            #line 460 "..\..\Window2.xaml"
            this.close.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.close_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 12:
            this.imagePics = ((System.Windows.Controls.Image)(target));
            return;
            case 13:
            this.imageMusic = ((System.Windows.Controls.Image)(target));
            return;
            case 14:
            this.imageVideo = ((System.Windows.Controls.Image)(target));
            return;
            case 15:
            this.imageRSS = ((System.Windows.Controls.Image)(target));
            return;
            case 16:
            this.imagePhone = ((System.Windows.Controls.Image)(target));
            return;
            case 17:
            this.imageUp = ((System.Windows.Controls.Image)(target));
            return;
            case 18:
            this.imageDown = ((System.Windows.Controls.Image)(target));
            return;
            case 19:
            this.textoSelec = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

