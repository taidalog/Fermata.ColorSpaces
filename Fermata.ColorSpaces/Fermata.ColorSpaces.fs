// Fermata.ColorSpaces Version 0.1.1
// https://github.com/taidalog/Fermata.ColorSpaces
// Copyright (c) 2024 taidalog
// This software is licensed under the MIT License.
// https://github.com/taidalog/Fermata.ColorSpaces/blob/main/LICENSE
namespace Fermata.ColorSpaces

open System
open Fermata

[<StructuredFormatDisplay("{DisplayText}")>]
type HexCode =
    | Valid of string
    | Invalid of exn

    member this.DisplayText = this.ToString()

    override this.ToString() =
        match this with
        | HexCode.Valid x -> x
        | HexCode.Invalid e -> e.ToString()

[<StructuredFormatDisplay("{DisplayText}")>]
type Rgb =
    | Valid of int * int * int
    | Invalid of exn

    member this.DisplayText = this.ToString()

    override this.ToString() =
        match this with
        | Rgb.Valid(r, g, b) -> $"%d{r}, %d{g}, %d{b}"
        | Rgb.Invalid e -> e.ToString()

[<RequireQualifiedAccess>]
module HexCode =
    let validate (value: string) : HexCode =
        let notEmptyString (x: string) : Result<string, exn> =
            if x = "" then
                Error(ArgumentException "The input value was an empty string.")
            else
                Ok x

        let withoutNumberSign (x: string) : string =
            match String.head x with
            | "#" -> String.tail x
            | _ -> x

        let is6CharLong (x: string) : Result<string, exn> =
            if String.length x = 6 then
                Ok x
            else
                Error(FormatException "The input value is too long or too short.")

        let validateFormat (x: string) : Result<string, exn> =
            //match Byte.TryParse x with
            match Regex.isMatch "#?[0-9A-Fa-f]{6}" x with
            | true -> Ok x
            | false -> Error(FormatException "The input value is not in the correct format.")

        let toHexCode (x: Result<string, exn>) : HexCode =
            match x with
            | Ok x -> HexCode.Valid x
            | Error e -> HexCode.Invalid e

        value
        |> String.trim
        |> Ok
        |> Result.bind notEmptyString
        |> Result.map withoutNumberSign
        |> Result.bind is6CharLong
        |> Result.bind validateFormat
        |> Result.map ((+) "#")
        |> toHexCode

    let toRgb (hexCode: HexCode) : Rgb =
        let hexToDec (input: string) : int = Convert.ToInt32(input, 16)

        match hexCode with
        | HexCode.Valid x ->
            let r', g', b' = String.mid 1 2 x, String.mid 3 2 x, String.mid 5 2 x
            Rgb.Valid(hexToDec r', hexToDec g', hexToDec b')
        | HexCode.Invalid e -> Rgb.Invalid e

    let ofRgb (rgb: Rgb) : HexCode =
        let decToHex2Digit (input: int) : string =
            Convert.ToString(input, 16).PadLeft(2, '0')

        match rgb with
        | Rgb.Valid(r, g, b) -> (r, g, b) |> Tuple.map3 decToHex2Digit |||> sprintf "#%s%s%s" |> validate
        | Rgb.Invalid e -> HexCode.Invalid e

[<RequireQualifiedAccess>]
module Rgb =
    let validate (r: int) (g: int) (b: int) : Rgb =
        if List.forall (fun x -> 0 <= x && x <= 255) [ r; g; b ] then
            Rgb.Valid(r, g, b)
        else
            Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    let validate' (r: int, g: int, b: int) : Rgb = validate r g b

    let toHexCode (rgb: Rgb) : HexCode = HexCode.ofRgb rgb

    let ofHexCode (hexCode: HexCode) : Rgb = HexCode.toRgb hexCode
