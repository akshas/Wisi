﻿#pragma checksum "..\..\MartkplatzWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "7337110F07F2529981C624F87E49424677D35F95D696D2D8AB94D1DBF1F2D9BC"
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
using WiSi;


namespace WiSi {
    
    
    /// <summary>
    /// MartkplatzWindow
    /// </summary>
    public partial class MartkplatzWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 58 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnzahlSteinKaufen;
        
        #line default
        #line hidden
        
        
        #line 66 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnzahlEisenKaufen;
        
        #line default
        #line hidden
        
        
        #line 74 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnzahlHolzKaufen;
        
        #line default
        #line hidden
        
        
        #line 86 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnzahlBrotKaufen;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox AnzahlMilchKaufen;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplaySteinPreis;
        
        #line default
        #line hidden
        
        
        #line 110 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplayEisenPreis;
        
        #line default
        #line hidden
        
        
        #line 111 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplayHolzPreis;
        
        #line default
        #line hidden
        
        
        #line 112 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplayBrotPreis;
        
        #line default
        #line hidden
        
        
        #line 113 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock DisplayMilchPreis;
        
        #line default
        #line hidden
        
        
        #line 114 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock GesamtPreis;
        
        #line default
        #line hidden
        
        
        #line 126 "..\..\MartkplatzWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox test;
        
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
            System.Uri resourceLocater = new System.Uri("/WiSi;component/martkplatzwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MartkplatzWindow.xaml"
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
            
            #line 8 "..\..\MartkplatzWindow.xaml"
            ((WiSi.MartkplatzWindow)(target)).Closing += new System.ComponentModel.CancelEventHandler(this.OnWindowClosing);
            
            #line default
            #line hidden
            return;
            case 2:
            this.AnzahlSteinKaufen = ((System.Windows.Controls.TextBox)(target));
            
            #line 58 "..\..\MartkplatzWindow.xaml"
            this.AnzahlSteinKaufen.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.OnTextChanged);
            
            #line default
            #line hidden
            
            #line 58 "..\..\MartkplatzWindow.xaml"
            this.AnzahlSteinKaufen.LostFocus += new System.Windows.RoutedEventHandler(this.OnLostFocus);
            
            #line default
            #line hidden
            return;
            case 3:
            this.AnzahlEisenKaufen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 4:
            this.AnzahlHolzKaufen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 5:
            this.AnzahlBrotKaufen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 6:
            this.AnzahlMilchKaufen = ((System.Windows.Controls.TextBox)(target));
            return;
            case 7:
            this.DisplaySteinPreis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 8:
            this.DisplayEisenPreis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.DisplayHolzPreis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 10:
            this.DisplayBrotPreis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 11:
            this.DisplayMilchPreis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 12:
            this.GesamtPreis = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 13:
            this.test = ((System.Windows.Controls.TextBox)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

