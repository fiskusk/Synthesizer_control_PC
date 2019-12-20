#include <stdio.h>
#include "format.h"

#define FREF    10e6
#define DBR     0      // when DBR is set (1) -> its active FREF*2
#define RDIV2   0      // when RDIV2 is set (1) -> its active FREF/2
#define DIVA    1

int n_counter, f_counter, m_counter, r_counter;

float compute_f1_frequency(int r_counter);
float check_set_frequency(void);
void ask_for_registers(void);
void print_set_registers(void);
void preset_registers(void);

void formated_print(prefixes prefix);

int main(void)
{
    //ask_for_registers();
    preset_registers();
    formated_print(M);
    return 0;
}

float check_set_frequency(void)
{
    float f_out, f1;
    print_set_registers();
    f1 = compute_f1_frequency(r_counter);
    f_out = (f1)*(n_counter+(f_counter/(m_counter*1.0))/(DIVA));
    return f_out;
}

float compute_f1_frequency(int r_counter)
{
    float f1 = (FREF*(1+DBR))/(r_counter*(1+RDIV2));
    return f1;
}

void ask_for_registers(void)
{
    printf("Zadej hodnotu Integer-N = ");
    scanf("%d", &n_counter);
    printf("Zadej hodnotu Fractional-F = ");
    scanf("%d", &f_counter);
    printf("Zadej hodnotu Modulo-M = ");
    scanf("%d", &m_counter);
    printf("Zadej hodnotu R citace = ");
    scanf("%d", &r_counter);
}

void preset_registers(void)
{
    n_counter = 500;
    f_counter = 70;
    m_counter = 4095;
    r_counter = 1;
}

void print_set_registers(void)
{
    float f1 = compute_f1_frequency(r_counter);
    float f1_formated;
    char *formated[10];
    format_number(M, f1, &f1_formated, &formated);
    printf("\n\nAhoj svete.\n\nFrekvence f1 je %.3f MHz\n", f1_formated);
    printf("Hodnota registru Integer-N je %d\n", n_counter);
    printf("Hodnota registru Fractional-F je %d\n", f_counter);
    printf("Hodnota registru Modulo-M je %d\n", m_counter);
    printf("Hodnota registru citace-R je %d\n", r_counter);
}

void formated_print(prefixes prefix)
{
    float fout=check_set_frequency();
    char fout_formated[10];
    const char * prefix_text = format_number(prefix, fout, &fout, &fout_formated);
    
    printf("Prima fout = %.3f %s\n", fout, prefix_text);
    printf("Vysledna frekvence fout = %d.%s %s\n", fout_integer, fout_fractional, prefix_text);
}
