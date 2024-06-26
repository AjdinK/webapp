﻿using SkiaSharp;

public class ImageHelper
{
    public static byte[]? ResizeSlike(byte[] slikaBajtovi, int size, int quality)
    {
        using (var input = new MemoryStream(slikaBajtovi))
        {
            using (var inputStream = new SKManagedStream(input))
            {
                using (var original = SKBitmap.Decode(inputStream))
                {
                    int width,
                        height;
                    if (original.Width > original.Height)
                    {
                        width = size;
                        height = original.Height * size / original.Width;
                    }
                    else
                    {
                        width = original.Width * size / original.Height;
                        height = size;
                    }

                    using (
                        var resized = original.Resize(
                            new SKImageInfo(width, height),
                            SKBitmapResizeMethod.Lanczos3
                        )
                    )
                    {
                        if (resized == null)
                            return null;

                        using (var image = SKImage.FromBitmap(resized))
                        {
                            return image.Encode(SKEncodedImageFormat.Jpeg, quality).ToArray();
                        }
                    }
                }
            }
        }
    }
}
