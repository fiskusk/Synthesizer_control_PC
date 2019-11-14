#ifndef FORMAT_H_INCLUDED
#define FORMAT_H_INCLUDED

typedef enum {
    kilo, mega, giga,
    k=kilo, M=mega, G=giga
} prefixes;

const char * format_number(prefixes prefix, float *output);

#endif // FORMAT_H_INCLUDED
