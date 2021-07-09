﻿#pragma checksum "..\..\..\UI\CustomerPortal.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "A56A8665264F953D617207019B57537CF83BAC3AA875376CAF2C1B0CCF2E702A"
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
        
        
        #line 103 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnName;
        
        #line default
        #line hidden
        
        
        #line 106 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnUserID;
        
        #line default
        #line hidden
        
        
        #line 109 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button CustomerPaymentOptions;
        
        #line default
        #line hidden
        
        
        #line 131 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Border lblbNoSub;
        
        #line default
        #line hidden
        
        
        #line 132 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblNoSub;
        
        #line default
        #line hidden
        
        
        #line 148 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnSubscribe;
        
        #line default
        #line hidden
        
        
        #line 150 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBlock lblSubscribePrice;
        
        #line default
        #line hidden
        
        
        #line 157 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateCustomerAccount;
        
        #line default
        #line hidden
        
        
        #line 160 "..\..\..\UI\CustomerPortal.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClearProperties;
        
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
            this.btnName = ((System.Windows.Controls.Button)(target));
            return;
            case 3:
            this.btnUserID = ((System.Windows.Controls.Button)(target));
            return;
            case 4:
            this.CustomerPaymentOptions = ((System.Windows.Controls.Button)(target));
            
            #line 110 "..\..\..\UI\CustomerPortal.xaml"
            this.CustomerPaymentOptions.Click += new System.Windows.RoutedEventHandler(this.CustomerPaymentOptions_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.lblbNoSub = ((System.Windows.Controls.Border)(target));
            return;
            case 6:
            this.lblNoSub = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 7:
            this.btnSubscribe = ((System.Windows.Controls.Button)(target));
            
            #line 149 "..\..\..\UI\CustomerPortal.xaml"
            this.btnSubscribe.Click += new System.Windows.RoutedEventHandler(this.btnSubscribe_Click);
            
            #line default
            #line hidden
            return;
            case 8:
            this.lblSubscribePrice = ((System.Windows.Controls.TextBlock)(target));
            return;
            case 9:
            this.btnCreateCustomerAccount = ((System.Windows.Controls.Button)(target));
            
            #line 158 "..\..\..\UI\CustomerPortal.xaml"
            this.btnCreateCustomerAccount.Click += new System.Windows.RoutedEventHandler(this.btnCreateCustomerAccount_Click);
            
            #line default
            #line hidden
            return;
            case 10:
            this.btnClearProperties = ((System.Windows.Controls.Button)(target));
            
            #line 160 "..\..\..\UI\CustomerPortal.xaml"
            this.btnClearProperties.Click += new System.Windows.RoutedEventHandler(this.btnClearProperties_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

