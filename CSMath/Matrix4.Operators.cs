using System;
using System.Collections.Generic;

namespace CSMath;

public partial struct Matrix4
{
	/// <summary>
	/// Multiplies two matrices.
	/// </summary>
	/// <returns>A new instance containing the result.</returns>
	public static Matrix4 Multiply(Matrix4 a, Matrix4 b)
	{
		// expanded rows(a) dot cols(b), without the lists GetRows and GetCols allocated per call.
		// the leading 0.0 reproduces the zero seeded accumulator of Dot so results stay bit identical,
		// the sign of a zero matters to callers extracting angles with Math.Atan2.
		Matrix4 result = new Matrix4();

		result.M00 = 0.0 + a.M00 * b.M00 + a.M10 * b.M01 + a.M20 * b.M02 + a.M30 * b.M03;
		result.M10 = 0.0 + a.M00 * b.M10 + a.M10 * b.M11 + a.M20 * b.M12 + a.M30 * b.M13;
		result.M20 = 0.0 + a.M00 * b.M20 + a.M10 * b.M21 + a.M20 * b.M22 + a.M30 * b.M23;
		result.M30 = 0.0 + a.M00 * b.M30 + a.M10 * b.M31 + a.M20 * b.M32 + a.M30 * b.M33;
		result.M01 = 0.0 + a.M01 * b.M00 + a.M11 * b.M01 + a.M21 * b.M02 + a.M31 * b.M03;
		result.M11 = 0.0 + a.M01 * b.M10 + a.M11 * b.M11 + a.M21 * b.M12 + a.M31 * b.M13;
		result.M21 = 0.0 + a.M01 * b.M20 + a.M11 * b.M21 + a.M21 * b.M22 + a.M31 * b.M23;
		result.M31 = 0.0 + a.M01 * b.M30 + a.M11 * b.M31 + a.M21 * b.M32 + a.M31 * b.M33;
		result.M02 = 0.0 + a.M02 * b.M00 + a.M12 * b.M01 + a.M22 * b.M02 + a.M32 * b.M03;
		result.M12 = 0.0 + a.M02 * b.M10 + a.M12 * b.M11 + a.M22 * b.M12 + a.M32 * b.M13;
		result.M22 = 0.0 + a.M02 * b.M20 + a.M12 * b.M21 + a.M22 * b.M22 + a.M32 * b.M23;
		result.M32 = 0.0 + a.M02 * b.M30 + a.M12 * b.M31 + a.M22 * b.M32 + a.M32 * b.M33;
		result.M03 = 0.0 + a.M03 * b.M00 + a.M13 * b.M01 + a.M23 * b.M02 + a.M33 * b.M03;
		result.M13 = 0.0 + a.M03 * b.M10 + a.M13 * b.M11 + a.M23 * b.M12 + a.M33 * b.M13;
		result.M23 = 0.0 + a.M03 * b.M20 + a.M13 * b.M21 + a.M23 * b.M22 + a.M33 * b.M23;
		result.M33 = 0.0 + a.M03 * b.M30 + a.M13 * b.M31 + a.M23 * b.M32 + a.M33 * b.M33;

		return result;
	}

	/// <summary>
	/// Multiplies two matrices.
	/// </summary>
	/// <returns>A new instance containing the result.</returns>
	public static Matrix4 operator *(Matrix4 a, Matrix4 b)
	{
		return Matrix4.Multiply(a, b);
	}

	/// <summary>Multiply the matrix and a coordinate</summary>
	/// <param name="matrix"></param>
	/// <param name="value"></param>
	/// <returns>Result matrix</returns>
	public static XYZ operator *(Matrix4 matrix, XYZ value)
	{
		// expanded rows(matrix) dot (x, y, z, 1), without the list GetRows allocated per call.
		// this runs once per transformed point. the leading 0.0 reproduces the zero seeded
		// accumulator of Dot so results stay bit identical, the trailing 1 folds away exactly.
		return new XYZ(
			0.0 + matrix.M00 * value.X + matrix.M10 * value.Y + matrix.M20 * value.Z + matrix.M30,
			0.0 + matrix.M01 * value.X + matrix.M11 * value.Y + matrix.M21 * value.Z + matrix.M31,
			0.0 + matrix.M02 * value.X + matrix.M12 * value.Y + matrix.M22 * value.Z + matrix.M32);
	}

	/// <summary>Multiply the matrix and XYZM</summary>
	/// <param name="matrix"></param>
	/// <param name="v"></param>
	/// <returns>Result matrix</returns>
	public static XYZM operator *(Matrix4 matrix, XYZM v)
	{
		return new XYZM(
			matrix.M00 * v.X + matrix.M10 * v.Y + matrix.M20 * v.Z + matrix.M30 * v.M,
			matrix.M01 * v.X + matrix.M11 * v.Y + matrix.M21 * v.Z + matrix.M31 * v.M,
			matrix.M02 * v.X + matrix.M12 * v.Y + matrix.M22 * v.Z + matrix.M32 * v.M,
			matrix.M03 * v.X + matrix.M13 * v.Y + matrix.M23 * v.Z + matrix.M33 * v.M);
	}
}