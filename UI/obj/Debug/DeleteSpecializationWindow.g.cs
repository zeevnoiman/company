﻿#pragma checksum "..\..\DeleteSpecializationWindow.xaml" "{406ea660-64cf-4c82-b6f0-42d48172a799}" "FC9E6593A34EA2915DDEDABFCAF90B30"
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
using UI;


namespace UI {
    
    
    /// <summary>
    /// DeleteSpecializationWindow
    /// </summary>
    public partial class DeleteSpecializationWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 16 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxSpecName;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxSpecNumber;
        
        #line default
        #line hidden
        
        
        #line 18 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox boxField;
        
        #line default
        #line hidden
        
        
        #line 21 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelSpecName;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelSpecNumber;
        
        #line default
        #line hidden
        
        
        #line 23 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelSpecField;
        
        #line default
        #line hidden
        
        
        #line 25 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label labelAllSpecs;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button deleteSpec;
        
        #line default
        #line hidden
        
        
        #line 27 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button closeButton;
        
        #line default
        #line hidden
        
        
        #line 29 "..\..\DeleteSpecializationWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox listBoxSpecs;
        
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
            System.Uri resourceLocater = new System.Uri("/UI;component/deletespecializationwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\DeleteSpecializationWindow.xaml"
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
            this.boxSpecName = ((System.Windows.Controls.TextBox)(target));
            return;
            case 2:
            this.boxSpecNumber = ((System.Windows.Controls.TextBox)(target));
            return;
            case 3:
            this.boxField = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.labelSpecName = ((System.Windows.Controls.Label)(target));
            return;
            case 5:
            this.labelSpecNumber = ((System.Windows.Controls.Label)(target));
            return;
            case 6:
            this.labelSpecField = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.labelAllSpecs = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.deleteSpec = ((System.Windows.Controls.Button)(target));
            
            #line 26 "..\..\DeleteSpecializationWindow.xaml"
            this.deleteSpec.Click += new System.Windows.RoutedEventHandler(this.button_Click);
            
            #line default
            #line hidden
            return;
            case 9:
            this.closeButton = ((System.Windows.Controls.Button)(target));
            
            #line 27 "..\..\DeleteSpecializationWindow.xaml"
            this.closeButton.Click += new System.Windows.RoutedEventHandler(this.button_Click2);
            
            #line default
            #line hidden
            return;
            case 10:
            this.listBoxSpecs = ((System.Windows.Controls.ListBox)(target));
            
            #line 29 "..\..\DeleteSpecializationWindow.xaml"
            this.listBoxSpecs.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.listBox_SelectionChanged);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

