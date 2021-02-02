# BINARY SEARCH

## CONTENT
- [Binary Search Introduction](#binary-search-introduction)
- [Binary Search on Reverse Sorted Array](#binary-search-on-reverse-sorted-array)
- [Number of times sorted array is rotated](#number-of-times-sorted-array-is-rotated)
- [Find an element in a rotated sorted array](#find-an-element-in-a-rotated-sorted-array)
- [Find floor of an element in an array](#find-floor-of-an-element-in-an-array)
- [Find ceil of an element in an array](#find-ceil-of-an-element-in-an-array)
- [Find position of an element in an infinitely sorted array](#find-position-of-an-element-in-an-infinitely-sorted-array)
- [Minimum difference element in a sorted array](#minimum-difference-element-in-a-sorted-array)
- [Binary Search on Answer concept](#binary-search-on-answer-concept)
- [Finding Peak Element in a array](#finding-peak-element-in-a-array)
- [Finding Maximum Element in Bitonic Array](#finding-maximum-element-in-bitonic-array)
- [Search An Element in Bitonic Array](#search-an-element-in-bitonic-array)
- [Search in Row wise and Column wise sorted Array](#search-in-row-wise-and-column-wise-sorted-array)

### **Binary Search Introduction**
Search a sorted array by repeatedly dividing the search interval in half. Begin with an interval covering the whole array. If the value of the search key is less than the item in the middle of the interval, narrow the interval to the lower half. Otherwise narrow it to the upper half. Repeatedly check until the value is found or the interval is empty.

We basically ignore half of the elements just after one comparison.

1. Compare x with the middle element.
2. If x matches with middle element, we return the mid index.
3. Else If x is greater than the mid element, then x can only lie in right half subarray after the mid element. So we recur for right half.
4. Else (x is smaller) recur for the left half.

```C#
        public static int BinaryReturn(int[] arr,int num,int low,int high)
        {
            if (high >= low)
            {
                int mid = low + (high-low) / 2;
                if (arr[mid] == num)
                {
                    return mid;
                }
                if(arr[mid]>num)
                {
                    return BinaryReturn(arr, num, low, mid-1);
                }
                return BinaryReturn(arr, num, mid + 1, high);
            }
            return -1;
        }
    }
```
> Here we make mid as low + (high-low)/2 in order to avoid the overflow of int or the datatype while calculating high+low

---
> Now we will see about the Binary search and its various types of applications and questions that are possible in programming

[^Top](#content)

---
### **Binary Search on Reverse Sorted Array**
The simple logic of binary search can be applied even when array is sorted in descending order just the conditions when we does not find the **mid** element changes.

```C#
public static int ReturnIndex(int[] arr,int low,int high,int target){
    while(low<=high){
        int mid = low + (high-low)/2;
        if(arr[mid]==target)
            return mid;
        else if(target>arr[mid])
            high=mid-1;
        else if(target<arr[mid]>)
            low=mid+1;
    }
    return -1;
}
```

[^Top](#content)

---
### **First and Last occurence of an element in a sorted array**
As we know in binary search when we get an element we return the index of that element.

This is only correct if all the elements are distinct, but if some elements are repeating then we might be asked the first and last occurence of those elements in the array.

The concept still is binary search just the conditions changes

1. Find mid and check if element is equal to mid.If equal then we have
    - In case of first occurence it is possible that the mid was actually the first occurence or maybe it was not. So we save this mid value in a variable as result and then we make **high=mid-1.**As there may be occurences in the first half of the array again
    - In case of last occurence same thing can be there as first occurence but here after saving the value we change the condition to **low=mid+1** because more occurences can be there in second half of array that are last.

2. If mid is less than the number we do same as binary search.
3. If mid is greater than the number we do same as binary search.
4. At last we return result.

```C# 
    // For first occurence
    public int ReturnIndex(int[]arr,int low,int high,int target){
        int result=-1;
        while(low<=high){
            int mid = low + (high-low)/2;
            if(arr[mid]==target){
                result=mid;
                high=mid-1;
            }
            else if(target>arr[mid])
                low=mid+1;
            else if(target<arr[mid]>)
                high=mid-1;
        }
        return result;
    }
```
```C# 
    // For last occurence
    public int ReturnIndex(int[]arr,int low,int high,int target){
        int result=-1;
        while(low<=high){
            int mid = low + (high-low)/2;
            if(arr[mid]==target){
                result=mid;
                low=mid+1;
            }
            else if(target>arr[mid])
                low=mid+1;
            else if(target<arr[mid]>)
                high=mid-1;
        }
        return result;
    }
```

[^Top](#content)

---
### **Number of times sorted array is rotated**
We can have problems where the sorted array is rotated and we need to find out how many times the array is being rotated.

Now the array can be rotated in two ways i.e. either left or right so we have to just alter the solution accordingly.

Now the simplest approach here is just find the index of minimum element. When array is not rotated the minimum element is at 0th index and so when its rotated it will show the number of times array was rotated.

1. If array rotated from right :- Index of minimum element is answer
2. If array rotated from left :- Array Length - Index of minimum element is the answer

        0   1   2   3   4   5   6
        16  18  2   5   9   10  14 
 Now this is a rotated array from right. As we can see the minimu element i.e. 2 is at index 2 so the result is 2.

 But how to calculate that. As we can see that for minimum element the next and previous elements are greater than it.
 2<5 and 2<18

 So for the mid condition we have :- 
 
 **arr[mid] <arr[mid+1] && arr[mid]<arr[mid-1]**

 But here there is risk of overflow as mid might end up at end or at begining so we change the conditions as

 ``` C#
 int n = arr.Length;
 int mid = low +(high-low)/2;
 int next = (mid+1) % n;
 int previous = (mid-1+n) % n;
 ```
Now we are clear for the mid condition on how to find the minimum element.

If we don't find the mid element as minimum element then :-
Now if we closely observe when we don't find the minimum element it is on that side of the array which is not sorted.

        0   1   2   3   4   5   6
        16  18  2   5   9   10  14 
To understand more effectively we take this array.
Now mid is 3 here and mid is > arr[mid-1]

So 5 is not minimum element. Now 5 has divided the array in 2 halves.

16 18 2 and 5 9 10 14

As we can see one array is sorted and one is not. The unsorted array has the minimum element.

So this is the condition to move left or right. So we got all the conditions.

```C#
public int ReturnIndex(int[] arr){
    int low = 0;
    int high = arr.Length-1;
    int n = arr.Length;

    while(low<=high){
        int mid = low +(high-low)/2;
        int next = (mid+1) % n;
        int previous = (mid-1+n) % n;

        if(arr[mid]<=arr[prev] && arr[mid]<=arr[next])
            return mid;
        // We need to find the sorted array that we can do by comparing the mid with last element of that half of array
        else if(arr[mid]<=arr[high]){
            high=mid-1;
        }
        else if(arr[mid]>=arr[low]){
            low=mid+1;
        }
    }
    return -1;
}
```
[^Top](#content)

---
### **Find an element in a rotated sorted array**

The simple concept here is :-

From above part we already know that we can find the minimum index and when we have the minimum index we will get 2 arrays

minimumIndexElement to arr.Length -1
and
0 to minimumIndexElement-1

These will be 2 sorted arrays. Just simply apply Binary Search on both part one will return the index if its present otherwise both will return -1;

Not explaining code here as its already in previous sections.

[^Top](#content)


---
### **Find floor of an element in an array**

The question here is we need to find the floor of a given element in the array. 
> Now floor of an element is the greatest element less than or equal to the given element

To find the floor we have a simple modification of binary search :- 

```
    0   1   2   3   4   5   6   7   8
    2   5   7   8   9   10  11  23  45
```

Now in above array if we want floor of '22' suppose.The output should be 11.

> If not mentioned specifically then if the given number is present in the array then it is itself the floor or ceiling

Solving the above problem with Binary Search :-

1. First we calculate the mid of the array as usual.

``` C#
int mid = low + (high-low)/2;
```
2. If arr[mid]== target then we return mid(if its not mentioned to exclude the number for floor or ceil).
3. If arr[mid]< target then it is a possibility that it might be the floor of the array so we store that value in a variable as result and then make 
```
low = mid+1
``` 
and search in right array.

4. If arr[mid]> target then it cannot be floor as floor needs to less than or equal to target so we just simply make 
```
high = mid-1
```
Lets check for below array. We want floor of 22.

```
    0   1   2   3   4   5   6   7   8
    2   5   7   8   9   10  11  23  45
```

Now here target is 22 and mid = 4

- So now arr[4]==9 which is less than 22 so we store 4 in a temp variable result. So result is 4 for now and low = mid+1;
- Now low =5,high =8 then mid = 6. Now arr[6] = 11 and since it is also less than 22 so we make result = 6 and low = mid+1.
- Now low = 7, high=8,mid = 7 so now arr[mid]>target so we make high = mid-1.
- Now high becomes 7 and low becomes 7 and mid 7 since arr[mid]>target so we make high =6
- Now high < low so loop breaks and in result we have 6 which is correct answer

``` C#
public int ReturnIndex(int[] arr,int low,int high,int target){
    int result = -1;
    while(low<=high){
        int mid = low + (high-low)/2;
        if(arr[mid]==target)
            result=mid;
        else if(arr[mid]<target){
            result= mid;
            low = mid+1;
        }
        else if(arr[mid]>target){
            high = mid-1;
        }
    }
    return result;
}
```

[^Top](#content)

---
### **Find ceil of an element in an array**
This problem statement is exactly same as the above one with same approach just the change comes in the concept 
>Ceil of an element means the smallest element greater than the target.

So simply where we were storing mid value in the else if condition instead of that we will store in the other part rest concept remains same.

``` C#
public int ReturnIndex(int[] arr,int low,int high,int target){
    int result = -1;
    while(low<=high){
        int mid = low + (high-low)/2;
        if(arr[mid]==target)
            result=mid;
        else if(arr[mid]<target){
            low = mid+1;
        }
        else if(arr[mid]>target){
            result=mid;
            high = mid-1;
        }
    }
    return result;
}
```

[^Top](#content)

---
### **Find position of an element in an infinitely sorted array**

Now this is an interesting problem as it is not possible to have an infinite array while solving problem online but we can have such things asked during interview.

If we have an infinite array we have one problem as we don't know what will be high in such a case. We have low as 0 but high we can't find as its infinite and so we can't find mid too.

Solution

1. Lets suppose we have infinite array as 

```
0   1   2   3   4   5   6   7   8   9   10   11   12   13...
2   3   6   12  14  22  45  54  72  91  101  128  168  199...
```
Now we need to find a number lets say 72 in this. We have low as 0 but we don't have high.

2. So what we do is we find the range in which this number may be present and apply binary search there

3. That is we make low as 0 and high as 1 and add a condition as

``` C#
while(arr[high]<target){
    low = high;
    high*=2;
}
```
4. When this loop will break we will have low and high indexes between which our target number will be present and considering this section as a sorted finite array we can apply BS here.

``` C#
public int ReturnIndex(int[] arr,int target){
    int low=0;
    int high=1;
    while(arr[high]<target){
        low=high;
        high*=2;
    }
    BinarySearch(int[] arr,int low,int high,int target)
}
```

[^Top](#content)

---
### **Minimum difference element in a sorted array**
Now in this type of problem we need to find the element that will be closest to the target element in the array. Now this element can be the floor of that element or ceil of that element or the element itself.

The simplest approach is just find the element if it is present then that is the value. 
Else when we are looping through the array if we encounter the value > than the target break it and then compute which one is close the floor or ceil

This takes O(n). But we can improve this by simply finding floor and ceil of the element (from previous knowledge) and then simply compare.

But in this section I want to discuss one more approach to find the floor and ceil together.

Let us suppose we have this sorted array and we wish to find **13** in this. We know that we will get -1 as result but lets see what happens actually :- 
```
    0   1   2   3   4   5   6   7   8
    2   5   7   8   9   10  11  23  45
```

1. First we will have low = 0,high = 8 and target is 13 so since low<=high loop will run.
2. mid = 4 now arr[4]==9 so we move to the right array
```
    5   6   7   8
    10  11  23  45
```
low = 5 and high = 8

3. Now mid = 6 and arr[6]==11 so still < 13 hence we move right 
```
    7   8
    23  45
```
low = 7 high = 8

4. Now mid = 7 and arr[7]=23 which is greater than 13 so we move left.

5. high becomes = mid-1 i.e. 7-1 =6

high is 6 and low is 7 so loop breaks.

Now if we observe in the original array
```
    0   1   2   3   4   5   6   7   8
    2   5   7   8   9   10  11  23  45
```
For number 13 its floor is at index 6 i.e. at high and its ceil is at index 7 i.e. at low

So in other words 

floor = high index

ceil = low index

> In a sorted array if we try to search any element and we fail to find it then at last when we return -1 the values of high and low are at the floor and ceil of that element or in other words they are between the indexes where the element should have been present if it was in the array.

```C#
public int ReturnIndex(int[] arr,int low,int high,int target){
    int floor = -1;
    int ceil = -1;
    while(low<=high){
        int mid = low + (high-low)/2;
        if(arr[mid]==target)
            return mid;
        else if(target<arr[mid])
            high=mid-1;
        else if(target>arr[mid])
            low=mid+1;
    }
    floor = high;
    ceil = low;
    return MaxOf(target-arr[floor],arr[ceil]-target);
}
```

[^Top](#content)

---

### **Binary Search on Answer concept**
This is basically a concept which tells us that Binary Search is also applicable on unsorted arrays.

Now if the array is sorted we 99% of the time need to apply Binary Search but in some cases where array is not sorted we still can apply BS.

Now what will be those cases...

So to understand this we need to understand that the concept of BS is to reduce the problem into halves and this reduction is done considering the fact that in either one of the half answer can never appear so just ignore it. And this thing should be applicable till last level when we cannot divide array further.

Similar for BS on Answer concept we have to check the question if such a thing is possible and if so try applying the BS.

In normal BS we have one condition of arr[mid]==target.
In these types of question this condition will be different. And the criteria to move to left side of half or right side will also be different. Those things we need to understand and learn through practice.

>In crux we can apply BS in unsorted array to but there are few conditions.

---

### **Finding Peak Element in a array**
The first example for binary search on answer concept.
In this question we will be given a unsorted array and we have to find the peak element.

 A peak element is the element whose left element and right element both are less than the number.

The given array may contain many peak elements and we need to just return any one of them.

Example :-
```
0   1   2   3   
5   10  20  15  
```
In this array we have 20 as the peak element so we need to return it.

Now lets apply BS here :-

1. First of all for the mid terminating condition we have obvious answer. arr[mid]>arr[mid-1] && > arr[mid+1] 
```
0   1   2   3   
5   10  20  15  
```
> Note that here we need to consider the corner cases also. Since if low becomes 0 or equal to n then there will be overflow.

> Another important thing to note is that the array may contain more than one peak element but we need to return any one.

2. Now we know that we have to handle the corner cases separately so all these steps will come under
```C#
    if(mid!=0 || mid !=array.Length-1)
```

3. Now lets see the array. If we find mid it will come as 3/2=1. So mid=1 and arr[mid]=10

```
0   1   2   3   
5   10  20  15  
```
4. Now we know mid is not the peak element so how to decide where to go.
If we observe 10 > 5 but is less than 20. In other words due to 20 10 is not a peak element. If in place of 20 we had some value less than 10 we would have 10 as peak element.

5. Now if we think of going to left, we know that since 10 is greater than 5(which is left part) so 5 can't be the peak element. So the probability of finding a peak element in left side decreases.

6. So the simple logic to decide which part to go is to check which part element was responsible for the mid element to **not** be a peak element.

7. Now if mid becomes 0 check with the 1st index element
8. Similarly for arr.Length-1 element check with array.Length-2.

```C#
public int ReturnPeakElement(int[] arr,int low,int high){
    int n = arr.Length;
    while(low<=high){
        int mid = low + (high-low)/2;
        if(mid !=0 || mid != n-1){
            if(arr[mid]>arr[mid+1] && arr[mid]>arr[mid-1]){
                return arr[mid];
            }
            else if(arr[mid]<arr[mid+1]>){
                low=mid+1;
            }
            else if(arr[mid]<arr[mid-1]){
                high=mid-1;
            }
        }
        else if(mid==0){
            if(arr[0]>arr[1])
            return arr[0]
            else
            return arr[1];
        }
        else if(mid==(n-1)){
            if(arr[n-1]>arr[n-1])
            return arr[n-1]
            else
            return arr[n-2];
        }
    }
}
```
[^Top](#content)

---

### **Finding Maximum Element in Bitonic Array**

This is a similar problem to peak element.
A bitonic array is an array which is monotonicaaly increases then reaches a threshold and then monotonically decreases.

So basically arr[i]!=arr[i+1]

So to find highest element in such an array we basically need to find the peak element. There is no difference in the code.

Example

```
0   1   2   3   4   5
1   3   8   12  4   2
```

```C#
public int ReturnPeakElement(int[] arr,int low,int high){
    int n = arr.Length;
    while(low<=high){
        int mid = low + (high-low)/2;
        if(mid !=0 || mid != n-1){
            if(arr[mid]>arr[mid+1] && arr[mid]>arr[mid-1]){
                return arr[mid];
            }
            else if(arr[mid]<arr[mid+1]>){
                low=mid+1;
            }
            else if(arr[mid]<arr[mid-1]){
                high=mid-1;
            }
        }
        else if(mid==0){
            if(arr[0]>arr[1])
            return arr[0]
            else
            return arr[1];
        }
        else if(mid==(n-1)){
            if(arr[n-1]>arr[n-1])
            return arr[n-1]
            else
            return arr[n-2];
        }
    }
}
```

> Note we will have only one peak element in bitonic array

[^Top](#content)

---

### **Search An Element in Bitonic Array**
Lets take an example
```
0   1   2   3   4   5
1   3   8   12  4   2
```
In the given array if we closely observe we have to arrays :- 
1. Increasing array till the peak element
2. Decreasing array after peek element

And both these arrays are sorted
So simply we just need to find the peak element and then apply bs on these 2 halves independently.

And then one of the array will return the answer and we will get our index required.

```C#
public int ReturnIndex(int[] arr,int low,int high){
    int n = arr.Length;
    while(low<=high){
        int mid = low +(high-low)/2;
        if(mid!=0 || mid!=n-1){
            if(arr[mid]>arr[mid+1] && arr[mid]>arr[mid-1]){
                return mid;
            }
            else if(arr[mid]<arr[mid+1]){
                low=mid+1;
            }
            else if(arr[mid]<arr[mid-1]){
                high=mid-1;
            }
        }
        else if(mid==0){
            if(arr[0]>arr[1])
            return 0;
            else 
            return 1;
        }
        else if(mid==n-1){
            if(arr[n-1]>arr[n-2])
            return n-1;
            else 
            return n-2;
        }
    }
    return -1;
}
// Now we apply BS on both halves independently and check if we get any index in any half. If not we return -1
```

[^Top](#content)

---

### **Search in Row wise and Column wise sorted Array**
We sometimes might be given row wise and column wise sorted 2d array and we need to find the index of the element to be searched. In such types of problems we have a very simply approach of BS

```
        0   1   2
    0   2   6   9
    1   3   7   10
    2   6   8   12
```
Suppose we have this array and we need to find the element '7' in the list.

Steps to solve the problem

1. First we make i=0 and j=columnLength-1.

2. We check the element at arr[i][j] and see if it is equal to the element we were searching. If yes we return these indexes. 
3. If no we have 2 options. Either the target element is greater or smaller

4. If target element is greater then arr[i][j], we know that the target element will never be present to left of the element, but will be present down the column. So we make i++.

5. If target element is smaller than arr[i][j], we know the element will not down the column but across the row so we make j--.

6. If bounded conditions are reached and still we didn't find the element we return -1.

Taking this example suppose we have to find '7'
```
        0   1   2
    0   2   6   9
    1   3   7   10
    2   6   8   12
```

1. We have i=0 and j=2.
2. arr[i][j]==9 which is greater than 7 so we make j--.
3. So now j=1 and arr[i][j]=6.
4. Now arr[i][j] < target so we know here we will get element down the column so we make i++.
5. So now i=1 and j=1 so arr[i][j]==7 and hence we return these 2 indexes.
6. The bound for the conditions is i>=0 and i < rowLength
.Similarly j>=0 and j < columnLength

```C#
public int[] ReturnIndex(int[,] arr,int m,int n,int target)
        {
            int[] result = new int[2];
            result[0] = -1;
            result[1] = -1;
            int i = 0;
            int j = m - 1;
            while(i>=0 && i<m && j>=0 && j < n)
            {
                if (arr[i, j] == target)
                {
                    result[0] = i;
                    result[1] = j;
                    break;
                }
                else if (arr[i, j] > target)
                {
                    j--;
                }
                else if (arr[i, j] < target)
                {
                    i++;
                }
            }
            return result;
        }
```
[^Top](#content)

---

END