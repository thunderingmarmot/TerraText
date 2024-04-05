# TerraText
[![License: GPL v3](https://img.shields.io/badge/License-GPLv3-blue?style=flat-square)](https://www.gnu.org/licenses/gpl-3.0)  
A C# program to render 3D objects to the terminal
> The name is a reference to [Terravision](https://en.wikipedia.org/wiki/Terravision_(computer_program)) as its original purpose was to render a spinning Earth inside the terminal.

## Features (or rather unfeatures)
- Shading and texturing is NOT supported
- Only triangular-faced 3D models are supported
- Only OBJ files can be loaded
- Horrible performance

## Introduction
This C# program allows **rendering a 3D object to the terminal output** using TextGL, a graphics library that I made to achieve this very purpose.
TextGL also includes the ModelMaker class that offers some built-in models to test with, though **it should also be able to load any OBJ file that contains a triangular-faced 3D model**.

## Triangular-faced 3D models
A tridimensional shape is usually represented by lots of triangles covering the shape's surface and the number of those is directly proportional to the quality of the model.
Sometimes, though, a 3D model can also be represented using other polygons (like squares), my library simply doesn't support them as I was making this just for fun.
Anyway, any non-triangular-faced 3D model can be converted to its triangular-faced counterpart using Blender.

## Shading and Texturing
Again, I was making this just for fun and to learn the basics of 3D rendering and rasterizing.
Though, while texturing shouldn't be that hard to implement, shading requires implementing one of the solutions to the [visibility problem](https://en.wikipedia.org/wiki/Visibility_(geometry)).
Infact, this program also renders and displays the insides of a model (which would be a bad thing), though since everything has a white texture, you can't really determine what's in front of what.

## Performance
The performance is obviously horrible, I tried to do the job of hundreds of slow workers with a single fast worker, meaning that these are usually operations optimized for the GPU, not the CPU.
Also, while I tried to write good code, I'm sure things can be further optimized to reach a better performance even on CPU.

## Epilogue
The point of this project is not in the program itself, but rather on improving my knowledge and skills while also having fun.
So feel free to start a discussion, suggest and contribute to the project or just leaving a feedback.
