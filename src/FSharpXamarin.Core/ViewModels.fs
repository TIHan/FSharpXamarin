
namespace FSharpXamarin.Core.ViewModels

open System
open Cirrious.MvvmCross.ViewModels
open FSharpXamarin.Core.Control

type Agent<'T> = MailboxProcessor<'T>

type Message =
    | None
    | PrintYo

module HomeAgent =
    let homeAgent = new Agent<Message> (fun inbox ->
        let rec loop () =
            async {
                    let! msg = inbox.Receive()

                    match msg with
                    | PrintYo ->
                        printfn "yo"
                        return! loop()
                    | _ -> return! loop() }
        loop ())

type HomeViewModel () =
    inherit MvxViewModel ()

    let createCommand (f: unit -> unit) = io {
        return MvxCommand (fun () -> f())
    }

    do
        HomeAgent.homeAgent.Start ()

    member this.ClickCommand = MvxCommand (fun () -> 
        HomeAgent.homeAgent.Post (PrintYo)
    )

    member this.ClickCommandMonad = io {
        return! createCommand (fun () -> printfn "yo")
    }