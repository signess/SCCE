//------------------------------------------------------------------------------
// <auto-generated>
//     This code was generated by a tool.
//     Runtime Version:4.0.30319.42000
//
//     Changes to this file may cause incorrect behavior and will be lost if
//     the code is regenerated.
// </auto-generated>
//------------------------------------------------------------------------------

[assembly: global::Xamarin.Forms.Xaml.XamlResourceIdAttribute("SCCE.Views.Popup.MessageBox.xaml", "Views/Popup/MessageBox.xaml", typeof(global::SCCE.Views.Popup.MessageBox))]

namespace SCCE.Views.Popup {
    
    
    [global::Xamarin.Forms.Xaml.XamlFilePathAttribute("Views\\Popup\\MessageBox.xaml")]
    public partial class MessageBox : global::Rg.Plugins.Popup.Pages.PopupPage {
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label title;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Label description;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.PancakeView.PancakeView imageFrame;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.PancakeView.DropShadow shadow;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Lottie.Forms.AnimationView animation;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private global::Xamarin.Forms.Button button;
        
        [global::System.CodeDom.Compiler.GeneratedCodeAttribute("Xamarin.Forms.Build.Tasks.XamlG", "2.0.0.0")]
        private void InitializeComponent() {
            global::Xamarin.Forms.Xaml.Extensions.LoadFromXaml(this, typeof(MessageBox));
            title = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "title");
            description = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Label>(this, "description");
            imageFrame = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.PancakeView.PancakeView>(this, "imageFrame");
            shadow = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.PancakeView.DropShadow>(this, "shadow");
            animation = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Lottie.Forms.AnimationView>(this, "animation");
            button = global::Xamarin.Forms.NameScopeExtensions.FindByName<global::Xamarin.Forms.Button>(this, "button");
        }
    }
}
