# Arithmetic
Arithmetic is an elementary part of number theory, and number theory is considered to be one of the top-level divisions of modern mathematics, along with algebra, geometry, and analysis

Create variable of following types:
* Matrix
* Vector
* Vector2
* Vector3
* Vector4
* Plane
* Quaternion

Supports most of the math arithmatic, comparision, trignometic, hyperbolic, log, exp, reduced, rounding functions.

## Matrix Example

```csharp
Matrix a = new Matrix(4, 6);
a.Fill(1);

Matrix b = new Matrix(4, 6);
b.Fill(2);

var m = Matrix.Matrix4x4();

Matrix c = Matrix.Sin(a + b);
c.Print();
```

## Vector3 Example

```csharp
//Create 3D vector of 1 size
Vector3 a = new Vector3(1);
//Assign the x,y,z of the vector
a[0] = (1, 2, 1);

//Create a unit with x,y,z
Vector3 b = Vector3.Unit(2, 1, 2);

//Dot product
var c = Vector3.Dot(a, b);
c.Print();
```

Nuget package available, search with name Arithmetica

# Documentation (Coming soon)
