# Implementation Guidelines

## .Net Standard Class Library Data Structures and Algorithms are forbidden....with one exception

The use of pre-existing Data Structures and Algorithms from the .Net Standard Class Library is forbidden.   As an example, this would mean that if you need to make use of a Queue structure, you must use Reference.Lib.DataStructure.Collections.Queue rather than System.Collections.Generic.Queue.  The lone exception is the use of Arrays.  Well, and Dictionary, at least until a HashTable<K,V> is added :)

## .Net SCL Interfaces are required

The focus of this library is only implementation.  The use of standard .Net interfaces (IEnumerable<>, IEquatable<>, IComparable<>, etc.) is required.