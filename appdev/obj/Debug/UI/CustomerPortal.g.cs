﻿#pragma checksum "..\..\..\UI\CustomerPortal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "EEEF823055101F45D8BFBA65D6FC2A49FB999336AC22BD3706CD4284A97C36B9"
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
using appdev.UI;


namespace appdev.UI {
    
    
    /// <summary>
    /// CustomerPortal
    /// </summary>
    public partial class CustomerPortal : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 93 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border lblbNoSub;
        
        #line default
        #line hidden
        
        
        #line 94 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblNoSub;
        
        #line default
        #line hidden
        
        
        #line 101 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnName;
        
        #line default
        #line hidden
        
        
        #line 104 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUserID;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CustomerPaymentOptions;
        
        #line default
        #line hidden
        
        
        #line 115 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubscribe;
        
        #line default
        #line hidden
        
        
        #line 117 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblSubscribePrice;
        
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
            System.Uri resourceLocater = new System.Uri("/appdev;component/ui/customerportal.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\CustomerPortal.xaml"
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
            
            #line 8 "..\..\..\UI\CustomerPortal.xaml"
            ((appdev.UI.CustomerPortal)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblbNoSub = ((System.Windows.Controls.Border)(target));
            return;
            case 3:
            this.lblNoSub = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 4:
            this.btnName = ((System.Windows.Controls.Button)(target));
            return;
            case 5:
            this.btnUserID = ((System.Windows.Controls.Button)(target));
            return;
            case 6:
            this.CustomerPaymentOptions = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\UI\CustomerPortal.xaml"
            this.CustomerPaymentOptions.Click += new System.Windows.RoutedEventHandler(this.CustomerPaymentOptions_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.btnSubscribe = ((System.Windows.Controls.Button)(target));
            
            #line 116 "..\..\..\UI\CustomerPortal.xaml"
            this.btnSubscribe.Click += new System.Windows.RoutedEventHandler(this.btnSubscribe_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblSubscribePrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

