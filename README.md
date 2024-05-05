# HamsterLang Interpreter

## Introduction

This project is the HamsterLang interpreter, a C# implementation following the principles laid out in Thorsten Ball's *"[Writing An Interpreter In Go]"*.
**Thorsten's book is excellent and I highly recommend everyone check it out and purchase it!**

HamsterLang is named after the iconic hamster sketch from Fawlty Towers. The project is currently in its developmental stages, primarily serving as a way to enhance my proficiency with C#.


**Current Status: In Development**
Note: The interpreter is not yet functional as the parser and other core components are under construction. The code may not be 'production ready', as it serves as a learning tool.

## Features
This is continuously being added to:
- Basic lexer providing lexical analysis
- Basic REPL (note: only Read and Print are currently implemented)

## License

MIT License

## Acknowledgments

- **Hamster** is deeply inspired by Thorsten Ball’s book, *[Writing An Interpreter In Go]*.
- This project serves as a translation of the concepts and implementations from Go into C#, intended to explore the differences in language implementation and to deepen my understanding of programming language theory.
- I extend my heartfelt gratitude to **[Thorsten Ball]** for his seminal work, which provided not only the foundation for this project but also a comprehensive guide to building an interpreter from scratch.
- While Hamster mirrors the structure and functionality of the Monkey language created by Thorsten, it is re-implemented in C# to leverage the specific features and paradigms of the .NET ecosystem.
- It is important to know that this project, at this time, does not introduce new concepts or substantial deviations from the original implementation by Thorsten, but serves as an educational tool to understand and compare language implementations.

## Tech

This project is implemented using a variety of technologies and tools designed to leverage the strengths of the .NET ecosystem. Below is a detailed list of the main components:

- **C#**: The primary programming language used for developing the Hamster interpreter.
- **.NET Core 7+**: Target framework providing a collection of libraries and runtime for building high-performance applications.
- **Neovim**: A terminal vim based text editor, chosen to reduce my reliance on more automated development environments and enforce dotnet cli usage.
- **Rider**: IDE from JetBrains used for developing this project, chosen for its powerful debugging tools.
- **xUnit**: Utilized for unit testing, xUnit is a free, open source, community-focused unit testing tool for .NET.
- **Git**: Version control

[//]: #
[Writing An Interpreter In Go]: <https://interpreterbook.com/>
[Thorsten Ball]: <https://thorstenball.com/>