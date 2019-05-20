using System;
using System.Collections.Generic;
using System.Text;
using Arithmetica;
using System.Linq;
using System.Threading.Tasks;

namespace Examples
{
    public class ConvolutionTest
    {
        public static void Run()
        {
            Image img = Image.FromFile("img/cat01.jpg", height: 200, width: 200, grayScale: true);
            //img.GetRegion(0, 0, 50, 50);
            Matrix smallBlur = Matrix.Ones(7, 7) * (1.0f / (7 * 7));
            img.Show();
            Image smallBlurImage = Convolve(img, smallBlur);
            smallBlurImage.Show();
        }

        private static Image Convolve(Image image, Matrix filter)
        {
            Image result;

            //Get the image height and width
            int iH = image.Height;
            int iW = image.Width;

            //Get the kernel height and width
            int kH = (int)filter.Rows;
            int kW = (int)filter.Cols;

            //Pad the matrix
            int pad = (kW - 1) / 2;

            //Pad the image which will create a border of size of the pad length
            image = image.Pad(pad, pad, pad, pad);

            //Create a empty image by allocating memory for the resulting image
            //taking care to the "pad" the borders of the image so that the spatial size are not reduced
            result = new Image(1, iH, iW);
            result.Fill(0);

            //Loop through the image to slide the kernel 
            //across each (x, y) coordinate from left to right and top to bottom
            Parallel.For(0, image.Height - kH, (y) =>
            {
                Parallel.For(0, image.Width - kW, (x) =>
                {
                    //Get the region of interest
                    var roi = image.GetRegion(x, y, kH, kW);

                    ////Convert it to a matrix, since we have one image we can take the 0 index.
                    ////Since its gray scale so we will get one matrix
                    var roiMatrix = roi.ToMatrix(0).First();

                    //// perform the actual convolution by taking the
                    //// element-wise multiplicate between the ROI and
                    //// the kernel, then summing the matrix
                    var k = Matrix.Sum(roiMatrix * filter);

                    // store the convolved value in the output (x,y)- coordinate of the output image
                    result.SetPixel(x, y, k);
                });
            });

            return result;
        }
    }
}
