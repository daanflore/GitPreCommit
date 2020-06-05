# GitPreCommit

1. [Using](#Using)
2. [Why](#Why)
3. [Features](#Features)
    1. [Trimming](#Trimming)
4. [Run](#Run)

## Using
This is a [dotnet-script](https://github.com/filipw/dotnet-script) based project that can be used as a pre-commit for git.
First you have to globaly install [dotnet-script](https://github.com/filipw/dotnet-script) to allow you tu run the scripts.
On git of dotnet-scripts you cna find how to install it.

You have to copy the following files from this project to the .git/hooks folder:
* CommandRunner.csx
* GitDiffIndexParser.csx
* GitStager.csx
* GitStasher.csx
* Logger.csx
* TrimTrailingWhiteSpace.csx
* pre-commit

## Why
Because not all the editors that I use support editorconfigs and auto trimming I had to use the pre-commit function of git to force the cleaning.


## Features
### Trimming
The trim will remove all the spaces that are at the end of a line.
To prevent it from always running it works based on a git diff that checks for errors in spaces.

## Run
First you will have to install the 'c#' and 'scriptcsRunner' plugin in vscode.

Next you have to alter the '.vscode/launch.json'.
Here you must change the 'args' so it refers to the localy installed dotnet-script.dll.
After this you can debug and run the code
