using UnityEngine;

public static class TextureGenerator {		

	// Height Map Colors
	private static Color DeepColor = new Color(0, 0, 0.5f, 1);
	private static Color ShallowColor = new Color(25/255f, 25/255f, 150/255f, 1);
	private static Color SandColor = new Color(240 / 255f, 240 / 255f, 64 / 255f, 1);
	private static Color GrassColor = new Color(50 / 255f, 220 / 255f, 20 / 255f, 1);
	private static Color ForestColor = new Color(16 / 255f, 160 / 255f, 0, 1);
	private static Color RockColor = new Color(0.5f, 0.5f, 0.5f, 1);            
	private static Color SnowColor = new Color(1, 1, 1, 1);

	public static Texture2D GetTexture(int width, int height, Tile[,] tiles)
	{
		var texture = new Texture2D(width, height);
		var pixels = new Color[width * height];

		for (var x = 0; x < width; x++)
		{
			for (var y = 0; y < height; y++)
			{
				switch (tiles[x,y].HeightType)
				{
				case HeightType.DeepWater:
					pixels[x + y * width] = DeepColor;
					break;
				case HeightType.ShallowWater:
					pixels[x + y * width] = ShallowColor;
					break;
				case HeightType.Sand:
					pixels[x + y * width] = SandColor;
					break;
				case HeightType.Grass:
					pixels[x + y * width] = GrassColor;
					break;
				case HeightType.Forest:
					pixels[x + y * width] = ForestColor;
					break;
				case HeightType.Rock:
					pixels[x + y * width] = RockColor;
					break;
				case HeightType.Snow:
					pixels[x + y * width] = SnowColor;
					break;
				}
			}
		}
		
		texture.SetPixels(pixels);
		texture.wrapMode = TextureWrapMode.Clamp;
		texture.Apply();
		return texture;
	}
	
}
