﻿#pragma checksum "..\..\LoadPage.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "090E2CDBAB320F54DD68D31BB3FB57F36C68829E7E52ED4AE1DF254DE8E70ED6"
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
using easySaveV2;


namespace easySaveV2 {
    
    
    /// <summary>
    /// LoadPage
    /// </summary>
    public partial class LoadPage : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 10 "..\..\LoadPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock LoadLabel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\LoadPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Load_ReturnButton;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\LoadPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListBox SaveList;
        
        #line default
        #line hidden
        
        
        #line 13 "..\..\LoadPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button RefreshListButton;
        
        #line default
        #line hidden
        
        
        #line 14 "..\..\LoadPage.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button SaveListButton;
        
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
            System.Uri resourceLocater = new System.Uri("/easySaveV2;component/loadpage.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\LoadPage.xaml"
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
            this.LoadLabel = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 2:
            this.Load_ReturnButton = ((System.Windows.Controls.Button)(target));
            
            #line 11 "..\..\LoadPage.xaml"
            this.Load_ReturnButton.Click += new System.Windows.RoutedEventHandler(this.Load_ReturnButton_Click);
            
            #line default
            #line hidden
            return;
            case 3:
            this.SaveList = ((System.Windows.Controls.ListBox)(target));
            return;
            case 4:
            this.RefreshListButton = ((System.Windows.Controls.Button)(target));
            
            #line 13 "..\..\LoadPage.xaml"
            this.RefreshListButton.Click += new System.Windows.RoutedEventHandler(this.RefreshListButton_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.SaveListButton = ((System.Windows.Controls.Button)(target));
            
            #line 14 "..\..\LoadPage.xaml"
            this.SaveListButton.Click += new System.Windows.RoutedEventHandler(this.SaveListButton_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

