#!/bin/zsh

set -e;

__EXE_FILE='Credit_linux/bin/Debug/Credit_linux.exe'

if test -e "$__EXE_FILE";then
  rm "$__EXE_FILE"
fi

zsh ~/Git_Clones/TimePass-Projects/colorPlusPlus/src/run.sh xbuild /nologo Credit_linux/Credit_linux.sln;

echo "\n";
if test -e "$__EXE_FILE";then
  Credit_linux/bin/Debug/Credit_linux.exe;
else
  echo -e "\033[0;36mErrors are there. Fix them"
fi

