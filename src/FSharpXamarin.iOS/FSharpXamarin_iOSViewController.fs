namespace FSharpXamarin.iOS

open System
open System.Drawing

open MonoTouch.UIKit
open MonoTouch.Foundation
open MonoTouch.SpriteKit
open MonoTouch.CoreGraphics

/// http://7sharpnine.com/posts/sprite-kit-particle-fun/
[<Register ("FSharpXamarin_iOSViewController")>]
type FSharpXamarin_iOSViewController () as x =
    inherit UIViewController ()

    let mutable scene = Unchecked.defaultof<SKScene>
    let mutable spriteView = new SKView()

    let setupScene() =
        spriteView.Bounds <- RectangleF(0.f, 0.f, x.View.Bounds.Width * UIScreen.MainScreen.Scale,
                                                  x.View.Bounds.Height * UIScreen.MainScreen.Scale)
        spriteView.ShowsDrawCount <- true
        spriteView.ShowsNodeCount <- true
        spriteView.ShowsFPS <- true

        x.View <- spriteView
        scene <- new SKScene (spriteView.Bounds.Size,
                              BackgroundColor = UIColor.Blue,
                              ScaleMode = SKSceneScaleMode.AspectFit)

        use sprite = new SKSpriteNode ("Sprites/firefly.png")
        sprite.Position <- PointF (scene.Frame.GetMidX(), scene.Frame.GetMidY())
        sprite.Name <- "Firefly"
        scene.AddChild(sprite)

    override x.DidReceiveMemoryWarning () =
        base.DidReceiveMemoryWarning ()

    override x.ShouldAutorotateToInterfaceOrientation (orientation) =
        orientation <> UIInterfaceOrientation.PortraitUpsideDown

    override x.ViewDidLoad () =
        base.ViewDidLoad()
        setupScene()

    override x.ViewDidAppear(animated) =
        base.ViewDidDisappear (animated)
        spriteView.PresentScene(scene)

    override x.ViewDidDisappear(animated) =
        base.ViewDidDisappear (animated)
        scene.RemoveAllChildren()
        scene.RemoveAllActions()

