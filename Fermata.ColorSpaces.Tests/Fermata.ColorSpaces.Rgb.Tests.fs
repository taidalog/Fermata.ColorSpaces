// Fermata.ColorSpaces Version 0.1.0
// https://github.com/taidalog/Fermata.ColorSpaces
// Copyright (c) 2024 taidalog
// This software is licensed under the MIT License.
// https://github.com/taidalog/Fermata.ColorSpaces/blob/main/LICENSE
module Fermata.ColorSpaces.Rgb.Tests

open System
open Xunit
open Fermata.ColorSpaces

[<Fact>]
let ``Rgb.validate 1`` () =
    let actual = Rgb.validate 101 162 172
    let expected = Rgb.Valid(101, 162, 172)

    Assert.Equal(expected, actual)

[<Fact>]
let ``Rgb.validate 2`` () =
    let actual = Rgb.validate 101 162 272

    let expected =
        Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``Rgb.validate' 1`` () =
    let input = (101, 162, 172)
    let actual = Rgb.validate' input
    let expected = Rgb.Valid(101, 162, 172)
    Assert.Equal(expected, actual)

[<Fact>]
let ``Rgb.validate' 2`` () =
    let input = (101, 162, 272)
    let actual = Rgb.validate' input

    let expected =
        Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``Rgb.toHexCode 1`` () =
    let input = Rgb.Valid(101, 162, 172)
    let actual = Rgb.toHexCode input
    let expected = HexCode.Valid "#65a2ac"
    Assert.Equal(expected, actual)

[<Fact>]
let ``Rgb.toHexCode 2`` () =
    let input =
        Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    let actual = Rgb.toHexCode input

    let expected =
        HexCode.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``Rgb.ofHexCode 1`` () =
    let input = HexCode.Valid "#65a2ac"
    let actual = Rgb.ofHexCode input
    let expected = Rgb.Valid(101, 162, 172)
    Assert.Equal(expected, actual)

[<Fact>]
let ``Rgb.ofHexCode 2`` () =
    let input =
        HexCode.Invalid(FormatException "The input value is not in the correct format.")

    let actual = Rgb.ofHexCode input

    let expected =
        Rgb.Invalid(FormatException "The input value is not in the correct format.")

    Assert.Equivalent(expected, actual)
