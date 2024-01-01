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
    val validate: value: string -> HexCode

    /// <summary>Returns <c>Rgb.Valid</c> if the input <c>HexCode</c> is valid, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="hexCode">The input <c>HexCode</c>.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    val toRgb: hexCode: HexCode -> Rgb

    /// <summary>Returns <c>HexCode.Valid</c> if the input <c>Rgb</c> is valid, otherwise <c>HexCode.Invalid</c>.</summary>
    ///
    /// <param name="rgb">The input <c>Rgb</c>.</param>
    ///
    /// <returns>The result <c>HexCode</c>.</returns>
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
    val validate: r: int -> g: int -> b: int -> Rgb

    /// <summary>Returns <c>Rgb.Valid</c> if the input set of int values can be parsed as an RGB value, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="r">The input int for R.</param>
    /// <param name="g">The input int for G.</param>
    /// <param name="b">The input int for B.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    val validate': r: int * g: int * b: int -> Rgb

    /// <summary>Returns <c>HexCode.Valid</c> if the input <c>Rgb</c> is valid, otherwise <c>HexCode.Invalid</c>.</summary>
    ///
    /// <param name="rgb">The input <c>Rgb</c>.</param>
    ///
    /// <returns>The result <c>HexCode</c>.</returns>
    val toHexCode: rgb: Rgb -> HexCode

    /// <summary>Returns <c>Rgb.Valid</c> if the input <c>HexCode</c> is valid, otherwise <c>Rgb.Invalid</c>.</summary>
    ///
    /// <param name="hexCode">The input <c>HexCode</c>.</param>
    ///
    /// <returns>The result <c>Rgb</c>.</returns>
    val ofHexCode: hexCode: HexCode -> Rgb
