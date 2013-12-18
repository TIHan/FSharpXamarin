module FSharpXamarin.Core.Control

type IO<'a> = IO of 'a
 
type IOBuilder () =
    member inline this.Bind (IO x, f) : IO<_>  = f x
    member inline this.Delay f                 = f ()
    member inline this.Return x                = IO x
    member inline this.ReturnFrom (IO x)       = x
    member inline this.Zero ()                 = IO ()
 
let io = IOBuilder ()
