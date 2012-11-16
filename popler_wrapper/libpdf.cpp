#include <stdlib.h>
#include <string.h>
#include <string>
#include "poppler-document.h"
#include "poppler-page-renderer.h"
#include "libpdf.h"

void * init_pdf(char * pdf_data, int length){
	return poppler::document::load_from_raw_data(pdf_data,length);
}

void * get_image(int page_number,image_data * retVal, void * pdf){
	poppler::page * page = ((poppler::document *)pdf)->create_page(page_number);
	poppler::page_renderer r;
	poppler::image i = r.render_page(page);

	retVal->bytes_per_row = i.bytes_per_row();
	retVal->height = i.height();
	retVal->width = i.width();
	retVal->data_size = retVal->height * retVal->bytes_per_row;
	void * p = (char *)malloc(retVal->data_size);
	memcpy(i.data(), p, retVal->data_size);
	retVal->format = i.format();
	return p;
}

int save_image(char * file_name, int page_number, char * format, int dpi, void * pdf){
	poppler::page * page = ((poppler::document *)pdf)->create_page(page_number);
	poppler::page_renderer r;
	poppler::image i = r.render_page(page);
	std::string fName(file_name);
	std::string outFormat(format);
	if(!i.save(fName, outFormat, dpi)){
		return 0;
	}
	return 1;
}

void free_image_data(void * image){
	free(image);
}

void free_pdf(void * pdf){
	delete ((poppler::document *)pdf);
}
