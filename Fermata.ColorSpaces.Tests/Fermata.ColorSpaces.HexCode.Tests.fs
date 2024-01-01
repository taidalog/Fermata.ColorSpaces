module Fermata.ColorSpaces.HexCode.Tests

open System
open Xunit
open Fermata.ColorSpaces

[<Fact>]
let ``HexCode.validate 1`` () =
    let input = "#65a2ac"
    let actual = HexCode.validate input
    let expected = HexCode.Valid "#65a2ac"

    Assert.Equal(expected, actual)

[<Fact>]
let ``HexCode.validate 2`` () =
    let input = "65a2ac"
    let actual = HexCode.validate input
    let expected = HexCode.Valid "#65a2ac"

    Assert.Equal(expected, actual)

[<Fact>]
let ``HexCode.validate 3`` () =
    let input = ""
    let actual = HexCode.validate input

    let expected =
        HexCode.Invalid(ArgumentException "The input value was an empty string.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``HexCode.validate 4`` () =
    let input = "#0123456"
    let actual = HexCode.validate input

    let expected =
        HexCode.Invalid(FormatException "The input value is too long or too short.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``HexCode.validate 5`` () =
    let input = "#xxyyzz"
    let actual = HexCode.validate input

    let expected =
        HexCode.Invalid(FormatException "The input value is not in the correct format.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``HexCode.toRgb 1`` () =
    let input = HexCode.Valid "#65a2ac"
    let actual = input |> HexCode.toRgb
    let expected = Rgb.Valid(101, 162, 172)
    Assert.Equal(expected, actual)

[<Fact>]
let ``HexCode.toRgb 2`` () =
    let input =
        HexCode.Invalid(FormatException "The input value is not in the correct format.")

    let actual = input |> HexCode.toRgb

    let expected =
        Rgb.Invalid(FormatException "The input value is not in the correct format.")

    Assert.Equivalent(expected, actual)

[<Fact>]
let ``HexCode.ofRgb 1`` () =
    let input = Rgb.Valid(101, 162, 172)
    let actual = HexCode.ofRgb input
    let expected = HexCode.Valid "#65a2ac"
    Assert.Equal(expected, actual)

[<Fact>]
let ``HexCode.ofRgb 2`` () =
    let input =
        Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    let actual = HexCode.ofRgb input

    let expected =
        HexCode.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")

    Assert.Equivalent(expected, actual)
