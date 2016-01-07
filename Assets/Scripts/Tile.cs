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











































//public enum TileType
//{
//    Blank,
//    Dirt,
//}


//public class Tile {

//    public int ChunkX;
//    public int ChunkY;
//    public Chunk Chunk;

//    public GameObject GO;

//    public bool Collidable;

//    public Tile Top, Bottom, Left, Right;
//    public TileType Type = TileType.Blank;
//    public string ByteCode;

//    bool Discovered;

//    public void Initialize()
//    {
//        GO = GameObject.Instantiate(Resources.Load("Tile")) as GameObject;
//        GO.transform.position = new Vector2(int.MinValue, int.MinValue);
//    }

//    public void Initialize(Chunk chunk, int chunkx, int chunky, bool collidable)
//    {
//        Chunk = chunk;
//        ChunkX = chunkx;
//        ChunkY = chunky;
//        Collidable = collidable;

//        if (collidable)
//        {
//            Type = TileType.Dirt;
//            GO.GetComponent<SpriteRenderer>().color = Color.white;
//        }
//        else
//        {
//            Type = TileType.Blank;
//            GO.GetComponent<SpriteRenderer>().color = Color.black;
//        }
//    }

//    public void Refresh()
//    {
//        //4bit mask
//        int count = 0;

//        if (Collidable)
//        {
//            //update bytecode
//            if (Top != null && Top.Collidable && Top.Type == this.Type) count += 1;
//            if (Right != null && Right.Collidable && Right.Type == this.Type) count += 2;
//            if (Bottom != null && Bottom.Collidable && Bottom.Type == this.Type) count += 4;
//            if (Left != null && Left.Collidable && Left.Type == this.Type) count += 8;

//            //check if surface block
//            //if (Top != null && Top.Blank) SurfaceBlock = true;
//            //else if (Left != null && Left.Blank) SurfaceBlock = true;
//            //else if (Bottom != null && Bottom.Blank) SurfaceBlock = true;
//            //else if (Right != null && Right.Blank) SurfaceBlock = true;
//        }
//        //else
//        //{
//        //    if (Top != null && !Top.Collidable && Top.Type == this.Type || Top != null && !Top.Blank) count += 1;
//        //    if (Right != null && !Right.Collidable && Right.Type == this.Type || Right != null && !Right.Blank) count += 2;
//        //    if (Bottom != null && !Bottom.Collidable && Bottom.Type == this.Type || Bottom != null && !Bottom.Blank) count += 4;
//        //    if (Left != null && !Left.Collidable && Left.Type == this.Type || Left != null && !Left.Blank) count += 8;
//        //}


//        bool update = ByteCode == count.ToString() ? false : true;
//        ByteCode = count.ToString();

//        //RefreshCollisions();



//        //if (update)
//        //{
//        //    RefreshCollisions();
//        //}

//    }


//    int LandCollisions;

//    public void RefreshCollisions()
//    {
//        //Get collision count of land tile
//        LandCollisions = 0;
//        //MinedLandCollisions = 0;

//        Tile top = Top;
//        for (int i = 0; i < 3; i++)
//        {
//            if (top == null) break;
//            if (top.Collidable) LandCollisions++;
//            //else if (!top.Blank) MinedLandCollisions++;
//            top = top.Top;
//        }
//        Tile left = Left;
//        for (int i = 0; i < 3; i++)
//        {
//            if (left == null) break;
//            if (left.Collidable) LandCollisions++;
//            //else if (!left.Blank) MinedLandCollisions++;
//            left = left.Top;
//        }
//        Tile right = Right;
//        for (int i = 0; i < 3; i++)
//        {
//            if (right == null) break;
//            if (right.Collidable) LandCollisions++;
//            //else if (!right.Blank) MinedLandCollisions++;
//            right = right.Top;
//        }
//        //SetLighting();

//        this.GO.transform.Find("Text").GetComponent<TextMesh>().text = LandCollisions.ToString();

//    }



//    public int GetEdgeDistance()
//    {
//        if (Blank && Discovered) return 0;
//        if (!Collidable && Discovered) return 0;

//        if (Top != null && !Top.Collidable && Top.Discovered) return 1;
//        if (Left != null && !Left.Collidable && Left.Discovered) return 1;
//        if (Right != null && !Right.Collidable && Right.Discovered) return 1;
//        if (Bottom != null && !Bottom.Collidable && Bottom.Discovered) return 1;

//        if (Top != null && Top.Right != null && !Top.Right.Collidable && Top.Right.Discovered) return 2;
//        if (Top != null && Top.Left != null && !Top.Left.Collidable && Top.Left.Discovered) return 2;
//        if (Bottom != null && Bottom.Right != null && !Bottom.Right.Collidable && Bottom.Right.Discovered) return 2;
//        if (Bottom != null && Bottom.Left != null && !Bottom.Left.Collidable && Bottom.Left.Discovered) return 2;

//        Land t = null, b = null, l = null, r = null;
//        if (Top != null && Top.Top != null)
//        {
//            t = Top.Top;
//            if (!t.Collidable && t.Discovered) return 3;
//        }
//        if (Bottom != null && Bottom.Bottom != null)
//        {
//            b = Bottom.Bottom;
//            if (!b.Collidable && b.Discovered) return 3;
//        }
//        if (Right != null && Right.Right != null)
//        {
//            r = Right.Right;
//            if (!r.Collidable && r.Discovered) return 3;
//        }
//        if (Left != null && Left.Left != null)
//        {
//            l = Left.Left;
//            if (!l.Collidable && l.Discovered) return 3;
//        }


//        if (t != null && t.Left != null && !t.Left.Collidable && t.Left.Discovered) return 4;
//        if (t != null && t.Right != null && !t.Right.Collidable && t.Right.Discovered) return 4;
//        if (b != null && b.Left != null && !b.Left.Collidable && b.Left.Discovered) return 4;
//        if (b != null && b.Right != null && !b.Right.Collidable && b.Right.Discovered) return 4;
//        if (l != null && l.Top != null && !l.Top.Collidable && l.Top.Discovered) return 4;
//        if (l != null && l.Bottom != null && !l.Bottom.Collidable && l.Bottom.Discovered) return 4;
//        if (r != null && r.Top != null && !r.Top.Collidable && r.Top.Discovered) return 4;
//        if (r != null && r.Bottom != null && !r.Bottom.Collidable && r.Bottom.Discovered) return 4;



//        Tile tl = null, tr = null, bl = null, br = null;
//        if (t != null && t.Left != null && t.Left.Left != null)
//        {
//            tl = t.Left.Left;
//            if (!tl.Collidable && tl.Discovered) return 5;
//        }
//        if (t != null && t.Right != null && t.Right.Right != null)
//        {
//            tr = t.Right.Right;
//            if (!tr.Collidable && tr.Discovered) return 5;
//        }
//        if (b != null && b.Left != null && b.Left.Left != null)
//        {
//            bl = b.Left.Left;
//            if (!bl.Collidable && bl.Discovered) return 5;
//        }
//        if (b != null && b.Right != null && b.Right.Right != null)
//        {
//            br = b.Right.Right;
//            if (!br.Collidable && br.Discovered) return 5;
//        }
//        if (t != null && t.Top != null)
//        {
//            t = t.Top;
//            if (!t.Collidable && t.Discovered) return 5;
//        }
//        if (b != null && b.Bottom != null)
//        {
//            b = b.Bottom;
//            if (!b.Collidable && b.Discovered) return 5;
//        }
//        if (r != null && r.Right != null)
//        {
//            r = r.Right;
//            if (!r.Collidable && r.Discovered) return 5;
//        }
//        if (l != null && l.Left != null)
//        {
//            l = l.Left;
//            if (!l.Collidable && l.Discovered) return 5;
//        }


//        if (t != null && t.Left != null && !t.Left.Collidable && t.Left.Discovered) return 6;
//        if (t != null && t.Right != null && !t.Right.Collidable && t.Right.Discovered) return 6;
//        if (b != null && b.Left != null && !b.Left.Collidable && b.Left.Discovered) return 6;
//        if (b != null && b.Right != null && !b.Right.Collidable && b.Right.Discovered) return 6;
//        if (l != null && l.Top != null && !l.Top.Collidable && l.Top.Discovered) return 6;
//        if (l != null && l.Bottom != null && !l.Bottom.Collidable && l.Bottom.Discovered) return 6;
//        if (r != null && r.Top != null && !r.Top.Collidable && r.Top.Discovered) return 6;
//        if (r != null && r.Bottom != null && !r.Bottom.Collidable && r.Bottom.Discovered) return 6;


//        if (t != null && t.Top != null)
//        {
//            t = t.Top;
//            if (!t.Collidable && t.Discovered) return 7;
//        }
//        if (b != null && b.Bottom != null)
//        {
//            b = b.Bottom;
//            if (!b.Collidable && b.Discovered) return 7;
//        }
//        if (r != null && r.Right != null)
//        {
//            r = r.Right;
//            if (!r.Collidable && r.Discovered) return 7;
//        }
//        if (l != null && l.Left != null)
//        {
//            l = l.Left;
//            if (!l.Collidable && l.Discovered) return 7;
//        }
//        if (tl != null)
//        {
//            if (tl.Top != null && !tl.Top.Collidable && tl.Top.Discovered) return 7;
//            if (tl.Left != null && !tl.Left.Collidable && tl.Left.Discovered) return 7;
//        }
//        if (tr != null)
//        {
//            if (tr.Top != null && !tr.Top.Collidable && tr.Top.Discovered) return 7;
//            if (tr.Right != null && !tr.Right.Collidable && tr.Right.Discovered) return 7;
//        }
//        if (bl != null)
//        {
//            if (bl.Bottom != null && !bl.Bottom.Collidable && bl.Bottom.Discovered) return 7;
//            if (bl.Left != null && !bl.Left.Collidable && bl.Left.Discovered) return 7;
//        }
//        if (br != null)
//        {
//            if (br.Bottom != null && !br.Bottom.Collidable && br.Bottom.Discovered) return 7;
//            if (br.Right != null && !br.Right.Collidable && br.Right.Discovered) return 7;
//        }


//        if (t != null && t.Left != null && !t.Left.Collidable && t.Left.Discovered) return 8;
//        if (t != null && t.Right != null && !t.Right.Collidable && t.Right.Discovered) return 8;
//        if (b != null && b.Left != null && !b.Left.Collidable && b.Left.Discovered) return 8;
//        if (b != null && b.Right != null && !b.Right.Collidable && b.Right.Discovered) return 8;
//        if (l != null && l.Top != null && !l.Top.Collidable && l.Top.Discovered) return 8;
//        if (l != null && l.Bottom != null && !l.Bottom.Collidable && l.Bottom.Discovered) return 8;
//        if (r != null && r.Top != null && !r.Top.Collidable && r.Top.Discovered) return 8;
//        if (r != null && r.Bottom != null && !r.Bottom.Collidable && r.Bottom.Discovered) return 8;
//        if (tl != null && tl.Top != null && tl.Top.Left != null)
//        {
//            tl = tl.Top.Left;
//            if (!tl.Collidable && tl.Discovered) return 8;
//        }
//        if (tr != null && tr.Top != null && tr.Top.Right != null)
//        {
//            tr = tr.Top.Right;
//            if (!tr.Collidable && tr.Discovered) return 8;
//        }
//        if (bl != null && bl.Bottom != null && bl.Bottom.Left != null)
//        {
//            bl = bl.Bottom.Left;
//            if (!bl.Collidable && bl.Discovered) return 8;
//        }
//        if (br != null && br.Bottom != null && br.Bottom.Right != null)
//        {
//            br = br.Bottom.Right;
//            if (!br.Collidable && br.Discovered) return 8;
//        }


//        if (t != null && t.Left != null && t.Left.Left != null && !t.Left.Left.Collidable && t.Left.Left.Discovered) return 9;
//        if (t != null && t.Right != null && t.Right.Right != null && !t.Right.Right.Collidable && t.Right.Right.Discovered) return 9;
//        if (b != null && b.Left != null && b.Left.Left != null && !b.Left.Left.Collidable && b.Left.Left.Discovered) return 9;
//        if (b != null && b.Right != null && b.Right.Right != null && !b.Right.Right.Collidable && b.Right.Right.Discovered) return 9;
//        if (l != null && l.Top != null && l.Top.Top != null && !l.Top.Top.Collidable && l.Top.Top.Discovered) return 9;
//        if (l != null && l.Bottom != null && l.Bottom.Bottom != null && !l.Bottom.Bottom.Collidable && l.Bottom.Bottom.Discovered) return 9;
//        if (r != null && r.Top != null && r.Top.Top != null && !r.Top.Top.Collidable && r.Top.Top.Discovered) return 9;
//        if (r != null && r.Bottom != null && r.Bottom.Bottom != null && !r.Bottom.Bottom.Collidable && r.Bottom.Bottom.Discovered) return 9;
//        if (t != null && t.Top != null)
//        {
//            t = t.Top;
//            if (!t.Collidable && t.Discovered) return 9;
//        }
//        if (b != null && b.Bottom != null)
//        {
//            b = b.Bottom;
//            if (!b.Collidable && b.Discovered) return 9;
//        }
//        if (l != null && l.Left != null)
//        {
//            l = l.Left;
//            if (!l.Collidable && l.Discovered) return 9;
//        }
//        if (r != null && r.Right != null)
//        {
//            r = r.Right;
//            if (!r.Collidable && r.Discovered) return 9;
//        }


//        if (t != null && t.Right != null && !t.Right.Collidable && t.Right.Discovered) return 10;
//        if (t != null && t.Left != null && !t.Left.Collidable && t.Left.Discovered) return 10;
//        if (b != null && b.Right != null && !b.Right.Collidable && b.Right.Discovered) return 10;
//        if (b != null && b.Left != null && !b.Left.Collidable && b.Left.Discovered) return 10;
//        if (l != null && l.Top != null && !l.Top.Collidable && l.Top.Discovered) return 10;
//        if (l != null && l.Bottom != null && !l.Bottom.Collidable && l.Bottom.Discovered) return 10;
//        if (r != null && r.Top != null && !r.Top.Collidable && r.Top.Discovered) return 10;
//        if (r != null && r.Bottom != null && !r.Bottom.Collidable && r.Bottom.Discovered) return 10;
//        if (tl != null && tl.Top != null && !tl.Top.Collidable && tl.Top.Discovered) return 10;
//        if (tl != null && tl.Left != null && !tl.Left.Collidable && tl.Left.Discovered) return 10;
//        if (tr != null && tr.Top != null && !tr.Top.Collidable && tr.Top.Discovered) return 10;
//        if (tr != null && tr.Right != null && !tr.Right.Collidable && tr.Right.Discovered) return 10;
//        if (bl != null && bl.Bottom != null && !bl.Bottom.Collidable && bl.Bottom.Discovered) return 10;
//        if (bl != null && bl.Left != null && !bl.Left.Collidable && bl.Left.Discovered) return 10;
//        if (br != null && br.Bottom != null && !br.Bottom.Collidable && br.Bottom.Discovered) return 10;
//        if (br != null && br.Right != null && !br.Right.Collidable && br.Right.Discovered) return 10;


//        if (t != null && t.Left != null && t.Left.Left != null && !t.Left.Left.Collidable && t.Left.Left.Discovered) return 11;
//        if (t != null && t.Right != null && t.Right.Right != null && !t.Right.Right.Collidable && t.Right.Right.Discovered) return 11;
//        if (t != null && t.Top != null)
//        {
//            t = t.Top;
//            if (!t.Collidable && t.Discovered) return 11;
//        }
//        if (b != null && b.Left != null && b.Left.Left != null && !b.Left.Left.Collidable && b.Left.Left.Discovered) return 11;
//        if (b != null && b.Right != null && b.Right.Right != null && !b.Right.Right.Collidable && b.Right.Right.Discovered) return 11;
//        if (b != null && b.Bottom != null)
//        {
//            b = b.Bottom;
//            if (!b.Collidable && b.Discovered) return 11;
//        }
//        if (l != null && l.Top != null && l.Top.Top != null && !l.Top.Top.Collidable && l.Top.Top.Discovered) return 11;
//        if (l != null && l.Bottom != null && l.Bottom.Bottom != null && !l.Bottom.Bottom.Collidable && l.Bottom.Bottom.Discovered) return 11;
//        if (l != null && l.Left != null)
//        {
//            l = l.Left;
//            if (!l.Collidable && l.Discovered) return 11;
//        }
//        if (r != null && r.Top != null && r.Top.Top != null && !r.Top.Top.Collidable && r.Top.Top.Discovered) return 11;
//        if (r != null && r.Bottom != null && r.Bottom.Bottom != null && !r.Bottom.Bottom.Collidable && r.Bottom.Bottom.Discovered) return 11;
//        if (r != null && r.Left != null)
//        {
//            r = r.Right;
//            if (!r.Collidable && r.Discovered) return 11;
//        }
//        if (tl != null && tl.Top != null && tl.Top.Left != null)
//        {
//            tl = tl.Top.Left;
//            if (!tl.Collidable && tl.Discovered) return 11;
//        }
//        if (tr != null && tr.Top != null && tr.Top.Right != null)
//        {
//            tr = tr.Top.Right;
//            if (!tr.Collidable && tr.Discovered) return 11;
//        }
//        if (bl != null && bl.Bottom != null && bl.Bottom.Left != null)
//        {
//            bl = bl.Bottom.Left;
//            if (!bl.Collidable && bl.Discovered) return 11;
//        }
//        if (br != null && br.Bottom != null && br.Bottom.Right != null)
//        {
//            br = br.Bottom.Right;
//            if (!br.Collidable && br.Discovered) return 11;
//        }



//        if (t != null && t.Left != null && !t.Left.Collidable && t.Left.Discovered) return 12;
//        if (t != null && t.Right != null && !t.Right.Collidable && t.Right.Discovered) return 12;
//        if (b != null && b.Left != null && !b.Left.Collidable && b.Left.Discovered) return 12;
//        if (b != null && b.Right != null && !b.Right.Collidable && b.Right.Discovered) return 12;
//        if (l != null && l.Top != null && !l.Top.Collidable && l.Top.Discovered) return 12;
//        if (l != null && l.Bottom != null && !l.Bottom.Collidable && l.Bottom.Discovered) return 12;
//        if (r != null && r.Top != null && !r.Top.Collidable && r.Top.Discovered) return 12;
//        if (r != null && r.Bottom != null && !r.Bottom.Collidable && r.Bottom.Discovered) return 12;
//        if (tl != null && tl.Right != null && tl.Right.Top != null && !tl.Right.Top.Collidable && tl.Right.Top.Discovered) return 12;
//        if (tl != null && tl.Bottom != null && tl.Bottom.Left != null && !tl.Bottom.Left.Collidable && tl.Bottom.Left.Discovered) return 12;
//        if (tr != null && tr.Left != null && tr.Left.Top != null && !tr.Left.Top.Collidable && tr.Left.Top.Discovered) return 12;
//        if (tr != null && tr.Bottom != null && tr.Bottom.Right != null && !tr.Bottom.Right.Collidable && tr.Bottom.Right.Discovered) return 12;
//        if (bl != null && bl.Left != null && bl.Left.Top != null && !bl.Left.Top.Collidable && bl.Left.Top.Discovered) return 12;
//        if (bl != null && bl.Bottom != null && bl.Bottom.Right != null && !bl.Bottom.Right.Collidable && bl.Bottom.Right.Discovered) return 12;
//        if (br != null && br.Right != null && br.Right.Top != null && !br.Right.Top.Collidable && br.Right.Top.Discovered) return 12;
//        if (br != null && br.Bottom != null && br.Bottom.Left != null && !br.Bottom.Left.Collidable && br.Bottom.Left.Discovered) return 12;


//        if (t != null && t.Left != null && t.Left.Left != null && !t.Left.Left.Collidable && t.Left.Left.Discovered) return 13;
//        if (t != null && t.Right != null && t.Right.Right != null && !t.Right.Right.Collidable && t.Right.Right.Discovered) return 13;
//        if (t != null && t.Top != null && !t.Top.Collidable && t.Top.Discovered) return 13;
//        if (b != null && b.Left != null && b.Left.Left != null && !b.Left.Left.Collidable && b.Left.Left.Discovered) return 13;
//        if (b != null && b.Right != null && b.Right.Right != null && !b.Right.Right.Collidable && b.Right.Right.Discovered) return 13;
//        if (b != null && b.Bottom != null && !b.Bottom.Collidable && b.Bottom.Discovered) return 13;
//        if (l != null && l.Top != null && l.Top.Top != null && !l.Top.Top.Collidable && l.Top.Top.Discovered) return 13;
//        if (l != null && l.Bottom != null && l.Bottom.Bottom != null && !l.Bottom.Bottom.Collidable && l.Bottom.Bottom.Discovered) return 13;
//        if (l != null && l.Left != null && !l.Left.Collidable && l.Left.Discovered) return 13;
//        if (r != null && r.Top != null && r.Top.Top != null && !r.Top.Top.Collidable && r.Top.Top.Discovered) return 13;
//        if (r != null && r.Bottom != null && r.Bottom.Bottom != null && !r.Bottom.Bottom.Collidable && r.Bottom.Bottom.Discovered) return 13;
//        if (r != null && r.Right != null && !r.Right.Collidable && r.Right.Discovered) return 13;
//        if (tr != null && tr.Top != null && !tr.Top.Collidable && tr.Top.Discovered) return 13;
//        if (tr != null && tr.Right != null && !tr.Right.Collidable && tr.Right.Discovered) return 13;
//        if (br != null && br.Bottom != null && !br.Bottom.Collidable && br.Bottom.Discovered) return 13;
//        if (br != null && br.Right != null && !br.Right.Collidable && br.Right.Discovered) return 13;
//        if (tl != null && tl.Top != null && !tl.Top.Collidable && tl.Top.Discovered) return 13;
//        if (tl != null && tl.Left != null && !tl.Left.Collidable && tl.Left.Discovered) return 13;
//        if (bl != null && bl.Bottom != null && !bl.Bottom.Collidable && bl.Bottom.Discovered) return 13;
//        if (bl != null && bl.Left != null && !bl.Left.Collidable && bl.Left.Discovered) return 13;

//        return 14;
//    }
//}
