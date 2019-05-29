# Arithmetic
To summarise, arithmetica is developed to help students, professional or scientists to learn or prototype work related to applied mathematics and quantum physics.

Following are the features:

* Full-featured implementation of mathematical data types including complex numbers’ quaternion and various sizes of matrices and vectors.
* Support for most of the math functions for basic maths, linear algebra, rounding, comparison, log, exp, powering etc.
* Support single-precision and double-precision floating point types.
* Covers most of the functions required to use Complex vectors and matrix.
* Geometric data types and algorithms for 2D and 3D — distance and intersection methods, bounding volumes etc.
* Random number and noise generation with around 10 algorithms
* Strong-Typed collections for the library’s data types.
* Support for Multi-Dimensional array in case 2D, 3D are not sufficient.

## How to use the library
* Create a new .NET core or Windows console project.
* Right-Click on the solution and select Managed NuGet References.
* Search for “Arithmetica”, select and install the latest version
* Open the class file and import namespace “using Arithmetica” to start using the library and its functions.

## Vector Example

```csharp
//Point A in the 2D space
Vector2 A = new Vector2(10, 20);

//Point B in the 2D space
Vector2 B = new Vector2(70, 80);

//Find the Euclidean distance
var distance = DistanceMethods.Distance(A, B);
```

## Complex Matrix Example

```csharp
//Define a 2x2 complex matrix
ComplexMatrix matrix = new ComplexMatrix(2, 2);
matrix[0, 0] = new Complex(2, 2);
matrix[0, 1] = new Complex(1, 2);
matrix[1, 0] = new Complex(3, 1);
matrix[1, 1] = new Complex(2, 3);
Console.WriteLine("First Matrix");
Console.WriteLine(matrix.ToString());

//Define a comple vector of length 2
ComplexVector vector = new ComplexVector(2);
vector[0] = new Complex(2, 1);
vector[1] = new Complex(1, 3);
Console.WriteLine("Second Vector");
Console.WriteLine(vector.ToString());

// Multiplying a 2x2 matrix with a vector will result a vector
var result = matrix * vector;

Console.WriteLine("Result Vector");
Console.WriteLine(result.ToString());

```

## Quantum Teleportation
```csharp
//Create a register with 2 Qubits
QuantumRegister register = new QuantumRegister(2);

//Create a blank circuit with the regiter initialised
QuantumCircuit circuit = new QuantumCircuit(register);

//Initialize the tranported counter
int transported = 0;

//Let try to teleport 25 quantum information
for (int i = 0; i < 25; i++)
{
	var send = GetRandom();

	//Initial the first Qubit with the particle to be teleported
	circuit.INIT(0, send);

	//Hadamard gate to apply superposition to the first quantum bit which means the first qubit will have both 0 and 1
	circuit.H(0);

	//Controlled not gate to entangle the two qubit
	circuit.CNOT(0, 1);

	//Measure the first will collapse the quantum state and bring it to reality whic will be either one or zero
	circuit.Measure(0);

	//Store the first state
	var res1 = register[0].QState;

	//Now measue the second particle and store the value
	circuit.Measure(1);
	var res2 = register[1].QState;

	Console.WriteLine("Send: {0}, Received: {1}", res1, res2);

	//If you compare the result the two result will be same which states that the information is teleported.
	if (res1 == res2)
		transported++;

	register.Reset();
}

//var result = circuit.Execute(1000);
Console.WriteLine("Teleported count: " + transported);
```

Nuget package available, search with name Arithmetica

API Documentation: https://deepakkumar1984.github.io/Arithmetica/api/Arithmetica.html

