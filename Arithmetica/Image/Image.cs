using OpenCvSharp;
using System;
using System.Collections.Generic;
using System.Text;
using System.Linq;
using System.IO;
using System.Drawing;
using System.Runtime.InteropServices;
using Arithmetica.LinearAlgebra.Single;
using NumSharp;

namespace Arithmetica.Imaging
{
    /// <summary>
    /// Provides a collection of static convenience methods for creating, manipulating, combining, and converting generic images.
    /// </summary>
    public partial class Image
    {
        internal NDArray variable;

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
                return variable.shape[0];
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
                return variable.shape[1];
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
                return variable.shape[3];
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
                return variable.shape[2];
            }
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="size">The size of the image.</param>
        public Image(int channel, int height, int width, int size = 1)
        {
            variable = new NDArray(size, channel, height, width);
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="Image"/> class.
        /// </summary>
        /// <param name="v">The arith array which is a generalised array.</param>
        private Image(NDArray v)
        {
            variable = v;
        }

        /// <summary>
        /// Ins the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static NDArray In(Image x)
        {
            return x.variable;
        }

        /// <summary>
        /// Outs the specified x.
        /// </summary>
        /// <param name="x">The x.</param>
        /// <returns></returns>
        internal static Image Out(NDArray x)
        {
            return new Image(x);
        }

        /// <summary>
        /// Gets the generalised arith array which is a multi dimensional array
        /// </summary>
        /// <value>
        /// The arith array.
        /// </value>
        public NDArray NDArray
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
            int W, H, C;
            Mat mat = null;
            if (grayScale)
                mat = Cv2.ImRead(filePath, ImreadModes.Grayscale);
            else
                mat = Cv2.ImRead(filePath, ImreadModes.Color);

            W = width.HasValue ? width.Value : mat.Width;
            H = height.HasValue ? height.Value : mat.Height;
            C = mat.Channels();
            if(mat.Height != H && mat.Width != W)
                mat = mat.Resize(new OpenCvSharp.Size(W, H));

            var imgdata = ImgToFloat(mat, W, H, C);

            var result = np.array(imgdata);
            result = result.reshape(new Shape(1, H, W, C));
            result = result.transpose(new int[] { 0, 3, 1, 2 });
            return Out(result);
        }

        /// <summary>
        /// Convert Open CV Mat object to Arithmetica image object
        /// </summary>
        /// <param name="mat">The open cv mat.</param>
        /// <returns></returns>
        public static Image FromOpenCVMat(Mat mat)
        {
            int W = mat.Width;
            int H = mat.Height;
            int C = mat.Channels();
            if(mat.Height != H && mat.Width != W)
                mat = mat.Resize(new OpenCvSharp.Size(W, H));

            var imgdata = ImgToFloat(mat, W, H, C);

            var result = np.array(imgdata);
            result = result.reshape(new Shape(1, H, W, C));
            result = result.transpose(new Shape(0, 3, 1, 2));
            return Out(result);
        }

        /// <summary>
        /// Imgs to float.
        /// </summary>
        /// <param name="mat">The mat.</param>
        /// <param name="W">The w.</param>
        /// <param name="H">The h.</param>
        /// <param name="C">The c.</param>
        /// <returns></returns>
        private static float[] ImgToFloat(Mat mat, int W, int H, int C)
        {
            float[] imgdata;
            imgdata = new float[C * H * W];
            float[] red = new float[H * W];
            float[] blue = new float[H * W];
            float[] green = new float[H * W];
            if (C == 1)
            {
                var floatData = mat.Cast<MatOfByte>().ToArray();
                imgdata = floatData.Select(x => (float)x).ToArray();
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

            return imgdata;
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
                    mat = Cv2.ImRead(filePath, ImreadModes.Grayscale);
                else
                    mat = Cv2.ImRead(filePath, ImreadModes.Color);
                
                mat = mat.Resize(new OpenCvSharp.Size(width, height));

                float[] imgdata = ImgToFloat(mat, width, height, C);
                data.AddRange(imgdata);
            }

            NDArray result = new NDArray(files.Count(), height, width, C);
            result.LoadFrom(data.ToArray());
            result = result.transpose(0, 3, 1, 2);
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
                var data = Helper.NewContiguous(variable.Select(0, index));
                Image img = new Image(Channel, Height, Width);
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
        public void Show(string title = "Img", long? index = null)
        {
            if (index.HasValue)
            {
                Cv2.ImShow(title, ToOpenCVMat(index.Value));
                Cv2.WaitKey();
            }
            else
            {
                for (int i = 0; i < Size; i++)
                {
                    Cv2.ImShow(title, ToOpenCVMat(i));
                    Cv2.WaitKey();
                }
            }
        }

        /// <summary>
        /// Save the image of specified index to the specified file path.
        /// </summary>
        /// <param name="filePath">The file path.</param>
        /// <param name="index">The index.</param>
        public void Save(string filePath, long index = 0)
        {
            Cv2.ImWrite(filePath, ToOpenCVMat(index));
        }

        /// <summary>
        /// Converts the data to Open CV Mat object.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public Mat ToOpenCVMat(long index = 0)
        {
            Image img = this[index];
            img.variable = img.variable.transpose(0, 2, 3, 1);

            Mat mat;

            if (Channel == 3)
            {
                mat = new MatOfByte3(Height, Width);
                var arr = img.variable.DataFloat.ToArray();
                Vec3b[] imgData = new Vec3b[Height * Width];

                int i = 0;
                while (i < imgData.Length)
                {
                    imgData[i].Item0 = (byte)arr[i * Channel];
                    imgData[i].Item1 = (byte)arr[i * Channel + 1];
                    imgData[i].Item2 = (byte)arr[i * Channel + 2];
                    i++;
                }
                mat.SetArray(0, 0, imgData);
            }
            else
            {
                mat = new MatOfByte(Height, Width);
                var bytes = img.variable.DataFloat.Select(x => (byte)x).ToArray();
                mat.SetArray(0, 0, bytes);
            }
            
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
        /// Implements the operator <.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <(Image lhs, Image rhs) { return lhs < rhs; }

        /// <summary>
        /// Implements the operator <.
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
        /// Implements the operator <=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <=(Image lhs, Image rhs) { return lhs <= rhs; }

        /// <summary>
        /// Implements the operator <=.
        /// </summary>
        /// <param name="lhs">The LHS.</param>
        /// <param name="rhs">The RHS.</param>
        /// <returns>
        /// The result of the operator.
        /// </returns>
        public static Image operator <=(Image lhs, float rhs) { return lhs <= rhs; }

        #region Image Functions
        /// <summary>
        /// Pad the image which will make border of specified length
        /// </summary>
        /// <param name="top">The top pad length.</param>
        /// <param name="bottom">The bottom pad length.</param>
        /// <param name="left">The lef pad lengtht.</param>
        /// <param name="right">The right pad length.</param>
        /// <param name="value">The pad value.</param>
        /// <returns></returns>
        public Image Pad(int top, int bottom, int left, int right,  float value = 0)
        {
            List<float> data = new List<float>();
            int H = Height + top + bottom;
            int W = Width + left + right;
            
            for (int i = 0; i < Size; i++)
            {
                var mat = ToOpenCVMat(i);
                Cv2.CopyMakeBorder(mat, mat, top, bottom, left, right, BorderTypes.Constant, value);
                data.AddRange(ImgToFloat(mat, mat.Width, mat.Height, mat.Channels()));
            }

            var result = new NDArray(1, H, W, Channel);
            result.LoadFrom(data.ToArray());
            result = result.transpose(new int[] { 0, 3, 1, 2 });
            return Out(result);
        }

        /// <summary>
        /// Gets the region of the image.
        /// </summary>
        /// <param name="x">The x value.</param>
        /// <param name="y">The y value.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        /// <returns></returns>
        public Image GetRegion(int x, int y, int width, int height)
        {
            List<float> data = new List<float>();
            for (int i = 0; i < Size; i++)
            {
                variable.
                data.AddRange(variable.GetRegion(new long[] { i, 0, y, x }, new long[] { 1, Channel, width, height }).DataFloat);
            }

            var result = new NDArray(1, Channel, height, width);
            result.LoadFrom(data.ToArray());
            return Out(result);
        }

        /// <summary>
        /// Converts the image to a list of matrix of RGB values
        /// </summary>
        /// <returns></returns>
        public List<List<Matrix>> ToMatrix()
        {
            List<List<Matrix>> result = new List<List<Matrix>>();
            List<Matrix> imageMats = new List<Matrix>();

            for (int i = 0; i < Size; i++)
            {
                imageMats.Clear();
                for (int j = 0; j < Channel; j++)
                {
                    
                    imageMats.Add(Matrix.Out(Helper.NewContiguous(variable.Select(0, i).Select(0, j))));
                }

                result.Add(imageMats);
            }

            return result;
        }

        /// <summary>
        /// Get the matrix of RGB of specific image index
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns></returns>
        public List<Matrix> ToMatrix(int index)
        {
            List<Matrix> result = new List<Matrix>();

            var img = this[index];
            for (int i = 0; i < img.Channel; i++)
            {
                result.Add(Matrix.Out(Helper.NewContiguous(img.variable.Select(0, 0).Select(0, i))));
            }

            return result;
        }

        /// <summary>
        /// Sets the pixel value of the image at cordinate (x, y).
        /// </summary>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="values">The values.</param>
        /// <exception cref="ArgumentException">Values length should be equal to channel size, if gray scale: pass one value, if color: pass B, G, R value</exception>
        public void SetPixel(int x, int y, params float[] values)
        {
            if(Channel != values.Length)
            {
                throw new ArgumentException("Values length should be equal to channel size, if gray scale: pass one value, if color: pass B, G, R value");
            }

            for (int i = 0; i < values.Length; i++)
            {
                variable.SetSingle(values[i], 0, i, y, x);
            }
        }
        #endregion
    }
}
