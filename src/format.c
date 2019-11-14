#include "format.h"

extern float fout;

const char * format_number(prefixes prefix, float *output)
{
     switch (prefix) {
         case kilo:
            *output=(float)(fout/1e3);
            return "kHz";
            break;
        case mega:
            *output=(float)(fout/1e6);
            return "MHz";
            break;
        case giga:
            *output=(float)(fout/1e9);
            return "GHz";
            break;
         default:
            break;
     }
 }
