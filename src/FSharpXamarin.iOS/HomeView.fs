namespace FSharpXamarin.iOS.Views

open System
open System.Drawing

open MonoTouch.UIKit
open MonoTouch.Foundation
open MonoTouch.SpriteKit
open MonoTouch.CoreGraphics

open Cirrious.MvvmCross.ViewModels
open Cirrious.MvvmCross.Touch.Views
open Cirrious.MvvmCross.Binding.BindingContext
open Cirrious.MvvmCross.Binding.Touch.Views

open FSharpXamarin.Core.ViewModels

type HomeView () =
    inherit MvxViewController ()

    override this.ViewDidLoad () =
        base.ViewDidLoad ()

        let button = UIButton.FromType (UIButtonType.System)
        button.Frame <- RectangleF (PointF (0.f, 16.f), SizeF (80.f, 128.f))
        button.SetTitle ("Click Me!", UIControlState.Normal)

        this.CreateBinding(button).To("ClickCommandMonad").Apply()

        this.View.AddSubview (button)
