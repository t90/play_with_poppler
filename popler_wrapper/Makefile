INCLUDE_DIR=./include
LIBRARY_DIR=./lib
OBJECTS=libpdf.o
OUTPUT=libpdf
CFLAGS=-DBUILDING_LIBPDF_DLL

all: clean $(OBJECTS)
	g++ -shared $(OBJECTS) -L$(LIBRARY_DIR) -lpoppler-cpp.dll -lopenjpeg -lz  -o $(OUTPUT).dll -Wl,--subsystem,windows
%.o:
	g++ -fPIC -I$(INCLUDE_DIR) $(CFLAGS) -c $(@:.o=.cpp)
clean:
	rm -f $(OBJECTS)
	rm -f $(OUTPUT).so
	rm -f $(OUTPUT).dll
	rm -f $(OUTPUT).so.dll