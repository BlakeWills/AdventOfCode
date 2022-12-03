module Helpers

open System
open System.IO

let getDataPath path = 
    [$"..\\..\\..\\Data\\{path}"; $"Data\\{path}"]
    |> List.filter (fun x -> File.Exists (Path.Combine (Environment.CurrentDirectory, x)))
    |> List.head