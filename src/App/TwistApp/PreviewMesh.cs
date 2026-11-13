using System;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows;
using System.Windows.Media.Media3D;

namespace TwistApp;

public sealed class PreviewMesh
{
	public Point3D[] Positions;

	public Vector3D[] Normals;

	public Point[] Uv;

	public int[] Faces;

	private static float RecoveredMethod743(BinaryReader P_0)
	{
		float num = P_0.ReadSingle();
		if (float.IsNaN(num) || float.IsInfinity(num) || Math.Abs(num) > 10000000f)
		{
			throw new Exception("Invalid mesh coordinate.");
		}
		return num;
	}

	public static PreviewMesh Load(string file)
	{
		using FileStream fileStream = File.OpenRead(file);
		using BinaryReader binaryReader = new BinaryReader(fileStream);
		if (Encoding.ASCII.GetString(binaryReader.ReadBytes(10)) == "twistmesh1")
		{
			int num = binaryReader.ReadInt32();
			int num2 = binaryReader.ReadInt32();
			if (num < 1 || num > 250000 || num2 < 1 || num2 > 500000 || fileStream.Length != 18 + (long)num * 40L + (long)num2 * 12L)
			{
				throw new Exception("Invalid cached mesh.");
			}
			PreviewMesh previewMesh = new PreviewMesh();
			previewMesh.Positions = new Point3D[num];
			previewMesh.Normals = new Vector3D[num];
			previewMesh.Uv = new Point[num];
			previewMesh.Faces = new int[num2 * 3];
			PreviewMesh previewMesh2 = previewMesh;
			for (int i = 0; i < num; i++)
			{
				long position = fileStream.Position;
				ref Point3D reference = ref previewMesh2.Positions[i];
				reference = new Point3D(RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader));
				ref Vector3D reference2 = ref previewMesh2.Normals[i];
				reference2 = new Vector3D(RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader));
				ref Point reference3 = ref previewMesh2.Uv[i];
				reference3 = new Point(RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader));
				fileStream.Position = position + 40;
			}
			for (int j = 0; j < previewMesh2.Faces.Length; j++)
			{
				uint num3 = binaryReader.ReadUInt32();
				if (num3 >= num)
				{
					throw new Exception("Mesh index out of range.");
				}
				previewMesh2.Faces[j] = (int)num3;
			}
			return previewMesh2;
		}
		fileStream.Position = 0L;
		string text = Encoding.ASCII.GetString(binaryReader.ReadBytes(13));
		if (!text.StartsWith("version "))
		{
			throw new Exception("Not a mesh asset.");
		}
		string text2 = text.Substring(8).Trim();
		if (!int.TryParse(text2.Split('.')[0], out var result) || result < 2 || result > 5)
		{
			throw new Exception("This mesh format needs a fallback preview.");
		}
		long position2 = fileStream.Position;
		int num4 = binaryReader.ReadUInt16();
		int num5 = 40;
		int num6 = 0;
		int num7 = 0;
		int num8;
		int num9;
		if (result >= 4)
		{
			binaryReader.ReadUInt16();
			num8 = (int)binaryReader.ReadUInt32();
			num9 = (int)binaryReader.ReadUInt32();
			num6 = binaryReader.ReadUInt16();
			num7 = binaryReader.ReadUInt16();
			binaryReader.ReadUInt32();
			binaryReader.ReadUInt16();
			binaryReader.ReadUInt16();
			if (result >= 5)
			{
				binaryReader.ReadUInt32();
				binaryReader.ReadUInt32();
			}
		}
		else
		{
			num5 = binaryReader.ReadByte();
			int num10 = binaryReader.ReadByte();
			if (num10 != 12)
			{
				throw new Exception("Unsupported face layout.");
			}
			if (result >= 3)
			{
				binaryReader.ReadUInt16();
				num6 = binaryReader.ReadUInt16();
			}
			num8 = (int)binaryReader.ReadUInt32();
			num9 = (int)binaryReader.ReadUInt32();
		}
		if (num8 < 1 || num8 > 250000 || num9 < 1 || num9 > 500000 || num5 < 36 || num5 > 64 || num4 < 12 || num4 > 256)
		{
			throw new Exception("Mesh is outside preview bounds.");
		}
		fileStream.Position = position2 + num4;
		long num11 = (long)num8 * (long)num5 + ((num7 > 0) ? ((long)num8 * 8L) : 0) + (long)num9 * 12L + num6 * 4;
		if (num11 > fileStream.Length - fileStream.Position)
		{
			throw new Exception("Truncated mesh.");
		}
		PreviewMesh previewMesh3 = new PreviewMesh();
		previewMesh3.Positions = new Point3D[num8];
		previewMesh3.Normals = new Vector3D[num8];
		previewMesh3.Uv = new Point[num8];
		PreviewMesh previewMesh4 = previewMesh3;
		for (int k = 0; k < num8; k++)
		{
			long position3 = fileStream.Position;
			ref Point3D reference4 = ref previewMesh4.Positions[k];
			reference4 = new Point3D(RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader));
			ref Vector3D reference5 = ref previewMesh4.Normals[k];
			reference5 = new Vector3D(RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader));
			ref Point reference6 = ref previewMesh4.Uv[k];
			reference6 = new Point(RecoveredMethod743(binaryReader), RecoveredMethod743(binaryReader));
			fileStream.Position = position3 + num5;
		}
		if (num7 > 0)
		{
			fileStream.Position += (long)num8 * 8L;
		}
		int[] array = new int[num9 * 3];
		for (int l = 0; l < array.Length; l++)
		{
			uint num12 = binaryReader.ReadUInt32();
			if (num12 >= num8)
			{
				throw new Exception("Mesh index out of range.");
			}
			array[l] = (int)num12;
		}
		int num13 = 0;
		int num14 = num9;
		if (num6 >= 2)
		{
			uint num15 = binaryReader.ReadUInt32();
			uint num16 = binaryReader.ReadUInt32();
			if (num15 < num16 && num16 <= (uint)num9)
			{
				num13 = (int)num15;
				num14 = (int)num16;
			}
		}
		previewMesh4.Faces = array.Skip(num13 * 3).Take((num14 - num13) * 3).ToArray();
		return previewMesh4;
	}

	public static PreviewMesh Cube()
	{
		Point3D[] positions = new Point3D[8]
		{
			new Point3D(-0.5, -0.5, -0.5),
			new Point3D(0.5, -0.5, -0.5),
			new Point3D(0.5, 0.5, -0.5),
			new Point3D(-0.5, 0.5, -0.5),
			new Point3D(-0.5, -0.5, 0.5),
			new Point3D(0.5, -0.5, 0.5),
			new Point3D(0.5, 0.5, 0.5),
			new Point3D(-0.5, 0.5, 0.5)
		};
		PreviewMesh previewMesh = new PreviewMesh();
		previewMesh.Positions = positions;
		previewMesh.Normals = new Vector3D[0];
		previewMesh.Uv = new Point[8]
		{
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0),
			new Point(0.0, 1.0),
			new Point(1.0, 1.0),
			new Point(1.0, 0.0),
			new Point(0.0, 0.0)
		};
		previewMesh.Faces = new int[36]
		{
			0, 2, 1, 0, 3, 2, 4, 5, 6, 4,
			6, 7, 0, 1, 5, 0, 5, 4, 3, 7,
			6, 3, 6, 2, 1, 2, 6, 1, 6, 5,
			0, 4, 7, 0, 7, 3
		};
		return previewMesh;
	}
}
