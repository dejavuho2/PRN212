﻿#pragma checksum "..\..\..\CreateReportWindow.xaml" "{ff1816ec-aa5e-4d10-87f7-6f4963833460}" "CCF66DC7DAB19F86B87E932CAFEFD04E7D853200"
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
using WpfApp;


namespace WpfApp {
    
    
    /// <summary>
    /// CreateReportWindow
    /// </summary>
    public partial class CreateReportWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 41 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label;
        
        #line default
        #line hidden
        
        
        #line 44 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageCustomerInfo;
        
        #line default
        #line hidden
        
        
        #line 45 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnManageRoomInfo;
        
        #line default
        #line hidden
        
        
        #line 46 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateReport;
        
        #line default
        #line hidden
        
        
        #line 47 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnCreateBookingReservation;
        
        #line default
        #line hidden
        
        
        #line 50 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label1;
        
        #line default
        #line hidden
        
        
        #line 51 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpStartDate;
        
        #line default
        #line hidden
        
        
        #line 53 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label label2;
        
        #line default
        #line hidden
        
        
        #line 54 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DatePicker dpEndDate;
        
        #line default
        #line hidden
        
        
        #line 56 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnGenerateReport;
        
        #line default
        #line hidden
        
        
        #line 58 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.DataGrid dgReportData;
        
        #line default
        #line hidden
        
        
        #line 68 "..\..\..\CreateReportWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button btnClose;
        
        #line default
        #line hidden
        
        private bool _contentLoaded;
        
        /// <summary>
        /// InitializeComponent
        /// </summary>
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        public void InitializeComponent() {
            if (_contentLoaded) {
                return;
            }
            _contentLoaded = true;
            System.Uri resourceLocater = new System.Uri("/WpfApp;V1.0.0.0;component/createreportwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\..\CreateReportWindow.xaml"
            System.Windows.Application.LoadComponent(this, resourceLocater);
            
            #line default
            #line hidden
        }
        
        [System.Diagnostics.DebuggerNonUserCodeAttribute()]
        [System.CodeDom.Compiler.GeneratedCodeAttribute("PresentationBuildTasks", "8.0.5.0")]
        [System.ComponentModel.EditorBrowsableAttribute(System.ComponentModel.EditorBrowsableState.Never)]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Design", "CA1033:InterfaceMethodsShouldBeCallableByChildTypes")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity")]
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1800:DoNotCastUnnecessarily")]
        void System.Windows.Markup.IComponentConnector.Connect(int connectionId, object target) {
            switch (connectionId)
            {
            case 1:
            
            #line 8 "..\..\..\CreateReportWindow.xaml"
            ((WpfApp.CreateReportWindow)(target)).Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            return;
            case 2:
            this.label = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.btnManageCustomerInfo = ((System.Windows.Controls.Button)(target));
            
            #line 44 "..\..\..\CreateReportWindow.xaml"
            this.btnManageCustomerInfo.Click += new System.Windows.RoutedEventHandler(this.btnManageCustomerInfo_Click);
            
            #line default
            #line hidden
            return;
            case 4:
            this.btnManageRoomInfo = ((System.Windows.Controls.Button)(target));
            
            #line 45 "..\..\..\CreateReportWindow.xaml"
            this.btnManageRoomInfo.Click += new System.Windows.RoutedEventHandler(this.btnManageRoomInfo_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.btnCreateReport = ((System.Windows.Controls.Button)(target));
            
            #line 46 "..\..\..\CreateReportWindow.xaml"
            this.btnCreateReport.Click += new System.Windows.RoutedEventHandler(this.btnCreateReport_Click);
            
            #line default
            #line hidden
            return;
            case 6:
            this.btnCreateBookingReservation = ((System.Windows.Controls.Button)(target));
            
            #line 47 "..\..\..\CreateReportWindow.xaml"
            this.btnCreateBookingReservation.Click += new System.Windows.RoutedEventHandler(this.btnCreateBookingReservation_Click);
            
            #line default
            #line hidden
            return;
            case 7:
            this.label1 = ((System.Windows.Controls.Label)(target));
            return;
            case 8:
            this.dpStartDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 9:
            this.label2 = ((System.Windows.Controls.Label)(target));
            return;
            case 10:
            this.dpEndDate = ((System.Windows.Controls.DatePicker)(target));
            return;
            case 11:
            this.btnGenerateReport = ((System.Windows.Controls.Button)(target));
            
            #line 56 "..\..\..\CreateReportWindow.xaml"
            this.btnGenerateReport.Click += new System.Windows.RoutedEventHandler(this.btnGenerateReport_Click);
            
            #line default
            #line hidden
            return;
            case 12:
            this.dgReportData = ((System.Windows.Controls.DataGrid)(target));
            return;
            case 13:
            this.btnClose = ((System.Windows.Controls.Button)(target));
            
            #line 68 "..\..\..\CreateReportWindow.xaml"
            this.btnClose.Click += new System.Windows.RoutedEventHandler(this.btnClose_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

