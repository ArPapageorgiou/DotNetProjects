# Generics Bubble Sort

## Overview

This repository contains a C# program that demonstrates a generic implementation of the Bubble Sort algorithm. The `Bubble<T>` class sorts arrays of any type `T` that implements the `IComparable<T>` interface. It supports both ascending and descending sorting orders.

## Contents

- **Program.cs**: Contains the entry point of the application and examples of sorting integers and characters.
- **Bubble.cs**: Defines the `Bubble<T>` class with sorting methods and utility functions.
- **NullArrayException.cs**: Defines a custom exception for handling null arrays.

## Classes

### `Program`

The entry point of the application.

#### Methods

- **`Main(string[] args)`**: 
  - Initializes and sorts arrays of integers and characters using the `Bubble<T>` class.
  - Prints the array before and after sorting in ascending and descending orders.

### `Bubble<T>`

A generic class that implements the Bubble Sort algorithm.

#### Type Parameters

- **`T`**: The type of elements in the array, constrained to types that implement the `IComparable<T>` interface.

#### Properties

- **`Array`**: The array of elements to be sorted.

#### Constructors

- **`Bubble(T[] array)`**: 
  - Initializes a new instance of the `Bubble<T>` class with the specified array.

#### Methods

- **`T[] BubbleSortAscending()`**: 
  - Sorts the array in ascending order using the Bubble Sort algorithm.
  - Returns the sorted array.

- **`T[] BubbleSortDescending()`**: 
  - Sorts the array in descending order using the Bubble Sort algorithm.
  - Returns the sorted array.

- **`void PrintArray()`**: 
  - Prints the elements of the array to the console, separated by commas.

#### Private Methods

- **`void Swap(int index1, int index2)`**: 
  - Swaps the elements at the specified indices in the array.

### `NullArrayException`
A custom exception class for handling cases where a null array is provided to the Bubble<T> constructor.

#### Constructors

- **`NullArrayException(string message)`**: 
  - Initializes a new instance of the NullArrayException class with a specified error message.

## Example Usage

### Sorting Integers

```csharp
int[] numbersToSort = { 5, 4, 2, 1, 3 };
Bubble<int> bubbleNumbers = new Bubble<int>(numbersToSort);
bubbleNumbers.PrintArray(); // Output: 5, 4, 2, 1, 3
bubbleNumbers.BubbleSortAscending();
bubbleNumbers.PrintArray(); // Output: 1, 2, 3, 4, 5
bubbleNumbers.BubbleSortDescending();
bubbleNumbers.PrintArray(); // Output: 5, 4, 3, 2, 1
```

## Exception Handling

The `Bubble<T>` class includes basic exception handling:

- **`NullArrayException`**: Thrown when a null array is provided to the constructor.
- **Print Method**: Handles exceptions that occur during the printing of the array.
- **Swap Method**: Handles index out-of-range and other exceptions that may occur during the swap operation.
- **BubbleSortAscending and BubbleSortDescending Methods**: Handle exceptions that occur during the sorting process and print appropriate error messages.

This ensures that the application can handle and report errors gracefully, providing insights into what might have gone wrong during execution.

