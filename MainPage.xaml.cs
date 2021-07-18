using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using myPersonalDict.Models;

namespace myPersonalDict
{
    public partial class MainPage : TabbedPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private async void btnAddSentence_Clicked(object sender, EventArgs e)
        {
            await App.TranslationRepo.AddNewSentence(editorGerman.Text, editorSpanish.Text);
            labelStatus.Text = "Sentence successful stored";
            btnClear.IsVisible = true;
        }

        private void btnClear_Clicked(object sender, EventArgs e)
        {
            editorGerman.Text = "";
            editorSpanish.Text = "";
            labelStatus.Text = "";
            btnClear.IsVisible = false;
        }

        private async void btnSearch_Clicked(object sender, EventArgs e)
        {
            List<Translations> translations = await App.TranslationRepo.GetSearchedTranslations();
            TranslationList.ItemsSource = translations;
        }

        private async void btnSearchAll_Clicked(object sender, EventArgs e)
        {
            List<Translations> translations = await App.TranslationRepo.GetAllTranslations();
            TranslationList.ItemsSource = translations;
        }
    }
}
