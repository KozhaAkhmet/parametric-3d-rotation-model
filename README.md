# parametric-3d-rotation-model

An interactive Unity interface that displays the 3D rotation of symmetric geometrical shapes using only line segments — no meshes, just a `LineRenderer` driven by parametric equations.

![demo](https://user-images.githubusercontent.com/80167990/198712847-6d5245a4-56ed-4d81-9061-4c02938182f0.gif)

## Controls

The scene (`Assets/Scenes/main.unity`) exposes a set of sliders (wired up in `UI.cs`) that drive the shape live:

| Slider | Effect |
| ------ | ------ |
| Speed | Rotation speed |
| Radius X / Radius Y | Ellipse radii of each point's orbit (equal values give a circle, unequal give an ellipse) |
| Transpose X / Transpose Y | Shifts the center of rotation |
| Height | Vertical offset used to draw the "extruded" second ring, giving the shape depth |

`Add Point` / `Remove Point` buttons spawn or destroy `Point` GameObjects at runtime — the more points, the more sides the resulting rotating polygon has.

## How It Works

`Controller.cs` runs every point tagged `"Point"` through the same parametric equation each frame:

```csharp
currentPos = new Vector2(
    radiusX * Mathf.Cos(Time.timeSinceLevelLoad * speed + iteration) + transposeX,
    radiusY * Mathf.Sin(Time.timeSinceLevelLoad * speed + iteration) + transposeY
);
```

Each point gets its own constant phase offset (`iteration`, spaced evenly around `360° / points.Length`), so together they trace a rotating regular polygon inscribed in an ellipse. A second position, `shiftedPos`, is the same point offset vertically by `height`; connecting `currentPos` → `shiftedPos` for every point turns the flat rotating polygon into a wireframe 3D prism, all drawn through a single shared `LineRenderer`.

## Tech Stack

- Unity, C# (`Assets/Scripts/Controller.cs`, `Assets/Scripts/UI.cs`)
- Built-in `LineRenderer` + `ShaderLab`/HLSL for rendering
- TextMesh Pro for UI text

## License

MIT — see [LICENSE](LICENSE).
