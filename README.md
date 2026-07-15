# Bézier Curves Visualization

An interactive visualization of Bézier curves using De Casteljau's algorithm.

## Demo

![Demo](Assets/demo.gif)

## Features

- Add control points with the left mouse button
- Drag control points with the right mouse button
- Real-time Bézier curve updates
- Bézier curve generation using De Casteljau's algorithm

## Technologies

- C#
- Raylib-cs

## Algorithm

The Bézier curve is computed using De Casteljau's algorithm, which repeatedly performs linear interpolation between adjacent control points until a single point remains. Repeating this process for values of **t** from **0** to **1** produces the complete Bézier curve.

## Controls

| Action | Mouse |
|---------|-------|
| Add a control point | Left Click |
| Move a control point | Right Click + Drag |