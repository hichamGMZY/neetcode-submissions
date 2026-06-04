
public class Solution {
    public int[][] FloodFill(int[][] image, int sr, int sc, int color)
    {
        var originalColor = image[sr][sc];
        if (originalColor == color)
            return image;
        HashSet<(int row, int column)> dejaVus = new();
        FloodFill(image, sr, sc, color, originalColor, dejaVus);
        return image;
    }

    private void FloodFill(int[][] image, int sr, int sc, int color, int originalColor, HashSet<(int row, int column)> dejaVus)
    {
        if (!CheckDimension(image, sr, sc))
            return;

        if (!dejaVus.Add((sr, sc)))
            return;

        var current = image[sr][sc];
        if (current != originalColor)
            return;

        image[sr][sc] = color;

        FloodFill(image, sr + 1, sc, color, originalColor, dejaVus);
        FloodFill(image, sr - 1 , sc, color, originalColor, dejaVus);
        FloodFill(image, sr , sc + 1, color, originalColor, dejaVus);
        FloodFill(image, sr , sc - 1, color, originalColor, dejaVus);
    }

    private bool CheckDimension(int[][] image, int sr, int sc)
    {
        return sr >= 0 && sr < image.Length && sc >= 0 && sc < image[0].Length;
    }
}