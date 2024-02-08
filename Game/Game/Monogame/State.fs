module State

open GameTypes

let newGame =
    {Entities = [{Position = {X = 0; Y = 0}; Id = 0; Type = Hero}]; Step = 0}
let mutable game = newGame
let mutable selectedIdx = 0
let mutable rightDown = false
let mutable leftDown = false