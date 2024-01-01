// Fermata.ColorSpaces Version 0.1.1
// https://github.com/taidalog/Fermata.ColorSpaces
// Copyright (c) 2024 taidalog
// This software is licensed under the MIT License.
// https://github.com/taidalog/Fermata.ColorSpaces/blob/main/LICENSE
namespace Fermata.ColorSpaces

[<StructuredFormatDisplay("{DisplayText}")>]
type HexCode =
    | Valid of string
    | Invalid of exn

    override ToString: unit -> string

    member DisplayText: string

[<StructuredFormatDisplay("{DisplayText}")>]
type Rgb =
    | Valid of int * int * int
    | Invalid of exn

    override ToString: unit -> string

    member DisplayText: string

[<RequireQualifiedAccess>]
module HexCode =
    /// <summary>Returns <c>HexCode.Valid</c> if the input string can be parsed as a HEX color code, otherwise <c>HexCode.Invalid</c>.</summary>
    ///
    /// <param name="value">The input string.</param>
    ///
    /// <returns>The result <c>HexCode</c>.</returns>
    ///
    /// <example id="HexCode.validate-1">
    /// <code lang="fsharp">
    /// let input = "#65a2ac"
    /// HexCode.validate input
    /// </code>
    /// Evaluates to <c>HexCode.Valid "#65a2ac"</c>
    /// </example>
    ///
    /// <example id="HexCode.validate-2">
    /// <code lang="fsharp">
    /// let input = "65a2ac"
    /// HexCode.validate input
    /// </code>
    /// Evaluates to <c>HexCode.Valid "#65a2ac"</c>
    /// </example>
    ///
    /// <example id="HexCode.validate-3">
    /// <code lang="fsharp">
    /// let input = ""
    /// HexCode.validate input
    /// </code>
    /// Evaluates to <c>HexCode.Invalid(ArgumentException "The input value was an empty string.")</c>
    /// </example>
    ///
    /// <example id="HexCode.validate-4">
    /// <code lang="fsharp">
    /// let input = "#0123456"
    /// HexCode.validate input
    /// </code>
    /// Evaluates to <c>HexCode.Invalid(FormatException "The input value is too long or too short.")</c>
    /// </example>
    ///
    /// <example id="HexCode.validate-5">
    /// <code lang="fsharp">
    /// let input = "#xxyyzz"
    /// HexCode.validate input
    /// </code>
    /// Evaluates to <c>HexCode.Invalid(FormatException "The input value is not in the correct format.")</c>
    /// </example>
    val validate: value: string -> HexCode

    /// <summary>Returns <c>Rgb.Valid</c> if the input <c>HexCode</c> is valid, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="hexCode">The input <c>HexCode</c>.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    ///
    /// <example id="HexCode.toRgb-1">
    /// <code lang="fsharp">
    /// let input = HexCode.Valid "#65a2ac"
    /// input |> HexCode.toRgb
    /// </code>
    /// Evaluates to <c>Rgb.Valid(101, 162, 172)</c>
    /// </example>
    ///
    /// <example id="HexCode.toRgb-2">
    /// <code lang="fsharp">
    /// let input = HexCode.Invalid(FormatException "The input value is not in the correct format.")
    /// input |> HexCode.toRgb
    /// </code>
    /// Evaluates to <c>Rgb.Invalid(FormatException "The input value is not in the correct format.")</c>
    /// </example>
    val toRgb: hexCode: HexCode -> Rgb

    /// <summary>Returns <c>HexCode.Valid</c> if the input <c>Rgb</c> is valid, otherwise <c>HexCode.Invalid</c>.</summary>
    ///
    /// <param name="rgb">The input <c>Rgb</c>.</param>
    ///
    /// <returns>The result <c>HexCode</c>.</returns>
    ///
    /// <example id="HexCode.ofRgb-1">
    /// <code lang="fsharp">
    /// let input = Rgb.Valid(101, 162, 172)
    /// HexCode.ofRgb input
    /// </code>
    /// Evaluates to <c>HexCode.Valid "#65a2ac"</c>
    /// </example>
    ///
    /// <example id="HexCode.ofRgb-2">
    /// <code lang="fsharp">
    /// let input = Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")
    /// HexCode.ofRgb input
    /// </code>
    /// Evaluates to <c>HexCode.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")</c>
    /// </example>
    val ofRgb: rgb: Rgb -> HexCode

[<RequireQualifiedAccess>]
module Rgb =
    /// <summary>Returns <c>Rgb.Valid</c> if the input set of int values can be parsed as an RGB value, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="r">The input int for R.</param>
    /// <param name="g">The input int for G.</param>
    /// <param name="b">The input int for B.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    ///
    /// <example id="Rgb.validate-1">
    /// <code lang="fsharp">
    /// Rgb.validate 101 162 172
    /// </code>
    /// Evaluates to <c>Rgb.Valid(101, 162, 172)</c>
    /// </example>
    ///
    /// <example id="Rgb.validate-2">
    /// <code lang="fsharp">
    /// Rgb.validate 101 162 272
    /// </code>
    /// Evaluates to <c>Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")</c>
    /// </example>
    val validate: r: int -> g: int -> b: int -> Rgb

    /// <summary>Returns <c>Rgb.Valid</c> if the input set of int values can be parsed as an RGB value, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="r">The input int for R.</param>
    /// <param name="g">The input int for G.</param>
    /// <param name="b">The input int for B.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    ///
    /// <example id="Rgb.validate'-1">
    /// <code lang="fsharp">
    /// let input = (101, 162, 172)
    /// Rgb.validate' input
    /// </code>
    /// Evaluates to <c>Rgb.Valid(101, 162, 172)</c>
    /// </example>
    ///
    /// <example id="Rgb.validate'-2">
    /// <code lang="fsharp">
    /// let input = (101, 162, 272)
    /// Rgb.validate' input
    /// </code>
    /// Evaluates to <c>Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")</c>
    /// </example>
    val validate': r: int * g: int * b: int -> Rgb

    /// <summary>Returns <c>HexCode.Valid</c> if the input <c>Rgb</c> is valid, otherwise <c>HexCode.Invalid</c>.</summary>
    ///
    /// <param name="rgb">The input <c>Rgb</c>.</param>
    ///
    /// <returns>The result <c>HexCode</c>.</returns>
    ///
    /// <example id="Rgb.toHexCode-1">
    /// <code lang="fsharp">
    /// let input = Rgb.Valid(101, 162, 172)
    /// Rgb.toHexCode input
    /// </code>
    /// Evaluates to <c>HexCode.Valid "#65a2ac"</c>
    /// </example>
    ///
    /// <example id="Rgb.toHexCode-2">
    /// <code lang="fsharp">
    /// let input = Rgb.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")
    /// Rgb.toHexCode input
    /// </code>
    /// Evaluates to <c>HexCode.Invalid(OverflowException "Value was either too large or too small for an unsigned byte.")</c>
    /// </example>
    val toHexCode: rgb: Rgb -> HexCode

    /// <summary>Returns <c>Rgb.Valid</c> if the input <c>HexCode</c> is valid, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="hexCode">The input <c>HexCode</c>.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    /// <example id="Rgb.ofHexCode-1">
    /// <code lang="fsharp">
    /// let input = HexCode.Valid "#65a2ac"
    /// Rgb.ofHexCode input
    /// </code>
    /// Evaluates to <c>Rgb.Valid(101, 162, 172)</c>
    /// </example>
    ///
    /// <example id="Rgb.ofHexCode-2">
    /// <code lang="fsharp">
    /// let input = HexCode.Invalid(FormatException "The input value is not in the correct format.")
    /// Rgb.ofHexCode input
    /// </code>
    /// Evaluates to <c>Rgb.Invalid(FormatException "The input value is not in the correct format.")</c>
    /// </example>
    val ofHexCode: hexCode: HexCode -> Rgb
