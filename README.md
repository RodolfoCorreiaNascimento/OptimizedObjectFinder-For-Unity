# OptimizedObjectFinder-For-Unity
A script in C# to use Unity methods more efficiently, making the processing cost very low and your codes using the GameObject.FindGameObjectsWithTag and GameObject.Find methods much more efficient, as we know that searching for Strings generates high costs, remembering that the scene objects for this Tool need to be named this way ex: 1-sword, 2-shield, 3-fire in this way you probably are going to generate a sucess binary search for your object.

This implemetation I found when I was studing c++ data structs on CodeWars and I manage to use it in Unity. Thank you so much use it as many times as you can be happy making cool games! :)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Binary search in strings tends to be more costly in terms of processing than binary search in integers. This is due to the nature of the data involved:

Comparison of elements: In binary search, the main operation is the comparison between the element being sought and the element in the middle of the array (or list). For integers, this comparison is straightforward and efficient, usually involving a single comparison operation (such as ==, <, >). For strings, however, the comparison can be more complex and take longer. This is because strings are sequences of characters and each character needs to be compared until a difference is found or until the comparison ends.

Search key size: In general, strings tend to be larger in size than integers. Comparing long strings can be significantly more time consuming than comparing integers, especially if the strings are of different lengths and the difference is at the beginning of the strings.

Comparison cost: Although it depends on the specific implementation, string comparison may require more operations than integer comparison, especially if the comparison takes into account not only equality but also lexicographical order (as in many programming languages) .

Therefore, due to the greater complexity and greater number of operations involved in comparing strings, binary search on strings is generally more costly in terms of processing than binary search on integers.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
The next step is to try to obtain the name of all the objects in the Unity scene and place them in a List, generating an ID for each object and perform a binary search on the ID, which will be in integer. This will be the finally complete and best performance implementation.

Regards, Rodolfo Correia do Nascimento.  
06/16/2024
