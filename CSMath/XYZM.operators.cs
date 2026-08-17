using System;

namespace CSMath;

public partial struct XYZM : IVector, IEquatable<XYZM>
{
	/// <summary>
	/// Adds two vectors together.
	/// </summary>
	/// <param name="left">The first source vector.</param>
	/// <param name="right">The second source vector.</param>
	/// <returns>The summed vector.</returns>
	public static XYZM operator +(XYZM left, XYZM right)
	{
		return new XYZM(left.X + right.X, left.Y + right.Y, left.Z + right.Z, left.M + right.M);
	}

	/// <summary>
	/// Subtracts the second vector from the first.
	/// </summary>
	/// <param name="left">The first source vector.</param>
	/// <param name="right">The second source vector.</param>
	/// <returns>The difference vector.</returns>
	public static XYZM operator -(XYZM left, XYZM right)
	{
		return new XYZM(left.X - right.X, left.Y - right.Y, left.Z - right.Z, left.M - right.M);
	}

	/// <summary>
	/// Multiplies two vectors together.
	/// </summary>
	/// <param name="left">The first source vector.</param>
	/// <param name="right">The second source vector.</param>
	/// <returns>The product vector.</returns>
	public static XYZM operator *(XYZM left, XYZM right)
	{
		return new XYZM(left.X * right.X, left.Y * right.Y, left.Z * right.Z, left.M * right.M);
	}

	/// <summary>
	/// Multiplies a vector by the given scalar.
	/// </summary>
	/// <param name="left">The source vector.</param>
	/// <param name="scalar">The scalar value.</param>
	/// <returns>The scaled vector.</returns>
	public static XYZM operator *(XYZM left, double scalar)
	{
		return new XYZM(left.X * scalar, left.Y * scalar, left.Z * scalar, left.M * scalar);
	}

	/// <summary>
	/// Multiplies a vector by the given scalar.
	/// </summary>
	/// <param name="scalar">The scalar value.</param>
	/// <param name="vector">The source vector.</param>
	/// <returns>The scaled vector.</returns>
	public static XYZM operator *(double scalar, XYZM vector)
	{
		return new XYZM(scalar * vector.X, scalar * vector.Y, scalar * vector.Z, scalar * vector.M);
	}

	/// <summary>
	/// Divides the first vector by the second.
	/// </summary>
	/// <param name="left">The first source vector.</param>
	/// <param name="right">The second source vector.</param>
	/// <returns>The vector resulting from the division.</returns>
	public static XYZM operator /(XYZM left, XYZM right)
	{
		return new XYZM(left.X / right.X, left.Y / right.Y, left.Z / right.Z, left.M / right.M);
	}

	/// <summary>
	/// Divides the vector by the given scalar.
	/// </summary>
	/// <param name="xyzm">The source vector.</param>
	/// <param name="value">The scalar value.</param>
	/// <returns>The result of the division.</returns>
	public static XYZM operator /(XYZM xyzm, double value)
	{
		return new XYZM(xyzm.X / value, xyzm.Y / value, xyzm.Z / value, xyzm.M / value);
	}

	/// <summary>
	/// Negates a given vector.
	/// </summary>
	/// <param name="value">The source vector.</param>
	/// <returns>The negated vector.</returns>
	public static XYZM operator -(XYZM value)
	{
		// 0 - x (not -x) keeps the sign of a zero component identical to the previous
		// Zero.Subtract(value) implementation: 0 - (+0) is +0, while -(+0) is -0
		return new XYZM(0.0 - value.X, 0.0 - value.Y, 0.0 - value.Z, 0.0 - value.M);
	}

	/// <summary>
	/// Returns a boolean indicating whether the two given vectors are equal.
	/// </summary>
	/// <param name="left">The first vector to compare.</param>
	/// <param name="right">The second vector to compare.</param>
	/// <returns>True if the vectors are equal; False otherwise.</returns>
	public static bool operator ==(XYZM left, XYZM right)
	{
		return left.IsEqual(right);
	}

	/// <summary>
	/// Returns a boolean indicating whether the two given vectors are not equal.
	/// </summary>
	/// <param name="left">The first vector to compare.</param>
	/// <param name="right">The second vector to compare.</param>
	/// <returns>True if the vectors are not equal; False if they are equal.</returns>
	public static bool operator !=(XYZM left, XYZM right)
	{
		return !left.IsEqual(right);
	}
}
