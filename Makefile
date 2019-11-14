# Shyntetizer project Makefile
# fiskus & wykys 2019


######################################
# project variables
######################################
# target name
TARGET = synthetiser
OPT = -O0
# build dir
BUILD_DIR = build
# source dir
SRC = src
# includes
INC = -Iinc


######################################
# source
######################################
# C sources
C_SOURCES = $(wildcard $(SRC)/*.c)


#######################################
# toolchain
#######################################
CC = gcc -fdiagnostics-color=always
RM = rm -rf


#######################################
# build the application
#######################################
# compile gcc flags
CFLAGS = -Wall -std=c99 $(INC) $(OPT)
LDFLAGS = -Wl,-Map=$(BUILD_DIR)/$(TARGET).map -Wl,--cref

# generate dependency information
CFLAGS += -MMD -MP -MF"$(@:%.o=%.d)" -MT"$(@:%.o=%.d)"

# list of objects
OBJECTS = $(addprefix $(BUILD_DIR)/,$(notdir $(C_SOURCES:.c=.o)))
vpath %.c $(sort $(dir $(C_SOURCES)))

# default action: build all
all: $(BUILD_DIR)/$(TARGET).elf
# create object files from C files
$(BUILD_DIR)/%.o: %.c Makefile | $(BUILD_DIR)
	@$(CC) -c $(CFLAGS) -Wa,-a,-ad,-alms=$(BUILD_DIR)/$(notdir $(<:.c=.lst)) $< -o $@
# create aplication ELF file
$(BUILD_DIR)/$(TARGET).elf: $(OBJECTS) Makefile
	@$(CC) $(OBJECTS) $(LDFLAGS) -o $@
# create build directory
$(BUILD_DIR):
	@mkdir $@
clean:
	@$(RM) $(BUILD_DIR)