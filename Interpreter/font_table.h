typedef struct {
	const uint8_t *bytearray;
	char *name;
	} FONT;
	
FONT font_table[] = {
	#include "font_list.h"
};