#pragma checksum "..\..\MainWindow.xaml" "{8829d00f-11b8-4213-878b-770e8597ac16}" "006E31127E24FB1B0F0D3B09F5A6DE314697E37AE85628B99344F7FB2C0A025F"
//------------------------------------------------------------------------------
// <auto-generated>
//     Этот код создан программой.
//     Исполняемая версия:4.0.30319.42000
//
//     Изменения в этом файле могут привести к неправильной работе и будут потеряны в случае
//     повторной генерации кода.
// </auto-generated>
//------------------------------------------------------------------------------

using MaterialDesignThemes.Wpf;
using MaterialDesignThemes.Wpf.Converters;
using MaterialDesignThemes.Wpf.Transitions;
using System;
using System.Diagnostics;
using System.Windows;
using System.Windows.Automation;
using System.Windows.Controls;
using System.Windows.Controls.Primitives;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Forms.Integration;
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
using УчетЛПА;


namespace УчетЛПА {
    
    
    /// <summary>
    /// MainWindow
    /// </summary>
    public partial class MainWindow : System.Windows.Window, System.Windows.Markup.IComponentConnector {
        
        
        #line 85 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ListView LViewLPA;
        
        #line default
        #line hidden
        
        
        #line 125 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.TextBox Find;
        
        #line default
        #line hidden
        
        
        #line 130 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.ComboBox ComboTdel;
        
        #line default
        #line hidden
        
        
        #line 140 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Back;
        
        #line default
        #line hidden
        
        
        #line 144 "..\..\MainWindow.xaml"
        [System.Diagnostics.CodeAnalysis.SuppressMessageAttribute("Microsoft.Performance", "CA1823:AvoidUnusedPrivateFields")]
        internal System.Windows.Controls.Button Spravka;
        
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
            System.Uri resourceLocater = new System.Uri("/УчетЛПА;component/mainwindow.xaml", System.UriKind.Relative);
            
            #line 1 "..\..\MainWindow.xaml"
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
            this.LViewLPA = ((System.Windows.Controls.ListView)(target));
            
            #line 86 "..\..\MainWindow.xaml"
            this.LViewLPA.SelectionChanged += new System.Windows.Controls.SelectionChangedEventHandler(this.LViewLPA_SelectionChanged);
            
            #line default
            #line hidden
            return;
            case 2:
            this.Find = ((System.Windows.Controls.TextBox)(target));
            
            #line 129 "..\..\MainWindow.xaml"
            this.Find.TextChanged += new System.Windows.Controls.TextChangedEventHandler(this.Find_TextChanged);
            
            #line default
            #line hidden
            
            #line 129 "..\..\MainWindow.xaml"
            this.Find.GotFocus += new System.Windows.RoutedEventHandler(this.Find_GotFocus);
            
            #line default
            #line hidden
            
            #line 129 "..\..\MainWindow.xaml"
            this.Find.MouseDown += new System.Windows.Input.MouseButtonEventHandler(this.Find_MouseDown);
            
            #line default
            #line hidden
            return;
            case 3:
            this.ComboTdel = ((System.Windows.Controls.ComboBox)(target));
            
            #line 131 "..\..\MainWindow.xaml"
            this.ComboTdel.GotFocus += new System.Windows.RoutedEventHandler(this.ComboRating_GotFocus);
            
            #line default
            #line hidden
            return;
            case 4:
            this.Back = ((System.Windows.Controls.Button)(target));
            
            #line 142 "..\..\MainWindow.xaml"
            this.Back.Click += new System.Windows.RoutedEventHandler(this.Back_Click);
            
            #line default
            #line hidden
            return;
            case 5:
            this.Spravka = ((System.Windows.Controls.Button)(target));
            
            #line 146 "..\..\MainWindow.xaml"
            this.Spravka.Click += new System.Windows.RoutedEventHandler(this.Spravka_Click);
            
            #line default
            #line hidden
            return;
            }
            this._contentLoaded = true;
        }
    }
}

