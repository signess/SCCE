using SCCE.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace SCCE.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class FinalView : ContentPage
    {
        public FinalView(ProcessosItem processoitem, string bgS, string bgE)
        {
            InitializeComponent();
            this.ProcessoItem = processoitem;
            BGS = bgS;
            BGE = bgE;
            BombaItem = ProcessoItem.BombaSubmersa;
            this.BindingContext = this;
        }
        public string BGS { get; set; }
        public string BGE { get; set; }
        public ProcessosItem ProcessoItem { get; set; }
        public BombaSubmersaItem BombaItem { get; set; }

        private void GoBack(object sender, EventArgs e)
        {
            Navigation.PopAsync();
        }
    }
}