No routine should exceed a page. 

Modularity’ s advantages: 

- Much easier to debug small routines than big ones 

- Work simultaneously 

- Places certain dependencies in only one routine, making changes easier 

# ADT 

- An ADT is a set of operations; 

- ADTs are mathematical abstractions; 

- nowhere in an ADT’s definition is there any mention of how the set of operations is implemented. 

Operations for the set ADT: 

- Union 

- Intersection 

- Size 

- Complement 

## The List ADT 

Empty list—the special list of size 0. 

Operations: 

- Find: returns the position of the 1st occurrence of a key; 

- Insert and Delete: insert and delete some key from some position in the list 

- Find kth: returns the element in some position (specified as an argument) 

- Next and Previous: take a position as  an argument and return the position of the successor and predecessor, rsp. 

The cost of these operations: 

- PrintList and Find: Linear time 

- Find kth: Constant time 

- Insert and Delete: Worst of these operations is O(N), generally not used to implement lists. 



To avoid the linear cost of insertion and deletion, ensure that list is not stored contiguously. 



Next pointer: Each structure contains the element and a pointer to a structure containing its successor. 



The last cell’s Next pointer points to NULL (ANSI C specifies it is 0.). 



A pointer variable is a variable that contains the address where some other data are stored. 



Convention: the header (dummy node) is in position 0. 



and (&&) operation is short-circuited: if the first half of the statement is false, the result is automatically false and the second half is not executed. 

### Common Errors 

```memory access violation``` or ```segmentation violation``` 



A pointer variable contains a bogus address. 



Common reason: failure to initialize the variable. 



Whenever you do an indirection, you must make sure that the pointer is not NULL. 

### When and when not to use ```malloc``` to get a new cell? 

You must remember that declare a pointer to a structure does not create the structure but only give enough space to hold the address where some structure might be. 



The consequence of ```free(P)```: the address that P is pointing to is unchanged but the data that reside at the address are now undefined. 



If you never delete from a linked list, ```n(malloc) = size```. (```n(malloc) + 1 ``` if header is used.) 



You need to keep a temporary variable to set the cell to be disposed of. 



```malloc(sizeof(PtrToNode))``` doesn’t allocate enough space for a structure **but for a pointer**. 



Doubly linked list: doubles the cost of insertions and deletions and simplifies deletion. 



Double circularly linked list—have the last cell keep a pointer back to the first. 



## The Stack Model 

A stack is a list with the restriction that insertions and deletions can be performed only at the end of the list, called the top. 



Insert—Push; 



Delete—Pop, which deletes the most recently inserted element. 



LIFO—last in, first out. 



Top operation—examines the element at the front of the list, returning its value. 



The drawback of list implementation: calls to ```malloc``` and ``` free``` are expensive, esp. in comparison to the pointer manipulation routines. (Some of this could be avoided by using a 2nd stack which is initially empty.) 



### Array Implementation of Stacks: 

The only hazard—we need to declare an array size ahead of time. 



Associated with each stack is ```TopOfStack```, which is -1 for the empty stack. 



Push—increment ```TopOfStack``` and the set ```Stack[TopOfStack] = X ``` (Stack[] is the array representing the actual stack, X is the element to be pushed onto the stack); 



Pop—set the return value to the ```Stack[TopOfStack]``` and then decrement ```TopOfStack```. 



BAD IDEA—use global variables and fixed names to represent or any data structure. (In real life, more than 1 stack will be used.) 



No part of your code, except for stack routines, can attempt to access the array or TopOfStack variable implied by each stack. 



Common Practice: Skimp on error checking in the stack routines, except where error handling is crucial. 



Declaring the stack to be large enough not to overflow and ensuring that use  ```Pop``` that never attempt to pop an empty stack. 