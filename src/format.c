#include "format.h"
#include <stdio.h>
#include <stdlib.h>

const char *format_number(prefixes prefix, float input, float *output, char *formated_output)
{
    char *str_k = "kHz";
    char *str_m = "MHz";
    char *str_g = "GHz";
    char *str_return = NULL;

    switch (prefix)
    {
    case kilo:
        *output = (float)(input / 1e3);
        str_return = str_k;
        break;
    case mega:
        *output = (float)(input / 1e6);
        str_return = str_m;
        break;
    case giga:
        *output = (float)(input / 1e9);
        str_return = str_g;
        break;
    default:
        break;
    }
    gcvt(output, 3, *formated_output);

    return str_return;
}
