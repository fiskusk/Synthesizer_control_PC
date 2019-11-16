#include <stdio.h>
#include "format.h"

#define FREF    10e6
#define DBR     0      // when DBR is set (1) -> its active FREF*2
#define RDIV2   0      // when RDIV2 is set (1) -> its active FREF/2
#define DIVA    1

float f1, fout;
int n_counter, f_counter, m_counter, r_counter;

float compute_f1_frequency(int r_counter);
float check_set_frequency(void);
void ask_for_registers(void);
void print_set_registers(void);

void formated_print(prefixes prefix);

int main(void)
{
    ask_for_registers();
    formated_print(kilo);
    formated_print(M);
    formated_print(G);
    return 0;
}

float check_set_frequency(void)
{
    float f_out;
    print_set_registers();
    f_out = f1*(n_counter+(f_counter/m_counter)/DIVA);
    return f_out;
}

float compute_f1_frequency(int r_counter)
{
    f1 = (FREF*(1+DBR))/(r_counter*(1+RDIV2));
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

void print_set_registers(void)
{
    printf("\n\nAhoj svete.\n\nFrekvence f1 je %.3f MHz\n", compute_f1_frequency(r_counter));
    printf("Hodnota registru Integer-N je %d\n", n_counter);
    printf("Hodnota registru Fractional-F je %d\n", f_counter);
    printf("Hodnota registru Modulo-M je %d\n", m_counter);
    printf("Hodnota registru citace-R je %d\n", r_counter);
}

void formated_print(prefixes prefix)
{
    fout=check_set_frequency();
    const char * prefix_text = format_number(prefix, &fout);
    printf("Vysledna frekvence fout = %.3f %s\n", fout, prefix_text);
}
