using System;
using System.Runtime.InteropServices;
using System.IO;
using System.Drawing;
using System.Drawing.Imaging;

namespace test_libpdf
{
	class MainClass
	{

		struct image_data_type{
			public int	bytes_per_row;
			public int	height;
			public int	width;
			public int	format;
			public int	data_size;

		};

		[DllImport("libpdf.dll", SetLastError=true)]
		static extern IntPtr init_pdf([MarshalAs(UnmanagedType.LPArray)]byte[] pdfContent, int contentLength);

		[DllImport("libpdf.dll", SetLastError=true)]
		static extern void free_pdf(IntPtr pdf);

		[DllImport("libpdf.dll", SetLastError=true)]
		static extern IntPtr get_image(int pageNumber,IntPtr imageData, IntPtr pdf);

		[DllImport("libpdf.dll", SetLastError=true)]
		static extern bool save_image(string file_name, int page_number, string format, int dpi, IntPtr pdf);

		public static void Main (string[] args)
		{
			var data = File.ReadAllBytes(@"C:\projects\test_libpdf\test_libpdf\svn-book.pdf");
			var pdf = init_pdf(data, data.Length);

			if(!save_image("test.jpg",0,"jpg",96,pdf)){
				Console.WriteLine("FAILED");
			}

//			image_data_type image_data = new image_data_type();
//			image_data.bytes_per_row = 0;
//
//			IntPtr pnt;
//			pnt = Marshal.AllocHGlobal (Marshal.SizeOf (image_data));
//
//			try{
//
//				Marshal.StructureToPtr(image_data, pnt, false);
//
//				var dataPtr = get_image(1, pnt, pdf);
//
//				image_data_type image_data2 = (image_data_type)Marshal.PtrToStructure(pnt, typeof(image_data_type));
//				var imageBytes = new byte[image_data2.data_size];
//				Marshal.Copy(dataPtr,imageBytes,0, image_data2.data_size);
//
//
//				var mem = new MemoryStream(imageBytes, 0, imageBytes.Length);
//				mem.Position = 0;
//
//				var image = new Bitmap(mem);
//
//				image.Save("test.png",ImageFormat.Jpeg);
//
//
//			}
//			finally{
//				Marshal.FreeHGlobal(pnt);
//			}
//


//			get_image(1, ref image_data, pdf);


			free_pdf(pdf);
		}
	}
}
