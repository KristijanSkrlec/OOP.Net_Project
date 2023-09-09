﻿#pragma checksum "..\..\..\InitSettingsWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "ED391E14D44FC0ED8D2F58E3169C8E93414F5BDF"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
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
using System.Windows.Controls.Ribbon;
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
using System.Windows.Shell;
using WinPresentationFoundation;


namespace WinPresentationFoundation {
    
    
    /// <summary>
    /// InitSettingsWindow
    /// </summary>
    public partial class InitSettingsWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal WinPresentationFoundation.InitSettingsWindow Initial_Settings;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel spContainer;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbMale;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbFemale;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbCroatian;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.RadioButton rbEnglish;
        
        #line default
        #line hidden
        
        
        #line 19 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox cbRepresentations;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\..\InitSettingsWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnContinue;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WinPresentationFoundation;component/initsettingswindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\InitSettingsWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "6.0.10.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.Initial_Settings = ((WinPresentationFoundation.InitSettingsWindow)(target));
            
            #line 8 "..\..\..\InitSettingsWindow.xaml"
            this.Initial_Settings.Loaded += new System.Windows.RoutedEventHandler(this.Initial_Settings_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.spContainer = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 3:
            this.rbMale = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 4:
            this.rbFemale = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 5:
            this.rbCroatian = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 6:
            this.rbEnglish = ((System.Windows.Controls.RadioButton)(target));
            return;
            case 7:
            this.cbRepresentations = ((System.Windows.Controls.ComboBox)(target));
            return;
            case 8:
            this.btnContinue = ((System.Windows.Controls.Button)(target));
            
            #line 21 "..\..\..\InitSettingsWindow.xaml"
            this.btnContinue.Click += new System.Windows.RoutedEventHandler(this.btnMessage_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

