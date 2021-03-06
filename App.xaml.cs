using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace myPersonalDict
{
    public partial class App : Application
    {

        string dbPath => FileAccessHelper.GetLocalFilePath("dict.db3");

        public static Translation TranslationRepo { get; set; }
        public App()
        {
            InitializeComponent();

            TranslationRepo = new Translation(dbPath);

            MainPage = new MainPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
