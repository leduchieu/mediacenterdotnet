﻿#pragma checksum "..\..\WindowGames.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "211B88C1AC0A5D83E181E897D76B50BB"
//------------------------------------------------------------------------------
// <auto-generated>
//     Este código fue generado por una herramienta.
//     Versión del motor en tiempo de ejecución:2.0.50727.3053
//
//     Los cambios en este archivo podrían causar un comportamiento incorrecto y se perderán si
//     se vuelve a generar el código.
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
    /// WindowGames
    /// </summary>
    public partial class WindowGames : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 5 "..\..\WindowGames.xaml"
        internal ProjectDOTNET.WindowGames Window;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\WindowGames.xaml"
        internal System.Windows.Controls.Grid LayoutRoot;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\WindowGames.xaml"
        internal System.Windows.Controls.Image closeImg;
        
        #line default
        #line hidden
        
        
        #line 48 "..\..\WindowGames.xaml"
        internal System.Windows.Controls.Image imgShinju;
        
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
            System.Uri resourceLocater = new System.Uri("/ProjectDOTNET;component/windowgames.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\WindowGames.xaml"
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
            this.Window = ((ProjectDOTNET.WindowGames)(target));
            return;
            case 2:
            this.LayoutRoot = ((System.Windows.Controls.Grid)(target));
            return;
            case 3:
            this.closeImg = ((System.Windows.Controls.Image)(target));
            
            #line 47 "..\..\WindowGames.xaml"
            this.closeImg.MouseEnter += new System.Windows.Input.MouseEventHandler(this.Image_MouseEnter);
            
            #line default
            #line hidden
            
            #line 47 "..\..\WindowGames.xaml"
            this.closeImg.MouseLeave += new System.Windows.Input.MouseEventHandler(this.Image_MouseLeave);
            
            #line default
            #line hidden
            
            #line 47 "..\..\WindowGames.xaml"
            this.closeImg.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.closeImg_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            case 4:
            this.imgShinju = ((System.Windows.Controls.Image)(target));
            
            #line 48 "..\..\WindowGames.xaml"
            this.imgShinju.MouseEnter += new System.Windows.Input.MouseEventHandler(this.imgShinju_MouseEnter);
            
            #line default
            #line hidden
            
            #line 48 "..\..\WindowGames.xaml"
            this.imgShinju.MouseLeave += new System.Windows.Input.MouseEventHandler(this.imgShinju_MouseLeave);
            
            #line default
            #line hidden
            
            #line 48 "..\..\WindowGames.xaml"
            this.imgShinju.MouseLeftButtonUp += new System.Windows.Input.MouseButtonEventHandler(this.imgShinju_MouseLeftButtonUp);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

