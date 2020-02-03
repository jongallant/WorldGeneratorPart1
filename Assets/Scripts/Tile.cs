using UnityEngine;
using System;
using System.Collections.Generic;

public enum HeightType
{
	DeepWater = 1,
	ShallowWater = 2,
	Shore = 3,
	Sand = 4,
	Grass = 5,
	Forest = 6,
	Rock = 7,
	Snow = 8
}

public class Tile
{
	public HeightType HeightType;
	public float HeightValue { get; set; }
	public int X, Y;
		
	public Tile()
	{
	}
}
