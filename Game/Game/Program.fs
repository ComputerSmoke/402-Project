open GameTypes
open System.Numerics
open GameLogic
open Graphics
open Input
open Draw


let graphics = new Game1(takeInput, draw)
//TODO: also get a thread going with our web server
graphics.Run()

