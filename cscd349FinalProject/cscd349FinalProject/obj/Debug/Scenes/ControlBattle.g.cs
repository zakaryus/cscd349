﻿#pragma checksum "..\..\..\Scenes\ControlBattle.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "9BD3E28AD15D5C6F1ECD472BC3F1B613"
//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.34209
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
    /// ControlBattle
    /// </summary>
    public partial class ControlBattle : System.Windows.Controls.UserControl, System.Windows.Markup.IComponentConnector {
        
        
        #line 8 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Grid grdControlBattle;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnBack;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnLose;
        
        #line default
        #line hidden
        
        
        #line 24 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAttack;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblBattle;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblComputerTurn;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblPlayerTurn;
        
        #line default
        #line hidden
        
        
        #line 28 "..\..\..\Scenes\ControlBattle.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox lbInventoryList;
        
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
            System.Uri resourceLocater = new System.Uri("/cscd349FinalProject;component/scenes/controlbattle.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\Scenes\ControlBattle.xaml"
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
            this.grdControlBattle = ((System.Windows.Controls.Grid)(target));
            return;
            case 2:
            this.btnBack = ((System.Windows.Controls.Button)(target));
            
            #line 22 "..\..\..\Scenes\ControlBattle.xaml"
            this.btnBack.Click += new System.Windows.RoutedEventHandler(this.btnBack_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.btnLose = ((System.Windows.Controls.Button)(target));
            
            #line 23 "..\..\..\Scenes\ControlBattle.xaml"
            this.btnLose.Click += new System.Windows.RoutedEventHandler(this.btnLose_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnAttack = ((System.Windows.Controls.Button)(target));
            
            #line 24 "..\..\..\Scenes\ControlBattle.xaml"
            this.btnAttack.Click += new System.Windows.RoutedEventHandler(this.btnAttack_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblBattle = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.lblComputerTurn = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.lblPlayerTurn = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.lbInventoryList = ((System.Windows.Controls.ListBox)(target));
            
            #line 28 "..\..\..\Scenes\ControlBattle.xaml"
            this.lbInventoryList.MouseMove += new System.Windows.Input.MouseEventHandler(this.lbItemList_MouseMove);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

