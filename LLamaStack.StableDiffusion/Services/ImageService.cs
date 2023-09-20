﻿using Microsoft.ML.OnnxRuntime.Tensors;
using LLamaStack.StableDiffusion.Common;

namespace LLamaStack.StableDiffusion.Services
{
    public class ImageService : IImageService
    {
        public Image<Rgba32> TensorToImage(Tensor<float> imageTensor, int width = 512, int height = 512)
        {
            var result = new Image<Rgba32>(width, height);
            for (var y = 0; y < height; y++)
            {
                for (var x = 0; x < width; x++)
                {
                    result[x, y] = new Rgba32(
                        CalculateByte(imageTensor, 0, y, x),
                        CalculateByte(imageTensor, 1, y, x),
                        CalculateByte(imageTensor, 2, y, x)
                    );
                }
            }
            return result;
        }

        private static byte CalculateByte(Tensor<float> imageTensor, int index, int y, int x)
        {
            return (byte)Math.Round(Math.Clamp(imageTensor[0, index, y, x] / 2 + 0.5, 0, 1) * 255);
        }
    }
}
