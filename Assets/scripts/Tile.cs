using System;

public class Tile
{

    private int GScore;
    private int HScore;

    private int x;
    private int y;

    private Tile parent;

    public Tile(int GScore, int HScore, int x, int y, Tile parent)
    {
        this.x = x;
        this.y = y;
        this.GScore = GScore;
        this.HScore = HScore;
        this.parent = parent;
    }

    public Tile getParent()
    {
        return parent;
    }

    public int getFScore()
    {
        return GScore + HScore;
    }

    public int getGScore()
    {
        return GScore;
    }

    public void setGScore(int GScore)
    {
        this.GScore = GScore;
    }

    public int getX()
    {
        return x;
    }

    public int getY()
    {
        return y;
    }
}
