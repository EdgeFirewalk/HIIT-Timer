﻿#pragma checksum "..\..\TimerWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "5D66B817BAD851CD2328130C46E4CF743FEF0EAF1A488F3024EB722D197D5330"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using HIIT_Timer;
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


namespace HIIT_Timer {
    
    
    /// <summary>
    /// TimerWindow
    /// </summary>
    public partial class TimerWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 1 "..\..\TimerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal HIIT_Timer.TimerWindow HIIT_Timer;
        
        #line default
        #line hidden
        
        
        #line 10 "..\..\TimerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label timeLabel;
        
        #line default
        #line hidden
        
        
        #line 11 "..\..\TimerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label stageLabel;
        
        #line default
        #line hidden
        
        
        #line 12 "..\..\TimerWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Label exerciseLabel;
        
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
            System.Uri resourceLocater = new System.Uri("/HIIT_Timer;component/timerwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\TimerWindow.xaml"
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
            this.HIIT_Timer = ((HIIT_Timer.TimerWindow)(target));
            
            #line 8 "..\..\TimerWindow.xaml"
            this.HIIT_Timer.Closed += new System.EventHandler(this.Window_Closed);
            
            #line default
            #line hidden
            
            #line 8 "..\..\TimerWindow.xaml"
            this.HIIT_Timer.Loaded += new System.Windows.RoutedEventHandler(this.Window_Loaded);
            
            #line default
            #line hidden
            
            #line 8 "..\..\TimerWindow.xaml"
            this.HIIT_Timer.KeyDown += new System.Windows.Input.KeyEventHandler(this.HIIT_Timer_KeyDown);
            
            #line default
            #line hidden
            return;
            case 2:
            this.timeLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 3:
            this.stageLabel = ((System.Windows.Controls.Label)(target));
            return;
            case 4:
            this.exerciseLabel = ((System.Windows.Controls.Label)(target));
            return;
            }
            this._contentLoaded = true;
        }
    }
}
