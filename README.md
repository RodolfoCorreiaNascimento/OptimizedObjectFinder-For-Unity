![PerformanceTest_FullUnityScreen](https://github.com/RodolfoCorreiaNascimento/OptimizedObjectFinder-For-Unity/assets/64981849/dde91652-90e4-4f21-ba48-70545506c47b)

![PerformanceTest](https://github.com/RodolfoCorreiaNascimento/OptimizedObjectFinder-For-Unity/assets/64981849/4bbc5fab-9d33-41f9-9eed-81b2e514a54f)

# OptimizedObjectFinder-For-Unity
A Unity Extension to gain performance, GameObject.Find / CompareTag / GameObject.FindGameObjectsWithTag cost much more making the cpu processing cost very high using String compare, those methods cost much more as we know that searching for Strings generates high costs, With this Extension you can gain performance remembering that the scene objects for this Extension need to be named this way ex: 1-sword, 2-shield, 3-fire in this way you probably are going to generate a sucess binary search for your object.

This implemetation I Imagined when I was studing c++ data structs on CodeWars and I manage to use it in Unity. Thank you so much use it as many times as you can be happy making cool games! :)

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------
Binary search in strings tends to be more costly in terms of processing than binary search in integers. This is due to the nature of the data involved:

Comparison of elements: In binary search, the main operation is the comparison between the element being sought and the element in the middle of the array (or list). For integers, this comparison is straightforward and efficient, usually involving a single comparison operation (such as ==, <, >). For strings, however, the comparison can be more complex and take longer. This is because strings are sequences of characters and each character needs to be compared until a difference is found or until the comparison ends.

Search key size: In general, strings tend to be larger in size than integers. Comparing long strings can be significantly more time consuming than comparing integers, especially if the strings are of different lengths and the difference is at the beginning of the strings.

Comparison cost: Although it depends on the specific implementation, string comparison may require more operations than integer comparison, especially if the comparison takes into account not only equality but also lexicographical order (as in many programming languages) .

Therefore, due to the greater complexity and greater number of operations involved in comparing strings, binary search on strings is generally more costly in terms of processing than binary search on integers.

-----------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------------

# How to use
This script is an extension, for example if you have a GameObject renamed as 27-PlayerProjectile you can pass the value 27 to the function OptimizedObjectFinderExtensions.FindObject(27), Another Example: you can reference: GameObject object obj = OptimizedObjectFinderExtensions.FindObject(27 ) or Also use in comparison: if(col.gameObject == OptimizedObjectFinderExtensions.FindObject(27)) { //code here }

Next Goal:

The next goal is to get the names of all objects in the Unity scene, store them in a list, and generate a numeric ID for each object. Then implement a binary search of these IDs to improve performance. Additionally, an extension will be created to automatically generate IDs for all GameObjects in the scene and in Prefabs, eliminating the need to manually set the numeric prefix on GameObjects.

Regards, Rodolfo Correia do Nascimento.  
06/16/2024
