using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Drawing;

namespace Arithmetica
{
    /// <summary>
    /// Provides a collection of static convenience methods for creating, manipulating, combining, and converting generic images.
    /// </summary>
    public partial class Image
    {
        internal ArithArray variable;

        /// <summary>
        /// Gets the size of the image.
        /// </summary>
        /// <value>
        /// The size.
        /// </value>
        public int Size
        {
            get
            {
                return (int)variable.Shape[0];
            }
        }

        /// <summary>
        /// Gets the channel or color depth of the image.
        /// </summary>
        /// <value>
        /// The channel.
        /// </value>
        public int Channel
        {
            get
            {
                return (int)variable.Shape[1];
            }
        }

        /// <summary>
        /// Gets the width of the image.
        /// </summary>
        /// <value>
        /// The width.
        /// </value>
        public int Width
        {
            get
            {
                return (int)variable.Shape[2];
            }
        }

        /// <summary>
        /// Gets the height of the image.
        /// </summary>
        /// <value>
        /// The height.
        /// </value>
        public int Height
        {
            get
            {
                return (int)variable.Shape[3];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="size">The size of the image.</param>
        public Image(int channel, int height, int width, int size = 1)
        {
            variable = new ArithArray(size, channel, height, width);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="v">The arith array which is a generalised array.</param>
        private Image(ArithArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Ins the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static ArithArray In(Image x)
        {
            return x.variable;
        }

        /// <summary>
        /// Outs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static Image Out(ArithArray x)
        {
            return new Image(x);
        }

        /// <summary>
        /// Gets the generalised arith array which is a multi dimensional array
        /// </summary>
        /// <value>
        /// The arith array.
        /// </value>
        public ArithArray ArithArray
        {
            get
            {
                return variable;
            }
        }

        /// <summary>
        /// Gets the data in the .NET Array format.
        /// </summary>
        /// <value>
        /// The data.
        /// </value>
        public Array Data
        {
            get
            {
                return variable.ToArray();
            }
        }

        /// <summary>
        /// Loads the data to the image.
        /// </summary>
        /// <param name="data">The data.</param>
        public void LoadData(Array data)
        {
            variable.LoadFrom(data);
        }

        /// <summary>
        /// Create image instance from the file
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="grayScale">if set to <c>true</c> [gray scale].</param>
        /// <returns></returns>
        public static Image FromFile(string filePath, int? height = null, int? width = null, bool grayScale = false)
        {
            Bitmap bmp = new Bitmap(filePath);
            if (height.HasValue && width.HasValue)
                bmp = bmp.Resize(width.Value, height.Value, false);

            float[] data = null;
            int W = bmp.Width;
            int H = bmp.Height;
            int C = 3;
            if (grayScale)
            {
                data = bmp.ParallelExtractGrayScale().ToArray();
                C = 1;
            }
            else
                data = bmp.ParallelExtractCHW().ToArray();

            ArithArray result = new ArithArray(1, C, H, W);
            result.LoadFrom(data);
            return Out(result);
        }

        /// <summary>
        /// Load all images from the folder based on criteria to the Image object
        /// </summary>
        /// <param name="path">The path.</param>
        /// <param name="height">The height.</param>
        /// <param name="width">The width.</param>
        /// <param name="grayScale">if set to <c>true</c> [gray scale].</param>
        /// <param name="searchPattern">The search pattern.</param>
        /// <param name="recursive">if set to <c>true</c> [recursive].</param>
        /// <returns></returns>
        public static Image FromFolder(string path, int height, int width, bool grayScale = false, string searchPattern = "*.*", bool recursive = true)
        {
            SearchOption opt = SearchOption.TopDirectoryOnly;

            if (recursive)
            {
                opt = SearchOption.AllDirectories;
            }

            var files = Directory.EnumerateFiles(path, searchPattern, opt);
            List<float> data = new List<float>();
            int C = grayScale ? 1 : 3;

            foreach (var filePath in files)
            {
                Mat mat = null;

                if (grayScale)
                    mat = Cv2.ImRead(filePath, ImreadModes.GrayScale);
                else
                    mat = Cv2.ImRead(filePath);
                
                mat = mat.Resize(new OpenCvSharp.Size(width, height));
                
                float[] imgdata = new float[C * height * width];
                if (C == 1)
                {
                    imgdata = mat.Cast<MatOfFloat>().ToArray();
                }
                else
                {
                    var vecData = mat.Cast<MatOfByte3>().ToArray();
                    int i = -1;
                    foreach (var item in vecData)
                    {
                        imgdata[++i] = item.Item0;
                        imgdata[++i] = item.Item1;
                        imgdata[++i] = item.Item2;
                    }
                }

                data.AddRange(imgdata);
            }

            ArithArray result = new ArithArray(files.Count(), C, height, width);
            result.LoadFrom(data.ToArray());
            return Out(result);
        }

        /// <summary>
        /// Gets or sets the image value at the specified index.
        /// </summary>
        /// <value>
        /// Get the value at the index
        /// </value>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Image this[long index]
        {
            get
            {
                
                var data = ArrayOps.NewContiguous(variable.Select(0, index));
                Image img = new Image(Channel, Width, Height);
                img.LoadData(data.ToArray());
                return img;
            }
        }

        /// <summary>
        /// Fills all the values in the image with specified value
        /// </summary>
        /// <param name="value">The value.</param>
        public void Fill(float value)
        {
            variable.Fill(value);
        }


        /// <summary>
        /// Shows the image at the specified index.
        /// </summary>
        /// <param name="index">The index of the image from the list.</param>
        /// <param name="title">The title for the window.</param>
        public void Save(long index = 0, string title = "Img")
        {
            //Cv2.ImShow(title, ToOpenCVMat(index));
            //Cv2.ImWrite("test.jpg", ToOpenCVMat(index));
        }

        /// <summary>
        /// Converts the data to Open CV Mat object.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Mat ToOpenCVMat(long index = 0)
        {
            Image img = this[index];
            img.variable = img.variable.Transpose(0, 2, 3, 1);
            MatType matType = MatType.CV_8U;
            //if (Channel == 1)
            //    matType = MatType.CV_32FC1;

            MatOfByte3 mat = new MatOfByte3(Height, Width);
            
            var bytes = img.variable.DataFloat.Select(x => (byte)x).ToArray();
            return mat;
        }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator +(Image lhs, Image rhs) { return Out(In(lhs) + In(rhs)); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator +(Image lhs, float rhs) { return Out(In(lhs) + rhs); }

        /// <summary>
        /// Implements the operator +.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator +(float lhs, Image rhs) { return Out(lhs + In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator -(Image lhs, Image rhs) { return Out(In(lhs) - In(rhs)); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator -(Image lhs, float rhs) { return Out(In(lhs) - rhs); }

        /// <summary>
        /// Implements the operator -.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator -(float lhs, Image rhs) { return Out(lhs - In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator *(Image lhs, Image rhs) { return Out(In(lhs) * In(rhs)); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator *(Image lhs, float rhs) { return Out(In(lhs) * rhs); }

        /// <summary>
        /// Implements the operator *.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator *(float lhs, Image rhs) { return Out(lhs * In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator /(Image lhs, Image rhs) { return Out(In(lhs) / In(rhs)); }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator /(Image lhs, float rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator /.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator /(float lhs, Image rhs) { return lhs / rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator >(Image lhs, Image rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &gt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator >(Image lhs, float rhs) { return lhs > rhs; }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <(Image lhs, Image rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator &lt;.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <(Image lhs, float rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator >=(Image lhs, Image rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &gt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator >=(Image lhs, float rhs) { return lhs >= rhs; }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <=(Image lhs, Image rhs) { return lhs <= rhs; }

        /// <summary>
        /// Implements the operator &lt;=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <=(Image lhs, float rhs) { return lhs <= rhs; }
    }
}
