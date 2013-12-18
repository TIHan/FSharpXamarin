
namespace FSharpXamarin.Core.App

open Cirrious.CrossCore
open Cirrious.MvvmCross.ViewModels

open FSharpXamarin.Core.ViewModels

type App () =
    inherit MvxApplication ()

    do
        Mvx.RegisterSingleton<IMvxAppStart> (MvxAppStart<HomeViewModel> ())

