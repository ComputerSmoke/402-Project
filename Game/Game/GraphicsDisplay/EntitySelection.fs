module EntitySelection

open InputOutput
open Microsoft.Xna.Framework.Input
open System

let mutable selectedIdx = 0
let mutable rightDown = false
let mutable leftDown = false

let updateEntitySelection (state:KeyboardState) =
    let IncrementSelected() =
        selectedIdx <- (selectedIdx + 1) % game.Entities.Length
    let DeincrementSelected() =
        selectedIdx <- Math.Max(selectedIdx - 1, 0)
    match state.IsKeyDown(Keys.Right) with
    | true -> 
        match rightDown with
        | true -> ()
        | false ->
            IncrementSelected()
        rightDown <- true
    | false ->
        rightDown <- false
        match state.IsKeyDown(Keys.Left) with
        | true ->
            match leftDown with
            | true -> ()
            | false -> DeincrementSelected()
            leftDown <- true
        | false -> 
            leftDown <- false

 //Cycle through entities with left/right arrows
let getSelected() =
    match List.length game.Entities with
    | 0 -> None
    | _ ->
        selectedIdx <- selectedIdx % game.Entities.Length
        Some game.Entities[selectedIdx]