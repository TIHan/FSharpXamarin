namespace FSharpXamarin.iOS

open System
open MonoTouch.UIKit
open MonoTouch.Foundation

open Cirrious.CrossCore
open Cirrious.MvvmCross.Touch.Platform
open Cirrious.MvvmCross.Touch.Views.Presenters
open Cirrious.MvvmCross.ViewModels

open FSharpXamarin.Core
open FSharpXamarin.Core.App

type Setup (appDelegate: MvxApplicationDelegate, presenter: IMvxTouchViewPresenter) =
    inherit MvxTouchSetup (appDelegate, presenter)

    override this.CreateApp () : IMvxApplication = App () :> IMvxApplication

[<Register ("AppDelegate")>]
type AppDelegate () =
    inherit MvxApplicationDelegate ()

    let window = new UIWindow (UIScreen.MainScreen.Bounds)

    override this.FinishedLaunching (app, options) =
        let presenter = MvxTouchViewPresenter (this, window)

        let setup = new Setup (this, presenter)
        setup.Initialize ()

        let startup = Mvx.Resolve<IMvxAppStart> ()
        startup.Start ()

        window.MakeKeyAndVisible ()
        true

module Main =
    [<EntryPoint>]
    let main args =
        UIApplication.Main (args, null, "AppDelegate")
        0

