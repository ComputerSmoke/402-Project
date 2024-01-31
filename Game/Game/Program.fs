open GameTypes
open System.Numerics
open GameLogic
open Graphics

//We will construct a game state for each level
let newGame =
    {Entities = [{Pos = Vector2.Zero}]; Step = 0}

//Example of usage
let mutable game = newGame
for i in [0..1000] do
    game <- updateState game [Move(Vector2.UnitY)]
    //This is an access of protected members, so will not be possible in consumer code.
    //We will write functions to access the internals of the game state in a limited manner
    printfn $"{game.Entities.Head.Pos}"

