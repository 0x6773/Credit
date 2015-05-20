#!/bin/zsh

# Exit on error
set -e

# Print all commands
set -x


#rm -rf Credit_linux/bin/Debug/Data

xbuild Credit_linux/Credit_linux.sln 

Credit_linux/bin/Debug/Credit_linux.exe 
