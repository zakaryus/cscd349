﻿#pragma checksum "..\..\..\Scenes\ControlCharacter.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "890FC05378A0D59E90B52619DCA3EBB6"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34014
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
using System.Windows.Shell;


namespace cscd349FinalProject {
    
    
    /// <summary>
    /// ControlCharacter
    /// </summary>
    public partial class ControlCharacter : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbEngineer;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbMage;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbPaladin;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbRogue;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbWanderer;
        
        #line default
        #line hidden
        
        
        #line 15 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.CheckBox cbWarrior;
        
        #line default
        #line hidden
        
        
        #line 16 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnPlay;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\Scenes\ControlCharacter.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/cscd349FinalProject;component/scenes/controlcharacter.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Scenes\ControlCharacter.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "4.0.0.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            this.cbEngineer = ((System.Windows.Controls.CheckBox)(target));
            
            #line 10 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbEngineer.Checked += new System.Windows.RoutedEventHandler(this.cb_Checked);
            
            #line default
            #line hidden
            
            #line 10 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbEngineer.Unchecked += new System.Windows.RoutedEventHandler(this.cb_Unchecked);
            
            #line default
            #line hidden
            return;
            case 2:
            this.cbMage = ((System.Windows.Controls.CheckBox)(target));
            
            #line 11 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbMage.Unchecked += new System.Windows.RoutedEventHandler(this.cb_Unchecked);
            
            #line default
            #line hidden
            
            #line 11 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbMage.Checked += new System.Windows.RoutedEventHandler(this.cb_Checked);
            
            #line default
            #line hidden
            return;
            case 3:
            this.cbPaladin = ((System.Windows.Controls.CheckBox)(target));
            
            #line 12 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbPaladin.Unchecked += new System.Windows.RoutedEventHandler(this.cb_Unchecked);
            
            #line default
            #line hidden
            
            #line 12 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbPaladin.Checked += new System.Windows.RoutedEventHandler(this.cb_Checked);
            
            #line default
            #line hidden
            return;
            case 4:
            this.cbRogue = ((System.Windows.Controls.CheckBox)(target));
            
            #line 13 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbRogue.Unchecked += new System.Windows.RoutedEventHandler(this.cb_Unchecked);
            
            #line default
            #line hidden
            
            #line 13 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbRogue.Checked += new System.Windows.RoutedEventHandler(this.cb_Checked);
            
            #line default
            #line hidden
            return;
            case 5:
            this.cbWanderer = ((System.Windows.Controls.CheckBox)(target));
            
            #line 14 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbWanderer.Unchecked += new System.Windows.RoutedEventHandler(this.cb_Unchecked);
            
            #line default
            #line hidden
            
            #line 14 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbWanderer.Checked += new System.Windows.RoutedEventHandler(this.cb_Checked);
            
            #line default
            #line hidden
            return;
            case 6:
            this.cbWarrior = ((System.Windows.Controls.CheckBox)(target));
            
            #line 15 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbWarrior.Unchecked += new System.Windows.RoutedEventHandler(this.cb_Unchecked);
            
            #line default
            #line hidden
            
            #line 15 "..\..\..\Scenes\ControlCharacter.xaml"
            this.cbWarrior.Checked += new System.Windows.RoutedEventHandler(this.cb_Checked);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnPlay = ((System.Windows.Controls.Button)(target));
            
            #line 16 "..\..\..\Scenes\ControlCharacter.xaml"
            this.btnPlay.Click += new System.Windows.RoutedEventHandler(this.btnPlay_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 17 "..\..\..\Scenes\ControlCharacter.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

