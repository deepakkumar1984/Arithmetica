This is a simple library to build and simulate your own quantum computing algorithms in C#, yes in C#.

## How to use the library
* Create a new .NET core or Windows console project.
* Right-Click on the solution and select Managed NuGet References.
* Search for “Arithmetica”, select and install the latest version
* Open the class file and import namespace “using Arithmetica” to start using the library and its functions.


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

API Documentation: https://tech-quantum.github.io/Arithmetica/api/Arithmetica.html

