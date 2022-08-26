# TerraText
A C# program to render 3D objects to the terminal.

## Introduction
This C# program allows to render a 3D object to the terminal output using TextGL.  
TextGL is a graphics library that I made to achieve this purpose.  
The ModelMaker class inside TextGL offers some built-in models to test with.  
Though it should load any OBJ file that represents a triangle-faced 3D model.  
**(Shading or texturing is NOT supported)**  

## Why only triangles?
A tridimensional shape is usually represented by lots of triangles covering the shape's surface.  
The number of triangles used to cover its shape is directly proportional to the quality of the model.  
(More triangles == More fidelity to the original shape)  
Sometimes, though, a 3D model can be represented with squares instead of triangles.  
My graphics library simply doesn't support square-faced 3D models as I was making this just for fun.  
Anyway any square-faced 3D model can be converted to its triangle-faced counterpart using Blender.  

## Why no shading or texturing?
Texturing shouldn't be that hard to implement, but I just don't have any more time for this project.  
Shading, instead, is very hard to implement because it also brings the visibility problem.  
This program renders everything as a white block so you can't determine what's in front of what.  
Technically, though, even the insides of the model are being rendered, which would be a bad thing.  
Shading must be implemented only after solving this problem, a problem that I never tried to solve  
as I didn't want this to become too much of a hassle, so no shading.  

## Performance
Tremendously horrible.  
Everything is ran on the CPU, this makes it generally slow and even slower with complex models.  
The code could surely be more optimized, since I made this without caring about performance.  
I was trying to understand how to use the GPU to accelerate everything,  
but in the end I never looked enough into it.  

## Other informations
> So, what's its use? Well, I don't know!  
> I made it, but you'll have to find a use for it.  
> It might even not have any.  

Joking aside, I'm no expert, this was just something I made for fun.  
I shared this because I wanted to improve, to understand my mistakes with people.  
So, feel free to suggest and contribute as I'm always interested in learning.  
The project's name is a reference to Terravision.  
