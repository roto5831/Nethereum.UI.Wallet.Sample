﻿using Xamarin.Forms;
using System.Reflection;
using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;
using Nethereum.UI.Core.Views;

namespace Nethereum.UI.Core
{
   public class App : MvxApplication
    {
        public static bool IsWindows10 { get; set; }
        public override void Initialize()
        {
           

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            typeof(Nethereum.Wallet.Services.IEthWalletService).GetTypeInfo().Assembly.CreatableTypes()
           .EndingWith("Service")
           .AsInterfaces()
           .RegisterAsLazySingleton();

            //if (Device.RuntimePlatform == Device.Android || Device.RuntimePlatform == Device.iOS)
            //{
            //    Resources.AppResources.Culture = Mvx.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();
            //}


            // Construct custom application start object
            Mvx.ConstructAndRegisterSingleton<IMvxAppStart, AppStart>();
            

            // request a reference to the constructed appstart object 
            var appStart = Mvx.Resolve<IMvxAppStart>();

            // register the appstart object
            RegisterAppStart(appStart);

        }
    }
}
