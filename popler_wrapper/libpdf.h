#ifndef LIBPDF_H
#define LIBPDF_H
#ifdef __cplusplus
extern "C" {
#endif

#ifdef BUILDING_LIBPDF_DLL
#define LIBPDF_DLL __declspec(dllexport)
#else
#define LIBPDF_DLL __declspec(dllimport)
#endif

typedef struct image_data_type{
	int	bytes_per_row;
	int	height;
	int	width;
	int	format;
	int	data_size;
	char *	data;
} image_data;


LIBPDF_DLL void * __cdecl init_pdf(char * pdf_data, int length);

LIBPDF_DLL void * __cdecl get_image(int page_number,image_data * retVal, void * pdf);
LIBPDF_DLL int __cdecl save_image(char * file_name, int page_number, char * format, int dpi, void * pdf);

LIBPDF_DLL void __cdecl free_image_data(void *);
LIBPDF_DLL void __cdecl free_pdf(void * pdf);


#ifdef __cplusplus
}
#endif

#endif