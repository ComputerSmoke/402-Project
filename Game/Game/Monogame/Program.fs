open GameTypes
open State
open GameLogic
open Microsoft.Xna.Framework.Input
open Graphics
open Input
open Draw
open System

let updateEntitySelection (state:KeyboardState) =
    let IncrementSelected() =
        selectedIdx <- (selectedIdx + 1) % game.Entities.Length
    let DeincrementSelected() =
        selectedIdx <- Math.Max(selectedIdx - 1, 0)

    if state.IsKeyDown Keys.Right && not rightDown then IncrementSelected()
    else if state.IsKeyDown Keys.Left && not leftDown then DeincrementSelected()

    rightDown <- state.IsKeyDown Keys.Right
    leftDown <- state.IsKeyDown Keys.Left

let takeInput () =
    let state = Keyboard.GetState()
    updateEntitySelection state
    let action: GameAction = findAction state
    game <- 
        [(selectedIdx, action)]
        |> (actionBindingsToActionList game.Entities)
        |> updateState game

let game1 = new Game1(takeInput, draw )
//TODO: also get a thread going with our web server
game1.Run()

