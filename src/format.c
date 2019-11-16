#include "format.h"
#include <stdio.h>

extern float fout;

const char *format_number(prefixes prefix, float *output)
{
    char *str_k = "kHz";
    char *str_m = "MHz";
    char *str_g = "GHz";
    char *str_return = NULL;

    switch (prefix)
    {
    case kilo:
        *output = (float)(fout / 1e3);
        str_return = str_k;
        break;
    case mega:
        *output = (float)(fout / 1e6);
        str_return = str_m;
        break;
    case giga:
        *output = (float)(fout / 1e9);
        str_return = str_g;
        break;
    default:
        break;
    }
    return str_return;
}
