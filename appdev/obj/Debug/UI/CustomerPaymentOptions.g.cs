﻿#pragma checksum "..\..\..\UI\CustomerPaymentOptions.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "58342B4A1A3E057662BD62DDCFB17F18B213905EE01885CA688A440A83181E75"
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
    /// CustomerPaymentOptions
    /// </summary>
    public partial class CustomerPaymentOptions : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 15 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCredit;
        
        #line default
        #line hidden
        
        
        #line 17 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblCreditValue;
        
        #line default
        #line hidden
        
        
        #line 22 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel vertiStacker;
        
        #line default
        #line hidden
        
        
        #line 26 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.StackPanel horizFooterStackPanel;
        
        #line default
        #line hidden
        
        
        #line 33 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label lblNoCards;
        
        #line default
        #line hidden
        
        
        #line 42 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnDeleteCard;
        
        #line default
        #line hidden
        
        
        #line 43 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnEditCard;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\UI\CustomerPaymentOptions.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnAddCard;
        
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
            System.Uri resourceLocater = new System.Uri("/appdev;component/ui/customerpaymentoptions.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\UI\CustomerPaymentOptions.xaml"
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
            
            #line 8 "..\..\..\UI\CustomerPaymentOptions.xaml"
            ((appdev.UI.CustomerPaymentOptions)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.lblCredit = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.lblCreditValue = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.vertiStacker = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 5:
            this.horizFooterStackPanel = ((System.Windows.Controls.StackPanel)(target));
            return;
            case 6:
            this.lblNoCards = ((System.Windows.Controls.Label)(target));
            return;
            case 7:
            this.btnDeleteCard = ((System.Windows.Controls.Button)(target));
            return;
            case 8:
            this.btnEditCard = ((System.Windows.Controls.Button)(target));
            return;
            case 9:
            this.btnAddCard = ((System.Windows.Controls.Button)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}

