using System;
using System.Collections.Generic;
using System.IO;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Media.Media3D;
using a;

namespace TwistApp;

public sealed class ItemPreviewRenderer
{
	private readonly AssetFiles assets;

	private readonly string folder;

	public ItemPreviewRenderer(string cache)
	{
		folder = cache;
		Directory.CreateDirectory(folder);
		assets = new AssetFiles(Path.Combine(folder, "raw"));
	}

	public BitmapSource Cached(ItemMetadata item)
	{
		if (item.IsFruit)
		{
			return RecoveredType220.RecoveredMethod632(item.Name);
		}
		string text = FileFor(item);
		if (!File.Exists(text))
		{
			throw new Exception("Waiting for worker preview");
		}
		return RecoveredMethod744(text);
	}

	public string FileFor(ItemMetadata item)
	{
		return Path.Combine(folder, item.IconKey + ".png");
	}

	private static BitmapSource RecoveredMethod744(string P_0)
	{
		using FileStream bitmapStream = File.OpenRead(P_0);
		BitmapFrame bitmapFrame = BitmapFrame.Create(bitmapStream, BitmapCreateOptions.None, BitmapCacheOption.OnLoad);
		bitmapFrame.Freeze();
		return bitmapFrame;
	}

	private static Rect3D RecoveredMethod745(IEnumerable<Point3D> P_0)
	{
		Rect3D empty = Rect3D.Empty;
		foreach (Point3D item in P_0)
		{
			empty.Union(item);
		}
		return empty;
	}

	private static Point3D RecoveredMethod746(Point3D P_0, VisualPart P_1)
	{
		float[] rotation = P_1.Rotation;
		float[] position = P_1.Position;
		return new Point3D((double)rotation[0] * P_0.X + (double)rotation[1] * P_0.Y + (double)rotation[2] * P_0.Z + (double)position[0], (double)rotation[3] * P_0.X + (double)rotation[4] * P_0.Y + (double)rotation[5] * P_0.Z + (double)position[1], (double)rotation[6] * P_0.X + (double)rotation[7] * P_0.Y + (double)rotation[8] * P_0.Z + (double)position[2]);
	}

	public BitmapSource Render(ItemMetadata item)
	{
		if (item.IsFruit)
		{
			return RecoveredType220.RecoveredMethod632(item.Name);
		}
		string text = FileFor(item);
		if (File.Exists(text))
		{
			try
			{
				return RecoveredMethod744(text);
			}
			catch
			{
			}
		}
		if (item.Image != "")
		{
			try
			{
				BitmapSource bitmapSource = RecoveredMethod744(assets.RecoveredMethod742(item.Image));
				RecoveredMethod349(bitmapSource, text);
				return bitmapSource;
			}
			catch
			{
			}
		}
		bool flag = false;
		Model3DGroup model3DGroup = new Model3DGroup();
		foreach (VisualPart part in item.Parts)
		{
			if (part.Position == null || part.Rotation == null || part.Size == null || part.Position.Length != 3 || part.Rotation.Length != 9 || part.Size.Length != 3)
			{
				continue;
			}
			try
			{
				PreviewMesh previewMesh = ((part.Mesh == "") ? PreviewMesh.Cube() : PreviewMesh.Load(assets.RecoveredMethod742(part.Mesh)));
				Rect3D rect3D = RecoveredMethod745(previewMesh.Positions);
				double num = (double)part.Size[0] / Math.Max(1E-05, rect3D.SizeX);
				double num2 = (double)part.Size[1] / Math.Max(1E-05, rect3D.SizeY);
				double num3 = (double)part.Size[2] / Math.Max(1E-05, rect3D.SizeZ);
				Point3D point3D = new Point3D(rect3D.X + rect3D.SizeX / 2.0, rect3D.Y + rect3D.SizeY / 2.0, rect3D.Z + rect3D.SizeZ / 2.0);
				MeshGeometry3D meshGeometry3D = new MeshGeometry3D();
				Point3D[] positions = previewMesh.Positions;
				for (int i = 0; i < positions.Length; i++)
				{
					Point3D point3D2 = positions[i];
					meshGeometry3D.Positions.Add(RecoveredMethod746(new Point3D((point3D2.X - point3D.X) * num, (point3D2.Y - point3D.Y) * num2, (point3D2.Z - point3D.Z) * num3), part));
				}
				Point[] recoveredField = previewMesh.Uv;
				foreach (Point value in recoveredField)
				{
					meshGeometry3D.TextureCoordinates.Add(value);
				}
				int[] faces = previewMesh.Faces;
				foreach (int value2 in faces)
				{
					meshGeometry3D.TriangleIndices.Add(value2);
				}
				Brush brush = new SolidColorBrush(Color.FromRgb(181, 186, 196));
				if (part.Texture != "")
				{
					try
					{
						ImageBrush imageBrush = new ImageBrush(RecoveredMethod744(assets.RecoveredMethod742(part.Texture)));
						imageBrush.ViewportUnits = BrushMappingMode.Absolute;
						imageBrush.Viewport = new Rect(0.0, 0.0, 1.0, 1.0);
						imageBrush.TileMode = TileMode.Tile;
						brush = imageBrush;
					}
					catch
					{
					}
				}
				DiffuseMaterial diffuseMaterial = new DiffuseMaterial(brush);
				GeometryModel3D geometryModel3D = new GeometryModel3D(meshGeometry3D, diffuseMaterial);
				geometryModel3D.BackMaterial = diffuseMaterial;
				GeometryModel3D value3 = geometryModel3D;
				model3DGroup.Children.Add(value3);
			}
			catch
			{
				flag = true;
			}
		}
		if (model3DGroup.Children.Count == 0)
		{
			throw new Exception("No renderable inventory asset is available.");
		}
		Rect3D bounds = model3DGroup.Bounds;
		Point3D point3D3 = new Point3D(bounds.X + bounds.SizeX / 2.0, bounds.Y + bounds.SizeY / 2.0, bounds.Z + bounds.SizeZ / 2.0);
		model3DGroup.Transform = new TranslateTransform3D(0.0 - point3D3.X, 0.0 - point3D3.Y, 0.0 - point3D3.Z);
		double num4 = Math.Sqrt(bounds.SizeX * bounds.SizeX + bounds.SizeY * bounds.SizeY + bounds.SizeZ * bounds.SizeZ) / 2.0;
		Vector3D vector3D = new Vector3D(1.2, 0.45, 1.7);
		vector3D.Normalize();
		double num5 = Math.Max(0.1, num4 * 3.9);
		PerspectiveCamera perspectiveCamera = new PerspectiveCamera(new Point3D(vector3D.X * num5, vector3D.Y * num5, vector3D.Z * num5), -vector3D, new Vector3D(0.0, 1.0, 0.0), 40.0);
		perspectiveCamera.NearPlaneDistance = 0.001;
		perspectiveCamera.FarPlaneDistance = 100000.0;
		PerspectiveCamera camera = perspectiveCamera;
		Model3DGroup model3DGroup2 = new Model3DGroup();
		model3DGroup2.Children.Add(new AmbientLight(Color.FromRgb(192, 192, 192)));
		model3DGroup2.Children.Add(new DirectionalLight(Color.FromRgb(200, 200, 200), new Vector3D(-1.0, -1.0, -2.0)));
		model3DGroup2.Children.Add(model3DGroup);
		Viewport3D viewport3D = new Viewport3D();
		viewport3D.Width = 256.0;
		viewport3D.Height = 192.0;
		viewport3D.Camera = camera;
		Viewport3D viewport3D2 = viewport3D;
		viewport3D2.Children.Add(new ModelVisual3D
		{
			Content = model3DGroup2
		});
		viewport3D2.Measure(new Size(256.0, 192.0));
		viewport3D2.Arrange(new Rect(0.0, 0.0, 256.0, 192.0));
		viewport3D2.UpdateLayout();
		RenderTargetBitmap renderTargetBitmap = new RenderTargetBitmap(256, 192, 96.0, 96.0, PixelFormats.Pbgra32);
		renderTargetBitmap.Render(viewport3D2);
		renderTargetBitmap.Freeze();
		if (!flag)
		{
			RecoveredMethod349(renderTargetBitmap, text);
		}
		return renderTargetBitmap;
	}

	private static void RecoveredMethod349(BitmapSource P_0, string P_1)
	{
		PngBitmapEncoder pngBitmapEncoder = new PngBitmapEncoder();
		pngBitmapEncoder.Frames.Add(BitmapFrame.Create(P_0));
		using FileStream stream = File.Create(P_1);
		pngBitmapEncoder.Save(stream);
	}
}
